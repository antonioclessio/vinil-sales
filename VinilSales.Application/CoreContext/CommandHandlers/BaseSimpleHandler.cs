using MediatR;
using VinilSales.Application.CoreContext.Interfaces;

namespace VinilSales.Application.CoreContext.CommandHandlers
{
    public abstract class BaseSimpleHandler
    {
        protected IValidationHandler _validation;
        protected IMediator _mediator;

        public BaseSimpleHandler(IValidationHandler validation, IMediator mediator)
        {
            this._validation = validation;
            this._mediator = mediator;
        }
    }
}
