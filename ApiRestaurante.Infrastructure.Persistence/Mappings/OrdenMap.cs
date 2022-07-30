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
    class OrdenMap : IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> builder)
        {
            builder.ToTable("orden")
               .HasKey(p => p.Id);

            #region "Relationships"
            builder.ToTable("orden")
                .HasMany<DetalleOrden>(detalle => detalle.Platos)
                .WithOne(product => product.Orden)
                .HasForeignKey(product => product.IdOrden)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }
    }
}
