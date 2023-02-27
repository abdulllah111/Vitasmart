using MediatR;
using Microsoft.EntityFrameworkCore;
using Vitasmart.Application.Common.Exceptions;
using Vitasmart.Application.Interfaces;
using Vitasmart.Domain;

namespace Vitasmart.Application.Patients.Commands.UpdatePatient
{
    public class UpdatePatientCommandHandler : IRequest<UpdatePatientCommand>
    {
        private readonly IApplicationDbContext _dbContext;
        public UpdatePatientCommandHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var entity = 
                await _dbContext.Patients.FirstOrDefaultAsync(patient =>
                    patient.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Patient), request.Id);
            }

            entity.Surname = request.Surname;
            entity.Name = request.Name;
            entity.Patronymic = request.Patronymic;
            entity.BirthDay = request.BirthDay;
            entity.PhoneNumber = request.PhoneNumber;
            entity.DateUpdated = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}