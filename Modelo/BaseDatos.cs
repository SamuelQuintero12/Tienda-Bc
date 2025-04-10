using Modelo.Entity; // Asegúrate de que este namespace contiene las entidades necesarias
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using Modelo;
using Modelo.Entitys;

public class BaseDatos
{
    private string cadenaConexion = "server=localhost; database=tu_basedatos; uid=tu_usuario; pwd=tu_contraseña;";
    private MySqlConnection conexion;

    public BaseDatos()
    {
        conexion = new MySqlConnection(cadenaConexion);
    }

    public MySqlConnection GetConnection()
    {
        if (conexion.State != ConnectionState.Open)
        {
            conexion.Open();
        }
        return conexion;
    }


    // ✅ Corrección: Método para traer productos
    public List<ProductoEntity> TraerProductos()
    {
        List<ProductoEntity> productos = new List<ProductoEntity>();

        try
        {
            using (MySqlCommand cmd = GetConnection().CreateCommand())
            {
                cmd.CommandText = "SELECT id, nombre, descripcion, precio, cantidad, imagen, id_provedor FROM productos";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        productos.Add(new ProductoEntity
                        {
                            id_producto = reader.GetInt32("id"),
                            nombre = reader.GetString("nombre"),
                            descripcion = reader.GetString("descripcion"),
                            precio = reader.GetDouble("precio"),
                            cantidad = reader.GetInt32("cantidad"),
                            id_proveedor = reader.GetInt32("id_provedor")
                        });
                    }
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error al traer productos: " + ex.Message);
        }

        return productos;
    }
    public List<ProveedoresEntity> TraerProveedores()
    {
        List<ProveedoresEntity> lista = new List<ProveedoresEntity>();

        using (MySqlCommand cmd = GetConnection().CreateCommand())
        {
            cmd.CommandText = "SELECT id_proveedor, nombre, direccion, telefono, email, fecha_registro FROM proveedores";

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ProveedoresEntity proveedor = new ProveedoresEntity
                    {
                        id = Convert.ToInt32(reader["id_proveedor"]),
                        nombre = reader["nombre"].ToString(),
                        direccion = reader["direccion"].ToString(),
                        telefono = reader["telefono"].ToString(),
                        email = reader["email"].ToString(),
                        fecha_registro = Convert.ToDateTime(reader["fecha_registro"])
                    };

                    lista.Add(proveedor);
                }
            }
        }

        return lista;
    }



    // ✅ Corrección: Definición de la entidad ProveedoresEntity
    public class ProveedoresEntity
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public DateTime fecha_registro { get; set; }
    }

    // ✅ Corrección: Método para guardar un producto (si te referías a esto con "GuardarProducto")
    public int GuardarProducto(ProductoEntity producto)
    {
        return AgregarProducto(producto);
    }

    public int GuardarProveedor(ProveedoresEntity proveedor)
    {
        int resultado = 0;
        try
        {
            using (MySqlCommand cmd = GetConnection().CreateCommand())
            {
                cmd.CommandText = "INSERT INTO proveedores (nombre, direccion, telefono, email, fecha_registro) VALUES (@nombre, @direccion, @telefono, @email, @fecha_registro)";
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

    public int AgregarProducto(ProductoEntity producto)
    {
        int resultado = 0;
        try
        {
            using (MySqlCommand cmd = GetConnection().CreateCommand())
            {
                cmd.CommandText = "INSERT INTO productos (nombre, descripcion, precio, cantidad, imagen, id_provedor) VALUES (@nombre, @descripcion, @precio, @cantidad, @imagen, @id_provedor)";
                cmd.Parameters.AddWithValue("@nombre", producto.nombre);
                cmd.Parameters.AddWithValue("@descripcion", producto.descripcion);
                cmd.Parameters.AddWithValue("@precio", producto.precio);
                cmd.Parameters.AddWithValue("@cantidad", producto.cantidad);
                cmd.Parameters.AddWithValue("@id_provedor", producto.id_proveedor);
                cmd.Parameters.AddWithValue("@imagen", producto.imagen ?? (object)DBNull.Value);

                resultado = cmd.ExecuteNonQuery();
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error al agregar producto: " + ex.Message);
        }

        return resultado;
    }

    public int EditarProducto(ProductoEntity producto)
    {
        int resultado = 0;
        try
        {
            using (MySqlCommand cmd = GetConnection().CreateCommand())
            {
                cmd.CommandText = "UPDATE productos SET nombre=@nombre, descripcion=@descripcion, precio=@precio, cantidad=@cantidad, imagen=@imagen, id_provedor=@id_provedor WHERE id=@id";
                cmd.Parameters.AddWithValue("@id", producto.id_producto);
                cmd.Parameters.AddWithValue("@nombre", producto.nombre);
                cmd.Parameters.AddWithValue("@descripcion", producto.descripcion);
                cmd.Parameters.AddWithValue("@precio", producto.precio);
                cmd.Parameters.AddWithValue("@cantidad", producto.cantidad);
                cmd.Parameters.AddWithValue("@id_provedor", producto.id_proveedor);
                cmd.Parameters.AddWithValue("@imagen", producto.imagen ?? (object)DBNull.Value);

                resultado = cmd.ExecuteNonQuery();
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error al actualizar producto: " + ex.Message);
        }

        return resultado;
    }

    public int EliminarProducto(int id)
    {
        int resultado = 0;
        try
        {
            using (MySqlCommand cmd = GetConnection().CreateCommand())
            {
                cmd.CommandText = "DELETE FROM productos WHERE id=@id";
                cmd.Parameters.AddWithValue("@id", id);

                resultado = cmd.ExecuteNonQuery();
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error al eliminar producto: " + ex.Message);
        }

        return resultado;
    }

    public DataTable ObtenerProductos()
    {
        DataTable productos = new DataTable();
        try
        {
            using (MySqlCommand cmd = GetConnection().CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM productos";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(productos);
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error al obtener productos: " + ex.Message);
        }
        return productos;
    }

    public int RegistrarVenta(int productoId, int cantidad)
    {
        int resultado = 0;
        try
        {
            using (MySqlCommand cmd = GetConnection().CreateCommand())
            {
                cmd.CommandText = "INSERT INTO ventas (producto_id, cantidad_vendida, fecha) VALUES (@producto_id, @cantidad, NOW())";
                cmd.Parameters.AddWithValue("@producto_id", productoId);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);

                resultado = cmd.ExecuteNonQuery();
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error al registrar venta: " + ex.Message);
        }

        return resultado;
    }
    public ProductoEntity ObtenerProductoPorId(int idProducto)
    {
        ProductoEntity producto = null;

        try
        {
            using (var connection = GetConnection())  // ✅ Asegura que la conexión se maneja correctamente
            {
                connection.Open();

                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM productos WHERE id = @id_producto";
                    cmd.Parameters.AddWithValue("@id_producto", idProducto);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())  // ✅ Si encuentra el producto, lo asigna
                        {
                            producto = new ProductoEntity
                            {
                                id_producto = reader.GetInt32("id"),
                                nombre = reader.GetString("nombre"),
                                descripcion = reader.GetString("descripcion"),
                                precio = reader.GetDouble("precio"),
                                cantidad = reader.GetInt32("cantidad"),
                                id_proveedor = reader.GetInt32("id_proveedor")
                            };
                        }
                    }
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("❌ Error al obtener el producto por ID: " + ex.Message);
        }

        return producto;
    }


    public int ActualizarProducto(ProductoEntity producto)
    {
        int resultado = 0;

        try
        {
            using (var connection = GetConnection())  // ✅ Se asegura de manejar la conexión correctamente
            {
                connection.Open();

                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE productos 
                                    SET nombre = @nombre, 
                                        descripcion = @descripcion, 
                                        precio = @precio, 
                                        cantidad = @cantidad, 
                                        imagen = @imagen, 
                                        id_proveedor = @id_proveedor
                                    WHERE id = @id_producto";

                    cmd.Parameters.AddWithValue("@nombre", producto.nombre);
                    cmd.Parameters.AddWithValue("@descripcion", producto.descripcion);
                    cmd.Parameters.AddWithValue("@precio", producto.precio);
                    cmd.Parameters.AddWithValue("@cantidad", producto.cantidad);
                    cmd.Parameters.AddWithValue("@imagen", producto.imagen);
                    cmd.Parameters.AddWithValue("@id_proveedor", producto.id_proveedor);
                    cmd.Parameters.AddWithValue("@id_producto", producto.id_producto);

                    resultado = cmd.ExecuteNonQuery();  // ✅ Ejecuta la consulta y devuelve el número de filas afectadas
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("❌ Error al actualizar el producto: " + ex.Message);
        }

        return resultado;
    }
    // Método para buscar un producto por nombre
    public ProductoEntity BuscarProducto(string nombre)
    {
        ProductoEntity producto = null;
        try
        {
            using (MySqlCommand cmd = GetConnection().CreateCommand())
            {
                cmd.CommandText = "SELECT id_producto, nombre, descripcion, precio, cantidad FROM productos WHERE nombre = @nombre";
                cmd.Parameters.AddWithValue("@nombre", nombre);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        producto = new ProductoEntity
                        {
                            id_producto = reader.GetInt32("id_producto"),
                            nombre = reader.GetString("nombre"),
                            descripcion = reader.GetString("descripcion"),
                            precio = reader.GetDouble("precio"),
                            cantidad = reader.GetInt32("cantidad")
                        };
                    }
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error al buscar producto: " + ex.Message);
        }
        return producto;
    }

    // Método para registrar una venta
    public int InsertarVenta(int id_producto, int cantidad) // Cambié RegistrarVenta a InsertarVenta
    {
        int resultado = 0;
        try
        {
            using (MySqlCommand cmd = GetConnection().CreateCommand())
            {
                cmd.CommandText = "INSERT INTO ventas (id_producto, cantidad, fecha) VALUES (@id_producto, @cantidad, NOW())";
                cmd.Parameters.AddWithValue("@id_producto", id_producto);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);

                resultado = cmd.ExecuteNonQuery();
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error al registrar venta: " + ex.Message);
        }
        return resultado;
    }
    public int InsertarProducto(ProductoEntity producto)
    {
        int resultado = 0;

        try
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO productos (nombre, descripcion, precio, cantidad, imagen, id_proveedor) " +
                                      "VALUES (@nombre, @descripcion, @precio, @cantidad, @imagen, @id_proveedor)";

                    cmd.Parameters.AddWithValue("@nombre", producto.nombre);
                    cmd.Parameters.AddWithValue("@descripcion", producto.descripcion);
                    cmd.Parameters.AddWithValue("@precio", producto.precio);
                    cmd.Parameters.AddWithValue("@cantidad", producto.cantidad);
                    cmd.Parameters.AddWithValue("@imagen", producto.imagen);
                    cmd.Parameters.AddWithValue("@id_proveedor", producto.id_proveedor);

                    resultado = cmd.ExecuteNonQuery();
                }
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("❌ Error al insertar producto: " + ex.Message);
        }

        return resultado;
    }



    // Método para editar un producto
    public int EditarProducto(int id_producto, string descripcion, double precio, int cantidad)
    {
        int resultado = 0;
        try
        {
            using (MySqlCommand cmd = GetConnection().CreateCommand())
            {
                cmd.CommandText = "UPDATE productos SET descripcion = @descripcion, precio = @precio, cantidad = @cantidad WHERE id_producto = @id_producto";
                cmd.Parameters.AddWithValue("@id_producto", id_producto);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@precio", precio);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);

                resultado = cmd.ExecuteNonQuery();
            }
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error al editar producto: " + ex.Message);
        }
        return resultado;
    }
    public int TraerProveedor(ProveedoresEntity proveedor)
    {
        int resultado = 0;
        try
        {
            using (MySqlCommand cmd = GetConnection().CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO proveedores (nombre, direccion, telefono, email, fecha_registro) 
                                    VALUES (@nombre, @direccion, @telefono, @email, @fecha_registro)";
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

    public class UsuarioModel : BaseDatos
    {
        public List<UsuarioEntity> ObtenerUsuarios()
        {
            List<UsuarioEntity> lista = new List<UsuarioEntity>();
            string query = "SELECT id, nombre, email, contraseña, rol, fecha_creacion FROM usuarios";

            using (MySqlConnection conn = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new UsuarioEntity
                        {
                            id = reader.GetInt32("id"),
                            nombre = reader.GetString("nombre"),
                            email = reader.GetString("email"),
                            contraseña = reader.GetString("contraseña"),
                            rol = reader.GetString("rol"),
                            fecha_creacion = reader.IsDBNull(reader.GetOrdinal("fecha_creacion"))
                                ? DateTime.MinValue
                                : reader.GetDateTime("fecha_creacion")
                        });
                    }
                }
            }
            return lista;
        }

        public int InsertarUsuario(UsuarioEntity usuario)
        {
            string query = "INSERT INTO usuarios (nombre, email, contraseña, rol) VALUES (@nombre, @email, @contraseña, @rol)";

            using (MySqlConnection conn = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", usuario.nombre);
                    cmd.Parameters.AddWithValue("@email", usuario.email);
                    cmd.Parameters.AddWithValue("@contraseña", usuario.contraseña);
                    cmd.Parameters.AddWithValue("@rol", usuario.rol);

                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }

    public class InventarioModel : BaseDatos
    {
        public List<InventarioEntity> ObtenerInventario()
        {
            List<InventarioEntity> lista = new List<InventarioEntity>();
            string query = "SELECT id, id_producto, cantidad, tipo_accion, fecha FROM inventarios";

            using (MySqlConnection conn = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new InventarioEntity
                        {
                            id = reader.GetInt32("id"),
                            id_producto = reader.GetInt32("id_producto"),
                            cantidad = reader.GetInt32("cantidad"),
                            tipo_accion = reader.GetString("tipo_accion"),
                            fecha = reader.IsDBNull(reader.GetOrdinal("fecha")) ? DateTime.MinValue : reader.GetDateTime("fecha")
                        });
                    }
                }
            }
            return lista;
        }

        public int InsertarMovimientoInventario(InventarioEntity inventario)
        {
            string query = "INSERT INTO inventarios (id_producto, cantidad, tipo_accion) VALUES (@id_producto, @cantidad, @tipo_accion)";

            using (MySqlConnection conn = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_producto", inventario.id_producto);
                    cmd.Parameters.AddWithValue("@cantidad", inventario.cantidad);
                    cmd.Parameters.AddWithValue("@tipo_accion", inventario.tipo_accion);

                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }

    public class VentaModel : BaseDatos
    {
        public int InsertarVenta(VentaEntity venta)
        {
            string query = "INSERT INTO ventas (id_usuario, fecha_venta, total) VALUES (@id_usuario, NOW(), @total)";

            using (MySqlConnection conn = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_usuario", venta.id_usuario);
                    cmd.Parameters.AddWithValue("@total", venta.total);

                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }

    public class FacturaModel : BaseDatos
    {
        public int InsertarFactura(FacturaEntity factura)
        {
            string query = "INSERT INTO facturas (id_venta, monto_total, fecha) VALUES (@id_venta, @monto_total, NOW())";

            using (MySqlConnection conn = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_venta", factura.id_venta);
                    cmd.Parameters.AddWithValue("@monto_total", factura.monto_total);

                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}