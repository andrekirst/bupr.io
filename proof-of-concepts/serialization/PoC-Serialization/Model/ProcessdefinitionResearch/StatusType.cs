using Ardalis.GuardClauses;

namespace PoC_Serialization.Model.ProcessdefinitionResearch
{
    public class StatusType
    {
        public string Value { get; }

        public StatusType(string value)
        {
            Guard.Against.NullOrWhiteSpace(value, nameof(value));

            Value = value;
        }

        public override string ToString() => Value;

        public static StatusType Error = new StatusType("error");
        public static StatusType Warning = new StatusType("warning");
        public static StatusType Success = new StatusType("success");
    }
}