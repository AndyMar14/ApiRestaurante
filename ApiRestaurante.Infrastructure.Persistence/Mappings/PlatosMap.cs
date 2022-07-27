using ApiRestaurante.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Infrastructure.Persistence.Mappings
{
    class PlatosMap : IEntityTypeConfiguration<Platos>
    {
        public void Configure(EntityTypeBuilder<Platos> builder)
        {
            builder.ToTable("platos")
               .HasKey(p => p.Id);
        }
    }
}
