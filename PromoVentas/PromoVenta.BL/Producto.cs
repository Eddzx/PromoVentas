using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoVenta.BL
{
    public class Producto
    {
        public Producto()
        {
            Activo = true;
        }
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        //agregados de categoria
        public Categoria categoria { get; set; }
        public bool Activo { get; set; }
    }
}
