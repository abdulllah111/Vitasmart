using FluentValidation;
using Vitasmart.Application.Patients.Queries.GetPatientList;

namespace Vitasmart.Application.Patients.Queries
{
    public class GetPatientListQueryValidation : AbstractValidator<GetPatientListQuery>
    {
        public GetPatientListQueryValidation()
        {

        }
    }
}