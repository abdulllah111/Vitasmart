using MediatR;

namespace Vitasmart.Application.Visitings.Queries.GetVisitingList
{
    public class GetVisitingListQuery : IRequest<VisitingListVm>
    {
        public Guid PatientId { get; set; }
    }
}