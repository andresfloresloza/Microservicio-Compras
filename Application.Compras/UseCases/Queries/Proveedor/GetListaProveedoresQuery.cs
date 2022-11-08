using Application.Compras.Dto;
using MediatR;

namespace Application.Compras.UseCases.Queries.Proveedor
{
    public class GetListaProveedoresQuery : IRequest<IEnumerable<ProveedorDto>>
    {
        public string NombreSearchTerm { get; set; }
    }
}
