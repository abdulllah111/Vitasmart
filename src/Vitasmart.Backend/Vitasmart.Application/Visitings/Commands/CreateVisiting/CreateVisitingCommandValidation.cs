using FluentValidation;
using Vitasmart.Application.Visitings.Commands.CreateVisiting;

namespace Vitasmart.Application.Patients.Commands
{
    public class CreateVisitingCommandValidation : AbstractValidator<CreateVisitingCommand>
    {
        public CreateVisitingCommandValidation()
        {
            RuleFor(updatePatientCommand => updatePatientCommand.PatientId).NotEqual(Guid.Empty);
            RuleFor(updatePatientCommand => updatePatientCommand.Diagnose).NotEmpty().MaximumLength(250);
            RuleFor(updatePatientCommand => updatePatientCommand.Date).NotEmpty();
        }
    }
}