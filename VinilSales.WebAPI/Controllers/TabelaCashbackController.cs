using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VinilSales.Application.TabelaCashbackContext.Queries;
using VinilSales.Domain.CoreContext.Interfaces;

namespace VinilSales.WebAPI.Controllers
{
    [Route("api/cashback")]
    public class TabelaCashbackController : BaseController
    {
        public TabelaCashbackController(IValidationMessage validation, IMediator mediator) : base(validation, mediator) { }

        [HttpGet]
        [Route("tabela-vigente")]
        public async Task<IActionResult> GetVigente()
        {
            var result = await _mediator.Send(new ObterVigenteQuery());
            return CreateActionResponse(result);
        }
    }
}
