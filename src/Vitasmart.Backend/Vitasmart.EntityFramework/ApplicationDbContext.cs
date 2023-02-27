using Microsoft.EntityFrameworkCore;
using Vitasmart.Application.Interfaces;
using Vitasmart.Domain;
using Vitasmart.Persistence.Npgsql.EntityTypeConfigurations;

namespace Vitasmart.Persistence.Npgsql
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visiting> Visitings { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PatientConfiguration());
            builder.ApplyConfiguration(new VisitingConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
