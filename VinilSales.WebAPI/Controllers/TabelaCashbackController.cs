using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VinilSales.Application.TabelaCashbackContext.Queries;

namespace VinilSales.WebAPI.Controllers
{
    [Route("api/cashback")]
    public class TabelaCashbackController : BaseController
    {
        public TabelaCashbackController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [Route("tabela-vigente")]
        public async Task<IActionResult> GetVigente()
        {
            var result = await _mediator.Send(new ObterVigenteQuery());
            return CreateActionResponse(true, result);
        }
    }
}
