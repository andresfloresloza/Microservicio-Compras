using Domain.Compras.Events;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Compras.Model.Compras
{

    public class Compra : AggregateRoot
    {
        private readonly ICollection<DetalleCompra> _detalle;
        public decimal Total { get; private set; }

        public Guid? ProveedorId { get; set; }
        public IEnumerable<DetalleCompra> DetalleCompra
        {
            get { return _detalle; }
        }

        internal Compra()
        {
            Id = Guid.NewGuid();
            _detalle = new List<DetalleCompra>();
        }

        internal Compra(Guid proveedorId)
        {
            Id = Guid.NewGuid();
            _detalle = new List<DetalleCompra>();
            ProveedorId = proveedorId;
        }

        public void AgregarDetalleCompra(Guid productoId, int cantidad, decimal precio)
        {
            var detalle = new DetalleCompra(productoId, cantidad, precio);
            _detalle.Add(detalle);
            Total += detalle.SubTotal;

            var evento = new DetalleCompraAgregado(productoId, cantidad, precio);
            AddDomainEvent(evento);
        }

    }
}
