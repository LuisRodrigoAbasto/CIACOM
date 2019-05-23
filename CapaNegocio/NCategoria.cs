using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NCategoria 
    {
        //metodo insertar que llam al metodo insertar de la 
        // clase DCategoria de la capa de DAtos
        public static string Insertar(string nombre)
        {
            DCategoria Obj = new DCategoria();
            Obj.Nombre = nombre;
            return Obj.Insertar(Obj);
        }
        /// metodo editar que llama al metodo editar de la clase Dcategoria
        public static string Editar(int idCategoria, string nombre)
        {
            DCategoria Obj = new DCategoria();
            Obj.IdCategoria = idCategoria;
            Obj.Nombre = nombre;
            return Obj.Editar(Obj);
        }

        // metodo Eliminar
        public static string Eliminar(int idCategoria)
        {
            DCategoria Obj = new DCategoria();
            Obj.IdCategoria = idCategoria;
            return Obj.Eliminar(Obj);
        }

        // metodo Mostrar
        public static DataTable Mostrar()
        {
            return new DCategoria().Mostrar();
        }

        // metodo Buscar Nombre
        public static DataTable BuscarNombre(string textoBuscar)
        {
            DCategoria Obj = new DCategoria();
            Obj.TextoBuscar = textoBuscar;
        
            return Obj.BuscarNombre(Obj);
        }
    }
}
