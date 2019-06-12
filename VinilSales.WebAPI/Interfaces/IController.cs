using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace VinilSales.WebAPI.Interfaces
{
    public interface IController<TModel>
    {
        Task<IActionResult> Get();
        Task<IActionResult> GetByKey(int key);
        Task<IActionResult> Post(TModel model);
        Task<IActionResult> Put(int key, TModel model);
        Task<IActionResult> Delete();
    }
}
