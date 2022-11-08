using Domain.Compras.Model.Compras;
using Infrastructure.Compras.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShareKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Compras.EF.Config.ReadConfig
{
    internal class DetalleCompraWriteConfig : IEntityTypeConfiguration<DetalleCompra>
    {
        public void Configure(EntityTypeBuilder<DetalleCompra> builder)
        {
            builder.ToTable("DetalleCompra");
            builder.Property(x => x.Id)
                .HasColumnName("detalleCompraId");

            var cantidadConverter = new ValueConverter<CantidadValue, int>(
                cantidadValue => cantidadValue.Value,
                intValue => new CantidadValue(intValue)
            );

            builder.Property(x => x.Cantidad)
                .HasConversion(cantidadConverter)
                .HasColumnName("cantidad");

            var precioConverter = new ValueConverter<PrecioValue, decimal>(
                precioValue => precioValue.Value ,
                decimalValue => new PrecioValue(decimalValue)
            );

            builder.Property(x => x.PrecioCompra)
                .HasConversion(precioConverter)
                .HasColumnName("precio");
            
            builder.Property(x => x.SubTotal)
                .HasConversion(precioConverter)
                .HasColumnName("subtotal");
            

            builder.Property(x => x.ProductoId)
                .HasColumnName("productoId");


            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}
