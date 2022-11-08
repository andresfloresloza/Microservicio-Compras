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
    internal class ProveedorRepository : IProveedorRepository
    {
        private readonly WriteDbContext _context;

        public ProveedorRepository(WriteDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Proveedor obj)
        {
            await _context.Proveedores.AddAsync(obj);
        }

        public async Task<Proveedor?> FindByIdAsync(Guid id)
        {
            return await _context.Proveedores.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task RemoveAsync(Proveedor obj)
        {
            _context.Proveedores.Remove(obj); 
            return Task.CompletedTask;

        }

        public Task UpdateAsync(Proveedor obj)
        {
            _context.Proveedores.Update(obj);
            return Task.CompletedTask;
        }
    }
}
