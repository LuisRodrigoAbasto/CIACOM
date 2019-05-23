using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NDetalleRepuesto
    {
        public static string Insertar(int cantidad, float precio,int idRepuesto)
        {
            DDetalleRepuesto Obj = new DDetalleRepuesto();
            Obj.Cantidad = cantidad;
            Obj.Precio = precio;
            Obj.IdRepuesto = idRepuesto;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int cantidad, float precio, int idOrden, int idRepuesto)
        {
            DDetalleRepuesto Obj = new DDetalleRepuesto();
            Obj.Cantidad = cantidad;
            Obj.Precio = precio;
            Obj.IdOrden = idOrden;
            Obj.IdRepuesto = idRepuesto;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idOrden)
        {
            DDetalleRepuesto Obj = new DDetalleRepuesto();
            Obj.IdOrden = idOrden;
            return Obj.Insertar(Obj);
        }

        public static DataTable Mostar()
        {

            return new DDetalleRepuesto().Mostrar();
        }

        public static DataTable BuscarNombre(int idOrden)
        {
            DDetalleRepuesto Obj = new DDetalleRepuesto();
            Obj.IdOrden = idOrden;
            return Obj.BuscarNombre(Obj);
        }

    }
}
