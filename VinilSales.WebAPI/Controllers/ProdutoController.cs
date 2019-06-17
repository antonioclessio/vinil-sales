using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VinilSales.Application.CoreContext.Interfaces;
using VinilSales.Application.ProdutoContext.Commands;
using VinilSales.Application.ProdutoContext.Queries;
using VinilSales.Domain.ProdutoContext.Model;
using VinilSales.WebAPI.Models.Produto;

namespace VinilSales.WebAPI.Controllers
{
    [Route("api/produtos")]
    public class ProdutoController : BaseController
    {
        public ProdutoController(IValidationHandler validation, IMediator mediator) : base(validation, mediator) {}

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProdutoFiltroModel filtro)
        {
            var result = await _mediator.Send(new ObterProdutosQuery(filtro));
            if (result == null)
                return CreateActionResponse("Os albuns estão sendo carregados, tente novamente em poucos segundos");

            return CreateActionResponse(result);
        }

        [HttpGet("{key:int}")]
        public async Task<IActionResult> GetByKey([FromRoute] int key)
        {
            return CreateActionResponse(await _mediator.Send(new ObterProdutoQuery(key)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SalvarProdutoModel model)
        {
            return CreateActionResponse(await _mediator.Send(new SalvarProdutoCommand(model.Preco, model.Nome, model.Genero, model.Artista)));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromRoute] int key, [FromBody] SalvarProdutoModel model)
        {
            return CreateActionResponse(await _mediator.Send(new SalvarProdutoCommand(key, model.Preco, model.Nome, model.Genero, model.Artista)));
        }
    }
}
