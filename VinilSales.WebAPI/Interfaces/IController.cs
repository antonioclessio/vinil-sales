using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace VinilSales.WebAPI.Interfaces
{
    public interface IController
    {
        Task<IActionResult> Get();
        Task<IActionResult> GetByKey(int key);
        Task<IActionResult> Post();
        Task<IActionResult> Put(int key);
        Task<IActionResult> Delete();
    }
}
