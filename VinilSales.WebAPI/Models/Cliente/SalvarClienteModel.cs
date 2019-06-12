using VinilSales.Domain.CoreContext.ValueObjects;

namespace VinilSales.WebAPI.Models.Cliente
{
    public class SalvarClienteModel
    {
        public string Nome { get; set; }
        public CPF CPF { get; set; }
    }
}
