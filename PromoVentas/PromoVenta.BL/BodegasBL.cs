using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoVenta.BL
{
    public class BodegasBL
    {
        Contexto _contexto;

        public List<Bodega> ListadeBodegas { get; set; }
        public int Id { get; private set; }

        public BodegasBL()
        {
            _contexto = new Contexto();
            ListadeBodegas = new List<Bodega>();
        }

        public List<Bodega> ObtenerBodegas()
        {
            ListadeBodegas = _contexto.Bodegas.ToList();

            return ListadeBodegas;
        }
        public void GuardarBodega(Bodega bodega)
        {
            if (bodega.Id == 0)
            {
                _contexto.Bodegas.Add(bodega);
            }
            else
            {
                var bodegaExistente = _contexto.Bodegas.Find(bodega.Id);
                bodegaExistente.Descripcion = bodega.Descripcion;
            }

            _contexto.SaveChanges();
        }

        public Bodega ObtenerBodega(int id)
        {
            var bodega = _contexto.Bodegas.Find(id);

            return bodega;
        }

        public void EliminarBodega(int id)
        {
            var bodega = _contexto.Bodegas.Find(id);

            _contexto.Bodegas.Remove(bodega);
            _contexto.SaveChanges();
        }
    }
}
