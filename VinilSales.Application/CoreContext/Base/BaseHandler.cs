using MediatR;

namespace VinilSales.Application.CoreContext.Base
{
    public abstract class BaseHandler
    {
        protected IMediator _mediator;

        public BaseHandler(IMediator mediator)
        {
            this._mediator = mediator;
        }
    }
}
