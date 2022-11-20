using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.DeleteProveedor
{
    public class DeleteProveedorCommand : IRequest
    {
        public Guid ProveedorId { get; set; }
        }
}
