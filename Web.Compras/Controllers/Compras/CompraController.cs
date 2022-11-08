using Application.Compras.UseCases.Commands.Compras.RegistrarCompra;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Compras.Controllers.Compras
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ILogger<CompraController> _logger;
        private readonly IMediator _mediator;

        public CompraController(IMediator mediator, ILogger<CompraController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompra([FromBody] RegistrarCompraCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar la compra");
                throw ex;
            }

        }
    }
}
