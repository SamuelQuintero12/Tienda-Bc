using System;
using System.Windows.Forms;
using logica;

namespace Principal
{
    public partial class AgregarP : Form
    {
        public AgregarP()
        {
            InitializeComponent();
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            UsuarioController controller = new UsuarioController();

            string resultado = controller.GuardarProducto(
                tbNombre.Text,
                tbDescripcion.Text,
                tbPrecio.Text,
                tbCantidad.Text,
                tbImagen.Text,
                tbProovedor.Text
            );

            tbResultado.Text = resultado;
            tbResultado.ForeColor = resultado.Contains("éxito") ? Color.Green : Color.Red;
        }
    }
}
