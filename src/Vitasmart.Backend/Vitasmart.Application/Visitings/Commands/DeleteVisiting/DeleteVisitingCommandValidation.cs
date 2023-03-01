using FluentValidation;
using Vitasmart.Application.Visitings.Commands.DeleteVisiting;

namespace Vitasmart.Application.Patients.Commands
{
    public class DeleteVisitingCommandValidation : AbstractValidator<DeleteVisitingCommand>
    {
        public DeleteVisitingCommandValidation()
        {
            RuleFor(deleteVisitingCommand => deleteVisitingCommand.Id).NotEqual(Guid.Empty);
        }
    }
}