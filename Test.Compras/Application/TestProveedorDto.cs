using Application.Compras.Dto;

namespace Test.Compras.Application
{
    public class TestProveedorDto
    {
        [Fact]
        public void ProveedorDtoCreation_Should_Correct()
        {
            var proveedorId = Guid.NewGuid();
            var nombre = "Luis Andres Flores Loza";
            var ubicacion = "Av. Cumavi";


            ProveedorDto obj = new ProveedorDto();


            //Assert.Equal(Guid.Empty, obj.ProveedorId);
            //Assert.Equal("", obj.Nombre);
            //Assert.Equal("", obj.Ubicacion);


            obj.ProveedorId = proveedorId;
            obj.Nombre = nombre;
            obj.Ubicacion = ubicacion;


            Assert.Equal(proveedorId, obj.ProveedorId);
            Assert.Equal(nombre, obj.Nombre);
            Assert.Equal(ubicacion, obj.Ubicacion);
        }
    }
}