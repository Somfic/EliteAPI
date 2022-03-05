using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EliteAPI.VoiceAttack.Messages.Paths;
using EliteAPI.VoiceAttack.Proxy;
using EliteAPI.VoiceAttack.Proxy.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocket4Net;
using ErrorEventArgs = SuperSocket.ClientEngine.ErrorEventArgs;

namespace EliteAPI.VoiceAttack
{
    public class VoiceAttackPlugin
    {
        public static Guid VA_Id() => new Guid("189a4e44-caf1-459b-b62e-fabc60a12986");
        public static string VA_DisplayName() => "EliteAPI";
        public static string VA_DisplayInfo() => "EliteAPI by Somfic";

        private static WebSocket _webSocket;
        private static VoiceAttackProxy _proxy;
        
        public static void VA_Init1(dynamic vaProxy)
        {
            _proxy = new VoiceAttackProxy(vaProxy);
            
            _webSocket = new WebSocket("ws://127.0.0.1:51550/");
            _webSocket.Opened += WebSocketOpened;
            _webSocket.Error += WebSocketError;
            _webSocket.Closed += WebSocketClosed;
            _webSocket.MessageReceived += WebSocketMessageReceived;
            
            _webSocket.Open();
        }

        public static void VA_Exit1(dynamic vaProxy)
        {
            _proxy = new VoiceAttackProxy(vaProxy);
            _webSocket.Close();
        }
        
        public static void VA_StopCommand()
        {
            
        }
        
        public static void VA_Invoke1(dynamic vaProxy)
        {
            _proxy = new VoiceAttackProxy(vaProxy);
        }
        
        private static void WebSocketMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            try
            {
                var paths = JsonConvert.DeserializeObject<EventPaths>(e.Message);
                var eventName = paths.Paths.First(x => x.Path.EndsWith("Event")).Value;

                foreach (var pathValue in paths.Paths)  
                {
                    try
                    {
                        var rawValue = pathValue.Value;

                        if (string.IsNullOrWhiteSpace(rawValue))
                        {
                          continue; //todo: fix for this, is empty its skipping but should really reset
                        }
                        
                        var value = JToken.Parse(rawValue);

                        var path = pathValue.Path;

                        _proxy.Variables.Set(path, value);
                    }
                    catch (Exception ex)
                    {
                        _proxy.Log.Write(pathValue.Path + ": " + pathValue.Value + ", " + ex.ToString(), VoiceAttackColor.Orange);
                    }
                }

                var command = $"((EliteAPI.{eventName}))";
                
                if(_proxy.Commands.Exists(command).GetAwaiter().GetResult())
                    _proxy.Commands.Invoke(command);
            }
            catch (Exception ex)
            {
                _proxy.Log.Write($"Could not set variables: {ex.Message}", VoiceAttackColor.Red);
            }

            try
            {
                _webSocket.Send(JsonConvert.SerializeObject(_proxy.Variables.SetVariables.Values));
            }
            catch (Exception ex)
            {
                _proxy.Log.Write($"Could not send variables: {ex.Message}", VoiceAttackColor.Red);
            }
        }

        private static void WebSocketClosed(object sender, EventArgs e)
        {
            _proxy.Log.Write("Connection with EliteAPI has been closed", VoiceAttackColor.Orange);
            _webSocket.Open();
        }

        private static void WebSocketError(object sender, ErrorEventArgs e)
        {
            _proxy.Log.Write($"Error while connecting with EliteAPI: {e.Exception}", VoiceAttackColor.Red);
        }

        private static void WebSocketOpened(object sender, EventArgs e)
        {
            _proxy.Log.Write("Connection established with EliteAPI", VoiceAttackColor.Green);
        }
    }
}

