using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VinilSales.WebAPI.Interfaces;

namespace VinilSales.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : BaseController, IController
    {
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(new string[] { "value5", "value6" });
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
    }
}
