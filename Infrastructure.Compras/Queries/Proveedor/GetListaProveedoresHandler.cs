using Application.Compras.Dto;
using Application.Compras.UseCases.Queries.Proveedor;
using Infrastructure.Compras.EF.Context;
using Infrastructure.Compras.EF.ReadModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Compras.Queries.Proveedor
{
    internal class GetListaProveedoresHandler : IRequestHandler<GetListaProveedoresQuery, IEnumerable<ProveedorDto>>
    {
        private readonly DbSet<ProveedorReadModel> proveedores;

        public GetListaProveedoresHandler(ReadDbContext dbContext)
        {
            proveedores = dbContext.Proveedores;
        }


        public async Task<IEnumerable<ProveedorDto>> Handle(GetListaProveedoresQuery request, CancellationToken cancellationToken)
        {
            var query = proveedores.AsNoTracking().AsQueryable();

            if (!string.IsNullOrEmpty(request.NombreSearchTerm))
            {
                query = query.Where(x => x.NombreCompleto.ToLower().Contains(request.NombreSearchTerm.ToLower()));
            }

            var lista = await query.Select(x => new ProveedorDto
            {
                ProveedorId = x.Id,
                Nombre = x.NombreCompleto,
                Ubicacion = x.Ubicacion
            }).ToListAsync();

            return lista;
        }
    }
}
