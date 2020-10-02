using System;
using System.Runtime.Serialization;

namespace Api.Libraries.MediatR
{
	[Serializable]
	public class InvalidCommandException : Exception
	{

		public InvalidCommandException()
		{
		}

		public InvalidCommandException(string message)
			: base(message)
		{
		}

		public InvalidCommandException(string message, object? details)
			: base(message)
		{
			Details = details;
		}

		public object? Details { get; set; }

		public InvalidCommandException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected InvalidCommandException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
