using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NOrden
    {
        public static string Insertar(DateTime fechaEntrada, float montoTotal,
            int empleado,int cliente, int tecnico)
        {
            DOrden Obj = new DOrden();
            Obj.FechaEntrada = fechaEntrada;
            Obj.MontoTotal = montoTotal;
            Obj.IdEmpleado = empleado;
            Obj.IdCliente = cliente;
            Obj.IdTecnico = tecnico;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idOrden, DateTime fechaSalida, float montoTotal,
            int empleado, int cliente, int tecnico)
        {
            DOrden Obj = new DOrden();
            Obj.IdOrden = idOrden;
            Obj.FechaSalida = fechaSalida;
            Obj.MontoTotal = montoTotal;
            Obj.IdEmpleado = empleado;
            Obj.IdCliente = cliente;
            Obj.IdTecnico = tecnico;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idOrden)
        {
            DOrden Obj = new DOrden();
            Obj.IdOrden = idOrden;

            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DOrden().Mostrar();
        }

        public static DataTable BuscarNombre(string textoBuscar, string opcion)
        {
            DOrden Obj = new DOrden();
            Obj.Opcion = opcion;
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNombre(Obj);
        }


    }
}
