namespace PoC_Serialization
{
    public class FunctionName
    {
        public string Name { get; }

        public FunctionName(string name)
        {
            Name = name;
        }

        public static implicit operator FunctionName(string name) => new FunctionName(name);
        
        public override string ToString() => Name;
    }
}