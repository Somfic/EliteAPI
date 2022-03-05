using System;
using System.Threading.Tasks;

namespace EliteAPI.VoiceAttack.Proxy.Logging
{
    public class VoiceAttackLog
    {
        private readonly dynamic _proxy;

        internal VoiceAttackLog(dynamic proxy, IServiceProvider services = null)
        {
            _proxy = proxy;
        }

        /// <summary>
        /// Writes to the VoiceAttack log
        /// </summary>
        /// <param name="content">The log message</param>
        /// <param name="color">The log color</param>
        public Task Write(string content, VoiceAttackColor color = VoiceAttackColor.Black)
        {
            _proxy.WriteToLog(content, color.ToString());
            return Task.CompletedTask;
        }

        /// <summary>
        /// Clears the VoiceAttack log
        /// </summary>
        public Task Clear()
        {
            _proxy.ClearLog();
            return Task.CompletedTask;
        }
    }
}