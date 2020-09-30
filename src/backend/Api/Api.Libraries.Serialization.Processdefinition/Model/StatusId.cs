namespace Api.Libraries.Serialization.Processdefinition.Model
{
    public class StatusId
    {
        public StatusId(string id)
        {
            //Guard.Against.NullOrWhiteSpace(id, nameof(id));

            //Id = id;
        }

        public string Id { get; }

        public override string ToString() => Id;
    }
}
