using Infrastructure.Compras.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Compras.EF.Config.ReadConfig
{
    internal class ProveedorReadConfig : IEntityTypeConfiguration<ProveedorReadModel>
    {
        public void Configure(EntityTypeBuilder<ProveedorReadModel> builder)
        {
            builder.ToTable("Proveedor");
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id).HasColumnName("proveedorId");

            builder.Property(x => x.NombreCompleto)
                .HasColumnName("nombreCompleto")
                .HasMaxLength(250);

            builder.Property(x => x.Ubicacion)
                .HasColumnName("ubicacion")
                .HasMaxLength(250);
        }
    }
}
