using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EliteAPI.Status.Abstractions
{
    public abstract class StatusBase : IStatus
    {
        private IRawStatus _rawStatus;
        
        /// <inheritdoc />
        public event EventHandler<IRawStatus> OnChange;

        /// <inheritdoc />
        public string ToJson()
        {
            return JsonConvert.SerializeObject(_rawStatus, new JsonSerializerSettings {ContractResolver = new JsonContractResolver()});
        }

        void IStatus.TriggerOnChange(IRawStatus status)
        {
            _rawStatus = status;
            OnChange?.Invoke(this, status);
        }
    }
}