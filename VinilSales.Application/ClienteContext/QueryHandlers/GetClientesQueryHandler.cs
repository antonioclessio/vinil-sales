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
    public class GetClientesQueryHandler : BaseHandler<IClienteRepository>, IRequestHandler<GetClientesQuery, IEnumerable<GetClientesResult>>
    {
        public GetClientesQueryHandler(IMediator mediator, IClienteRepository repository) : base(mediator, repository) { }

        public override void ConfigureMapper()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClienteEntity, GetClientesResult>();
            }).CreateMapper();
        }

        public async Task<IEnumerable<GetClientesResult>> Handle(GetClientesQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.ObterTodos();
            return _mapper.Map<List<GetClientesResult>>(result);
        }
    }
}
