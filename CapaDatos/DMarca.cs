using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DMarca
    {
        private int _IdMarca;
        private string _Nombre;

        private string _TextoBuscar;

    

        public int IdMarca { get => _IdMarca; set => _IdMarca = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //COntructor Vacio
        public DMarca()
        {

        }

        public DMarca(int idMarca, string nombre, string textoBuscar)
        {
            this.IdMarca = idMarca;
            this.Nombre = nombre;
            this.TextoBuscar = textoBuscar;

        }

        ///metodo Insertar
        public string Insertar(DMarca Marca)
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
                SqlCmd.CommandText = "insertarMarca";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdMarca = new SqlParameter();
                ParIdMarca.ParameterName = "@idMarca";
                ParIdMarca.SqlDbType = SqlDbType.Int;
                ParIdMarca.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdMarca);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Marca.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

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
        public string Editar(DMarca Marca)
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
                SqlCmd.CommandText = "modificarMarca";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdMarca = new SqlParameter();
                ParIdMarca.ParameterName = "@idMarca";
                ParIdMarca.SqlDbType = SqlDbType.Int;
                ParIdMarca.Value = Marca.IdMarca;
                SqlCmd.Parameters.Add(ParIdMarca);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Marca.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

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
        public string Eliminar(DMarca Marca)
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
                SqlCmd.CommandText = "eliminarMarca";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdMarca = new SqlParameter();
                ParIdMarca.ParameterName = "@idMarca";
                ParIdMarca.SqlDbType = SqlDbType.Int;
                ParIdMarca.Value = Marca.IdMarca;
                SqlCmd.Parameters.Add(ParIdMarca);


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
            DataTable DtResultado = new DataTable("marca");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "mostrarMarca";
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
        public DataTable BuscarNombre(DMarca Marca)
        {
            DataTable DtResultado = new DataTable("marca");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "buscarMarca";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Marca.TextoBuscar;
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