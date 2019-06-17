using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VinilSales.Application.ClienteContext.Commands;
using VinilSales.Application.ClienteContext.Queries;
using VinilSales.Domain.CoreContext.Interfaces;
using VinilSales.WebAPI.Models.Cliente;

namespace VinilSales.WebAPI.Controllers
{
    [Route("api/clientes")]
    public class ClienteController : BaseController
    {
        public ClienteController(IValidationMessage validation, IMediator mediator) : base(validation, mediator) { }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return CreateActionResponse(await _mediator.Send(new ObterClientesQuery()));
        }

        [HttpGet("{key:int}")]
        public async Task<IActionResult> GetByKey([FromRoute] int key)
        {
            return CreateActionResponse(await _mediator.Send(new ObterClienteQuery(key)));
        }

        [HttpGet("{key:int}/extrato")]
        public async Task<IActionResult> GetExtrato([FromRoute] int key)
        {
            return CreateActionResponse(await _mediator.Send(new ObterExtratoPorClienteQuery(key)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SalvarClienteModel model)
        {
            return CreateActionResponse(await _mediator.Send(new SalvarClienteCommand(model.Nome, model.CPF)));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromRoute] int key, [FromBody] SalvarClienteModel model)
        {
            return CreateActionResponse(await _mediator.Send(new SalvarClienteCommand(key, model.Nome, model.CPF)));
        }
    }
}
