using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalleRepuesto
    {
        private int _Cantidad;
        private float _Precio;
        private int _IdOrden;
        private int _IdRepuesto;

        private string _TextoBuscar;

        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public float Precio { get => _Precio; set => _Precio = value; }  
        public int IdOrden { get => _IdOrden; set => _IdOrden = value; }
        public int IdRepuesto { get => _IdRepuesto; set => _IdRepuesto = value; }


        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public DDetalleRepuesto()
        {

        }

        public DDetalleRepuesto(int cantidad, float precio, int idOrden, int idRepuesto, string textoBuscar)
        {
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.IdOrden = idOrden;
            this.IdRepuesto = idRepuesto; ;
            this.TextoBuscar = textoBuscar;
        }

        public string Insertar(DDetalleRepuesto DetalleRepuesto)
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
                SqlCmd.CommandText = "insertarDetalleRepuesto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = DetalleRepuesto.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Money;
                ParPrecio.Value = DetalleRepuesto.Precio;
                SqlCmd.Parameters.Add(ParPrecio);

                SqlParameter ParIdOrden = new SqlParameter();
                ParIdOrden.ParameterName = "@idOrden";
                ParIdOrden.SqlDbType = SqlDbType.Int;
                ParIdOrden.Value = DetalleRepuesto.IdOrden;
                SqlCmd.Parameters.Add(ParIdOrden);

                SqlParameter ParIdRepuesto = new SqlParameter();
                ParIdRepuesto.ParameterName = "@idRepuesto";
                ParIdRepuesto.SqlDbType = SqlDbType.Int;
                ParIdRepuesto.Value = DetalleRepuesto.IdRepuesto;
                SqlCmd.Parameters.Add(ParIdRepuesto);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Puede Registrar";

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

        public string Editar(DDetalleRepuesto DetalleRepuesto)
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
                SqlCmd.CommandText = "insertarDetalleRepuesto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = DetalleRepuesto.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Money;
                ParPrecio.Value = DetalleRepuesto.Precio;
                SqlCmd.Parameters.Add(ParPrecio);

                SqlParameter ParIdOrden = new SqlParameter();
                ParIdOrden.ParameterName = "@idOrden";
                ParIdOrden.SqlDbType = SqlDbType.Int;
                ParIdOrden.Value = DetalleRepuesto.IdOrden;
                SqlCmd.Parameters.Add(ParIdOrden);

                SqlParameter ParIdRepuesto = new SqlParameter();
                ParIdRepuesto.ParameterName = "@idRepuesto";
                ParIdRepuesto.SqlDbType = SqlDbType.Int;
                ParIdRepuesto.Value = DetalleRepuesto.IdRepuesto;
                SqlCmd.Parameters.Add(ParIdRepuesto);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Puede Modificar";

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

        public string Eliminar(DDetalleRepuesto DetalleRepuesto)
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
                SqlCmd.CommandText = "eliminarDetalleRepuesto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdOrden = new SqlParameter();
                ParIdOrden.ParameterName = "@idOrden";
                ParIdOrden.SqlDbType = SqlDbType.Int;
                ParIdOrden.Value = DetalleRepuesto.IdOrden;
                SqlCmd.Parameters.Add(ParIdOrden);

              /*  SqlParameter ParIdRepuesto = new SqlParameter();
                ParIdRepuesto.ParameterName = "@idRepuesto";
                ParIdRepuesto.SqlDbType = SqlDbType.Int;
                ParIdRepuesto.Value = DetalleRepuesto.IdRepuesto;
                SqlCmd.Parameters.Add(ParIdRepuesto);*/

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
            DataTable DtResultado = new DataTable("detalleRepuesto");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "mostrarDetalleRepuesto";
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

        public DataTable BuscarNombre(DDetalleRepuesto DetalleRepuesto)
        {
            DataTable DtResultado = new DataTable("detalleRepuesto");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "buscarDetalleRepuesto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                /*  SqlParameter ParOpcion = new SqlParameter();
                  ParOpcion.ParameterName = "@opcion";
                  ParOpcion.SqlDbType = SqlDbType.VarChar;
                  ParOpcion.Size = 50;
                  ParOpcion.Value = DetalleVenta.Opcion;
                  SqlCmd.Parameters.Add(ParOpcion);
                 */
                SqlParameter ParIdOrden = new SqlParameter();
                ParIdOrden.ParameterName = "@idOrden";
                ParIdOrden.SqlDbType = SqlDbType.Int;
                ParIdOrden.Value = DetalleRepuesto.IdOrden;
                SqlCmd.Parameters.Add(ParIdOrden);


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