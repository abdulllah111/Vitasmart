using MediatR;
using Vitasmart.Domain;

namespace Vitasmart.Application.Visitings.Queries.GetVisitingDetails
{
    public class GetVisitingDetailsQuery : IRequest<VisitingDetailsVm>
    {
        public Guid Id { get; set; }
    }
}