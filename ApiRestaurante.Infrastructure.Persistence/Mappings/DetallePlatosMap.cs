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
    class DetallePlatosMap : IEntityTypeConfiguration<DetallePlatos>
    {
        public void Configure(EntityTypeBuilder<DetallePlatos> builder)
        {
            builder.ToTable("DetallePlatos")
               .HasKey(p => p.Id);
        }
    }
}
