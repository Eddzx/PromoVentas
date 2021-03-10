using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoVenta.BL
{
    public class PedidosBL
    {
        Contexto _contexto;
        public List<Pedido> ListadePedidos { get; set; }

        public PedidosBL()
        {
            _contexto = new Contexto();
            ListadePedidos = new List<Pedido>();
        }

        public List<Pedido> ObtenerPedidos()
        {
            ListadePedidos = _contexto.Pedido
                .Include("Clientes")
                .ToList();

            return ListadePedidos;
        }

        public void GuardarPedido(Pedido pedido)
        {
            _contexto.Pedido.Add(pedido);

            _contexto.SaveChanges();
        }
    }
}
