using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoVenta.BL
{
    public class Pedido
    {
        //creamos el ID cliente la feca de la orden total
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Clientes cliente { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public bool Activo { get; set; }

        //lista de ordenes
        public List<PedidoDetalle> ListaOrdenDetalle { get; set; }

        public Pedido()
        {
            Activo = true;
            Fecha = DateTime.Now;
            ListaOrdenDetalle = new List<PedidoDetalle>();
        }

    }
    public class PedidoDetalle
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public Pedido Orden { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Total { get; set; }

    }

}
