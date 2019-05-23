using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;
namespace CapaNegocio
{
    public class NCliente
    {
        public static string Insertar(string nombre, string paterno, string materno, int telefono, string ci)
        {
            DCliente Obj = new DCliente();
            Obj.Nombre = nombre;
            Obj.Paterno = paterno;
            Obj.Materno = materno;
            Obj.Telefono = telefono;
            Obj.CI = ci;

            return Obj.Insertar(Obj);
        }

        public static string Editar(int idCliente, string nombre, string paterno, string materno, int telefono, string ci)
        {
            DCliente Obj = new DCliente();
            Obj.IdCliente = idCliente;
            Obj.Nombre = nombre;
            Obj.Paterno = paterno;
            Obj.Materno = materno;
            Obj.Telefono = telefono;
            Obj.CI = ci;

            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idCliente)
        {
            DCliente Obj = new DCliente();
            Obj.IdCliente = idCliente;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }

        public static DataTable BuscarNombre(string textoBuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNombre(Obj);
        }

    }
}
