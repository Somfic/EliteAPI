using System;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EliteAPI.Abstractions;
using EliteAPI.Dashboard.WebSockets.Logging;
using EliteAPI.Dashboard.WebSockets.Message;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EliteAPI.Dashboard.WebSockets.Handler
{
    public enum WebSocketType
    {
        FrontEnd,
        Client
    }

    public class WebSocketHandler
    {
        private readonly ILogger<WebSocketHandler> _log;
        private readonly IEliteDangerousApi _api;
        private readonly List<WebSocket> _frontendWebSockets;
        private readonly List<WebSocket> _clientWebSockets;

        private readonly List<WebSocketMessage> _frontendCatchupMessages;
        private readonly List<WebSocketMessage> _clientCatchupMessages;

        public WebSocketHandler(ILogger<WebSocketHandler> log, IEliteDangerousApi api)
        {
            _log = log;
            _api = api;
            _frontendWebSockets = new List<WebSocket>();
            _clientWebSockets = new List<WebSocket>();
            _frontendCatchupMessages = new List<WebSocketMessage>();
            _clientCatchupMessages = new List<WebSocketMessage>();

            WebSocketLogs.OnLog += async (sender, e) =>
                await Broadcast(new WebSocketMessage("Log", JsonConvert.SerializeObject(e)), WebSocketType.FrontEnd,
                    true, false);
        }

        public async Task Handle(WebSocket socket, WebSocketType type)
        {
            switch (type)
            {
                case WebSocketType.Client:
                    // Add socket to list of client WebSockets
                    _clientWebSockets.Add(socket);
                    break;

                case WebSocketType.FrontEnd:
                    // Add socket to list of frontend WebSockets
                    _frontendWebSockets.Add(socket);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Invalid WebSocket type");
            }

            // Keep connection to socket open
            await ListenTo(socket, type);
        }

        public async Task Broadcast(WebSocketMessage message, bool useDuringCatchup = false,
            bool onlySaveLatestForCatchup = false)
        {
            await Broadcast(message, WebSocketType.FrontEnd, useDuringCatchup, onlySaveLatestForCatchup);
            await Broadcast(message, WebSocketType.Client, useDuringCatchup, onlySaveLatestForCatchup);
        }

        public async Task Broadcast(WebSocketMessage message, WebSocketType type, bool useDuringCatchup,
            bool onlySaveLatestForCatchup)
        {
            switch (type)
            {
                case WebSocketType.Client:
                    // Store in catchup
                    if (useDuringCatchup)
                    {
                        if (onlySaveLatestForCatchup)
                        {
                            // Replace of same type
                            _clientCatchupMessages.RemoveAll(x =>
                                string.Equals(x.Type, message.Type, StringComparison.InvariantCultureIgnoreCase));
                        }

                        // Add
                        _clientCatchupMessages.Add(message);
                    }

                    // Broadcast to client WebSockets
                    foreach (var clientWebSocket in _clientWebSockets)
                    {
                        await SendTo(clientWebSocket, message);
                    }

                    break;

                case WebSocketType.FrontEnd:
                    // Store in catchup
                    if (useDuringCatchup)
                    {
                        if (onlySaveLatestForCatchup)
                        {
                            // Replace of same type
                            _frontendCatchupMessages.RemoveAll(x =>
                                string.Equals(x.Type, message.Type, StringComparison.InvariantCultureIgnoreCase));
                        }

                        // Add
                        _frontendCatchupMessages.Add(message);
                    }

                    // Broadcast to frontend WebSockets
                    foreach (var frontendWebSocket in _frontendWebSockets)
                    {
                        await SendTo(frontendWebSocket, message);
                    }

                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Invalid WebSocket type");
            }
        }

        public async Task SendTo(WebSocket socket, WebSocketMessage message)
        {
            if (socket.State != WebSocketState.Open)
                return;

            var compressed = Compressor.Compress(message);

            var bytes = Encoding.UTF8.GetBytes(compressed);

            var arraySegment = new ArraySegment<byte>(bytes);
            await socket.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private async Task ListenTo(WebSocket socket, WebSocketType type)
        {
            await using var memory = new MemoryStream();
            bool isAuthenticated = false;

            while (socket.State == WebSocketState.Open)
            {
                // Read message
                var message = await GetMessage(socket, memory);
                
                _log.LogInformation("WebSocket request ({Type}): {Json}", message.Type, message.Value);

                // Check authentication
                if (!isAuthenticated)
                {
                    _log.LogDebug("Unauthenticated socket, checking authentication");
                    isAuthenticated = await CheckAuthentication(message, type);

                    // Break connection if still not authenticated
                    if (!isAuthenticated)
                    {
                        _log.LogDebug("Did not pass authentication, kicking");
                        await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Unauthenticated",
                            CancellationToken.None);
                        return;
                    }

                    // Start listening from next message
                    _log.LogDebug("Passed authentication, sending catchup");

                    // Send EliteAPI information
                    await SendTo(socket, new WebSocketMessage("EliteAPI", $"{{\"Version\": \"{_api.Version}\"}}"));
                    
                    switch (type)
                    {
                        // Send catchup messages to frontend
                        case WebSocketType.FrontEnd:
                            await Catchup(socket, _frontendCatchupMessages);
                            break;

                        // Send catchup messages to client
                        case WebSocketType.Client:
                            await Catchup(socket, _clientCatchupMessages);
                            break;

                        default:
                            throw new ArgumentOutOfRangeException(nameof(type), type, "Invalid WebSocket type");
                    }
                }

                // Process message
            }
        }

        private async Task Catchup(WebSocket socket, List<WebSocketMessage> messages)
        {
            await SendTo(socket, new WebSocketMessage("CatchupStart", messages.Count));
            messages.ForEach(async x => await SendTo(socket, x));
            await SendTo(socket, new WebSocketMessage("CatchupEnd"));
        }

        private Task<bool> CheckAuthentication(WebSocketMessage message, WebSocketType type)
        {
            if (!string.Equals(message.Type, "auth", StringComparison.InvariantCultureIgnoreCase))
                return Task.FromResult(false);

            if (!string.Equals(message.Value, type.ToString(), StringComparison.InvariantCultureIgnoreCase))
                return Task.FromResult(false);

            return Task.FromResult(true);
        }

        private async Task<WebSocketMessage> GetMessage(WebSocket socket, MemoryStream memory)
        {
            try
            {
                // Read received message
                WebSocketReceiveResult result;
                do
                {
                    var messageBuffer = WebSocket.CreateClientBuffer(1024, 16);
                    result = await socket.ReceiveAsync(messageBuffer, CancellationToken.None);
                    memory.Write(messageBuffer.Array ?? Array.Empty<byte>(), messageBuffer.Offset, result.Count);
                } while (!result.EndOfMessage);

                // Process the received message
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    memory.Seek(0, SeekOrigin.Begin);
                    memory.Position = 0;

                    WebSocketMessage message;

                    try
                    {
                        message = Compressor.Decompress(Encoding.UTF8.GetString(memory.ToArray()));
                    }
                    catch (JsonException ex)
                    {
                        _log.LogWarning(ex, "Invalid WebSocket message");
                        return null;
                    }
                    catch (Exception ex)
                    {
                        _log.LogWarning(ex, "Could not process WebSocket request");
                        return null;
                    }

                    return message;
                }

                _log.LogWarning("Could not process WebSocket request, message type is not text");
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Could not read WebSocket message");
            }

            memory.Seek(0, SeekOrigin.Begin);
            memory.Position = 0;
            return null;
        }
    }
}