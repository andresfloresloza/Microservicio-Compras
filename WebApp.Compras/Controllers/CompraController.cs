﻿using MediatR;
using Application.Compras.UseCases.Commands.Compras.RegistrarCompra;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Compras.Controllers
{
    [Route("api/compra")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompraController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompra([FromBody] RegistrarCompraCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
