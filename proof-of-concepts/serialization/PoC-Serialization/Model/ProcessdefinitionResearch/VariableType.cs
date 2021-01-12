namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class VariableType
    {
        public string Type { get; }

        public VariableType(string type)
        {
            Type = type;
        }

        public static implicit operator VariableType(string type) => new VariableType(type);

        public override string ToString() => Type;
    }
}