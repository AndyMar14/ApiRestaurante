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
    public class MesasMap : IEntityTypeConfiguration<Mesas>
    {
        public void Configure(EntityTypeBuilder<Mesas> builder)
        {
            builder.ToTable("Mesas")
               .HasKey(i => i.Id);
        }
    }
}
