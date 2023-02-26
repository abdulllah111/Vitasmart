using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vitasmart.Application.Interfaces;

namespace Vitasmart.Application.Visitings.Queries.GetVisitingList
{
    public class GetVisitingListQueryHandler : IRequestHandler<GetVisitingListQuery, VisitingListVm>
    {
        private readonly IVisitingsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetVisitingListQueryHandler(IVisitingsDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<VisitingListVm> Handle(GetVisitingListQuery request, CancellationToken cancellationToken)
        {
            var visitingsQuery = await _dbContext.Visitings
                .Where(visiting => visiting.PatientId == request.PatientId)
                .ProjectTo<VisitingLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new VisitingListVm { Visitings = visitingsQuery };
        }
    }
}