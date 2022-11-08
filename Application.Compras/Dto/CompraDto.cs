using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Compras.Dto
{
    public class CompraDto
    {
        public Guid Id { get; set; }
        public string NroPedido { get; set; }
        public decimal Total { get; set; }
        public ICollection<DetalleCompraDto> Detalle { get; set; }

        public CompraDto()
        {
            Detalle = new List<DetalleCompraDto>();
        }
    }
}
