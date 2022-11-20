using ShareKernel.Core;
using ShareKernel.Rules;
using ShareKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Compras.Model.Proveedores
{
    public class Proveedor : AggregateRoot
    {
        public PersonNameValue NombreCompleto { get; private set; }
        public UbicacionValue Ubicacion { get; private set; }

        public Proveedor(string nombreCompleto, string ubicacion)
        {
            Id = Guid.NewGuid();
            NombreCompleto = nombreCompleto;
            Ubicacion = ubicacion;

        }

        public void EditProveedor(string nombreProveedor, string ubicacionProveedor)
        {
            NombreCompleto = nombreProveedor;
            Ubicacion = ubicacionProveedor;
        }

        //Only for Entity Framework
        private Proveedor() { }
    }
}
