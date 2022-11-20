using Domain.Compras.Model.Proveedores;
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

namespace Infrastructure.Compras.EF.Config.WriteConfig
{
    internal class ProveedorWriteConfig : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("Proveedor");
            
            builder.Property(x => x.Id).HasColumnName("proveedorId");


            var nombreConverter = new ValueConverter<PersonNameValue, string>(
                personNameValue => personNameValue.Name,
                stringValue => new PersonNameValue(stringValue)
            ); 
            var ubicacionConverter = new ValueConverter<UbicacionValue, string>(
                ubicacionValue => ubicacionValue.Name,
                stringValue => new UbicacionValue(stringValue)
            );

            builder.Property(x => x.NombreCompleto)
                .HasConversion(nombreConverter)
                .HasColumnName("nombreCompleto");

            builder.Property(x => x.Ubicacion)
                .HasConversion(ubicacionConverter)
                .HasColumnName("ubicacion");

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}
