using System.Net;
using System.Threading.Tasks;
using EliteAPI.Dashboard.WebSockets.Handler;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace EliteAPI.Dashboard.WebSockets.Handshake
{
    public class WebSocketHandshake
    {
        private readonly ILogger<WebSocketHandshake> _log;
        private readonly WebSocketHandler _handler;
        private readonly RequestDelegate _next;

        public WebSocketHandshake(ILogger<WebSocketHandshake> log, WebSocketHandler handler, RequestDelegate next)
        {
            _log = log;
            _next = next;
            _handler = handler;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Only allow handshake on /ws
            if (context.Request.Path != "/ws")
            {
                await _next(context);
                return;
            }

            // Check if it's actually a WebSocket
            if (!context.WebSockets.IsWebSocketRequest)
            {
                _log.LogDebug("Skipping WebSocket handshake request, not an actual WebSocket");
                await _next(context);
                return;
            }

            // Check protocols
            var protocols = context.WebSockets.WebSocketRequestedProtocols;
            var isFrontend = protocols.Contains("EliteAPI-app");
            var isClient = protocols.Contains("EliteAPI");

            if (isFrontend && isClient)
            {
                _log.LogDebug("Bad WebSocket handshake request, both protocols");
                context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
            }
            
            else if (isFrontend)
            {
                // Accept our frontend request
                _log.LogDebug("Accepting frontend WebSocket handshake");
                using var webSocket = await context.WebSockets.AcceptWebSocketAsync("EliteAPI-app");
                await _handler.Handle(webSocket, WebSocketType.FrontEnd);
            } 
            
            else if (isClient)
            {
                // Accept our client request
                _log.LogDebug("Accepting client WebSocket handshake");
                using var webSocket = await context.WebSockets.AcceptWebSocketAsync("EliteAPI");
                await _handler.Handle(webSocket, WebSocketType.Client);
            }
            
            else
            {
                _log.LogDebug("Bad WebSocket handshake request, bad protocol");
                context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
            }
        }
    }
}