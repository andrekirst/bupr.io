using Ardalis.GuardClauses;

namespace Api.Libraries.Serialization.Processdefinition.Model
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

        public static readonly StatusType Error = new StatusType("error");
        public static readonly StatusType Warning = new StatusType("warning");
        public static readonly StatusType Success = new StatusType("success");
    }
}
