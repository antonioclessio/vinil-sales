using MediatR;

namespace VinilSales.Application.CoreContext.Base
{
    public abstract class BaseSimpleHandler
    {
        protected IMediator _mediator;

        public BaseSimpleHandler(IMediator mediator)
        {
            this._mediator = mediator;
        }
    }
}
