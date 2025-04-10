using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using logica;

namespace Principal
{
    public partial class EditarUsuario : Form
    {
        public EditarUsuario()
        {
            InitializeComponent();
        }
        private int ObtenerIdProductoSeleccionado()
        {
            if (cbProductos.SelectedItem == null)
                return 0;

            return Convert.ToInt32(cbProductos.SelectedValue);
        }



        private void btEditarP_Click(object sender, EventArgs e)
        {
            UsuarioController controller = new UsuarioController();

            int idProducto = ObtenerIdProductoSeleccionado(); // Método que obtiene el ID

            if (idProducto == 0)
            {
                MessageBox.Show("Por favor, selecciona un producto válido.");
                return;
            }

            string resultado = controller.EditarProducto(
                idProducto,
                tbNombre.Text,
                tbDescripcion.Text,
                tbPrecio.Text,
                tbCantidad.Text
            );

            Resultado1.Text = resultado;

            if (resultado.Contains("éxito"))
            {
                Resultado1.ForeColor = Color.Green;
            }
            else
            {
                Resultado1.ForeColor = Color.Red;
            }

            MessageBox.Show(resultado);
        }


        private void tbPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }

    internal class cbProductos
    {
        public static object SelectedItem { get; internal set; }
        public static bool SelectedValue { get; internal set; }
    }
}
