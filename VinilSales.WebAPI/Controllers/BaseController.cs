using MediatR;
using Microsoft.AspNetCore.Mvc;
using VinilSales.WebAPI.Models.Core;

namespace VinilSales.WebAPI.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        protected IActionResult CreateActionResponse(bool success, object data)
        {
            return CreateActionResponse(success, "Action executada com sucesso", data);
        }

        protected IActionResult CreateActionResponse(bool success, string message, object data)
        {
            return Ok(new ActionResultModel(success, message, data));
        }
    }
}
