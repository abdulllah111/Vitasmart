using FluentValidation;
using Vitasmart.Application.Visitings.Queries.GetVisitingDetails;

namespace Vitasmart.Application.Visitings.Queries
{
    public class GetVisitingDetailsQueryValidation : AbstractValidator<GetVisitingDetailsQuery>
    {
        public GetVisitingDetailsQueryValidation()
        {
            RuleFor(visiting => visiting.Id).NotEqual(Guid.Empty);
        }
    }
}