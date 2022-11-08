using Domain.Compras.Model.Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Compras.Factories
{
    public class CompraFactory : ICompraFactory
    {
        public Compra CrearCompra()
        {
            return new Compra();
        }

        public Compra CrearCompra(Guid? proveedorId)
        {
            if (proveedorId == null || proveedorId.Value == Guid.Empty)
            {
                return new Compra();
            }
            return new Compra(proveedorId.Value);
        }
    }
}
