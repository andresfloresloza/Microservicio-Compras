using Infrastructure.Compras.EF.Config.ReadConfig;
using Infrastructure.Compras.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Compras.EF.Context
{
    internal class ReadDbContext : DbContext
    {
        public virtual DbSet<CompraReadModel> Compras{ get; set; }
        public virtual DbSet<ProveedorReadModel> Proveedores { get; set; }
        public virtual DbSet<ProductoReadModel> Productos { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<ProductoReadModel>(new ProductoReadConfig());
            modelBuilder.ApplyConfiguration<ProveedorReadModel>(new ProveedorReadConfig());
            modelBuilder.ApplyConfiguration<CompraReadModel>(new CompraReadConfig());
            modelBuilder.ApplyConfiguration<DetalleCompraReadModel>(new DetalleCompraReadConfig());


        }
    }
}