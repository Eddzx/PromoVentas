﻿using PromoVenta.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PromoVentas.Win
{
    public partial class Form2 : Form
    {
        ReportedeVentasPorProductoBL _reporteVentasPorProductoBL;

        public Form2()
        {
            InitializeComponent();
            _reporteVentasPorProductoBL = new ReportedeVentasPorProductoBL();

            RefrescarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefrescarDatos();
        }

        private void RefrescarDatos()
        {
            var listadeVentasPorProductos = _reporteVentasPorProductoBL.ObtenerVentasPorProducto();
            listadeVentasPorProductoBindingSource.DataSource = listadeVentasPorProductos;
            listadeVentasPorProductoBindingSource.ResetBindings(false); 
        }

    }
}
