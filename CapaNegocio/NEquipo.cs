using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NEquipo
    {
        public static string Insertar(string nombre, string descripcion, string modelo, string marca, string serie)
        {
            DEquipo Obj = new DEquipo();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Modelo = modelo;
            Obj.Marca = marca;
            Obj.Serie = serie;

            return Obj.Insertar(Obj);
        }

        public static string Editar(int idEquipo, string nombre, string descripcion, string modelo, string marca, string serie)
        {
            DEquipo Obj = new DEquipo();
            Obj.IdEquipo = idEquipo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Modelo = modelo;
            Obj.Marca = marca;
            Obj.Serie = serie;

            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idEquipo)
        {
            DEquipo Obj = new DEquipo();
            Obj.IdEquipo = idEquipo;

            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DEquipo().Mostrar();
        }

        public static DataTable BuscarNombre(string textoBuscar)
        {
            DEquipo Obj = new DEquipo();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNombre(Obj);
        }

    }
}
