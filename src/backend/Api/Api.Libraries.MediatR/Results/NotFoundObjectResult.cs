namespace Api.Libraries.MediatR.Results
{
	public class NotFoundObjectResult : IRequestResult
	{
		public object Value { get; }

		public NotFoundObjectResult(object value)
		{
			Value = value;
		}
	}
}
