using System;
using System.Windows.Forms;

namespace Principal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGestionProductos_Click(object sender, EventArgs e)
        {
            GestionProductos productos = new GestionProductos();
            productos.ShowDialog();
        }
    }
}
