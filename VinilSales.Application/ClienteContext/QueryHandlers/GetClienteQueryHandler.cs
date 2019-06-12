using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.ClienteContext.Queries;
using VinilSales.Application.ClienteContext.Results;
using VinilSales.Application.CoreContext.Base;
using VinilSales.Repository.Domain.ClienteContext.Entities;
using VinilSales.Repository.Domain.ClienteContext.Interfaces;

namespace VinilSales.Application.ClienteContext.QueryHandlers
{
    public class GetClienteQueryHandler : BaseHandler<IClienteRepository>, IRequestHandler<GetClienteQuery, GetClienteResult>
    {
        public GetClienteQueryHandler(IMediator mediator, IClienteRepository repository) : base(mediator, repository) { }

        public override void ConfigureMapper()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClienteEntity, GetClienteResult>();
            }).CreateMapper();
        }

        public async Task<GetClienteResult> Handle(GetClienteQuery request, CancellationToken cancellationToken)
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
            return _mapper.Map<GetClienteResult>(result);
        }
    }
}
