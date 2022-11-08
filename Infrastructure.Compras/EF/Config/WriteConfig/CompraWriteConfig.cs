using Domain.Compras.Model.Compras;
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
    internal class CompraWriteConfig : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {
            builder.ToTable("Compras");
            builder.Property(x => x.Id).HasColumnName("compraId");

            builder.Property(x => x.Total)
                .HasColumnName("total");

            builder.Property(x => x.ProveedorId)
                .HasColumnName("proveedorId");


            //builder.HasMany("_detalle");

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}
