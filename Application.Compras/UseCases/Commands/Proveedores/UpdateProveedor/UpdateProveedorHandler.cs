using Application.Compras.UseCases.Commands.Proveedores.UpdateProveedor;
using Domain.Compras.Model.Productos;
using Domain.Compras.Repositories;
using MediatR;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Compras.UseCases.Commands.Proveedores.UpdateProveedor
{
    internal class UpdateProveedorHandler : IRequestHandler<UpdateProveedorCommand>
    {
        private readonly IProveedorRepository _proveedorRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProveedorHandler(IProveedorRepository proveedorRepository, IUnitOfWork unitOfWork)
        {
            _proveedorRepository = proveedorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateProveedorCommand request, CancellationToken cancellationToken)
        {
            var proveedor = await _proveedorRepository.FindByIdAsync(request.ProveedorId);

            if (proveedor == null)
            {
                throw new Exception("Proveedor no encontrado");

            }

            proveedor.EditProveedor(request.Nombre, request.Ubicacion);

            await _proveedorRepository.UpdateAsync(proveedor);

            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}
