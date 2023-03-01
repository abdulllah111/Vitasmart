using FluentValidation;
using Vitasmart.Application.Patients.Commands.CreatePatient;

namespace Vitasmart.Application.Patients.Commands
{
    public class CreatePatientCommandValidation : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientCommandValidation()
        {
            RuleFor(createPatientCommand => createPatientCommand.Name).NotEmpty().MaximumLength(250);
            RuleFor(createPatientCommand => createPatientCommand.Surname).NotEmpty().MaximumLength(250);
            RuleFor(createPatientCommand => createPatientCommand.Patronymic).NotEmpty().MaximumLength(250);
            RuleFor(createPatientCommand => createPatientCommand.PhoneNumber).InclusiveBetween(10, 30);
        }
    }
}