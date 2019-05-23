using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NDetalleVenta
    {

        public static string Insertar(int cantidad, float precioVenta, int idProducto)
        {
            DDetalleVenta Obj = new DDetalleVenta();
            Obj.Cantidad = cantidad;
            Obj.PrecioVenta = precioVenta;      
            Obj.IdProducto= idProducto;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int cantidad, float precioVenta, int idVenta, int idProducto)
        {
            DDetalleVenta Obj = new DDetalleVenta();
            Obj.Cantidad = cantidad;
            Obj.PrecioVenta = precioVenta;
            Obj.IdVenta = idVenta;
            Obj.IdProducto = idProducto;
            return Obj.Editar(Obj);
        }
        public static string Eliminar(int idVenta)
        {
            DDetalleVenta Obj = new DDetalleVenta();
            Obj.IdVenta = idVenta;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DDetalleVenta().Mostrar();
        }

        public static DataTable Buscar(int idVenta)
        {
            DDetalleVenta Obj = new DDetalleVenta();
           // Obj.Opcion = opcion;
            Obj.IdVenta = idVenta;
            return Obj.BuscarNombre(Obj);
        }

    }
}
