using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using VinilSales.Application.CoreContext.Base;
using VinilSales.Application.PedidoContext.Queries;
using VinilSales.Application.PedidoContext.Results;
using VinilSales.Repository.Domain.PedidoContext.Entities;
using VinilSales.Repository.Domain.PedidoContext.Interfaces;

namespace VinilSales.Application.PedidoContext.QueryHandlers
{
    public class ObterPedidoQueryHandler : BaseHandler<IPedidoRepository>, IRequestHandler<ObterPedidoQuery, ObterPedidoResult>
    {
        public ObterPedidoQueryHandler(IMediator mediator, IPedidoRepository repository) : base(mediator, repository) { }

        public override void ConfigureMapper()
        {
            _mapper = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<PedidoEntity, ObterPedidoResult>();
            }).CreateMapper();
        }

        public async Task<ObterPedidoResult> Handle(ObterPedidoQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.ObterPorId(request.IdPedido);
            return _mapper.Map<ObterPedidoResult>(result);
        }
    }
}
