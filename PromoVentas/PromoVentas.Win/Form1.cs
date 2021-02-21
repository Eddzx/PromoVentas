using PromoVenta.BL;
using System.Windows.Forms;

namespace PromoVentas.Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var productosBL = new ProductosBL();
            var ListadeProductos = productosBL.ObtenerProductos();

            listadeProductosBindingSource.DataSource = ListadeProductos;
        }
    }
}
