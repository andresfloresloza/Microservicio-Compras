using Domain.Compras.Model.Proveedores;

namespace Test.Compras.Domain
{
    public class TestProveedor
    {
        [Fact]
        public void ProveedorCreation_Should_Correct()
        {
            var nombre = "Luis Andres Flores Loza";
            var ubicacion = "Av. Cumavi";

            Proveedor obj = new Proveedor(nombre, ubicacion);

            Assert.NotNull(obj.NombreCompleto);
            Assert.NotNull(obj.Ubicacion);
            Assert.Equal(nombre, obj.NombreCompleto);
            Assert.Equal(ubicacion, obj.Ubicacion);
        }
    }
}