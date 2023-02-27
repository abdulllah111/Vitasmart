using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vitasmart.Domain;

namespace Vitasmart.Persistence.Npgsql.EntityTypeConfigurations
{
    internal class VisitingConfiguration : IEntityTypeConfiguration<Visiting>
    {
        public void Configure(EntityTypeBuilder<Visiting> builder)
        {
            builder.HasKey(visiting => visiting.Id);
            builder.HasIndex(visiting => visiting.Id).IsUnique();
        }
    }
}
