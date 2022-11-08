using Domain.Compras.Model.Proveedores;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Compras.Repositories
{
    public interface IProveedorRepository : IRepository<Proveedor, Guid>
    {
        Task UpdateAsync(Proveedor obj);
    }
}
