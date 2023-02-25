using Microsoft.EntityFrameworkCore;
using Vitasmart.Application.Interfaces;
using Vitasmart.Domain;
using Vitasmart.EntityFramework.EntityTypeConfigurations;

namespace Vitasmart.EntityFramework
{
    public class VisitingsDbContext : DbContext, IVisitingsDbContext
    {
        public DbSet<Visiting> Visitings { get; set; }
        public VisitingsDbContext(DbContextOptions<VisitingsDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new VisitingConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
