using Domain.Compras.Model.Proveedores;
using Domain.Compras.Model.Productos;
using Domain.Compras.Model.Compras;
using Infrastructure.Compras.EF.Config.ReadConfig;
using Infrastructure.Compras.EF.Config.WriteConfig;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Compras.EF.Context
{
    internal class WriteDbContext : DbContext
    {
        public virtual DbSet<Proveedor> Proveedores { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new ProveedorWriteConfig());
            modelBuilder.ApplyConfiguration(new CompraWriteConfig());
            modelBuilder.ApplyConfiguration(new DetalleCompraWriteConfig());
            modelBuilder.ApplyConfiguration(new ProductoWriteConfig());
        }
    }
}
