using Application.Compras.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Compras.UseCases.Commands.Compras.RegistrarCompra
{
    public record RegistrarCompraCommand : IRequest<Guid>
    {
        public Guid? ProveedorId { get; set; }
        public ICollection<DetalleCompraDto> Detalle { get; set; }
        public RegistrarCompraCommand(Guid proveedorId, ICollection<DetalleCompraDto> detalle)
        {
            ProveedorId = proveedorId;
            Detalle = detalle;
        }

        public RegistrarCompraCommand()
        {
            Detalle = new List<DetalleCompraDto>();
        }

    }
}
