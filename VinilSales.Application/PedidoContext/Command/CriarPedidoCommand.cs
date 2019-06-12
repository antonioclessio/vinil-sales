﻿using MediatR;
using VinilSales.Domain.ProdutoContext.Enum;

namespace VinilSales.Application.PedidoContext.Command
{
    public class CriarPedidoCommand : IRequest<bool>
    {
        public CriarPedidoCommand(int idCliente, int idProduto, int quantidade)
        {
            this.IdCliente = idCliente;
            this.IdProduto = idProduto;
            this.Quantidade = quantidade;
        }

        public int IdCliente { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
    }
}