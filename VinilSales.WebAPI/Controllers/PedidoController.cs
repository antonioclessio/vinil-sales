using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VinilSales.Application.PedidoContext.Command;
using VinilSales.Application.PedidoContext.Queries;
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
        public async Task<IActionResult> Get(
            [FromQuery] int idCliente, 
            [FromQuery] int pagina, 
            [FromQuery] int totalPorPagina)
        {
            return CreateActionResponse(true, await _mediator.Send(new ObterPorFiltroQuery(idCliente, pagina, totalPorPagina)));
        }

        [HttpGet("{key:int}")]
        public async Task<IActionResult> GetByKey([FromRoute] int key)
        {
            return CreateActionResponse(true, await _mediator.Send(new ObterPedidoQuery(key)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SalvarPedidoModel model)
        {
            return CreateActionResponse(true, await _mediator.Send(new CriarPedidoCommand(model.IdCliente, model.IdProduto, model.Quantidade)));
        }

        [HttpPut]
        public async Task<IActionResult> AdicionarItem([FromRoute] int key, [FromBody] SalvarPedidoModel model)
        {
            throw new NotImplementedException();
        }
    }
}
