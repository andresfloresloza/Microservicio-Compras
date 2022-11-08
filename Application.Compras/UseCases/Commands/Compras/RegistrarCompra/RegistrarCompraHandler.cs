using Domain.Compras.Factories;
using Domain.Compras.Model.Compras;
using Domain.Compras.Repositories;
using MediatR;
using ShareKernel.Core;
using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Compras.UseCases.Commands.Compras.RegistrarCompra
{
    internal class RegistrarCompraHandler : IRequestHandler<RegistrarCompraCommand, Guid>
    {
        private readonly ICompraRepository _compraRepository;
        private readonly ICompraFactory _compraFactory;
        private readonly IUnitOfWork _unitOfWork;
        public RegistrarCompraHandler(ICompraRepository compraRepository, ICompraFactory compraFactory, IUnitOfWork unitOfWork)
        {
            _compraRepository = compraRepository;
            _compraFactory = compraFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(RegistrarCompraCommand request,
            CancellationToken cancellationToken)
        {

            var compra = _compraFactory.CrearCompra(request.ProveedorId);
            foreach (var item in request.Detalle)
            {
                compra.AgregarDetalleCompra(item.ProductoId, item.Cantidad, item.Precio);
            }
            await _compraRepository.CreateAsync(compra);
            await _unitOfWork.Commit();
            return compra.Id;

        }
    }
}
