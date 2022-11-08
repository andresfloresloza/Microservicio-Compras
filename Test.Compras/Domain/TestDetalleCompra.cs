using Domain.Compras.Model.Compras;

namespace Test.Compras.Domain
{
    public class TestDetalleCompra
    {
        [Fact]
        public void DetalleCompraCreation_Should_Correct()
        {
            var productoId = Guid.NewGuid();
            var cantidad = 25;
            var precio = 15;
            var subTotal = cantidad * precio;


            DetalleCompra obj = new DetalleCompra(productoId, cantidad, precio);

            Assert.NotNull(obj.Cantidad);
            Assert.NotNull(obj.PrecioCompra);
            Assert.NotNull(obj.SubTotal);

            Assert.Equal(productoId, obj.ProductoId);
            Assert.Equal(cantidad, obj.Cantidad.Value);
            Assert.Equal(precio, obj.PrecioCompra);
        }
    }
}