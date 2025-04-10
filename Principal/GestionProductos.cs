using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using logica;
using Modelo.Entity;

namespace Principal
{
    public partial class GestionProductos : Form
    {
        private UsuarioController productoController = new UsuarioController();

        private DataGridView dgvProductos;
        private TextBox tbNombre, tbDescripcion, tbPrecio, tbCantidad, tbImagen, tbProveedor;
        private Label lblResultado;
        private Button btnGuardar;

        public GestionProductos()
        {
            InicializarComponentes();
            CargarProductos();
        }

        private void InicializarComponentes()
        {
            this.Text = "Gestión de Productos";
            this.Size = new Size(850, 600);

            Label lblNombre = new Label { Text = "Nombre", Location = new Point(20, 20) };
            tbNombre = new TextBox { Location = new Point(100, 20), Width = 200 };

            Label lblDescripcion = new Label { Text = "Descripción", Location = new Point(20, 60) };
            tbDescripcion = new TextBox { Location = new Point(100, 60), Width = 200 };

            Label lblPrecio = new Label { Text = "Precio", Location = new Point(20, 100) };
            tbPrecio = new TextBox { Location = new Point(100, 100), Width = 200 };

            Label lblCantidad = new Label { Text = "Cantidad", Location = new Point(20, 140) };
            tbCantidad = new TextBox { Location = new Point(100, 140), Width = 200 };

            Label lblImagen = new Label { Text = "Imagen", Location = new Point(20, 180) };
            tbImagen = new TextBox { Location = new Point(100, 180), Width = 200 };

            Label lblProveedor = new Label { Text = "ID Proveedor", Location = new Point(20, 220) };
            tbProveedor = new TextBox { Location = new Point(100, 220), Width = 200 };

            btnGuardar = new Button
            {
                Text = "Guardar Producto",
                Location = new Point(100, 270),
                Width = 200
            };
            btnGuardar.Click += BtnGuardar_Click;

            lblResultado = new Label
            {
                Location = new Point(100, 310),
                Width = 400,
                ForeColor = Color.Red
            };

            dgvProductos = new DataGridView
            {
                Location = new Point(320, 20),
                Size = new Size(500, 400),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            this.Controls.Add(lblNombre);
            this.Controls.Add(tbNombre);
            this.Controls.Add(lblDescripcion);
            this.Controls.Add(tbDescripcion);
            this.Controls.Add(lblPrecio);
            this.Controls.Add(tbPrecio);
            this.Controls.Add(lblCantidad);
            this.Controls.Add(tbCantidad);
            this.Controls.Add(lblImagen);
            this.Controls.Add(tbImagen);
            this.Controls.Add(lblProveedor);
            this.Controls.Add(tbProveedor);
            this.Controls.Add(btnGuardar);
            this.Controls.Add(lblResultado);
            this.Controls.Add(dgvProductos);
        }

        private void CargarProductos()
        {
            var productos = productoController.TraerProductos();
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = productos;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string resultado = productoController.GuardarProducto(
                tbNombre.Text,
                tbDescripcion.Text,
                tbPrecio.Text,
                tbCantidad.Text,
                tbImagen.Text,
                tbProveedor.Text
            );

            lblResultado.Text = resultado;
            lblResultado.ForeColor = resultado.Contains("éxito") ? Color.Green : Color.Red;

            if (resultado.Contains("éxito"))
            {
                LimpiarCampos();
                CargarProductos();
            }
        }

        private void LimpiarCampos()
        {
            tbNombre.Clear();
            tbDescripcion.Clear();
            tbPrecio.Clear();
            tbCantidad.Clear();
            tbImagen.Clear();
            tbProveedor.Clear();
        }
    }
}
