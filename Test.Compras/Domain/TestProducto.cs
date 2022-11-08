using Domain.Compras.Model.Productos;

namespace Test.Compras.Domain
{
    public class TestProducto
    {
        [Fact]
        public void ProductoCreation_Should_Correct()
        {
            var nombre = "Sprite 3Ltrs";
            var precio = 15;
            var stock = 50;


            Producto obj = new Producto(nombre, precio, stock);

            Assert.NotNull(obj.NombreProducto);
            Assert.NotNull(obj.Precio);
            Assert.NotNull(obj.Stock);

            Assert.Equal(nombre, obj.NombreProducto);
            Assert.Equal(precio, obj.Precio, 1);
            Assert.Equal(stock, obj.Stock.Value);
        }
    }
}