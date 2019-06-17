using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VinilSales.Application.CoreContext.Interfaces;
using VinilSales.Application.TabelaCashbackContext.Queries;

namespace VinilSales.WebAPI.Controllers
{
    [Route("api/cashback")]
    public class TabelaCashbackController : BaseController
    {
        public TabelaCashbackController(IValidationHandler validation, IMediator mediator) : base(validation, mediator) { }

        [HttpGet]
        [Route("tabela-vigente")]
        public async Task<IActionResult> GetVigente()
        {
            var result = await _mediator.Send(new ObterVigenteQuery());
            return CreateActionResponse(result);
        }
    }
}
