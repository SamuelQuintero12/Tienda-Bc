using MySql.Data.MySqlClient;
using System;
using System.Data;
using Modelo;
using Mysqlx.Connection;

namespace Modelo
{
    public class ConexionDB
    {

    
        private string cadenaConexion = "Server=localhost; Database=tu_base_de_datos; Uid=root; Pwd=tu_contraseña;";

        public MySqlConnection AbrirConexion()
        {
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error al conectar: " + ex.Message);
                return null;
            }
        }

        public void CerrarConexion(MySqlConnection conexion)
        {
            if (conexion != null && conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
