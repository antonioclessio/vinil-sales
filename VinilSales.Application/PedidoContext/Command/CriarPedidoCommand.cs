using MediatR;
using System.Collections.Generic;
using VinilSales.Domain.ProdutoContext.Enum;

namespace VinilSales.Application.PedidoContext.Command
{
    public class CriarPedidoCommand : IRequest<bool>
    {
        public CriarPedidoCommand(int idCliente, List<CriarPedido_ItemCommand> itens)
        {
            this.IdCliente = idCliente;
            this.Itens.AddRange(itens);
        }

        public int IdCliente { get; set; }
        public List<CriarPedido_ItemCommand> Itens { get; } = new List<CriarPedido_ItemCommand>();
    }
}
