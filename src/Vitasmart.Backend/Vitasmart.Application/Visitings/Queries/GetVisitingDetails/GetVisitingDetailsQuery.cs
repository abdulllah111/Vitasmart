using MediatR;

namespace Vitasmart.Application.Visitings.Queries.GetVisitingDetails
{
    public class GetVisitingDetailsQuery : IRequest<VisitingDetailsVm>
    {
        public Guid Id { get; set; }
    }
}