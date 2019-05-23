using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NDetalleEquipo
    {
        public static string Insertar(int idEquipo)
        {
            DDetalleEquipo Obj = new DDetalleEquipo();
            Obj.IdEquipo = idEquipo;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idEquipo, int idOrden)
        {
            DDetalleEquipo Obj = new DDetalleEquipo();
            Obj.IdEquipo = idEquipo;
            Obj.IdOrden = idOrden;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idOrden)
        {
            DDetalleEquipo Obj = new DDetalleEquipo();
            Obj.IdOrden = idOrden;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostar()
        {

            return new DDetalleEquipo().Mostrar();
        }

        public static DataTable BuscarNombre(int idOrden)
        {
            DDetalleEquipo Obj = new DDetalleEquipo();
            Obj.IdOrden = idOrden;
            return Obj.BuscarNombre(Obj);
        }

    }
}
