using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DEquipo
    {
        private int _IdEquipo;
        private string _Nombre;
        private string _Descripcion;
        private string _Modelo;
        private string _Marca;
        private string _Serie;
        
        private string _TextoBuscar;

        public int IdEquipo { get => _IdEquipo; set => _IdEquipo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Modelo { get => _Modelo; set => _Modelo = value; }
        public string Marca { get => _Marca; set => _Marca = value; }
        public string Serie { get => _Serie; set => _Serie = value; }

        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public DEquipo()
        {

        }

        public DEquipo(int idEquipo,string nombre,string descripcion, string modelo, string marca,string serie, string textoBuscar)
        {
            this.IdEquipo = idEquipo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Modelo = modelo;
            this.Marca = marca;
            this.Serie = serie;


            this.TextoBuscar = textoBuscar;
        }

        public string Insertar(DEquipo Equipo)
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
                SqlCmd.CommandText = "insertarEquipo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdEquipo = new SqlParameter();
                ParIdEquipo.ParameterName = "@idEquipo";
                ParIdEquipo.SqlDbType = SqlDbType.Int;
                ParIdEquipo.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdEquipo);

                SqlParameter ParNombre= new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Equipo.Modelo;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Equipo.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParModelo = new SqlParameter();
                ParModelo.ParameterName = "@modelo";
                ParModelo.SqlDbType = SqlDbType.VarChar;
                ParModelo.Size = 50;
                ParModelo.Value = Equipo.Modelo;
                SqlCmd.Parameters.Add(ParModelo);

                SqlParameter ParMarca= new SqlParameter();
                ParMarca.ParameterName = "@marca";
                ParMarca.SqlDbType = SqlDbType.VarChar;
                ParMarca.Size = 50;
                ParMarca.Value = Equipo.Marca;
                SqlCmd.Parameters.Add(ParMarca);

                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@serie";
                ParSerie.SqlDbType = SqlDbType.VarChar;
                ParSerie.Size = 50;
                ParSerie.Value = Equipo.Serie;
                SqlCmd.Parameters.Add(ParSerie);



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

        public string Editar(DEquipo Equipo)
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
                    SqlCmd.CommandText = "modificarEquipo";
                    SqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter ParIdEquipo = new SqlParameter();
                    ParIdEquipo.ParameterName = "@idEquipo";
                    ParIdEquipo.SqlDbType = SqlDbType.Int;
                    ParIdEquipo.Value = Equipo.IdEquipo;
                    SqlCmd.Parameters.Add(ParIdEquipo);

                    SqlParameter ParNombre = new SqlParameter();
                    ParNombre.ParameterName = "@nombre";
                    ParNombre.SqlDbType = SqlDbType.VarChar;
                    ParNombre.Size = 50;
                    ParNombre.Value = Equipo.Modelo;
                    SqlCmd.Parameters.Add(ParNombre);

                    SqlParameter ParDescripcion = new SqlParameter();
                    ParDescripcion.ParameterName = "@descripcion";
                    ParDescripcion.SqlDbType = SqlDbType.VarChar;
                    ParDescripcion.Size = 100;
                    ParDescripcion.Value = Equipo.Descripcion;
                    SqlCmd.Parameters.Add(ParDescripcion);

                    SqlParameter ParModelo = new SqlParameter();
                    ParModelo.ParameterName = "@modelo";
                    ParModelo.SqlDbType = SqlDbType.VarChar;
                    ParModelo.Size = 50;
                    ParModelo.Value = Equipo.Modelo;
                    SqlCmd.Parameters.Add(ParModelo);

                    SqlParameter ParMarca = new SqlParameter();
                    ParMarca.ParameterName = "@marca";
                    ParMarca.SqlDbType = SqlDbType.VarChar;
                    ParMarca.Size = 50;
                    ParMarca.Value = Equipo.Marca;
                    SqlCmd.Parameters.Add(ParMarca);

                    SqlParameter ParSerie = new SqlParameter();
                    ParSerie.ParameterName = "@serie";
                    ParSerie.SqlDbType = SqlDbType.VarChar;
                    ParSerie.Size = 50;
                    ParSerie.Value = Equipo.Serie;
                    SqlCmd.Parameters.Add(ParSerie);



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


            public string Eliminar(DEquipo Equipo)
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
                SqlCmd.CommandText = "eliminarEquipo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdEquipo = new SqlParameter();
                ParIdEquipo.ParameterName = "@idEquipo";
                ParIdEquipo.SqlDbType = SqlDbType.Int;
                ParIdEquipo.Value = Equipo.IdEquipo;
                SqlCmd.Parameters.Add(ParIdEquipo);

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
            DataTable DtResultado = new DataTable("equipo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "mostrarEquipo";
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

        public DataTable BuscarNombre(DEquipo Equipo)
        {
            DataTable DtResultado = new DataTable("equipo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "buscarEquipo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Equipo.TextoBuscar;
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
