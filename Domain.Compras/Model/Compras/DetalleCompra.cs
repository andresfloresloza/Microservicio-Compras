using ShareKernel.ValueObjects;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Compras.Model.Compras
{
    public class DetalleCompra : Entity
    {
        public Guid ProductoId { get; private set; }
        public CantidadValue Cantidad { get; private set; }
        public PrecioValue PrecioCompra { get; private set; }
        public PrecioValue SubTotal { get; set; }

        public DetalleCompra(Guid productoId, int cantidad, decimal precioCompra)
        {
            if (productoId == Guid.Empty)
            {
                throw new ArgumentException("El producto no puede ser vacio");
            }
            Id = Guid.NewGuid();
            ProductoId = productoId;
            Cantidad = cantidad;
            PrecioCompra = precioCompra;
            SubTotal = cantidad * precioCompra;

        }
        private DetalleCompra() { }
    }
}
