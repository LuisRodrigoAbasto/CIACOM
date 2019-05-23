using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NRepuesto
    {

        public static string Insertar(string descripcion, string marca, int stock, float precio)
        {
            DRepuesto Obj = new DRepuesto();
            Obj.Descripcion = descripcion;
            Obj.Marca = marca;
            Obj.Stock = stock;
            Obj.Precio = precio;
            
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idRepuesto, string descripcion, string marca, int stock, float precio)
        {
            DRepuesto Obj = new DRepuesto();
            Obj.IdRepuesto = idRepuesto;
            Obj.Descripcion = descripcion;
            Obj.Marca = marca;
            Obj.Stock = stock;
            Obj.Precio = precio;

            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idRepuesto)
        {
            DRepuesto Obj = new DRepuesto();
            Obj.IdRepuesto = idRepuesto;

            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DRepuesto().Mostrar();
        }

        public static DataTable BuscarNombre(string textoBuscar)
        {
            DRepuesto Obj = new DRepuesto();
            Obj.TextoBuscar = textoBuscar;
            return Obj.BuscarNombre(Obj);
        }

    }
}
