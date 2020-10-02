using System;
using Ardalis.GuardClauses;

namespace Api.Libraries.Serialization.Processdefinition.Model
{
    public class ProcessdefinitionId
    {
        public string Id { get; }

        public ProcessdefinitionId(string id)
        {
			Guard.Against.Null(id, nameof(id));

			if (!IsValidIdStructure(id))
			{
				throw new ArgumentException("Id is not in a valid structure", nameof(id));
			}

			Id = id;
		}

		public static bool IsValidIdStructure(string id)
		{
			// TODO Bessere Implementierung
			return Guid.TryParse(id, out _);
		}

		public override string ToString() => Id;
    }
}
