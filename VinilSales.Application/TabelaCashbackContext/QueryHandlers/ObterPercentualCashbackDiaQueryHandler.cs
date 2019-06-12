using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.TabelaCashbackContext.Queries;
using VinilSales.Repository.Domain.TabelaCashbackContext.Interfaces;

namespace VinilSales.Application.TabelaCashbackContext.QueryHandlers
{
    public class ObterPercentualCashbackDiaQueryHandler : IRequestHandler<ObterPercentualCashbackDiaQuery, decimal>
    {
        private readonly ITabelaCashbackRepository _repository;

        public ObterPercentualCashbackDiaQueryHandler(ITabelaCashbackRepository repository)
        {
            this._repository = repository;
        }

        public async Task<decimal> Handle(ObterPercentualCashbackDiaQuery request, CancellationToken cancellationToken)
        {
            var vigentePorGenero = await _repository.ObterTabelaVigentePorGenero(request.Genero);
            decimal percentual = 0;
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Sunday: percentual = vigentePorGenero.Domingo; break;
                case DayOfWeek.Monday: percentual = vigentePorGenero.Segunda; break;
                case DayOfWeek.Tuesday: percentual = vigentePorGenero.Terca; break;
                case DayOfWeek.Wednesday: percentual = vigentePorGenero.Quarta; break;
                case DayOfWeek.Thursday: percentual = vigentePorGenero.Quinta; break;
                case DayOfWeek.Friday: percentual = vigentePorGenero.Segunda; break;
                case DayOfWeek.Saturday: percentual = vigentePorGenero.Sabado; break;
            }

            return percentual;
        }
    }
}
