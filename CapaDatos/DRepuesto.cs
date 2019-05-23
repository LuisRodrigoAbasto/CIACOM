using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DRepuesto
    {
        private int _IdRepuesto;
        private string _Descripcion;
        private string _Marca;
        private int _Stock;
        private float _Precio;

        private string _TextoBuscar;

        public int IdRepuesto { get => _IdRepuesto; set => _IdRepuesto = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Marca { get => _Marca; set => _Marca = value; }
        public int Stock { get => _Stock; set => _Stock = value; }
        public float Precio { get => _Precio; set => _Precio = value; }

        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        

        public DRepuesto()
        {

        }

        public DRepuesto(int idRpuesto, string descripcion, string marca, int stock, float precio, string textoBuscar)
        {
            this.IdRepuesto = idRpuesto;
            this.Descripcion = descripcion;
            this.Marca = marca;
            this.Stock = stock;
            this.Precio = precio;
            this.TextoBuscar = textoBuscar;

            this.TextoBuscar = textoBuscar;
        }

        public string Insertar(DRepuesto Repuesto)
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
                SqlCmd.CommandText = "insertarRepuesto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdRepuesto = new SqlParameter();
                ParIdRepuesto.ParameterName = "@idRespuesto";
                ParIdRepuesto.SqlDbType = SqlDbType.Int;
                ParIdRepuesto.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdRepuesto);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Repuesto.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParMarca= new SqlParameter();
                ParMarca.ParameterName = "@marca";
                ParMarca.SqlDbType = SqlDbType.VarChar;
                ParMarca.Size = 50;
                ParMarca.Value = Repuesto.Marca;
                SqlCmd.Parameters.Add(ParMarca);

                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@Stock";
                ParSerie.SqlDbType = SqlDbType.Int;
                ParSerie.Value = Repuesto.Stock;
                SqlCmd.Parameters.Add(ParSerie);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Money;
                ParPrecio.Value = Repuesto.Precio;
                SqlCmd.Parameters.Add(ParPrecio);


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

        public string Editar(DRepuesto Repuesto)
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
                SqlCmd.CommandText = "modificarRepuesto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdRepuesto = new SqlParameter();
                ParIdRepuesto.ParameterName = "@idRespuesto";
                ParIdRepuesto.SqlDbType = SqlDbType.Int;
                ParIdRepuesto.Value = Repuesto.IdRepuesto;
                SqlCmd.Parameters.Add(ParIdRepuesto);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 100;
                ParDescripcion.Value = Repuesto.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParMarca = new SqlParameter();
                ParMarca.ParameterName = "@marca";
                ParMarca.SqlDbType = SqlDbType.VarChar;
                ParMarca.Size = 50;
                ParMarca.Value = Repuesto.Marca;
                SqlCmd.Parameters.Add(ParMarca);

                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@Stock";
                ParSerie.SqlDbType = SqlDbType.Int;
                ParSerie.Value = Repuesto.Stock;
                SqlCmd.Parameters.Add(ParSerie);

                SqlParameter ParPrecio = new SqlParameter();
                ParPrecio.ParameterName = "@precio";
                ParPrecio.SqlDbType = SqlDbType.Money;
                ParPrecio.Value = Repuesto.Precio;
                SqlCmd.Parameters.Add(ParPrecio);


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

        public string Eliminar(DRepuesto Repuesto)
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
                SqlCmd.CommandText = "eliminarRepuesto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdRepuesto = new SqlParameter();
                ParIdRepuesto.ParameterName = "@idRespuesto";
                ParIdRepuesto.SqlDbType = SqlDbType.Int;
                ParIdRepuesto.Value = Repuesto.IdRepuesto;
                SqlCmd.Parameters.Add(ParIdRepuesto);


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
            DataTable DtResultado = new DataTable("repuesto");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "mostrarRepuesto";
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

        public DataTable BuscarNombre(DRepuesto Repuesto)
        {
            DataTable DtResultado = new DataTable("repuesto");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "buscarRepuesto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Repuesto.TextoBuscar;
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
