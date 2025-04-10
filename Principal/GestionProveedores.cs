using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using logica;
using Modelo.Entity;

namespace Principal
{
    public partial class GestionProveedores : Form
    {
        private UsuarioController controller = new UsuarioController();

        private DataGridView dgvProveedores;
        private TextBox tbNombre, tbTelefono, tbCorreo;
        private Label lblResultado;
        private Button btnGuardar;

        public GestionProveedores()
        {
            InicializarComponentes();
            CargarProveedores();
        }

        private void InicializarComponentes()
        {
            this.Text = "Gestión de Proveedores";
            this.Size = new Size(800, 500);

            Label lblNombre = new Label { Text = "Nombre", Location = new Point(20, 20) };
            tbNombre = new TextBox { Location = new Point(100, 20), Width = 200 };

            Label lblTelefono = new Label { Text = "Teléfono", Location = new Point(20, 60) };
            tbTelefono = new TextBox { Location = new Point(100, 60), Width = 200 };

            Label lblCorreo = new Label { Text = "Correo", Location = new Point(20, 100) };
            tbCorreo = new TextBox { Location = new Point(100, 100), Width = 200 };

            btnGuardar = new Button
            {
                Text = "Guardar Proveedor",
                Location = new Point(100, 150),
                Width = 200
            };
            btnGuardar.Click += BtnGuardar_Click;

            lblResultado = new Label
            {
                Location = new Point(100, 190),
                Width = 400,
                ForeColor = Color.Red
            };

            dgvProveedores = new DataGridView
            {
                Location = new Point(320, 20),
                Size = new Size(450, 350),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            this.Controls.Add(lblNombre);
            this.Controls.Add(tbNombre);
            this.Controls.Add(lblTelefono);
            this.Controls.Add(tbTelefono);
            this.Controls.Add(lblCorreo);
            this.Controls.Add(tbCorreo);
            this.Controls.Add(btnGuardar);
            this.Controls.Add(lblResultado);
            this.Controls.Add(dgvProveedores);
        }

        private void CargarProveedores()
        {
            var proveedores = controller.TraerProveedores(); // Método en UsuarioController
            dgvProveedores.DataSource = null;
            dgvProveedores.DataSource = proveedores;
        }
    
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string resultado = controller.GuardarProveedor(
                tbNombre.Text,
                tbTelefono.Text,
                tbCorreo.Text
            );

            lblResultado.Text = resultado;
            lblResultado.ForeColor = resultado.Contains("éxito") ? Color.Green : Color.Red;

            if (resultado.Contains("éxito"))
            {
                LimpiarCampos();
                CargarProveedores();
            }
        }

        private void LimpiarCampos()
        {
            tbNombre.Clear();
            tbTelefono.Clear();
            tbCorreo.Clear();
        }
    }
}
