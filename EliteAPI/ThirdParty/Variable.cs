namespace EliteAPI.ThirdParty
{
 
    /// <summary>
    /// A variable class that contains one variable that is to be used in third party plugins.
    /// </summary>
    public class Variable
    {
        /// <summary>
        /// Constructor for a new Variable.
        /// </summary>
        /// <param name="name">The name of the variable.</param>
        /// <param name="value">The value of the variable.</param>
        public Variable(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public object Value { get; }
        public VarType Type => GetVarType(Value);
        private static VarType GetVarType(object s)
        {
            try
            {
                string type = s.GetType()
                    .ToString()
                    .Replace("System.", "")
                    .Replace("Collections.Generic.","")
                    .ToLower();
                if (type.Contains("int")) { return VarType.Int; }
                else if (type.Contains("long")) { return VarType.Int; }
                else if (type.Contains("string")) { return VarType.String; }
                else if (type.Contains("decimal")) { return VarType.Decimal; }
                else if (type.Contains("float")) { return VarType.Decimal; }
                else if (type.Contains("float")) { return VarType.Decimal; }
                else if (type.Contains("bool")) { return VarType.Bool; }
                else { return VarType.Unknown; }
            }
            catch { return VarType.Unknown; }
        }
    }
}