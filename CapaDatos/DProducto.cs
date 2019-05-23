using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
      public class DProducto
    {
        private int _IdProducto;
        private string _Modelo;
        private string _Descripcion;
        private float _Precio;
        private int _Stock;
        private string _IdMarca;
        private string _IdCategoria;

        private string _TextoBuscar;
        private string _Opcion;

        public int IdProducto { get => _IdProducto; set => _IdProducto = value; }
        public string Modelo { get => _Modelo; set => _Modelo = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public float Precio { get => _Precio; set => _Precio = value; }
        public int Stock { get => _Stock; set => _Stock = value; }
        public string IdMarca { get => _IdMarca; set => _IdMarca = value; }
        public string IdCategoria { get => _IdCategoria; set => _IdCategoria = value; }

        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        public string Opcion { get => _Opcion; set => _Opcion = value; }

        public DProducto()
        {

        }

        public DProducto(int idProducto, string modelo, string descripcion, float precio, 
            int stock, string idMarca, string idCategoria, string textoBuscar, string opcion)
        {
            this.IdProducto = idProducto;
            this.Modelo = modelo;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Stock = stock;
            this.IdMarca = idMarca;
            this.IdCategoria = idCategoria;

            this.TextoBuscar = textoBuscar;
            this.Opcion = opcion;
        }

        public string Insertar(DProducto Producto)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "insertarProducto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdProducto);

                SqlParameter ParModelo = new SqlParameter();
                ParModelo.ParameterName = "@modelo";
                ParModelo.SqlDbType = SqlDbType.VarChar;
                ParModelo.Size = 50;
                ParModelo.Value = Producto.Modelo;
                SqlCmd.Parameters.Add(ParModelo);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Producto.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Money;
                ParPrecio.Value = Producto.Precio;
                SqlCmd.Parameters.Add(ParPrecio);

                SqlParameter ParStock = new SqlParameter();
                ParStock.ParameterName = "@stock";
                ParStock.SqlDbType = SqlDbType.Int;
                ParStock.Value = Producto.Stock;
                SqlCmd.Parameters.Add(ParStock);


                SqlParameter ParIdMarca = new SqlParameter();
                ParIdMarca.ParameterName = "@marca";
                ParIdMarca.SqlDbType = SqlDbType.VarChar;
                ParIdMarca.Size = 50;
                ParIdMarca.Value = Producto.IdMarca;
                SqlCmd.Parameters.Add(ParIdMarca);

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@categoria";
                ParIdCategoria.SqlDbType = SqlDbType.VarChar;
                ParIdCategoria.Size = 50;
                ParIdCategoria.Value = Producto.IdCategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);


                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "El Nombre del Producto ya Existe";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        public string Editar(DProducto Producto)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "modificarProducto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Value = Producto.IdProducto;
                SqlCmd.Parameters.Add(ParIdProducto);

                SqlParameter ParModelo = new SqlParameter();
                ParModelo.ParameterName = "@modelo";
                ParModelo.SqlDbType = SqlDbType.VarChar;
                ParModelo.Size = 50;
                ParModelo.Value = Producto.Modelo;
                SqlCmd.Parameters.Add(ParModelo);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Producto.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Money;
                ParPrecio.Value = Producto.Precio;
                SqlCmd.Parameters.Add(ParPrecio);

                SqlParameter ParStock = new SqlParameter();
                ParStock.ParameterName = "@stock";
                ParStock.SqlDbType = SqlDbType.Int;
                ParStock.Value = Producto.Stock;
                SqlCmd.Parameters.Add(ParStock);


                SqlParameter ParIdMarca = new SqlParameter();
                ParIdMarca.ParameterName = "@marca";
                ParIdMarca.SqlDbType = SqlDbType.VarChar;
                ParIdMarca.Size = 50;
                ParIdMarca.Value = Producto.IdMarca;
                SqlCmd.Parameters.Add(ParIdMarca);

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@categoria";
                ParIdCategoria.SqlDbType = SqlDbType.VarChar;
                ParIdCategoria.Size = 50;
                ParIdCategoria.Value = Producto.IdCategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo el Producto";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        public string Eliminar(DProducto Producto)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "eliminarProducto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@idProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Value = Producto.IdProducto;
                SqlCmd.Parameters.Add(ParIdProducto);


                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Elimino el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }


        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("producto");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "mostrarProducto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        public DataTable BuscarNombre(DProducto Producto)
        {
            DataTable DtResultado = new DataTable("producto");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "buscarProducto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

               

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Producto.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlParameter ParOpcion = new SqlParameter();
                ParOpcion.ParameterName = "@opcion";
                ParOpcion.SqlDbType = SqlDbType.VarChar;
                ParOpcion.Size = 30;
                ParOpcion.Value = Producto.Opcion;
                SqlCmd.Parameters.Add(ParOpcion);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }


    }
}
