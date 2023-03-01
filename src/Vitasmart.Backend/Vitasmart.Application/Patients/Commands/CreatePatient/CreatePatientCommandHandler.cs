using MediatR;
using System.Collections.ObjectModel;
using Vitasmart.Application.Interfaces;
using Vitasmart.Domain;

namespace Vitasmart.Application.Patients.Commands.CreatePatient
{
    public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;
        public CreatePatientCommandHandler(IApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = new Patient
            {
                Id = Guid.NewGuid(),
                Surname = request.Surname,
                Name = request.Name,
                Patronymic = request.Patronymic,
                BirthDay = request.BirthDay,
                PhoneNumber = request.PhoneNumber,
                DateAdded = DateTime.Now,
                DateUpdated = null
            };

            await _dbContext.Patients.AddAsync(patient, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return patient.Id;
        }
    }
}