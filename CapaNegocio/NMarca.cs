using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
   public class NMarca
    {
        public static string Insertar(string nombre)
        {
            DMarca Obj = new DMarca();
            Obj.Nombre = nombre;
            return Obj.Insertar(Obj);
        }
        /// metodo editar que llama al metodo editar de la clase Dcategoria
        public static string Editar(int idMarca, string nombre)
        {
            DMarca Obj = new DMarca();
            Obj.IdMarca = idMarca;
            Obj.Nombre = nombre;
            return Obj.Editar(Obj);
        }

        // metodo Eliminar
        public static string Eliminar(int idMarca)
        {
            DMarca Obj = new DMarca();
            Obj.IdMarca = idMarca;
            return Obj.Eliminar(Obj);
        }

        // metodo Mostrar
        public static DataTable Mostrar()
        {
            return new DMarca().Mostrar();
        }

        // metodo Buscar Nombre
        public static DataTable BuscarNombre(string textoBuscar)
        {
            DMarca Obj = new DMarca();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
