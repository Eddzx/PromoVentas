using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [ Required(ErrorMessage = "Ingrese la descripción")]
        [MinLength(3,ErrorMessage ="Ingrese minimo 3 Caracteres")]
        [MaxLength(20,ErrorMessage ="Ingrese maximo de 20 Caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Ingrese el precio")]
        [Range (0, 1000,ErrorMessage ="Ingrese un precio entre 0 y 1000")]
        public double Precio { get; set; }
        //agregados de categoria
        public int CategoriaId { get; set; }
        public Categoria categoria { get; set; }
        public bool Activo { get; set; }
       
    }
}
