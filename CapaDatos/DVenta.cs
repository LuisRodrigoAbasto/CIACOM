using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DVenta
    {
        private int _IdVenta;
        private DateTime _Fecha;
        private float _MontoVenta;
        private int _IdCliente;
        private int _IdEmpleado;

        private string _TextoBuscar;
        private string _Opcion;

        public int IdVenta { get => _IdVenta; set => _IdVenta = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public float MontoVenta { get => _MontoVenta; set => _MontoVenta = value; }
        public int IdCliente { get => _IdCliente; set => _IdCliente = value; }
        public int IdEmpleado { get => _IdEmpleado; set => _IdEmpleado = value; }

        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        public string Opcion { get => _Opcion; set => _Opcion = value; }

        public DVenta()
        {

        }

        public DVenta(int idVenta, DateTime fecha, float montoVenta, int idCliente, int idEmpleado, string textoBuscar, string opcion)
        {
            this.IdVenta = idVenta;
            this.Fecha = fecha;
            this.MontoVenta = montoVenta;
            this.IdCliente = idCliente;
            this.IdEmpleado = idEmpleado;
            this.TextoBuscar = textoBuscar;
            this.Opcion = Opcion;
        }

        public string Insertar(DVenta Venta)
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
                SqlCmd.CommandText = "insertarNotaVenta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Venta.Fecha;
                SqlCmd.Parameters.Add(ParFecha);
                               
                SqlParameter ParMontoVenta = new SqlParameter();
                ParMontoVenta.ParameterName = "@montoVenta";
                ParMontoVenta.SqlDbType = SqlDbType.Money;
                ParMontoVenta.Value = Venta.MontoVenta;
                SqlCmd.Parameters.Add(ParMontoVenta);
                                
                SqlParameter ParCliente = new SqlParameter();
                ParCliente.ParameterName = "@idCliente";
                ParCliente.SqlDbType = SqlDbType.Int;
                ParCliente.Value = Venta.IdCliente;
                SqlCmd.Parameters.Add(ParCliente);

                SqlParameter ParEmpleado = new SqlParameter();
                ParEmpleado.ParameterName = "@idEmpleado";
                ParEmpleado.SqlDbType = SqlDbType.Int;
                ParEmpleado.Value = Venta.IdEmpleado;
                SqlCmd.Parameters.Add(ParEmpleado);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Puede Resgistrar la Venta";

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

        public string Editar(DVenta Venta)
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
                SqlCmd.CommandText = "modificarNotaVenta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParVenta = new SqlParameter();
                ParVenta.ParameterName = "@idVenta";
                ParVenta.SqlDbType = SqlDbType.Int;
                ParVenta.Value = Venta.IdVenta;
                SqlCmd.Parameters.Add(ParVenta);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Venta.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParMontoVenta = new SqlParameter();
                ParMontoVenta.ParameterName = "@montoVenta";
                ParMontoVenta.SqlDbType = SqlDbType.Money;
                ParMontoVenta.Value = Venta.MontoVenta;
                SqlCmd.Parameters.Add(ParMontoVenta);

                SqlParameter ParCliente = new SqlParameter();
                ParCliente.ParameterName = "@idCliente";
                ParCliente.SqlDbType = SqlDbType.Int;
                ParCliente.Value = Venta.IdCliente;
                SqlCmd.Parameters.Add(ParCliente);

                SqlParameter ParEmpleado = new SqlParameter();
                ParEmpleado.ParameterName = "@idEmpleado";
                ParEmpleado.SqlDbType = SqlDbType.Int;
                ParEmpleado.Value = Venta.IdEmpleado;
                SqlCmd.Parameters.Add(ParEmpleado);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Puede actualizar la Venta";

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


        public string Eliminar(DVenta Venta)
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
                SqlCmd.CommandText = "eliminarNotaVenta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Venta.IdVenta;
                SqlCmd.Parameters.Add(ParIdVenta);

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
            DataTable DtResultado = new DataTable("notaVenta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "mostrarNotaVenta";
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

        public DataTable BuscarNombre(DVenta Venta)
        {
            DataTable DtResultado = new DataTable("notaVenta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "buscarNotaVenta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParOpcion = new SqlParameter();
                ParOpcion.ParameterName = "@opcion";
                ParOpcion.SqlDbType = SqlDbType.VarChar;
                ParOpcion.Size = 50;
                ParOpcion.Value = Venta.Opcion;
                SqlCmd.Parameters.Add(ParOpcion);

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Venta.TextoBuscar;
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
