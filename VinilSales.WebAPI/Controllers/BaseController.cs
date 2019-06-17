using MediatR;
using Microsoft.AspNetCore.Mvc;
using VinilSales.Application.CoreContext.Interfaces;
using VinilSales.WebAPI.Models.Core;

namespace VinilSales.WebAPI.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IMediator _mediator;
        protected IValidationHandler _validation;

        public BaseController(IValidationHandler validation, IMediator mediator)
        {
            this._validation = validation;
            this._mediator = mediator;
        }

        protected IActionResult CreateActionResponse(object data)
        {
            return CreateActionResponse("Action executada com sucesso", data);
        }

        protected IActionResult CreateActionResponse(string message, object data)
        {
            if (_validation.IsEmpty)
                return Ok(new ActionResultModel(true, message, data));

            return Ok(new ActionResultModel(false, "Ação concluída com erros", _validation.Messages));
        }
    }
}
