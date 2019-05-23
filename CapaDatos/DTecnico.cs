using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTecnico
    {
        private int _IdTecnico;
        private string _Nombre;
        private string _Paterno;
        private string _Materno;
        private int _Telefono;
        private string _CI;

        private string _TextoBuscar;

        public int IdTecnico { get => _IdTecnico; set => _IdTecnico = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Paterno { get => _Paterno; set => _Paterno = value; }
        public string Materno { get => _Materno; set => _Materno = value; }
        public int Telefono { get => _Telefono; set => _Telefono = value; }
        public string CI { get => _CI; set => _CI = value; }

        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public DTecnico()
        {

        }

        public DTecnico(int idTecnico, string nombre, string paterno, string materno, int telefono, string ci, string textoBuscar)
        {
            this.IdTecnico = idTecnico;
            this.Nombre = nombre;
            this.Paterno = paterno;
            this.Materno = materno;
            this.Telefono = telefono;
            this.CI = ci;
            this.TextoBuscar = textoBuscar;
        }

        public string Insertar(DTecnico Tecnico)
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
                SqlCmd.CommandText = "insertarTecnico";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTecnico = new SqlParameter();
                ParIdTecnico.ParameterName = "@idTecnico";
                ParIdTecnico.SqlDbType = SqlDbType.Int;
                ParIdTecnico.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdTecnico);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Tecnico.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParPaterno = new SqlParameter();
                ParPaterno.ParameterName = "@paterno";
                ParPaterno.SqlDbType = SqlDbType.VarChar;
                ParPaterno.Size = 50;
                ParPaterno.Value = Tecnico.Paterno;
                SqlCmd.Parameters.Add(ParPaterno);

                SqlParameter ParMaterno = new SqlParameter();
                ParMaterno.ParameterName = "@materno";
                ParMaterno.SqlDbType = SqlDbType.VarChar;
                ParMaterno.Size = 50;
                ParMaterno.Value = Tecnico.Materno;
                SqlCmd.Parameters.Add(ParMaterno);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.Int;
                ParTelefono.Value = Tecnico.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);


                SqlParameter ParCI = new SqlParameter();
                ParCI.ParameterName = "@ci";
                ParCI.SqlDbType = SqlDbType.VarChar;
                ParCI.Size = 20;
                ParCI.Value = Tecnico.CI;
                SqlCmd.Parameters.Add(ParCI);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "El Nombre del Tecnico ya Existe";

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

        public string Editar(DTecnico Tecnico)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "modificarTecnico";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTecnico = new SqlParameter();
                ParIdTecnico.ParameterName = "@idTecnico";
                ParIdTecnico.SqlDbType = SqlDbType.Int;
                ParIdTecnico.Value = Tecnico.IdTecnico;
                SqlCmd.Parameters.Add(ParIdTecnico);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Tecnico.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParPaterno = new SqlParameter();
                ParPaterno.ParameterName = "@paterno";
                ParPaterno.SqlDbType = SqlDbType.VarChar;
                ParPaterno.Size = 50;
                ParPaterno.Value = Tecnico.Paterno;
                SqlCmd.Parameters.Add(ParPaterno);

                SqlParameter ParMaterno = new SqlParameter();
                ParMaterno.ParameterName = "@materno";
                ParMaterno.SqlDbType = SqlDbType.VarChar;
                ParMaterno.Size = 50;
                ParMaterno.Value = Tecnico.Materno;
                SqlCmd.Parameters.Add(ParMaterno);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.Int;
                ParTelefono.Value = Tecnico.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParCI = new SqlParameter();
                ParCI.ParameterName = "@ci";
                ParCI.SqlDbType = SqlDbType.VarChar;
                ParCI.Size = 20;
                ParCI.Value = Tecnico.CI;
                SqlCmd.Parameters.Add(ParCI);

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

        public string Eliminar(DTecnico Tecnico)
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
                SqlCmd.CommandText = "eliminarTecnico";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTecnico = new SqlParameter();
                ParIdTecnico.ParameterName = "@idTecnico";
                ParIdTecnico.SqlDbType = SqlDbType.Int;
                ParIdTecnico.Value = Tecnico.IdTecnico;
                SqlCmd.Parameters.Add(ParIdTecnico);


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

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("tecnico");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "mostrarTecnico";
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


        public DataTable BuscarNombre(DTecnico Tecnico)
        {
            DataTable DtResultado = new DataTable("Tecnico");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "buscarTecnico";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Tecnico.TextoBuscar;
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