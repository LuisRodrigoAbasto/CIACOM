using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DEmpleado
    {
        private int _IdEmpleado;
        private string _Nombre;
        private string _Paterno;
        private string _Materno;
        private int _Telefono;
        private string _CI;

        private string _TextoBuscar;

        public int IdEmpleado { get => _IdEmpleado; set => _IdEmpleado = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Paterno { get => _Paterno; set => _Paterno = value; }
        public string Materno { get => _Materno; set => _Materno = value; }
        public int Telefono { get => _Telefono; set => _Telefono = value; }
        public string CI { get => _CI; set => _CI = value; }

        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        

        public DEmpleado()
        {

        }

        public DEmpleado(int idEmpleado, string nombre, string paterno, string materno, int telefono, string ci, string textoBuscar)
        {
            this.IdEmpleado = idEmpleado;
            this.Nombre = nombre;
            this.Paterno = paterno;
            this.Materno = materno;
            this.Telefono = telefono;
            this.CI = ci;
            this.TextoBuscar = textoBuscar;
        }

        public string Insertar(DEmpleado Empleado)
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
                SqlCmd.CommandText = "insertarEmpleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@idEmpleado";
                ParIdEmpleado.SqlDbType = SqlDbType.Int;
                ParIdEmpleado.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdEmpleado);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Empleado.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParPaterno = new SqlParameter();
                ParPaterno.ParameterName = "@paterno";
                ParPaterno.SqlDbType = SqlDbType.VarChar;
                ParPaterno.Size = 50;
                ParPaterno.Value = Empleado.Paterno;
                SqlCmd.Parameters.Add(ParPaterno);

                SqlParameter ParMaterno = new SqlParameter();
                ParMaterno.ParameterName = "@materno";
                ParMaterno.SqlDbType = SqlDbType.VarChar;
                ParMaterno.Size = 50;
                ParMaterno.Value = Empleado.Materno;
                SqlCmd.Parameters.Add(ParMaterno);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.Int;
                ParTelefono.Value = Empleado.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);


                SqlParameter ParCI = new SqlParameter();
                ParCI.ParameterName = "@ci";
                ParCI.SqlDbType = SqlDbType.VarChar;
                ParCI.Size = 20;
                ParCI.Value = Empleado.CI;
                SqlCmd.Parameters.Add(ParCI);

                

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "El Nombre del Empleado ya Existe";

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

        public string Editar(DEmpleado Empleado)
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
                SqlCmd.CommandText = "modificarEmpleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@idEmpleado";
                ParIdEmpleado.SqlDbType = SqlDbType.Int;
                ParIdEmpleado.Value = Empleado.IdEmpleado;
                SqlCmd.Parameters.Add(ParIdEmpleado);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Empleado.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParPaterno = new SqlParameter();
                ParPaterno.ParameterName = "@paterno";
                ParPaterno.SqlDbType = SqlDbType.VarChar;
                ParPaterno.Size = 50;
                ParPaterno.Value = Empleado.Paterno;
                SqlCmd.Parameters.Add(ParPaterno);

                SqlParameter ParMaterno = new SqlParameter();
                ParMaterno.ParameterName = "@materno";
                ParMaterno.SqlDbType = SqlDbType.VarChar;
                ParMaterno.Size = 50;
                ParMaterno.Value = Empleado.Materno;
                SqlCmd.Parameters.Add(ParMaterno);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.Int;
                ParTelefono.Value = Empleado.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);


                SqlParameter ParCI = new SqlParameter();
                ParCI.ParameterName = "@ci";
                ParCI.SqlDbType = SqlDbType.VarChar;
                ParCI.Size = 20;
                ParCI.Value = Empleado.CI;
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

        public string Eliminar(DEmpleado Empleado)
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
                SqlCmd.CommandText = "eliminarEmpleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@idEmpleado";
                ParIdEmpleado.SqlDbType = SqlDbType.Int;
                ParIdEmpleado.Value = Empleado.IdEmpleado;
                SqlCmd.Parameters.Add(ParIdEmpleado);


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
            DataTable DtResultado = new DataTable("empleado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "mostrarEmpleado";
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


        public DataTable BuscarNombre(DEmpleado Empleado)
        {
            DataTable DtResultado = new DataTable("empleado");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "buscarEmpleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Empleado.TextoBuscar;
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
