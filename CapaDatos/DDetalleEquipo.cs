using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalleEquipo
    {
        private int _Cantidad;
        private int _IdEquipo;
        private int _IdOrden;
        
        private string _TextoBuscar;

        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public int IdEquipo { get => _IdEquipo; set => _IdEquipo = value; }
        public int IdOrden { get => _IdOrden; set => _IdOrden = value; }



        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        

        public DDetalleEquipo()
        {

        }

        public DDetalleEquipo(int cantidad, int idEquipo, int idOrden, string textoBuscar)
        {
            this.Cantidad = cantidad;
            this.IdEquipo = idEquipo;
            this.IdOrden = idOrden;

            this.TextoBuscar = textoBuscar;
        }

        public string Insertar(DDetalleEquipo DetalleEquipo)
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
                SqlCmd.CommandText = "insertarDetalleEquipo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = DetalleEquipo.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParIdEquipo = new SqlParameter();
                ParIdEquipo.ParameterName = "@idEquipo";
                ParIdEquipo.SqlDbType = SqlDbType.Int;
                ParIdEquipo.Value = DetalleEquipo.IdEquipo;
                SqlCmd.Parameters.Add(ParIdEquipo);

                SqlParameter ParIdOrden = new SqlParameter();
                ParIdOrden.ParameterName = "@idOrden";
                ParIdOrden.SqlDbType = SqlDbType.Int;
                ParIdOrden.Value = DetalleEquipo.IdOrden;
                SqlCmd.Parameters.Add(ParIdOrden);

                

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

        public string Editar(DDetalleEquipo DetalleEquipo)
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
                SqlCmd.CommandText = "modificarDetalleEquipo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

            /*    SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = DetalleEquipo.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParIdEquipo = new SqlParameter();
                ParIdEquipo.ParameterName = "@idEquipo";
                ParIdEquipo.SqlDbType = SqlDbType.Int;
                ParIdEquipo.Value = DetalleEquipo.IdEquipo;
                SqlCmd.Parameters.Add(ParIdEquipo);*/

                SqlParameter ParIdOrden = new SqlParameter();
                ParIdOrden.ParameterName = "@idOrden";
                ParIdOrden.SqlDbType = SqlDbType.Int;
                ParIdOrden.Value = DetalleEquipo.IdOrden;
                SqlCmd.Parameters.Add(ParIdOrden);

                

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

        public string Eliminar(DDetalleEquipo DetalleEquipo)
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
                SqlCmd.CommandText = "eliminarDetalleEquipo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                /* SqlParameter ParIdEquipo = new SqlParameter();
                 ParIdEquipo.ParameterName = "@idEquipo";
                 ParIdEquipo.SqlDbType = SqlDbType.Int;
                 ParIdEquipo.Value = DetalleEquipo.IdEquipo;
                 SqlCmd.Parameters.Add(ParIdEquipo);*/

                SqlParameter ParIdOrden = new SqlParameter();
                ParIdOrden.ParameterName = "@idOrden";
                ParIdOrden.SqlDbType = SqlDbType.Int;
                ParIdOrden.Value = DetalleEquipo.IdOrden;
                SqlCmd.Parameters.Add(ParIdOrden);


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
                SqlCmd.CommandText = "mostrarDetalleEquipo";
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

        public DataTable BuscarNombre(DDetalleEquipo DetalleEquipo)
        {
            DataTable DtResultado = new DataTable("detalleEquipo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "buscarDetalleEquipo";
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
                ParIdOrden.Value = DetalleEquipo.IdOrden;
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