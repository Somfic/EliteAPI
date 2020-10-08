using System;
using EliteAPI.Event.Attributes;
using EliteAPI.Event.Models;
using Microsoft.Extensions.Logging;
using EliteAPI.Event.Module;

namespace Example2.Modules
{
    // Logs all text messages to the logging system
    public class ChatModule : EliteDangerousEventModule
    {
        private readonly ILogger<ChatModule> _log;

        public ChatModule(ILogger<ChatModule> log, IServiceProvider services) : base(services)
        {
            // Get the logging system through dependency injection
            _log = log;
        }

        // This method is ran every time a text message is send in-game
        [EliteDangerousEvent]
        public void OnChat(SendTextEvent e)
        {
            string content = e.Message;

            _log.LogInformation("Sent text: '{content}'", content);
        }

        // This method is ran every time a text message is received in-game
        [EliteDangerousEvent]
        public void OnChatReceived(ReceiveTextEvent e)
        {
            string author = e.FromLocalised ?? e.From;
            string content = e.MessageLocalised ?? e.Message;

            _log.LogInformation("Received text: '{content}' from {author}", content, author);
        }
    }
}
