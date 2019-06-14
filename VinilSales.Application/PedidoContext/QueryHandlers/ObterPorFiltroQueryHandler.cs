using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.CoreContext.Base;
using VinilSales.Application.PedidoContext.Queries;
using VinilSales.Application.PedidoContext.Results;
using VinilSales.Repository.Domain.PedidoContext.Entities;
using VinilSales.Repository.Domain.PedidoContext.Interfaces;

namespace VinilSales.Application.PedidoContext.QueryHandlers
{
    public class ObterPorFiltroQueryHandler : BaseHandler<IPedidoRepository>, IRequestHandler<ObterPorFiltroQuery, IEnumerable<ObterPorFiltroResult>>
    {
        public ObterPorFiltroQueryHandler(IMediator mediator, IPedidoRepository repository) : base(mediator, repository) { }

        public override void ConfigureMapper()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PedidoEntity, ObterPorFiltroResult>();
            }).CreateMapper();
        }

        public async Task<IEnumerable<ObterPorFiltroResult>> Handle(ObterPorFiltroQuery request, CancellationToken cancellationToken)
        {
            var pedidos = await _repository.ObterPorFiltro(request.Filtro);
            var result = _mapper.Map<IEnumerable<ObterPorFiltroResult>>(pedidos);

            return result;
        }
    }
}
