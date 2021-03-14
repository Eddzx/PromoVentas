using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoVenta.BL
{
    public class Clientes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese la Clientes")]
        //datso del formulario del cliente
        public string Nombre{ get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public bool Activo { get; set; }
    }
}
