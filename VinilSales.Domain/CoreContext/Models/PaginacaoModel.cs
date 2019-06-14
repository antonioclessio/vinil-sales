namespace VinilSales.Domain.ClienteContext.Models
{
    public class PaginacaoModel
    {
        private int _pagina = 1;
        public int Pagina
        {
            get { return _pagina - 1; }
            set { _pagina = value; }
        }
        
        public int TotalRegistrosPorPagina { get; set; } = 10;
    }
}
