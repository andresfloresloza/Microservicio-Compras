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
    internal class CompraReadConfig : IEntityTypeConfiguration<CompraReadModel>
    {
        public void Configure(EntityTypeBuilder<CompraReadModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("compraId");


            builder.Property(x => x.Total)
                .HasColumnName("total")
                .HasPrecision(14,2)
                .IsRequired();

            builder.Property(x => x.ProveedorId)
                .HasColumnName("proveedorId");

            builder.HasOne(x => x.Proveedor)
                .WithMany()
                .HasForeignKey(x => x.ProveedorId);

            builder.HasMany(x => x.Detalle)
                .WithOne(x => x.Compra)
                .HasForeignKey(x => x.CompraId);
        }
    }
}
