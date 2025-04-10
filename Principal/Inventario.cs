using logica;
using Modelo;
using Modelo.Entity;

namespace Principal
{
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
        }


        private void BtBusqueda_Click(object sender, EventArgs e)
        {
            BaseDatos db = new BaseDatos();
            UsuarioController controller = new UsuarioController();
            ProductoEntity producto = db.BuscarProducto(TbBusqueda.Text);

            if (producto != null)
            {
                lbResult.Text = $"producto Nombre: {producto.nombre}, Precio: {producto.precio}, cantidad: {producto.cantidad}";
            }
            else
            {
                lbResult.Text = "No se encontró el producto.";
            }
        }



        private void BtAgregarP_Click(object sender, EventArgs e)
        {
            AgregarP agregarP = new();
            agregarP.ShowDialog();
        }

        private void BtEditarP_Click(object sender, EventArgs e)
        {
            EditarUsuario editar = new();
            editar.ShowDialog();
        }

        private void BtEliminarP_Click(object sender, EventArgs e)
        {
            EliminarP eliminarP = new();
            eliminarP.ShowDialog();
        }

        private void BtTraerProducto_Click(object sender, EventArgs e)
        {
            UsuarioController us = new();
            var productos = us.TraerProductos();


            PanelContainer.Controls.Clear();

            int yOffset = 10;

            foreach (var producto in productos)
            {
                Label lblProducto = new();
                lblProducto.Text = $"Nombre: {producto.nombre}\nDescripción: {producto.descripcion}\nStock: {producto.cantidad}";
                lblProducto.AutoSize = true;
                lblProducto.Location = new Point(10, yOffset);

                PanelContainer.Controls.Add(lblProducto);

                yOffset += 50;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Abre el formulario de Inventario
            Inventario inventarioForm = new Inventario();
            inventarioForm.ShowDialog();
        }
        
        private void BtAgregarProve_Click(object sender, EventArgs e)
        {
            AgregarProve agregarProve = new();
            agregarProve.ShowDialog();
        }

        private void TbBusqueda_TextChanged(object sender, EventArgs e)
        {

        }

        private void PanelContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
