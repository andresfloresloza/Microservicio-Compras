using Domain.Compras.Model.Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Compras.Factories
{
    public interface ICompraFactory
    {
        Compra CrearCompra(Guid? proveedorId);

        Compra CrearCompra();
    }
}
