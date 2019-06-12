using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.ClienteContext.Queries;
using VinilSales.Application.ClienteContext.Results;
using VinilSales.Application.CoreContext.Base;
using VinilSales.Repository.Domain.ClienteContext.Entities;
using VinilSales.Repository.Domain.ClienteContext.Interfaces;

namespace VinilSales.Application.ClienteContext.QueryHandlers
{
    public class ObterClientesQueryHandler : BaseHandler<IClienteRepository>, IRequestHandler<ObterClientesQuery, IEnumerable<ObterClientesResult>>
    {
        public ObterClientesQueryHandler(IMediator mediator, IClienteRepository repository) : base(mediator, repository) { }

        public override void ConfigureMapper()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClienteEntity, ObterClientesResult>();
            }).CreateMapper();
        }

        public async Task<IEnumerable<ObterClientesResult>> Handle(ObterClientesQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.ObterTodos();
            return _mapper.Map<List<ObterClientesResult>>(result);
        }
    }
}
