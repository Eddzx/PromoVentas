using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoVenta.BL
{
    public class Contexto: DbContext
    {
        public Contexto(): base("PromosVentaDB")
        {

        }
        public DbSet<Producto> Producto { get; set; }
    }
}
