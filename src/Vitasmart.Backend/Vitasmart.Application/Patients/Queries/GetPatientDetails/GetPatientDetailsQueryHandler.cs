using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vitasmart.Application.Common.Exceptions;
using Vitasmart.Application.Interfaces;
using Vitasmart.Domain;

namespace Vitasmart.Application.Patients.Queries.GetPatientDetails
{
    public class GetPatientDetailsQueryHandler : IRequestHandler<GetPatientDetailsQuery, PatientDetailsVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetPatientDetailsQueryHandler(IApplicationDbContext dbContext, IMapper mapper)  => 
            (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<PatientDetailsVm> Handle(GetPatientDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Patients
                .FirstOrDefaultAsync(patient => patient.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Patient), request.Id);
            }

            return _mapper.Map<PatientDetailsVm>(entity);
        }
    }
}