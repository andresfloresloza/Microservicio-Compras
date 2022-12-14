// <auto-generated />
using System;
using Infrastructure.Compras.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Compras.EF.Migrations
{
    [DbContext(typeof(ReadDbContext))]
    [Migration("20221108054244_InitialStructure")]
    partial class InitialStructure
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc.2.22472.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.Compras.EF.ReadModel.CompraReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("compraId");

                    b.Property<Guid?>("ProveedorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("proveedorId");

                    b.Property<decimal>("Total")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)")
                        .HasColumnName("total");

                    b.HasKey("Id");

                    b.HasIndex("ProveedorId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("Infrastructure.Compras.EF.ReadModel.DetalleCompraReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("detalleCompraId");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("cantidad");

                    b.Property<Guid>("CompraId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("compraId");

                    b.Property<decimal>("Precio")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)")
                        .HasColumnName("precio");

                    b.Property<Guid>("ProductoId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("productoId");

                    b.Property<decimal>("Subtotal")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)")
                        .HasColumnName("subtotal");

                    b.HasKey("Id");

                    b.HasIndex("CompraId");

                    b.HasIndex("ProductoId");

                    b.ToTable("DetalleCompra", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Compras.EF.ReadModel.ProductoReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("productoId");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("nombreProducto");

                    b.Property<decimal>("Precio")
                        .HasMaxLength(250)
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)")
                        .HasColumnName("precio");

                    b.Property<int>("Stock")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(250)
                        .HasPrecision(12)
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("stock");

                    b.HasKey("Id");

                    b.ToTable("Producto", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Compras.EF.ReadModel.ProveedorReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("proveedorId");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("nombreCompleto");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("ubicacion");

                    b.HasKey("Id");

                    b.ToTable("Proveedor", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Compras.EF.ReadModel.CompraReadModel", b =>
                {
                    b.HasOne("Infrastructure.Compras.EF.ReadModel.ProveedorReadModel", "Proveedor")
                        .WithMany()
                        .HasForeignKey("ProveedorId");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("Infrastructure.Compras.EF.ReadModel.DetalleCompraReadModel", b =>
                {
                    b.HasOne("Infrastructure.Compras.EF.ReadModel.CompraReadModel", "Compra")
                        .WithMany("Detalle")
                        .HasForeignKey("CompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Compras.EF.ReadModel.ProductoReadModel", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compra");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Infrastructure.Compras.EF.ReadModel.CompraReadModel", b =>
                {
                    b.Navigation("Detalle");
                });
#pragma warning restore 612, 618
        }
    }
}
