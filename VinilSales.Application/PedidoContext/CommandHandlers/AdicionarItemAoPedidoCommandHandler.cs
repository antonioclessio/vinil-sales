using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.CoreContext.CommandHandlers;
using VinilSales.Application.CoreContext.Interfaces;
using VinilSales.Application.PedidoContext.Command;
using VinilSales.Application.ProdutoContext.Queries;
using VinilSales.Repository.Domain.PedidoContext.Entities;
using VinilSales.Repository.Domain.PedidoContext.Interfaces;

namespace VinilSales.Application.PedidoContext.CommandHandlers
{
    public class AdicionarItemAoPedidoCommandHandler : BaseHandler<IPedidoRepository>, IRequestHandler<AdicionarItemAoPedidoCommand, bool>
    {
        public AdicionarItemAoPedidoCommandHandler(IValidationHandler validation, IMediator mediator, IPedidoRepository repository)
            : base(validation, mediator, repository)
        {
        }

        public override void ConfigureMapper()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdicionarItemAoPedidoCommand, Pedido_ItemEntity>();
            }).CreateMapper();
        }

        public async Task<bool> Handle(AdicionarItemAoPedidoCommand request, CancellationToken cancellationToken)
        {
            var novoItem = _mapper.Map<Pedido_ItemEntity>(request);

            var produtoEntity = await _mediator.Send(new ObterProdutoQuery(request.IdProduto));
            novoItem.ValorUnitario = produtoEntity.Preco;

            if (!novoItem.IsValid())
                return false;

            await _repository.AdicionarItem(novoItem);
            return true;
        }
    }
}
