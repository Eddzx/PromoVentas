﻿using System;
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
                .Include("Cliente")
                .ToList();

            return ListadePedidos;
        }

        public List<PedidoDetalle> ObtenerPedidoDetalle(int pedidoId)
        {
            var listadePedidosDetalle = _contexto.PedidoDetalle
                .Include("Producto")
                .Where(p => p.PedidoId == pedidoId).ToList();

            return listadePedidosDetalle;
        }

        public PedidoDetalle ObtenerPedidoDetallePorId(int id)
        {
            var pedidoDetalle = _contexto.PedidoDetalle
            .Include("Cliente").FirstOrDefault(p => p.Id == id);

            return pedidoDetalle;
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
            _contexto.SaveChanges();
        }
        
        public void GuardarPedidoDetalle(PedidoDetalle pedidoDetalle)
        {
            var producto = _contexto.Productos.Find(pedidoDetalle.ProductoId);

            pedidoDetalle.Precio = producto.Precio;
            pedidoDetalle.Total = pedidoDetalle.Cantidad * pedidoDetalle.Precio; 

             _contexto.PedidoDetalle.Add(pedidoDetalle);

            var pedido = _contexto.Pedido.Find(pedidoDetalle.PedidoId);
            pedido.Total = pedido.Total + pedidoDetalle.Total;

            _contexto.SaveChanges();
        }

        public void EliminarPedidoDetalle(int Id)
        {
            var pedidoDetalle = _contexto.PedidoDetalle.Find(Id);
            _contexto.PedidoDetalle.Remove(pedidoDetalle);

            var pedido = _contexto.Pedido.Find(pedidoDetalle.PedidoId);
            pedido.Total = pedido.Total - pedidoDetalle.Total;

            _contexto.SaveChanges();
        }
    }
}
