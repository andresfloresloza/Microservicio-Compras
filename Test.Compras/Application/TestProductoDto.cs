using Application.Compras.Dto;
using Domain.Compras.Model.Proveedores;

namespace Test.Compras.Domain
{
    public class TestProductoDto
    {
        [Fact]
        public void ProductoDtoCreation_Should_Correct()
        {
            var productoId = Guid.NewGuid();
            var nombre = "Sprite 3Ltrs";
            var precio = 15;
            var stock = 50;


            ProductoDto obj = new ProductoDto();

            //Assert.Equal(Guid.Empty, obj.ProductoId);
            //Assert.Equal("", obj.Nombre);
            //Assert.Equal(0, obj.Precio);
            //Assert.Equal(0, obj.Stock);


            obj.ProductoId = productoId;
            obj.Nombre = nombre;
            obj.Precio = precio;
            obj.Stock = stock;


            Assert.Equal(productoId, obj.ProductoId);
            Assert.Equal(nombre, obj.Nombre);
            Assert.Equal(precio, obj.Precio);
            Assert.Equal(stock, obj.Stock);
        }
    }
}