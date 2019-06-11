using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VinilSales.Application.ProdutoContext.Queries;
using VinilSales.WebAPI.Interfaces;

namespace VinilSales.WebAPI.Controllers
{
    [Route("api/produtos")]
    public class ProdutoController : BaseController, IController
    {
        public ProdutoController(IMediator mediator) : base(mediator) {}

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetProdutosQuery());
            if (result == null || result.Count() == 0)
                return CreateActionResponse(true, "Os albuns estão sendo carregados, tente novamente em poucos segundos");

            return CreateActionResponse(true, result);
        }

        [HttpGet("{key:int}")]
        public async Task<IActionResult> GetByKey(int key)
        {
            throw new NotImplementedException();
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
