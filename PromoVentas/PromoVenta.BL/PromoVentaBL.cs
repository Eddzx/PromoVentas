using System;
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
            var Producto = _contexto.Producto.Find(id);

            return Producto;
        }

        public object ObtenerProductos(int id)
        {
            throw new NotImplementedException();
        }
    }
}
