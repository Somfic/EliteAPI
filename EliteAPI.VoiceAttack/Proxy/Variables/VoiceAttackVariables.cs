using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EliteAPI.VoiceAttack.Messages.Variables;
using Newtonsoft.Json.Linq;

namespace EliteAPI.VoiceAttack.Proxy.Variables
{
    public class VoiceAttackVariables
    {
        private readonly dynamic _proxy;

        public IDictionary<string, Variable> SetVariables = new Dictionary<string, Variable>();

        internal VoiceAttackVariables(dynamic vaProxy)
        {
            _proxy = vaProxy;
        }

        /// <summary>
        /// Set a variable
        /// </summary>
        /// <typeparam name="T">The type of variable</typeparam>
        /// <param name="name">The name of the variable</param>
        /// <param name="value">The value of the variable</param>
        public void Set(string name, JToken value)
        {
            name = $"EliteAPI.{name}";
            
            var type = value.Type;

            switch (type)
            {
                case JTokenType.Integer:
                    SetInt(name, value.Value<int>());
                    break;
                
                case JTokenType.Float:
                    SetDecimal(name, value.Value<decimal>());
                    break;
                
                case JTokenType.String:
                    SetText(name, value.Value<string>());
                    break;
                
                case JTokenType.Boolean:
                    SetBoolean(name, value.Value<bool>());
                    break;
                
                case JTokenType.Date:
                    SetDate(name, value.Value<DateTime>());
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }


        /// <summary>
        /// Get a variable
        /// </summary>
        /// <typeparam name="T">The type of variable</typeparam>
        /// <param name="name">The name of the variable</param>
        public T Get<T>(string name)
        {
            TypeCode code = Type.GetTypeCode(typeof(T));

            switch (code)
            {
                case TypeCode.Boolean:
                    return (T) Convert.ChangeType(GetBoolean(name), typeof(T));

                case TypeCode.DateTime:
                    return (T) Convert.ChangeType(GetDate(name), typeof(T));

                case TypeCode.Single:
                case TypeCode.Decimal:
                case TypeCode.Double:
                    return (T) Convert.ChangeType(GetDecimal(name), typeof(T));

                case TypeCode.Char:
                case TypeCode.String:
                    return (T) Convert.ChangeType(GetText(name), typeof(T));

                case TypeCode.Byte:
                case TypeCode.Int16:
                case TypeCode.UInt16:
                case TypeCode.SByte:
                    return (T) Convert.ChangeType(GetShort(name), typeof(T));

                case TypeCode.Int32:
                case TypeCode.UInt32:
                case TypeCode.Int64:
                case TypeCode.UInt64:
                    return (T) Convert.ChangeType(GetInt(name), typeof(T));

                default:
                    return default;
            }
        }

        private short? GetShort(string name)
        {
            return _proxy.GetSmallInt(name);
        }

        private int? GetInt(string name)
        {
            return _proxy.GetInt(name);
        }

        private string GetText(string name)
        {
            return _proxy.GetText(name);
        }

        private decimal? GetDecimal(string name)
        {
            return _proxy.GetDecimal(name);
        }

        private bool? GetBoolean(string name)
        {
            return _proxy.GetBoolean(name);
        }

        private DateTime? GetDate(string name)
        {
            return _proxy.GetDate(name);
        }

        private void SetInt(string name, int? value)
        {
            string variable = $"{{INT:{name}}}";
            SetVariable(variable, Types.Integer, value.ToString());

            _proxy.SetInt(name, value);
        }

        private void SetText(string name, string value)
        {
            string variable = $"{{TXT:{name}}}";
            SetVariable(variable, Types.Text, value.ToString());

            _proxy.SetText(name, value);
        }

        private void SetDecimal(string name, decimal? value)
        {
            string variable = $"{{DEC:{name}}}";
            SetVariable(variable, Types.Decimal, value.ToString());

            _proxy.SetDecimal(name, value);
        }

        private void SetBoolean(string name, bool? value)
        {
            string variable = $"{{BOOL:{name}}}";
            SetVariable(variable, Types.Boolean, value.ToString());

            _proxy.SetBoolean(name, value);
        }

        private void SetDate(string name, DateTime? value)
        {
            string variable = $"{{DATE:{name}}}";
            SetVariable(variable, Types.Date, value.ToString());

            _proxy.SetDate(name, value);
        }

        private void SetVariable(string name, Types type, string value)
        {
            if (SetVariables.ContainsKey(name)) { SetVariables[name] = new Variable(name, type, value); }
            else { SetVariables.Add(name, new Variable(name, type, value)); }
        }
    }
}