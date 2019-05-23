using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
namespace CapaNegocio
{
    public class NTecnico
    {
        public static string Insertar(string nombre, string paterno, string materno, int telefono, string ci)
        {
            DTecnico Obj = new DTecnico();
            Obj.Nombre = nombre;
            Obj.Paterno = paterno;
            Obj.Materno = materno;
            Obj.Telefono = telefono;
            Obj.CI = ci;

            return Obj.Insertar(Obj);
        }

        public static string Editar(int idTecnico, string nombre, string paterno, string materno, int telefono, string ci)
        {
            DTecnico Obj = new DTecnico();
            Obj.IdTecnico = idTecnico;
            Obj.Nombre = nombre;
            Obj.Paterno = paterno;
            Obj.Materno = materno;
            Obj.Telefono = telefono;
            Obj.CI = ci;

            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idTecnico)
        {
            DTecnico Obj = new DTecnico();
            Obj.IdTecnico = idTecnico;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DTecnico().Mostrar();
        }

        public static DataTable BuscarNombre(string textoBuscar)
        {
            DTecnico Obj = new DTecnico();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNombre(Obj);
        }

    }
}
