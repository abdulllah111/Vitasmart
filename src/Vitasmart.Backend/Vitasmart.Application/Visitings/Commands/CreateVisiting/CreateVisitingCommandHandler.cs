using MediatR;
using Vitasmart.Application.Interfaces;
using Vitasmart.Domain;

namespace Vitasmart.Application.Visitings.Commands.CreateVisiting
{
    public class CreateVisitingCommandHandler : IRequestHandler<CreateVisitingCommand, Guid>
    {
        private readonly IVisitingsDbContext _dbContext;
        public CreateVisitingCommandHandler(IVisitingsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(CreateVisitingCommand request, CancellationToken cancellationToken)
        {
            var visiting = new Visiting
            {
                PatientId = request.PatientId,
                Diagnose = request.Diagnose,
                DateUpdated = null
            };

            await _dbContext.Visitings.AddAsync(visiting, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return visiting.Id;
        }
    }
}