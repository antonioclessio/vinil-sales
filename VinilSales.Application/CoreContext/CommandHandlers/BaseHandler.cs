using AutoMapper;
using MediatR;
using VinilSales.Application.CoreContext.Interfaces;

namespace VinilSales.Application.CoreContext.CommandHandlers
{
    public abstract class BaseHandler<TRepository> : BaseSimpleHandler
    {
        protected TRepository _repository;
        protected IMapper _mapper;

        public BaseHandler(
            IValidationHandler validation,
            IMediator mediator, 
            TRepository repository
            ) : base(validation, mediator)
        {
            this._repository = repository;
            ConfigureMapper();
        }

        public abstract void ConfigureMapper();
    }
}
