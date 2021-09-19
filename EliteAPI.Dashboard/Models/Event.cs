using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EliteAPI.Dashboard.Models
{
    public class Event
    {
        [JsonConstructor]
        public Event()
        {
            
        }
        
        public Event(string name, List<Variable> variables)
        {
            Name = name;
            Variables = variables;
        }

        public string Name { get; }
        
        public List<Variable> Variables { get; }
    }
}