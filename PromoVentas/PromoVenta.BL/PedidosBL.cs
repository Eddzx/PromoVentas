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

        public Pedido ObtenerPedido(int id)
        {
            var pedido = _contexto.Pedido
                .Include("Cliente").FirstOrDefault(p => p.Id == id);

            return pedido;
        }

        public void GuardarPedido(Pedido pedido)
        {
            if (pedido.Id == 0)
            {
                _contexto.Pedido.Add(pedido);
            } else
            {
                var pedidoExistente = _contexto.Pedido.Find(pedido.Id);
                pedidoExistente.ClienteId = pedido.ClienteId;
                pedidoExistente.Activo = pedido.Activo;
            }

            _contexto.Pedido.Add(pedido);

            _contexto.SaveChanges();
        }
    }
}
