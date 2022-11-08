using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Compras.EF.ReadModel
{
    internal class DetalleCompraReadModel
    {
        public Guid Id { get; set; }

        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal { get; set; }

        public CompraReadModel Compra { get; set; }
        public Guid CompraId { get; set; }

        public ProductoReadModel Producto { get; set; }
        public Guid ProductoId { get; set; }

    }
}
