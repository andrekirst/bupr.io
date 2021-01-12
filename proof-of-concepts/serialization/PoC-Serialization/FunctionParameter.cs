namespace PoC_Serialization
{
    public class FunctionParameter
    {
        public FunctionParameterType Type { get; }
        public FunctionParameterName Name { get; }

        public FunctionParameter(FunctionParameterType parameterType, FunctionParameterName parameterName)
        {
            Type = parameterType;
            Name = parameterName;
        }
    }
}