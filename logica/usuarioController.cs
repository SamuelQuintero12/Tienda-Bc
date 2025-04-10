using Modelo;
using Modelo.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using static BaseDatos;

namespace logica
{
    public class UsuarioController
    {
        private BaseDatos db = new BaseDatos();

        public List<ProductoEntity> TraerProductos()
        {
            return db.TraerProductos();
        }

        public List<ProductoEntity> VerProductos()
        {
            return db.TraerProductos();
        }
        public List<ProveedoresEntity> TraerProveedores()
        {
            return db.TraerProveedores();
        }


        public string EditarProducto(int idProducto, string nombre, string descripcion, string precio, string cantidad)
        {
            ProductoEntity producto = new ProductoEntity
            {
                id_producto = idProducto,
                nombre = nombre,
                descripcion = descripcion,
                precio = Convert.ToDouble(precio),
                cantidad = Convert.ToInt32(cantidad)
            };

            int resultado = db.ActualizarProducto(producto);
            return resultado > 0 ? "✅ Producto editado con éxito." : "❌ Error al editar el producto.";
        }

        public string EditarProducto(int id, string descripcion, string precio, string cantidad)
        {
            ProductoEntity producto = db.ObtenerProductoPorId(id);
            if (producto == null) return "❌ Producto no encontrado.";

            producto.descripcion = descripcion;
            producto.precio = Convert.ToDouble(precio);
            producto.cantidad = Convert.ToInt32(cantidad);

            int resultado = db.ActualizarProducto(producto);
            return resultado > 0 ? "✅ Producto actualizado con éxito." : "❌ Error al actualizar el producto.";
        }

        public string EliminarUsuario(string idProducto)
        {
            int id = Convert.ToInt32(idProducto);
            int resultado = db.EliminarProducto(id);

            return resultado > 0 ? "✅ Producto eliminado con éxito." : "❌ No se pudo eliminar el producto.";
        }

        public string GuardarProducto(string nombre, string descripcion, string precio, string cantidad, string imagen, string idProveedor)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(precio) || string.IsNullOrWhiteSpace(cantidad))
                {
                    return "❌ Nombre, precio y cantidad son obligatorios.";
                }

                ProductoEntity producto = new ProductoEntity
                {
                    nombre = nombre,
                    descripcion = descripcion,
                    precio = Convert.ToDouble(precio),
                    cantidad = Convert.ToInt32(cantidad),
                    id_proveedor = Convert.ToInt32(idProveedor),
                    imagen = imagen // si no usas esta propiedad en tu entidad, puedes quitarla
                };

                int resultado = db.InsertarProducto(producto);
                return resultado > 0 ? "✅ Producto guardado con éxito." : "❌ Error al guardar el producto.";
            }
            catch (FormatException)
            {
                return "❌ Precio o cantidad inválidos.";
            }
            catch (Exception ex)
            {
                return $"❌ Error inesperado: {ex.Message}";
            }
        }

        public ProductoEntity BuscarProducto(string nombreProducto)
        {
            return db.TraerProductos().FirstOrDefault(p => p.nombre == nombreProducto);
        }

        public string RegistrarVenta(int idProducto, int cantidadVendida)
        {
            int resultado = db.InsertarVenta(idProducto, cantidadVendida);
            return resultado > 0 ? "✅ Venta registrada con éxito." : "❌ Error al registrar la venta.";
        }
        


        // Método corregido que guarda proveedores usando la clase del namespace correcto
        public int GuardarProveedor(ProveedoresEntity proveedor)
        {
            int resultado = 0;
            try
            {
                using (MySqlCommand cmd = db.GetConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO proveedores (nombre, direccion, telefono, email, fecha_registro) " +
                                      "VALUES (@nombre, @direccion, @telefono, @email, @fecha_registro)";

                    cmd.Parameters.AddWithValue("@nombre", proveedor.nombre);
                    cmd.Parameters.AddWithValue("@direccion", proveedor.direccion);
                    cmd.Parameters.AddWithValue("@telefono", proveedor.telefono);
                    cmd.Parameters.AddWithValue("@email", proveedor.email);
                    cmd.Parameters.AddWithValue("@fecha_registro", proveedor.fecha_registro);

                    resultado = cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al guardar proveedor: " + ex.Message);
            }

            return resultado;
        }

        public string GuardarProveedor(string text1, string text2, string text3)
        {
            throw new NotImplementedException();
        }
    }
}
