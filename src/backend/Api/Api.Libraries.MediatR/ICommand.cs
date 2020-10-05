using Api.Libraries.Infrastructure.MediatR.Results;
using MediatR;

namespace Api.Libraries.Infrastructure.MediatR
{
	public interface ICommand : IRequest<IRequestResult>
	{
		
	}
}
