using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTrabajo
    {
        private int _IdTrabajo;
        private string _Nombre;
        private float _Precio;

        private string _TextoBuscar;



        public int IdTrabajo { get => _IdTrabajo; set => _IdTrabajo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public float Precio { get => _Precio; set => _Precio = value; }

        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        

        //COntructor Vacio
        public DTrabajo()
        {

        }

        public DTrabajo(int idTrabajo, string nombre,float precio, string textoBuscar)
        {
            this.IdTrabajo = idTrabajo;
            this.Nombre = nombre;
            this.Precio = precio;
            this.TextoBuscar = textoBuscar;

        }

        ///metodo Insertar
        public string Insertar(DTrabajo Trabajo)
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
                SqlCmd.CommandText = "insertarTrabajo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTrabajo= new SqlParameter();
                ParIdTrabajo.ParameterName = "@idTrabajo";
                ParIdTrabajo.SqlDbType = SqlDbType.Int;
                ParIdTrabajo.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdTrabajo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Trabajo.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Money;
                ParPrecio.Value = Trabajo.Precio;
                SqlCmd.Parameters.Add(ParPrecio);

                //ejecutamos CMD

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "El Nombre de la Marca ya Existe";

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

        //Metodo Editar
        public string Editar(DTrabajo Trabajo)
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
                SqlCmd.CommandText = "modificarTrabajo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTrabajo= new SqlParameter();
                ParIdTrabajo.ParameterName = "@idtrabajo";
                ParIdTrabajo.SqlDbType = SqlDbType.Int;
                ParIdTrabajo.Value = Trabajo.IdTrabajo;
                SqlCmd.Parameters.Add(ParIdTrabajo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Trabajo.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Money;
                ParPrecio.Value = Trabajo.Precio;
                SqlCmd.Parameters.Add(ParPrecio);

                //ejecutamos CMD

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizo el Registro";

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

        // Metodo Eliminar 
        public string Eliminar(DTrabajo Trabajo)
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
                SqlCmd.CommandText = "eliminarTrabajo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTrabajo = new SqlParameter();
                ParIdTrabajo.ParameterName = "@idTrabajo";
                ParIdTrabajo.SqlDbType = SqlDbType.Int;
                ParIdTrabajo.Value = Trabajo.IdTrabajo;
                SqlCmd.Parameters.Add(ParIdTrabajo);


                //ejecutamos CMD

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

        // Metodo Mostrar 
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("trabajo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "mostrarTrabajo";
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

        // Metodo Buscar Nombre
        public DataTable BuscarNombre(DTrabajo Trabajo)
        {
            DataTable DtResultado = new DataTable("trabajo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "buscarTrabajo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Trabajo.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);


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