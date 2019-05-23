using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalleTrabajo
    {
        private int _IdTrabajo;
        private int _IdOrden;

        private string _TextoBuscar;

        public int IdTrabajo { get => _IdTrabajo; set => _IdTrabajo = value; }
        public int IdOrden { get => _IdOrden; set => _IdOrden = value; }


        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }


        public DDetalleTrabajo()
        {

        }

        public DDetalleTrabajo(int idTrabajo, int idOrden, string textoBuscar)
        {
            this.IdTrabajo=idTrabajo;
            this.IdOrden = idOrden;

            this.TextoBuscar = textoBuscar;
        }

        public string Insertar(DDetalleTrabajo DetalleTrabajo)
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
                SqlCmd.CommandText = "insertarDetalleTrabajo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTrabajo = new SqlParameter();
                ParIdTrabajo.ParameterName = "@idTrabajo";
                ParIdTrabajo.SqlDbType = SqlDbType.Int;
                ParIdTrabajo.Value = DetalleTrabajo.IdTrabajo;
                SqlCmd.Parameters.Add(ParIdTrabajo);

                SqlParameter ParIdOrden = new SqlParameter();
                ParIdOrden.ParameterName = "@idOrden";
                ParIdOrden.SqlDbType = SqlDbType.Int;
                ParIdOrden.Value = DetalleTrabajo.IdOrden;
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

        public string Editar(DDetalleTrabajo DetalleTrabajo)
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
                SqlCmd.CommandText = "modificarDetalleTrabajo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTrabajo = new SqlParameter();
                ParIdTrabajo.ParameterName = "@idTrabajo";
                ParIdTrabajo.SqlDbType = SqlDbType.Int;
                ParIdTrabajo.Value = DetalleTrabajo.IdTrabajo;
                SqlCmd.Parameters.Add(ParIdTrabajo);

                SqlParameter ParIdOrden = new SqlParameter();
                ParIdOrden.ParameterName = "@idOrden";
                ParIdOrden.SqlDbType = SqlDbType.Int;
                ParIdOrden.Value = DetalleTrabajo.IdOrden;
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

        public string Eliminar(DDetalleTrabajo DetalleTrabajo)
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
                SqlCmd.CommandText = "eliminarDetalletrabajo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

              /*  SqlParameter ParIdTrabajo = new SqlParameter();
                ParIdTrabajo.ParameterName = "@idTrabajo";
                ParIdTrabajo.SqlDbType = SqlDbType.Int;
                ParIdTrabajo.Value = DetalleTrabajo.IdTrabajo;
                SqlCmd.Parameters.Add(ParIdTrabajo);*/

                SqlParameter ParIdOrden = new SqlParameter();
                ParIdOrden.ParameterName = "@idOrden";
                ParIdOrden.SqlDbType = SqlDbType.Int;
                ParIdOrden.Value = DetalleTrabajo.IdOrden;
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
            DataTable DtResultado = new DataTable("detalleTrabajo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "mostrarDetalleTrabajo";
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

        public DataTable BuscarNombre(DDetalleTrabajo DetalleTrabajo)
        {
            DataTable DtResultado = new DataTable("detalleTrabajo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "buscarDetalleTrabajo";
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
                ParIdOrden.Value = DetalleTrabajo.IdOrden;
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