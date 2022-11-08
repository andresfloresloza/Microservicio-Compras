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
    internal class DetalleCompraReadConfig : IEntityTypeConfiguration<DetalleCompraReadModel>
    {
        public void Configure(EntityTypeBuilder<DetalleCompraReadModel> builder)
        {
            builder.ToTable("DetalleCompra");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("detalleCompraId");
            
            builder.Property(x => x.Cantidad)
                .HasColumnName("cantidad");
            
            builder.Property(x => x.Precio)
                .HasPrecision(14,2)
                .HasColumnName("precio");
            
            builder.Property(x => x.Subtotal)
                .HasPrecision(14, 2)
                .HasColumnName("subtotal");
            
            builder.Property(x => x.CompraId)
                .HasColumnName("compraId");

            builder.Property(x => x.ProductoId)
                .HasColumnName("productoId");            
            
            builder.HasOne(x => x.Producto)
                .WithMany()
                .HasForeignKey(x => x.ProductoId);
        }
    }
}
