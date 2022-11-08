﻿using Application.Compras.UseCases.Commands.Productos.CreateProducto;
using Application.Compras.UseCases.Queries.Producto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Compras.Controllers
{
    [Route("api/producto")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("search")]
        [HttpGet]
        public async Task<IActionResult> SearchProducto([FromQuery] string? nombre = "")
        {
            var query = new GetListaProductosQuery
            {
                NombreSearchTerm = nombre
            };
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> CreateProducto([FromBody] CreateProductoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);


        }

    }
}
