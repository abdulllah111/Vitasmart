using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vitasmart.Application.Interfaces;

namespace Vitasmart.Application.Patients.Queries.GetPatientList
{
    public class GetPatientListQueryHandler : IRequestHandler<GetPatientListQuery, PatientListVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPatientListQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<PatientListVm> Handle(GetPatientListQuery request, CancellationToken cancellationToken)
        {
            var patientsQuery = await _dbContext.Patients
                .ProjectTo<PatientLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PatientListVm { Patients= patientsQuery };
        }
    }
}