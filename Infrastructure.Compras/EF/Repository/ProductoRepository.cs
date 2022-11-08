using Domain.Compras.Model.Productos;
using Domain.Compras.Model.Proveedores;
using Domain.Compras.Repositories;
using Infrastructure.Compras.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Compras.EF.Repository
{
    internal class ProductoRepository : IProductoRepository
    {
        private readonly WriteDbContext _dbContext;

        public ProductoRepository(WriteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Producto obj)
        {
            await _dbContext.Productos.AddAsync(obj);
        }

        public async Task<Producto?> FindByIdAsync(Guid id)
        {
            return await _dbContext.Productos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(Producto obj)
        {
            _dbContext.Productos.Update(obj);
            return Task.CompletedTask;
        }

        public Task RemoveAsync(Producto obj)
        {
            _dbContext.Productos.Remove(obj);
            return Task.CompletedTask;

        }
    }
}
