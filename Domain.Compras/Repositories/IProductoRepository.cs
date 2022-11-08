using Domain.Compras.Model.Productos;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Compras.Repositories
{
    public interface IProductoRepository : IRepository<Producto, Guid>
    {
        Task UpdateAsync(Producto obj);
    }
}
