﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoVenta.BL
{
    public class OrdenesBL
    {
        Contexto _contexto;
        public List<Orden> ListadeOrdenes { get; set; }
        public OrdenesBL()
        {
            _contexto = new Contexto();
            ListadeOrdenes = new List<Orden>();

        }
        public List<Orden> ObtenerOrdenes()
        {
            ListadeOrdenes = _contexto.Ordenes
                .Include("Cliente")
                .ToList();

            return ListadeOrdenes;
        }
    }
}
