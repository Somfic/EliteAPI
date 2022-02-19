using System;

namespace EliteAPI.VoiceAttack.Proxy.Options
{
    public class VoiceAttackOptions
    {
        private readonly dynamic _proxy;

        internal VoiceAttackOptions(dynamic proxy, IServiceProvider services = null)
        {
            _proxy = proxy;
        }

        /// <summary>
        /// Whether plugins are enabled
        /// </summary>
        public bool PluginsEnabled => _proxy.PluginsEnabled;
        
        /// <summary>
        /// Whether the use of nested tokens is enabled
        /// </summary>
        public bool NestedTokensEnabled => _proxy.NestedTokensEnabled;

        /// <summary>
        /// Whether automatic profile switching is enabled
        /// </summary>
        public bool AutoProfileSwitchingEnabled => _proxy.AutoProfileSwitchingEnabled;
    }
}