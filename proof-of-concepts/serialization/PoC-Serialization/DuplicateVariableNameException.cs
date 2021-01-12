using System;

namespace PoC_Serialization
{
    public class DuplicateVariableNameException : Exception
    {
        public string VariableName { get; }

        public DuplicateVariableNameException(string variableName)
            : base($"The variable \"{variableName}\" exists several times")
        {
            VariableName = variableName;
        }
    }
}