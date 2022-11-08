﻿using ShareKernel.ValueObjects;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Compras.Model.Productos
{
    public class Producto : AggregateRoot
    {
        public PersonNameValue NombreProducto { get; private set; }
        public PrecioValue Precio { get; private set; }
        public CantidadValue Stock { get; private set; }

        public Producto(string nombreProducto, decimal precio, int stock)
        {
            Id = Guid.NewGuid();
            NombreProducto = nombreProducto;
            Precio = precio;
            Stock = stock;
        }

        public void AumentarStock(int cantidad)
        {
            if (Stock - cantidad < 0)
            {
                throw new BussinessRuleValidationException("No hay stock suficiente");
            }
            Stock -= cantidad;
        }
        private Producto() { }
    }
}