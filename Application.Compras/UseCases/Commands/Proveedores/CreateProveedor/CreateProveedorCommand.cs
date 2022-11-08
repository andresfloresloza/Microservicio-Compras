using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Compras.UseCases.Commands.Proveedores.CreateProveedor
{
    public class CreateProveedorCommand : IRequest<Guid>
    {
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }

    }
}
