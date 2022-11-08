﻿using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Compras.Dto
{
    public class ProductoDto
    {
        public Guid ProductoId { get; set; }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }
        public int Stock { get; set; }


    }
}
