using System;
using System.Drawing;
using System.Windows.Forms;

namespace Principal
{
    public partial class Menu : Form
    {
        private Button btnGestionProductos;
        private Button btnGestionProveedores;
        private Button btnInventario;
        private Button btnVentas;

        public Menu()
        {
            InitializeComponent();
            InicializarComponentesPersonalizados();
        }

        private void InicializarComponentesPersonalizados()
        {
            this.Text = "Menú Principal";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            btnGestionProductos = new Button();
            btnGestionProductos.Text = "Gestión de Productos";
            btnGestionProductos.Size = new Size(160, 40);
            btnGestionProductos.Location = new Point(30, 30);
            btnGestionProductos.Click += btnGestionProductos_Click;
            Controls.Add(btnGestionProductos);

            btnGestionProveedores = new Button();
            btnGestionProveedores.Text = "Gestión de Proveedores";
            btnGestionProveedores.Size = new Size(160, 40);
            btnGestionProveedores.Location = new Point(200, 30);
            btnGestionProveedores.Click += btnGestionProveedores_Click;
            Controls.Add(btnGestionProveedores);

            btnInventario = new Button();
            btnInventario.Text = "Inventario";
            btnInventario.Size = new Size(160, 40);
            btnInventario.Location = new Point(30, 100);
            btnInventario.Click += btnInventario_Click;
            Controls.Add(btnInventario);

            btnVentas = new Button();
            btnVentas.Text = "Ventas";
            btnVentas.Size = new Size(160, 40);
            btnVentas.Location = new Point(200, 100);
            btnVentas.Click += btnVentas_Click;
            Controls.Add(btnVentas);
        }

        private void btnGestionProductos_Click(object sender, EventArgs e)
        {
            GestionProductos productos = new GestionProductos();
            productos.ShowDialog();
        }

        private void btnGestionProveedores_Click(object sender, EventArgs e)
        {
            GestionProveedores proveedores = new GestionProveedores();
            proveedores.ShowDialog();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            Inventario inventario = new Inventario();
            inventario.ShowDialog();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            Ventas ventas = new Ventas();
            ventas.ShowDialog();
        }
    }
}
