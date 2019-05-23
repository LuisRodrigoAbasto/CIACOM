using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;
namespace CapaNegocio
{
    public class NEmpleado
    {
        public static string Insertar(string nombre, string paterno, string materno, int telefono, string ci)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.Nombre = nombre;
            Obj.Paterno = paterno;
            Obj.Materno = materno;
            Obj.Telefono = telefono;
            Obj.CI = ci;

            return Obj.Insertar(Obj);
        }

        public static string Editar(int idEmpleado, string nombre, string paterno, string materno, int telefono, string ci)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.IdEmpleado = idEmpleado;
            Obj.Nombre = nombre;
            Obj.Paterno = paterno;
            Obj.Materno = materno;
            Obj.Telefono = telefono;
            Obj.CI = ci;

            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idEmpleado)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.IdEmpleado = idEmpleado;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DEmpleado().Mostrar();
        }

        public static DataTable BuscarNombre(string textoBuscar)
        {
            DEmpleado Obj = new DEmpleado();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNombre(Obj);
        }

    }
}
