using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoVenta.BL
{
    public class Bodega
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese la Bodega")]

        public string Descripcion { get; set; }
    }
}
