using Microsoft.EntityFrameworkCore;
using Vitasmart.Domain;

namespace Vitasmart.Application.Interfaces
{
    public interface IVisitingsDbContext
    {
        DbSet<Visiting> Visitings { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
