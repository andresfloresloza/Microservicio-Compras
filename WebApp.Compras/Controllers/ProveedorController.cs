using Application.Compras.UseCases.Commands.Productos.CreateProducto;
using Application.Compras.UseCases.Commands.Proveedores.CreateProveedor;
using Application.Compras.UseCases.Commands.Proveedores.UpdateProveedor;
using Application.Compras.UseCases.Queries.Proveedor;
using Application.UseCases.DeleteProducto;
using Application.UseCases.DeleteProveedor;
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

        [HttpPut]
        public async Task<IActionResult> UpdateProveedor([FromBody] UpdateProveedorCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> EliminarProveedor([FromBody] DeleteProveedorCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
