using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PoC_Serialization.Model.ProcessdefinitionResearch;

namespace PoC_Serialization
{
    public class Variable
    {
        public VariableType VariableType { get; }
        public VariableName VariableName { get; }
        public object? Value { get; }

        public Variable(VariableType variableType, VariableName variableName, object? value)
        {
            VariableType = variableType;
            VariableName = variableName;
            Value = value;
        }

        public static Dictionary<string, Type> VariableTypeMapping => new Dictionary<string, Type>
        {
            { "string", typeof(string) }
        };

        public ConstantExpression GetConstantExpression() => Expression.Constant(Value, VariableTypeMapping[VariableType.Type]);

        public static implicit operator ConstantExpression(Variable variable) => Expression.Constant(variable.Value, VariableTypeMapping[variable.VariableType.Type]);

        public override string ToString() => $"{VariableType.Type} {VariableName.Name} = {Value}";
    }
}