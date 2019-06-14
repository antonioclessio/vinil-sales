using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VinilSales.Application.PedidoContext.Command;
using VinilSales.Application.PedidoContext.Queries;
using VinilSales.Domain.PedidoContext.Model;
using VinilSales.WebAPI.Models.Core;
using VinilSales.WebAPI.Models.Pedido;

namespace VinilSales.WebAPI.Controllers
{
    [Route("api/pedidos")]
    public class PedidoController : BaseController
    {
        public PedidoController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        [Route("{key:int}/cancelar")]
        public async Task<IActionResult> Cancelar([FromRoute] int key)
        {
            return CreateActionResponse(true, await _mediator.Send(new CancelarPedidoCommand(key)));
        }

        [HttpPost]
        [Route("{key:int}/finalizar")]
        public async Task<IActionResult> Finalizar([FromRoute] int key)
        {
            return CreateActionResponse(true, await _mediator.Send(new FinalizarPedidoCommand(key)));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PedidoFiltroModel filtro)
        {
            return CreateActionResponse(true, await _mediator.Send(new ObterPorFiltroQuery(filtro)));
        }

        [HttpGet("{key:int}")]
        public async Task<IActionResult> GetByKey([FromRoute] int key)
        {
            return CreateActionResponse(true, await _mediator.Send(new ObterPedidoQuery(key)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SalvarPedidoModel model)
        {
            List<CriarPedido_ItemCommand> itens = new List<CriarPedido_ItemCommand>();
            model.Itens.ForEach(item => itens.Add(new CriarPedido_ItemCommand(item.IdPedido, item.IdProduto, item.Quantidade)));

            return CreateActionResponse(true, await _mediator.Send(new CriarPedidoCommand(model.IdCliente, itens)));
        }
    }
}
