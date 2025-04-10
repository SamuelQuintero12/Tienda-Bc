using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using logica;
using Modelo.Entity;

namespace Principal
{
    public partial class Ventas : Form
    {
        private UsuarioController controller;
        private ComboBox cbProductos;
        private TextBox tbCantidad;
        private Label lbResultado;
        private DataGridView dataGridView1;
        private Button btVender;

        public Ventas()
        {
            InitializeComponent();
            controller = new UsuarioController();
            CargarProductos();
        }

        private void CargarProductos()
        {
            var productos = controller.VerProductos();
            foreach (var producto in productos)
            {
                cbProductos.Items.Add(producto.nombre);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ventas ventasForm = new Ventas();
            ventasForm.ShowDialog();
        }

        private void InitializeComponent()
        {

            cbProductos = new ComboBox();
            cbProductos.Name = "cbProductos";
            cbProductos.Location = new Point(20, 20);
            cbProductos.Size = new Size(200, 25);
            Controls.Add(cbProductos);

            cbProductos = new ComboBox();
            tbCantidad = new TextBox();
            lbResultado = new Label();
            btVender = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // cbProductos
            // 
            cbProductos.Location = new Point(50, 20);
            cbProductos.Name = "cbProductos";
            cbProductos.Size = new Size(200, 23);
            cbProductos.TabIndex = 0;
            // 
            // tbCantidad
            // 
            tbCantidad.Location = new Point(50, 60);
            tbCantidad.Name = "tbCantidad";
            tbCantidad.Size = new Size(200, 23);
            tbCantidad.TabIndex = 1;
            // 
            // lbResultado
            // 
            lbResultado.Location = new Point(50, 140);
            lbResultado.Name = "lbResultado";
            lbResultado.Size = new Size(300, 25);
            lbResultado.TabIndex = 3;
            lbResultado.Click += lbResultado_Click;
            // 
            // btVender
            // 
            btVender.Location = new Point(50, 100);
            btVender.Name = "btVender";
            btVender.Size = new Size(200, 30);
            btVender.TabIndex = 2;
            btVender.Text = "Realizar Venta";
            btVender.Click += btVender_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(385, 191);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(8, 8);
            dataGridView1.TabIndex = 4;
            // 
            // Ventas
            // 
            ClientSize = new Size(400, 200);
            Controls.Add(dataGridView1);
            Controls.Add(cbProductos);
            Controls.Add(tbCantidad);
            Controls.Add(btVender);
            Controls.Add(lbResultado);
            Name = "Ventas";
            Text = "Ventas";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void btVender_Click(object sender, EventArgs e)
        {
            if (cbProductos.SelectedItem == null || string.IsNullOrEmpty(tbCantidad.Text))
            {
                lbResultado.Text = "❌ Seleccione un producto y una cantidad válida.";
                lbResultado.ForeColor = Color.Red;
                return;
            }

            ProductoEntity producto = controller.BuscarProducto(cbProductos.SelectedItem.ToString());
            int cantidadVenta = Convert.ToInt32(tbCantidad.Text);

            if (producto != null && producto.cantidad >= cantidadVenta)
            {
                producto.cantidad -= cantidadVenta;
                controller.EditarProducto(producto.id_producto, producto.descripcion, producto.precio.ToString(), producto.cantidad.ToString());
                controller.RegistrarVenta(producto.id_producto, cantidadVenta);

                lbResultado.Text = "✅ Venta realizada con éxito.";
                lbResultado.ForeColor = Color.Green;
            }
            else
            {
                lbResultado.Text = "❌ Stock insuficiente.";
                lbResultado.ForeColor = Color.Red;
            }
        }

        private void lbResultado_Click(object sender, EventArgs e)
        {

        }
    }
}

