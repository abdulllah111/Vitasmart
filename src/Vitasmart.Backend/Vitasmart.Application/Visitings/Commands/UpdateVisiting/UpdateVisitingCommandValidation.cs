using FluentValidation;
using Vitasmart.Application.Visitings.Commands.UpdateVisiting;

namespace Vitasmart.Application.Patients.Commands
{
    public class UpdateVisitingCommandValidation : AbstractValidator<UpdateVisitingCommand>
    {
        public UpdateVisitingCommandValidation()
        {
            RuleFor(updatePatientCommand => updatePatientCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updatePatientCommand => updatePatientCommand.Diagnose).NotEmpty().MaximumLength(250);
            RuleFor(updatePatientCommand => updatePatientCommand.Date).NotEmpty();
        }
    }
}