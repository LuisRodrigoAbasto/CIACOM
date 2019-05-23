using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NTrabajo
    {
        public static string Insertar(string nombre, float precio)
        {
            DTrabajo Obj = new DTrabajo();
            Obj.Nombre = nombre;
            Obj.Precio = precio;
            return Obj.Insertar(Obj);
        }
        /// metodo editar que llama al metodo editar de la clase Dcategoria
        public static string Editar(int idTrabajo, string nombre, float precio)
        {
            DTrabajo Obj = new DTrabajo();
            Obj.IdTrabajo = idTrabajo;
            Obj.Nombre = nombre;
            Obj.Precio = precio;
            return Obj.Editar(Obj);
        }

        // metodo Eliminar
        public static string Eliminar(int idTrabajo)
        {
            DTrabajo Obj = new DTrabajo();
            Obj.IdTrabajo = idTrabajo;
            return Obj.Eliminar(Obj);
        }

        // metodo Mostrar
        public static DataTable Mostrar()
        {
            return new DTrabajo().Mostrar();
        }

        // metodo Buscar Nombre
        public static DataTable BuscarNombre(string textoBuscar)
        {
            DTrabajo Obj = new DTrabajo();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
