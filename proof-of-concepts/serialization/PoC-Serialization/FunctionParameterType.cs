namespace PoC_Serialization
{
    public class FunctionParameterType
    {
        public string Value { get; }

        public FunctionParameterType(string value)
        {
            Value = value;
        }

        public static implicit operator FunctionParameterType(string type) => new FunctionParameterType(type);
    }
}