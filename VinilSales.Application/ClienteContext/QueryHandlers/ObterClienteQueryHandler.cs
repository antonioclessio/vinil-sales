using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.ClienteContext.Queries;
using VinilSales.Application.ClienteContext.Results;
using VinilSales.Application.CoreContext.CommandHandlers;
using VinilSales.Application.CoreContext.Interfaces;
using VinilSales.Repository.Domain.ClienteContext.Entities;
using VinilSales.Repository.Domain.ClienteContext.Interfaces;

namespace VinilSales.Application.ClienteContext.QueryHandlers
{
    public class ObterClienteQueryHandler : BaseHandler<IClienteRepository>, IRequestHandler<ObterClienteQuery, ObterClienteResult>
    {
        public ObterClienteQueryHandler(IValidationHandler validation, IMediator mediator, IClienteRepository repository) 
            : base(validation, mediator, repository) { }

        public override void ConfigureMapper()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClienteEntity, ObterClienteResult>();
            }).CreateMapper();
        }

        public async Task<ObterClienteResult> Handle(ObterClienteQuery request, CancellationToken cancellationToken)
        {
            ClienteEntity result = null;
            if (request.Id.HasValue)
            {
                result = await _repository.ObterPorId(request.Id.Value);
            }
            else
            {
                result = await _repository.ObterPorCPF(request.CPF.Value);
            }

            if (result == null) return null;
            return _mapper.Map<ObterClienteResult>(result);
        }
    }
}
