using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using EliteAPI.Abstractions.Events;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EliteAPI.Server;

public class Client
{
    private readonly TcpClient _tcp;
    public readonly Guid Id;

    /// <summary>
    /// Whether the client has been authenticated.
    /// </summary>
    public bool IsAccepted { get; private set; }
    
    /// <summary>
    /// Whether the client is connected.
    /// </summary>
    public bool IsOpen { get; private set; }

    public bool IsAvailable => _tcp.Connected;

    private readonly NetworkStream _stream;
    private readonly ILogger<Client>? _log;

    public Client(IServiceProvider services, TcpClient tcp)
    {
        _tcp = tcp;
        Id = Guid.NewGuid();
        IsOpen = tcp.Connected;
        _stream = tcp.GetStream();

        _log = services.GetService<ILogger<Client>>();
    }

    public async Task Handle()
    {
        while (IsOpen)
        {
            if(!IsAccepted)
                _log?.LogDebug("Awaiting handshake from client {Id}", Id);

            var incoming = await ReadAsync();

            _log?.LogTrace("Incoming {Type}" + (string.IsNullOrEmpty(incoming.Payload) ? "" : ": ") + "{Payload}", incoming.Type, incoming.Payload);
            
            switch (incoming.Type)
            {
                case Opcode.Handshake:
                    await AcceptHandshakeAsync(incoming);
                    break;

                case Opcode.TextFrame:
                    //_log?.LogDebug("Incoming TextFrame: {Payload}", incoming.Payload);
                    //todo: send set variables to frontend
                    break;
                
                case Opcode.ConnectionClose:
                    await CloseAsync();
                    break;

                default:
                    _log?.LogWarning("Unhandled incoming {Type}", incoming.Type);
                    break;
            }
        }

        _log?.LogInformation("Client {Id} disconnected", Id);
    }

    /// <summary>
    /// Closes the connection.
    /// </summary>
    public async Task CloseAsync()
    {
        _log?.LogDebug("Closing client {Id}", Id);
        IsOpen = false;
        IsAccepted = false;
        _tcp.Close();
    }
        
    /// <summary>
    /// Reads a line from the client.
    /// </summary>
    /// <returns></returns>
    public async Task<WebSocketMessage> ReadAsync()
    {
        while (!_tcp.GetStream().DataAvailable) ;

        if (!IsAccepted)
        {
            while (_tcp.Available < 3) ;

            var bytes = new byte[_tcp.Available];
            await _stream.ReadAsync(bytes.AsMemory(0, _tcp.Available));
            var payload = Encoding.UTF8.GetString(bytes);

            return new WebSocketMessage(Opcode.Handshake, payload);
        }
        else
        {
            var bytes = new byte[_tcp.Available];

            await _stream.ReadAsync(bytes.AsMemory(0, _tcp.Available));

            // Convert opcode to enum
            var op = (Opcode) (byte) (bytes[0] & 0b00001111);

            if (op != Opcode.TextFrame)
                return new WebSocketMessage(op);

            var secondByte = bytes[1];
            var dataLength = secondByte & 127;
            var indexFirstMask = dataLength switch
            {
                126 => 4,
                127 => 10,
                _ => 2
            };

            var keys = bytes.Skip(indexFirstMask).Take(4).ToArray();
            var indexFirstDataByte = indexFirstMask + 4;

            var decoded = new byte[bytes.Length - indexFirstDataByte];
            for (int i = indexFirstDataByte, j = 0; i < bytes.Length; i++, j++)
            {
                decoded[j] = (byte) (bytes[i] ^ keys.ElementAt(j % 4));
            }

            var payload = Encoding.UTF8.GetString(decoded, 0, decoded.Length);

            return new WebSocketMessage(op, payload);
        }
    }

    /// <summary>
    /// Writes a line to the client.
    /// </summary>
    /// <param name="line"></param>
    public async Task WriteAsync(string? line)
    {
        if (line == null)
            return;

        var bytes = Encoding.UTF8.GetBytes(line);

        await WriteAsync(bytes);
    }

    /// <summary>
    /// Writes bytes to the client.
    /// </summary>
    /// <param name="bytes"></param>
    public async Task WriteAsync(byte[] bytes)
    {
        if (!IsAccepted)
        {
            await _stream.WriteAsync(bytes);
            await _stream.FlushAsync();
        }
        else
        {
            const int frameSize = 64;
            
            var parts = bytes.Select((b, i) => new {b, i})
                .GroupBy(x => x.i / (frameSize - 1))
                .Select(x => x.Select(y => y.b).ToArray())
                .ToList();

            for (var i = 0; i < parts.Count; i++)
            {
                byte cmd = 0;
                if (i == 0) cmd |= 1;
                if (i == parts.Count - 1) cmd |= 0x80;

                _stream.WriteByte(cmd);
                _stream.WriteByte((byte) parts[i].Length);
                _log?.LogTrace("Sending bytes: {Bytes}", string.Join(" ", parts[i].AsMemory(0, parts[i].Length).ToArray()));

                
                await _stream.WriteAsync(parts[i].AsMemory(0, parts[i].Length));
            }

            await _stream.FlushAsync();
        }
    }
    
    private async Task AcceptHandshakeAsync(WebSocketMessage incoming)
    {
        if (Regex.IsMatch(incoming.Payload, "^GET", RegexOptions.IgnoreCase))
        {
            var handshake = await GetHandshake(incoming.Payload);
            await WriteAsync(handshake);
            _log?.LogInformation("Client {Id} connected", Id);
            IsAccepted = true;
        }
    }
        
    private static async Task<string> GetHandshake(string handshake)
    {
        const string eol = "\r\n";
        const string guid = "258EAFA5-E914-47DA-95CA-C5AB0DC85B11";

        var key = Regex.Match(handshake, "Sec-WebSocket-Key: (.*)").Groups[1].Value.Trim();
        var rfcKey = key + guid;
        var hash = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(rfcKey));
        var base64 = Convert.ToBase64String(hash);

        var result = new StringWriter();
        await result.WriteAsync($"HTTP/1.1 101 Switching Protocols{eol}");
        await result.WriteAsync($"Connection: Upgrade{eol}");
        await result.WriteAsync($"Sec-WebSocket-Accept: {base64}{eol}");
        await result.WriteAsync($"Upgrade: websocket{eol}{eol}");

        return result.ToString();
    }
}