using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PoC_Serialization
{
    public class FunctionParameters : IEnumerable<FunctionParameter>
    {
        private readonly List<FunctionParameter> _functionParameters;
        public ReadOnlyCollection<FunctionParameter> Parameters => _functionParameters.AsReadOnly();
        
        public FunctionParameters(IEnumerable<FunctionParameter> functionParameters)
        {
            _functionParameters = functionParameters.ToList();
        }
        
        public IEnumerator<FunctionParameter> GetEnumerator() => _functionParameters.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public static implicit operator FunctionParameters(
            Dictionary<FunctionParameterType, FunctionParameterName> typeAndNames)
        {
            var functionParameters = new List<FunctionParameter>();
            
            foreach (var (type, name) in typeAndNames)
            {
                functionParameters.Add(new FunctionParameter(type, name));
            }

            return new FunctionParameters(functionParameters);
        }
    }
}