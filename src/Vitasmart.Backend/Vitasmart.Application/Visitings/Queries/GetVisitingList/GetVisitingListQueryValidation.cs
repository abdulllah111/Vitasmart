using FluentValidation;
using Vitasmart.Application.Visitings.Queries.GetVisitingList;

namespace Vitasmart.Application.Visitings.Queries
{
    public class GetVisitingListQueryValidation : AbstractValidator<GetVisitingListQuery>
    {
        public GetVisitingListQueryValidation()
        {
            RuleFor(visiting => visiting.PatientId).NotEqual(Guid.Empty);
        }
    }
}