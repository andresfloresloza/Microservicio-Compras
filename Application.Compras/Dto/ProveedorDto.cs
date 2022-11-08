using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Compras.Dto
{
    public class ProveedorDto 
    {
        public Guid ProveedorId { get; set; }

        public string Nombre { get; set; }

        public string Ubicacion { get; set; }

    }
}
