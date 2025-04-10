using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Modelo
{
    public class ProductoController
    {
        private ConexionDB conexion = new ConexionDB();

        public List<ProductoModel> ObtenerProductos()
        {
            List<ProductoModel> productos = new List<ProductoModel>();

            using (MySqlConnection conn = conexion.AbrirConexion())
            {
                if (conn != null)
                {
                    string query = "SELECT * FROM productos;";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        productos.Add(new ProductoModel
                        {
                            Id = reader.GetInt32("id"),
                            Nombre = reader.GetString("nombre"),
                            Descripcion = reader.GetString("descripcion"),
                            Precio = reader.GetDouble("precio"),
                            Cantidad = reader.GetInt32("cantidad")
                        });
                    }
                }
            }
            return productos;
        }

        public bool InsertarProducto(string nombre, string descripcion, double precio, int cantidad)
        {
            using (MySqlConnection conn = conexion.AbrirConexion())
            {
                if (conn != null)
                {
                    string query = "INSERT INTO productos (nombre, descripcion, precio, cantidad) VALUES (@nombre, @descripcion, @precio, @cantidad);";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            return false;
        }
    }
}
