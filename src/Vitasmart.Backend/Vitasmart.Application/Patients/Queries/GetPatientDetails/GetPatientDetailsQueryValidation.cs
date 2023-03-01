using FluentValidation;
using Vitasmart.Application.Patients.Queries.GetPatientDetails;

namespace Vitasmart.Application.Patients.Queries
{
    public class GetPatientDetailsQueryValidation : AbstractValidator<GetPatientDetailsQuery>
    {
        public GetPatientDetailsQueryValidation()
        {
            RuleFor(patient => patient.Id).NotEqual(Guid.Empty);
        }
    }
}