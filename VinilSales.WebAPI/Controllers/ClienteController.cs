using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VinilSales.Application.ClienteContext.Queries;
using VinilSales.Domain.CoreContext.ValueObjects;
using VinilSales.WebAPI.Interfaces;

namespace VinilSales.WebAPI.Controllers
{
    [Route("api/clientes")]
    public class ClienteController : BaseController, IController
    {
        public ClienteController(IMediator mediator) : base(mediator) { }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return CreateActionResponse(true, await _mediator.Send(new ObterClientesQuery()));
        }

        [HttpGet("{key:int}")]
        public async Task<IActionResult> GetByKey([FromRoute] int key)
        {
            return CreateActionResponse(true, await _mediator.Send(new ObterClienteQuery(key)));
        }

        [HttpGet]
        [Route("cpf")]
        public async Task<IActionResult> GetByCPF([FromQuery] string cpf)
        {
            return CreateActionResponse(true, await _mediator.Send(new ObterClienteQuery(cpf)));
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key)
        {
            throw new NotImplementedException();
        }
    }
}
