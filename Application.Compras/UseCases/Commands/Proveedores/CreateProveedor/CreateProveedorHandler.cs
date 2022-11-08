using Domain.Compras.Model.Proveedores;
using Domain.Compras.Repositories;
using MediatR;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Compras.UseCases.Commands.Proveedores.CreateProveedor
{
    internal class CreateProductoHandler : IRequestHandler<CreateProveedorCommand, Guid>
    {
        private readonly IProveedorRepository _proveedorRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateProductoHandler(IProveedorRepository proveedorRepository, IUnitOfWork unitOfWork)
        {
            _proveedorRepository = proveedorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateProveedorCommand request, CancellationToken cancellationToken)
        {
            Proveedor obj = new Proveedor(request.Nombre, request.Ubicacion);

            await _proveedorRepository.CreateAsync(obj);
 
            await _unitOfWork.Commit();

            return obj.Id;
        }
    }
}
