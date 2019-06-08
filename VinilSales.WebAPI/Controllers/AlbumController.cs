using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VinilSales.Application.AlbumContext.Commands;
using VinilSales.Application.AlbumContext.Queries;
using VinilSales.WebAPI.Interfaces;

namespace VinilSales.WebAPI.Controllers
{
    [Route("api/albuns")]
    public class AlbumController : BaseController, IController
    {
        public AlbumController(IMediator mediator) : base(mediator) {}

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return CreateActionResponse(true, await _mediator.Send(new GetAlbunsQuery()));
        }

        [HttpGet("{key:int}")]
        public async Task<IActionResult> GetByKey(int key)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            throw new System.NotImplementedException();
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost("atualizar-catalogo")]
        public async Task<IActionResult> PostAtualizarCatalogo()
        {
            return CreateActionResponse(true, await _mediator.Send(new AtualizarCatalogoSpotifyCommand()));
        }
    }
}
