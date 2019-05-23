using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NVenta
    {


        public static string Insertar(DateTime fecha, float montoVenta, int cliente, int empleado)
        {
            DVenta Obj = new DVenta();
            Obj.Fecha = fecha;
            Obj.MontoVenta = montoVenta;
            Obj.IdCliente = cliente;
            Obj.IdEmpleado = empleado;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idVenta, DateTime fecha, float montoVenta, int cliente, int empleado)
        {
            DVenta Obj = new DVenta();
            Obj.IdVenta = idVenta;
            Obj.Fecha = fecha;
            Obj.MontoVenta = montoVenta;
            Obj.IdCliente = cliente;
            Obj.IdEmpleado = empleado;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idVenta)
        {
            DVenta Obj = new DVenta();
            Obj.IdVenta = idVenta;

            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DVenta().Mostrar();
        }

        public static DataTable BuscarNombre(string textoBuscar, string opcion)
        {
            DVenta Obj = new DVenta();
            Obj.Opcion = opcion;
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNombre(Obj);
        }


    }
}
