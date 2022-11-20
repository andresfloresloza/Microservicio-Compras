using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Compras.UseCases.Commands.Proveedores.UpdateProveedor
{
    public class UpdateProveedorCommand : IRequest
    {
        public Guid ProveedorId { get; set; }

        public string Nombre { get; set; }
        public string Ubicacion { get; set; }


    }
}
