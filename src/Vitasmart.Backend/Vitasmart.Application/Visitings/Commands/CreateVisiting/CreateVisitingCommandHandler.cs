using MediatR;
using Vitasmart.Application.Interfaces;
using Vitasmart.Domain;

namespace Vitasmart.Application.Visitings.Commands.CreateVisiting
{
    public class CreateVisitingCommandHandler : IRequestHandler<CreateVisitingCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;
        public CreateVisitingCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(CreateVisitingCommand request, CancellationToken cancellationToken)
        {
            var visiting = new Visiting
            {
                Id = Guid.NewGuid(),
                Date = request.Date,
                Diagnose = request.Diagnose,
                PatientId = request.PatientId,
                DateAdded = DateTime.Now,
                DateUpdated = null
            };

            await _dbContext.Visitings.AddAsync(visiting, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return visiting.Id;
        }
    }
}