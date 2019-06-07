using MediatR;

namespace VinilSales.Application.CoreContext.Base
{
    public abstract class BaseHandler<TRepository> : BaseSimpleHandler
    {
        protected TRepository _repository;

        public BaseHandler(IMediator mediator, TRepository repository) : base(mediator)
        {
            this._repository = repository;
        }
    }
}
