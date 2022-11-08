using Domain.Compras.Model.Compras;
using Domain.Compras.Model.Productos;
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
    internal class CompraRepository : ICompraRepository
    {
        private readonly WriteDbContext _context;

        public CompraRepository(WriteDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Compra obj)
        {
            await _context.Compras.AddAsync(obj);
        }
        public Task UpdateAsync(Compra obj)
        {
            _context.Compras.Update(obj);
            return Task.CompletedTask;
        }

        public async Task<Compra?> FindByIdAsync(Guid id)
        {
            return await _context.Compras
                .Include("_detalle")
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
