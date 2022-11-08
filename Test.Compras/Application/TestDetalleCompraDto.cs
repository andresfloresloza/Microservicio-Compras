using Application.Compras.Dto;
using Domain.Compras.Model.Compras;

namespace Test.Compras.Domain
{
    public class TestDetalleCompraDto
    {
        [Fact]
        public void DetalleCompraDtoCreation_Should_Correct()
        {
            var productoId = Guid.NewGuid();
            var cantidad = 25;
            var precio = 15;


            DetalleCompraDto obj = new DetalleCompraDto();


            Assert.Equal(Guid.Empty, obj.ProductoId);
            Assert.Equal(0,obj.Cantidad);
            Assert.Equal(0,obj.Precio);


            obj.ProductoId = productoId;
            obj.Cantidad = cantidad;
            obj.Precio = precio;


            Assert.Equal(productoId, obj.ProductoId);
            Assert.Equal(cantidad, obj.Cantidad);
            Assert.Equal(precio, obj.Precio);
        }
    }
}