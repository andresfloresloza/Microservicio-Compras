using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Compras.EF.ReadModel
{
    internal class CompraReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public decimal Total { get; set; }

        public ProveedorReadModel? Proveedor { get; set; }
        public Guid? ProveedorId { get; set; }

        public ICollection<DetalleCompraReadModel> Detalle { get; set; }
    }
}
