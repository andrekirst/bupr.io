using System;
using System.Collections.Generic;
using System.Reflection;

namespace PoC_Serialization
{
    public abstract class Function
    {
        public FunctionParameterType FunctionReturnType { get; }
        public FunctionName FunctionName { get; }
        public IEnumerable<FunctionParameter> Parameters { get; }

        protected Function(FunctionParameterType functionReturnType, FunctionName functionName, FunctionParameters parameters)
        {
            FunctionReturnType = functionReturnType;
            FunctionName = functionName;
            Parameters = parameters;
        }

        private static Dictionary<string, Type> TypeMapping => new Dictionary<string, Type>
        {
            {"string", typeof(string)}
        };

        public abstract MethodInfo GetMethodInfo();

        public static implicit operator MethodInfo(Function f) => f.GetMethodInfo();
    }

    public class IsEmptyFunction : Function
    {
        public IsEmptyFunction() : base("bool", "IsEmpty", new Dictionary<FunctionParameterType, FunctionParameterName>
        {
            { "string", "value" }
        })
        {
        }

        public override MethodInfo GetMethodInfo() => typeof(string).GetMethod(nameof(string.IsNullOrEmpty))!;
    }
}