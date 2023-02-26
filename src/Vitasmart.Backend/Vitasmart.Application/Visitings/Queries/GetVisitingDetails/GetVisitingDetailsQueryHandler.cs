using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Vitasmart.Application.Common.Exceptions;
using Vitasmart.Application.Interfaces;

namespace Vitasmart.Application.Visitings.Queries.GetVisitingDetails
{
    public class GetVisitingDetailsQueryHandler : IRequestHandler<GetVisitingDetailsQuery, VisitingDetailsVm>
    {
        private readonly IVisitingsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetVisitingDetailsQueryHandler(IVisitingsDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<VisitingDetailsVm> Handle(GetVisitingDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Visitings.
                FirstOrDefaultAsync(visiting => visiting.Id == request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Visitings), request.Id);
            }

            return _mapper.Map<VisitingDetailsVm>(entity);
        }
    }
}