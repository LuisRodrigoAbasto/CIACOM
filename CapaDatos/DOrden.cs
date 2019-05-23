using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DOrden
    {
        private int _IdOrden;
        private DateTime _FechaEntrada;
        private DateTime _FechaSalida;
        private float _MontoTotal;
        private int _IdEmpleado;
        private int _IdCliente;
        private int _IdTecnico;

        private string _TextoBuscar;
        private string _Opcion;

        public int IdOrden { get => _IdOrden; set => _IdOrden = value; }
        public DateTime FechaEntrada { get => _FechaEntrada; set => _FechaEntrada = value; }
        public DateTime FechaSalida { get => _FechaSalida; set => _FechaSalida = value; }
        public float MontoTotal { get => _MontoTotal; set => _MontoTotal = value; }
        public int IdEmpleado { get => _IdEmpleado; set => _IdEmpleado = value; }
        public int IdCliente { get => _IdCliente; set => _IdCliente = value; }
        public int IdTecnico { get => _IdTecnico; set => _IdTecnico = value; }

        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        public string Opcion { get => _Opcion; set => _Opcion = value; }

        public DOrden()
        {

        }

        public DOrden(int idOrden,DateTime fechaEntrada,DateTime fechaSalida, float montoTotal,int idEmpleado,
            int idCliente,int idTecnico,string textoBuscar, string opcion)
        {
            this.IdOrden = idOrden;
            this.FechaEntrada = fechaEntrada;
            this.FechaSalida = fechaSalida;
            this.MontoTotal = montoTotal;
            this.IdEmpleado = idEmpleado;
            this.IdCliente = idCliente;
            this.IdTecnico = idTecnico;
            this.TextoBuscar = textoBuscar;
            this.Opcion = opcion;
        }

        public string Insertar(DOrden Orden)
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
                SqlCmd.CommandText = "insertarOrdenServicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdOrden = new SqlParameter();
                ParIdOrden.ParameterName = "@idOrden";
                ParIdOrden.SqlDbType = SqlDbType.Int;
                ParIdOrden.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdOrden);

                SqlParameter ParFechaEntrada = new SqlParameter();
                ParFechaEntrada.ParameterName = "@fechaEntrada";
                ParFechaEntrada.SqlDbType = SqlDbType.Date;
                ParFechaEntrada.Value = Orden.FechaEntrada;
                SqlCmd.Parameters.Add(ParFechaEntrada);

              /*  SqlParameter ParFechaSalida = new SqlParameter();
                ParFechaSalida.ParameterName = "@fechaSalida";
                ParFechaSalida.SqlDbType = SqlDbType.Date;
                ParFechaSalida.Value = Orden.FechaSalida;
                SqlCmd.Parameters.Add(ParFechaSalida);*/

                SqlParameter ParMonto = new SqlParameter();
                ParMonto.ParameterName = "@montoTotal";
                ParMonto.SqlDbType = SqlDbType.Money;
                ParMonto.Value = Orden.MontoTotal;
                SqlCmd.Parameters.Add(ParMonto);

                SqlParameter ParEmpleado = new SqlParameter();
                ParEmpleado.ParameterName = "@empleado";
                ParEmpleado.SqlDbType = SqlDbType.Int;
                ParEmpleado.Value = Orden.IdEmpleado;
                SqlCmd.Parameters.Add(ParEmpleado);

                SqlParameter ParCliente = new SqlParameter();
                ParCliente.ParameterName = "@cliente";
                ParCliente.SqlDbType = SqlDbType.Int;
                ParCliente.Value = Orden.IdCliente;
                SqlCmd.Parameters.Add(ParCliente);

                SqlParameter ParTecnico = new SqlParameter();
                ParTecnico.ParameterName = "@tecnico";
                ParTecnico.SqlDbType = SqlDbType.Int;
                ParTecnico.Value =Orden.IdTecnico;
                SqlCmd.Parameters.Add(ParTecnico);

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


        public string Editar(DOrden Orden)
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
                SqlCmd.CommandText = "modificarOrdenServicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdOrden = new SqlParameter();
                ParIdOrden.ParameterName = "@idOrden";
                ParIdOrden.SqlDbType = SqlDbType.Int;
                ParIdOrden.Value = Orden.IdOrden;
                SqlCmd.Parameters.Add(ParIdOrden);

             /*   SqlParameter ParFechaEntrada = new SqlParameter();
                ParFechaEntrada.ParameterName = "@fechaEntrada";
                ParFechaEntrada.SqlDbType = SqlDbType.Date;
                ParFechaEntrada.Value = Orden.FechaEntrada;
                SqlCmd.Parameters.Add(ParFechaEntrada);*/

                SqlParameter ParFechaSalida = new SqlParameter();
                ParFechaSalida.ParameterName = "@fechaSalida";
                ParFechaSalida.SqlDbType = SqlDbType.Date;
                ParFechaSalida.Value = Orden.FechaSalida;
                SqlCmd.Parameters.Add(ParFechaSalida);

                SqlParameter ParMonto = new SqlParameter();
                ParMonto.ParameterName = "@montoTotal";
                ParMonto.SqlDbType = SqlDbType.Money;
                ParMonto.Value = Orden.MontoTotal;
                SqlCmd.Parameters.Add(ParMonto);

                SqlParameter ParEmpleado = new SqlParameter();
                ParEmpleado.ParameterName = "@empleado";
                ParEmpleado.SqlDbType = SqlDbType.VarChar;
                ParEmpleado.Size = 50;
                ParEmpleado.Value = Orden.IdEmpleado;
                SqlCmd.Parameters.Add(ParEmpleado);

                SqlParameter ParCliente = new SqlParameter();
                ParCliente.ParameterName = "@cliente";
                ParCliente.SqlDbType = SqlDbType.VarChar;
                ParCliente.Size = 50;
                ParCliente.Value = Orden.IdCliente;
                SqlCmd.Parameters.Add(ParCliente);

                SqlParameter ParTecnico = new SqlParameter();
                ParTecnico.ParameterName = "@tecnico";
                ParTecnico.SqlDbType = SqlDbType.VarChar;
                ParTecnico.Size = 50;
                ParTecnico.Value = Orden.IdTecnico;
                SqlCmd.Parameters.Add(ParTecnico);

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

        public string Eliminar(DOrden Orden)
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
                SqlCmd.CommandText = "EliminarOrdenServicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdOrden = new SqlParameter();
                ParIdOrden.ParameterName = "@idOrden";
                ParIdOrden.SqlDbType = SqlDbType.Int;
                ParIdOrden.Value = Orden.IdOrden;
                SqlCmd.Parameters.Add(ParIdOrden);
                

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Puede Eliminar el Orden Servicio";

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
            DataTable DtResultado = new DataTable("ordenServicio");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "mostrarOrdenServicio";
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

        public DataTable BuscarNombre(DOrden Orden)
        {
            DataTable DtResultado = new DataTable("ordenServico");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "buscarOrdenServicio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParOpcion = new SqlParameter();
                ParOpcion.ParameterName = "@opcion";
                ParOpcion.SqlDbType = SqlDbType.VarChar;
                ParOpcion.Size = 50;
                ParOpcion.Value = Orden.Opcion;
                SqlCmd.Parameters.Add(ParOpcion);

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value =Orden.TextoBuscar;
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
