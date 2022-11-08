using Domain.Compras.Model.Compras;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Compras.Repositories
{
    public interface ICompraRepository : IRepository<Compra, Guid>
    {
    }
}
