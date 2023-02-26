using MediatR;
using Vitasmart.Domain;

namespace Vitasmart.Application.Patients.Queries.GetPatientDetails
{
    public class GetPatientDetailsQuery : IRequest<PatientDetailsVm>
    {
        public Guid Id { get; set; }
    }
}