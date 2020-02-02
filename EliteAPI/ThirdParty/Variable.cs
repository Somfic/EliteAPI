namespace EliteAPI.ThirdParty
{
    public class Variable
    {
        public Variable(string name, object value)
        {
            Name = name;
            Value = value;
        }
        public enum VarType { String, Bool, Int, Decimal, Unknown }
        public string Name { get; }
        public object Value { get; }
        public VarType Type => GetVarType(Value);
        private VarType GetVarType(object s)
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
                else if (type.Contains("double")) { return VarType.Decimal; }
                else if (type.Contains("float")) { return VarType.Decimal; }
                else if (type.Contains("bool")) { return VarType.Bool; }
                else { return VarType.Unknown; }
            }
            catch { return VarType.Unknown; }
        }
    }
}