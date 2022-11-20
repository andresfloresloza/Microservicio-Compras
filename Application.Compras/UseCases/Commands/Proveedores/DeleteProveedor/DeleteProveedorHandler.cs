using Domain.Compras;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Compras.Repositories;
using ShareKernel.Core;
using Domain.Compras.Model.Productos;
using System.Collections;

namespace Application.UseCases.DeleteProveedor
{
    public class DeleteProveedorHandler : IRequestHandler<DeleteProveedorCommand>
    {
        private readonly IProveedorRepository _proveedorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProveedorHandler(IProveedorRepository proveedorRepository, IUnitOfWork unitOfWork)
        {
            _proveedorRepository = proveedorRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteProveedorCommand request, CancellationToken cancellationToken)
        {
            var obj = await _proveedorRepository.FindByIdAsync(request.ProveedorId);
            if (obj == null)
            {
                throw new Exception("Proveedor no encontrado");
            }
            await _proveedorRepository.RemoveAsync(obj);
            await _unitOfWork.Commit();
            return Unit.Value;
        }
    }
}
