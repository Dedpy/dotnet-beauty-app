using ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class RDVConfiguration : IEntityTypeConfiguration<RDV>
    {
        public void Configure(EntityTypeBuilder<RDV> builder)

        {
            builder.HasOne(c => c.Client)
                       .WithMany(l => l.RDVs)
                       .HasForeignKey(c => c.ClientFK)
                       .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(c => c.Prestation)
                       .WithMany(l => l.RDVs)
                       .HasForeignKey(c => c.PrestationFK)
                       .OnDelete(DeleteBehavior.Cascade);

            builder.HasKey(e => new {e.ClientFK, e.PrestationFK,e.DateRDV });

        }
    }
}
