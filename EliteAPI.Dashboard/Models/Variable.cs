using System;
using Newtonsoft.Json;

namespace EliteAPI.Dashboard.Models
{
    public class Variable
    {
        [JsonConstructor]
        public Variable()
        {
        }
        
        public Variable(string name, object value, string type)
        {
            Name = name;
            Value = value;
            Type = type;
        }
        
        public Variable(string name, string value)
        {
            Name = name;
            Value = value;
            Type = "string";
        }

        public Variable(string name, int value)
        {
            Name = name;
            Value = value;
            Type = "int32";
        }

        public Variable(string name, long value)
        {
            Name = name;
            Value = value;
            Type = "int64";
        }

        public Variable(string name, decimal value)
        {
            Name = name;
            Value = value;
            Type = "decimal";
        }

        public Variable(string name, DateTime value)
        {
            Name = name;
            Value = value;
            Type = "date";
        }

        public Variable(string name, bool value)
        {
            Name = name;
            Value = value;
            Type = "boolean";
        }

        public string Name { get; }
        public object Value { get; }
        public string Type { get; }
    }
}