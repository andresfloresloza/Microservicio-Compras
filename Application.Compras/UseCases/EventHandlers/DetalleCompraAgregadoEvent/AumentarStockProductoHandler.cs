using Domain.Compras.Events;
using Domain.Compras.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Compras.UseCases.EventHandlers.DetalleCompraAgregadoEvent
{
    internal class AumentarStockProductoHandler : INotificationHandler<DetalleCompraAgregado>
    {
        private readonly IProductoRepository _productoRepository;

        public AumentarStockProductoHandler(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task Handle(DetalleCompraAgregado notification, CancellationToken cancellationToken)
        {
            var producto = await _productoRepository.FindByIdAsync(notification.ProductoId);

            producto.AumentarStock(notification.Cantidad);

            await _productoRepository.UpdateAsync(producto);
        }
    }
}
