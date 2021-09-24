using System;

using EliteAPI.Options.Abstractions;
using EliteAPI.Options.Bindings.Models;
using Newtonsoft.Json;

namespace EliteAPI.Options.Bindings
{
    /// <inheritdoc />
    public class Bindings : IBindings
    {
        private KeyBindings _active;
        private string _raw;

        public Bindings()
        {
            _active = new KeyBindings();
        }
        
        /// <inheritdoc />
        public event EventHandler<KeyBindings> OnChange;
        
        /// <inheritdoc />
        void IOption.TriggerOnChange() { OnChange?.Invoke(this, _active); }

        /// <inheritdoc />
        public string ToJson()
        {
            return JsonConvert.SerializeObject(_active, new JsonSerializerSettings {ContractResolver = new JsonContractResolver()});
        }

        /// <inheritdoc />
        KeyBindings IBindings.Active
        {
            get => _active;
            set => _active = value;
        }

        string IBindings.Raw
        {
            get => _raw;
            set => _raw = value;
        }

        public string ToXml()
        {
            return this._raw;
        }
    }
}