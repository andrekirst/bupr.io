namespace PoC_Serialization
{
    public class FunctionParameterName
    {
        public string Value { get; }

        public FunctionParameterName(string value)
        {
            Value = value;
        }

        public static implicit operator FunctionParameterName(string name) => new FunctionParameterName(name);
    }
}