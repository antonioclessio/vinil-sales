using MediatR;
using VinilSales.Domain.CoreContext.Interfaces;

namespace VinilSales.Application.CoreContext.CommandHandlers
{
    public abstract class BaseSimpleHandler
    {
        protected IValidationMessage _validation;
        protected IMediator _mediator;

        public BaseSimpleHandler(IValidationMessage validation, IMediator mediator)
        {
            this._validation = validation;
            this._mediator = mediator;
        }
    }
}
