using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NProducto
    {

        public static string Insertar(string modelo, string descripcion, float precio, int stock
         ,string idMarca, string idCategoria)
        {
            DProducto Obj = new DProducto();
            Obj.Modelo = modelo;
            Obj.Descripcion = descripcion;
            Obj.Precio = precio;
            Obj.Stock = stock;
            Obj.IdMarca = idMarca;
            Obj.IdCategoria = idCategoria;

            return Obj.Insertar(Obj);
        }

        public static string Editar(int idProducto, string modelo, string descripcion, float precio, int stock
         , string idMarca, string idCategoria)
        {
            DProducto Obj = new DProducto();
            Obj.IdProducto = idProducto;
            Obj.Modelo = modelo;
            Obj.Descripcion = descripcion;
            Obj.Precio = precio;
            Obj.Stock = stock;
            Obj.IdMarca = idMarca;
            Obj.IdCategoria = idCategoria;

            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idProducto)
        {
            DProducto Obj = new DProducto();
            Obj.IdProducto = idProducto;

            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DProducto().Mostrar();
        }

        public static DataTable BuscarNombre(string textoBuscar, string opcion)
        {
            DProducto Obj = new DProducto();
            Obj.TextoBuscar = textoBuscar;
            Obj.Opcion = opcion;
            return Obj.BuscarNombre(Obj);
        }
      

    }
}
