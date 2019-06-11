using AutoMapper;
using MediatR;

namespace VinilSales.Application.CoreContext.Base
{
    public abstract class BaseHandler<TRepository> : BaseSimpleHandler
    {
        protected TRepository _repository;
        protected IMapper _mapper;

        public BaseHandler(IMediator mediator, TRepository repository) : base(mediator)
        {
            this._repository = repository;
            ConfigureMapper();
        }

        public abstract void ConfigureMapper();
    }
}
