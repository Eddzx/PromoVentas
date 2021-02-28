using System;
using System.Collections.Generic;
using System.Linq;

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
            ListadeProductos = _contexto.Producto
                  .Include("Categoria")
                  .ToList();

            return ListadeProductos;
        }
        public void GuardarProducto(Producto Producto)
        {
            if(Producto.Id == 0)
            {
                _contexto.Producto.Add(Producto);
            } else
            {
                var ProductoExistente = _contexto.Producto.Find(Producto.Id);
                ProductoExistente.Descripcion = Producto.Descripcion;
                ProductoExistente.Precio = Producto.Precio;
            }

            _contexto.SaveChanges();
        }
        public Producto ObtenerProducto(int id)
        {
            var Producto = _contexto.Producto.Include("Categoria").FirstOrDefault(p => p.Id == id);


            return Producto;
        }

        public void EliminarProducto(int id)
        {
            var Producto = _contexto.Producto.Find(id);

            _contexto.Producto.Remove(Producto);
            _contexto.SaveChanges();
        }

    }
}
