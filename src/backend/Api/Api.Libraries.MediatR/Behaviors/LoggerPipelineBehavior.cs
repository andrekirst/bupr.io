using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Api.Libraries.Infrastructure.MediatR.Behaviors
{
	public class LoggerPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : notnull
	{
		private readonly IEnumerable<IValidator<TRequest>> _validators;
		private readonly ILogger<LoggerPipelineBehavior<TRequest, TResponse>> _logger;

		public LoggerPipelineBehavior(
			IEnumerable<IValidator<TRequest>> validators,
			ILogger<LoggerPipelineBehavior<TRequest, TResponse>> logger)
		{
			_validators = validators;
			_logger = logger;
		}

		public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
		{
			var errors = _validators
				.Select(v => v.Validate(request))
				.SelectMany(result => result.Errors)
				.Where(item => item != null)
				.ToList();

			if (!errors.Any())
			{
				return next();
			}

			var errorBuilder = new StringBuilder();
			errorBuilder.AppendLine("Invalid command, reason: ");
			foreach (var error in errors)
			{
				errorBuilder.AppendLine(error.ErrorMessage);
			}

			_logger.LogError(errorBuilder.ToString());

			throw new InvalidCommandException(errorBuilder.ToString(), details: null);
		}
	}
}
