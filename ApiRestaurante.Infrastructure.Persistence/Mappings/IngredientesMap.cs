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
    public class IngredientesMap : IEntityTypeConfiguration<Ingredientes>
    {
        public void Configure(EntityTypeBuilder<Ingredientes> builder)
        {
            builder.ToTable("ingredientes")
               .HasKey(i => i.Id);
        }
    }
}
