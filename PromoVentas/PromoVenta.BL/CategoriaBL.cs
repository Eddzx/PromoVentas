using PromoVenta.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoVenta.BL
{
    public class CategoriasBL
    {
        Contexto _contexto;

        public List<Categoria> ListadeCategorias { get; set; }

        public CategoriasBL()
        {
            _contexto = new Contexto();
            ListadeCategorias = new List<Categoria>();
        }

        public List<Categoria> ObtenerCategoria()
        {
            ListadeCategorias = _contexto.Categorias.ToList();

            return ListadeCategorias;
        }
        public void GuardarCategoria(Categoria categoria)
        {
            if (categoria.Id == 0)
            {
                _contexto.Categorias.Add(categoria);
            }
            else
            {
                var categoriaExistente = _contexto.Categorias.Find(categoria.Id);
                categoriaExistente.Descripcion = categoria.Descripcion;
            }

            _contexto.SaveChanges();
        }

        public object ObtenerCategoria(int id)
        {
            throw new NotImplementedException();
        }

        public void GuardarCategoria(CategoriasBL categoria)
        {
            throw new NotImplementedException();
        }

        public Categoria ObtenerProducto(int id)
        {
            var categoria = _contexto.Categorias.Find(id);

            return categoria;
        }

        public void EliminarCategoria(int id)
        {
            var categoria = _contexto.Categorias.Find(id);

            _contexto.Categorias.Remove(categoria);
            _contexto.SaveChanges();
        }
    }
}
