﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoVenta.BL
{
    public class ProductosBL
    {
        Contexto _contexto;
        public List<Producto> ListadeProductos { get; set; }

        public ProductosBL()
        {
            _contexto = new Contexto();
            ListadeProductos = new List<Producto>();
        }

        public List<Producto> ObtenerProductos()
        {
            ListadeProductos = _contexto.Producto.ToList();

            return ListadeProductos;
        }
        public void GuardarProducto(Producto Producto)
        {
            _contexto.Producto.Add(Producto);
            _contexto.SaveChanges();
        }
    
    }
}
