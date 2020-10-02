using System;
using System.Threading;
using System.Threading.Tasks;
using Api.Libraries.MediatR.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using BadRequestObjectResult = Api.Libraries.MediatR.Results.BadRequestObjectResult;
using BadRequestResult = Api.Libraries.MediatR.Results.BadRequestResult;
using CreatedAtActionResult = Api.Libraries.MediatR.Results.CreatedAtActionResult;
using NoContentResult = Api.Libraries.MediatR.Results.NoContentResult;
using NotFoundObjectResult = Api.Libraries.MediatR.Results.NotFoundObjectResult;
using NotFoundResult = Api.Libraries.MediatR.Results.NotFoundResult;
using OkObjectResult = Api.Libraries.MediatR.Results.OkObjectResult;
using OkResult = Api.Libraries.MediatR.Results.OkResult;
using UnauthorizedResult = Api.Libraries.MediatR.Results.UnauthorizedResult;

namespace Api.Libraries.MediatR
{
	public class WebApiBaseController : ControllerBase
	{
		private readonly IMediator _mediator;

		public WebApiBaseController(IMediator mediator)
		{
			_mediator = mediator;
		}

		protected async Task<ActionResult> ExecuteRequestAsync<T>(T request, CancellationToken cancellationToken = default)
			where T : IRequest<IRequestResult>
		{
			var requestResult = await _mediator.Send(request, cancellationToken);
			return ActionResult(requestResult);
		}

		public ActionResult ActionResult(IRequestResult result) =>
			result switch
			{
				OkResult _ => Ok(),
				OkObjectResult okObjectResult => Ok(okObjectResult.Value),
				BadRequestResult _ => BadRequest(),
				BadRequestObjectResult badRequestObjectResult when badRequestObjectResult.Error != null => BadRequest(badRequestObjectResult.Error),
				BadRequestObjectResult badRequestObjectResult when badRequestObjectResult.ModelState != null => BadRequest(badRequestObjectResult.ModelState),
				BadRequestObjectResult _ => BadRequest(),
				CreatedAtActionResult createdAtActionResult => CreatedAtAction(
					createdAtActionResult.ActionName,
					createdAtActionResult.ControllerName?.Replace("Controller", string.Empty) ?? "<NoContrller>",
					value: createdAtActionResult.Value,
					routeValues: createdAtActionResult.RouteValues),
				NotFoundResult _ => NotFound(),
				NotFoundObjectResult notFoundObjectResult => NotFound(notFoundObjectResult.Value),
				NoContentResult _ => NoContent(),
				UnauthorizedResult _ => Unauthorized(),
				_ => throw new NotImplementedException()
			};
	}
}
