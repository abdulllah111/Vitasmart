using FluentValidation;
using Vitasmart.Application.Patients.Commands.UpdatePatient;

namespace Vitasmart.Application.Patients.Commands
{
    public class UpdatePatientCommandValidation : AbstractValidator<UpdatePatientCommand>
    {
        public UpdatePatientCommandValidation()
        {
            RuleFor(updatePatientCommand => updatePatientCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updatePatientCommand => updatePatientCommand.Name).NotEmpty().MaximumLength(250);
            RuleFor(updatePatientCommand => updatePatientCommand.Surname).NotEmpty().MaximumLength(250);
            RuleFor(updatePatientCommand => updatePatientCommand.Patronymic).NotEmpty().MaximumLength(250);
        }
    }
}