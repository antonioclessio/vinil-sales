﻿using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VinilSales.Application.ClienteContext.Queries;
using VinilSales.Application.ClienteContext.Results;
using VinilSales.Application.CoreContext.Base;
using VinilSales.Repository.Domain.ClienteContext.Entities;
using VinilSales.Repository.Domain.ClienteContext.Interfaces;

namespace VinilSales.Application.ClienteContext.QueryHandlers
{
    public class ObterExtratoPorClienteQueryHandler : BaseHandler<IClienteRepository>, IRequestHandler<ObterExtratoPorClienteQuery, IEnumerable<ObterExtratoPorClienteResult>>
    {
        public ObterExtratoPorClienteQueryHandler(IMediator mediator, IClienteRepository repository) 
            : base(mediator, repository) { }

        public override void ConfigureMapper()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClienteEntity, ObterExtratoPorClienteResult>();
            }).CreateMapper();
        }

        public async Task<IEnumerable<ObterExtratoPorClienteResult>> Handle(ObterExtratoPorClienteQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.ObterExtratoPorCliente(request.IdCliente);
            return _mapper.Map<List<ObterExtratoPorClienteResult>>(result);
        }
    }
}