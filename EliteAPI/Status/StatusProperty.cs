using System;

using Newtonsoft.Json;

namespace EliteAPI.Status
{
    /// <summary>
    /// Container class for a status property
    /// </summary>
    public class StatusProperty<T>
    {

        /// <summary>
        /// Triggered whenever this property is changed
        /// </summary>
        public EventHandler<T> OnChange;

        internal StatusProperty()
        {
            Value = default;
        }

        internal StatusProperty(T initValue)
        {
            Value = initValue;
        }

        /// <summary>
        /// The value of this property
        /// </summary>
        public T Value { get; private set; }

        internal bool NeedsUpdate(object rawValue)
        {
            //todo: find a better way to do this
            return JsonConvert.SerializeObject(rawValue) != JsonConvert.SerializeObject(Value);
        }

        internal void Update(object sender, object rawValue)
        {
            var value = (T) rawValue;
            Value = value;
            InvokeEvent(sender, value);
        }

        private void InvokeEvent(object sender, T value)
        {
            OnChange?.Invoke(sender, value);
        }
    }
}