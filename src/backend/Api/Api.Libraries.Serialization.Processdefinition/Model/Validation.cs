namespace Api.Libraries.Serialization.Processdefinition.Model
{
    public class Validation
    {
        public string Value { get; }

        public Validation(string value)
        {
            //Guard.Against.NullOrWhiteSpace(value, nameof(value));
            //Value = value;
        }

        public override string ToString() => Value;
    }
}
