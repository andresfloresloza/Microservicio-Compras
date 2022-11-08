using Application.Compras.UseCases.Commands.Proveedores.CreateProveedor;
using Application.Compras.UseCases.Queries.Proveedor;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Ventas.Controllers
{
    [Route("api/proveedor")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProveedorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("search")]
        [HttpGet]
        public async Task<IActionResult> SearchProveedor([FromQuery] string? nombre = "")
        {
            var query = new GetListaProveedoresQuery
            {
                NombreSearchTerm = nombre
            };
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> CreateProveedor([FromBody] CreateProveedorCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);


        }

    }
}
