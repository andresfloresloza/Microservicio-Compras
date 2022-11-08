﻿using Application.Compras.Dto;
using Application.Compras.UseCases.Queries.Producto;
using Infrastructure.Compras.EF.Context;
using Infrastructure.Compras.EF.ReadModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Compras.Queries.Producto
{
    internal class GetListaProductosHandler : IRequestHandler<GetListaProductosQuery, IEnumerable<ProductoDto>>
    {
        private readonly DbSet<ProductoReadModel> productos;

        public GetListaProductosHandler(ReadDbContext dbContext)
        {
            productos = dbContext.Productos;
        }


        public async Task<IEnumerable<ProductoDto>> Handle(GetListaProductosQuery request, CancellationToken cancellationToken)
        {
            var query = productos.AsNoTracking().AsQueryable();

            if (!string.IsNullOrEmpty(request.NombreSearchTerm))
            {
                query = query.Where(x => x.NombreProducto.ToLower().Contains(request.NombreSearchTerm.ToLower()));
            }

            var lista = await query.Select(x => new ProductoDto
            {
                ProductoId = x.Id,
                Nombre = x.NombreProducto,
                Precio = x.Precio,
                Stock = x.Stock
            }).ToListAsync();

            return lista;
        }
    }
}
