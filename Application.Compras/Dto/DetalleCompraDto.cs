using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Compras.Dto
{
    public class DetalleCompraDto
    {
        public Guid ProductoId { set; get; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
