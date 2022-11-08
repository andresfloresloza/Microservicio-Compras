using Application.Compras.Dto;
using MediatR;

namespace Application.Compras.UseCases.Queries.Producto
{
    public class GetListaProductosQuery : IRequest<IEnumerable<ProductoDto>>
    {
        public string NombreSearchTerm { get; set; }
    }
}
