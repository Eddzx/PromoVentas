using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoVenta.BL
{
    public class Orden
    {
        //creamos el ID cliente la feca de la orden total
        public int Id { get; set; }
        public int Cliente { get; set; }
        public Clientes cliente { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public bool Activo { get; set; }

        //lista de ordenes
        public List<OrdenDetalle> ListaOrdenDetalle { get; set; }

        public Orden()
        {
            Activo = true;
            Fecha = DateTime.Now;
        }

    }
    public class OrdenDetalle
    {
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public Orden Orden { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Total { get; set; }

    }

}
