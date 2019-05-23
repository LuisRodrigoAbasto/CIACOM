using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NDetalleTrabajo
    {
        public static string Insertar(int idTrabajo)
        {
            DDetalleTrabajo Obj = new DDetalleTrabajo();
            Obj.IdTrabajo=idTrabajo;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idTrabajo, int idOrden)
        {
            DDetalleTrabajo Obj = new DDetalleTrabajo();
            Obj.IdTrabajo = idTrabajo;
            Obj.IdOrden = idOrden;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idOrden)
        {
            DDetalleTrabajo Obj = new DDetalleTrabajo();
            Obj.IdOrden = idOrden;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostar()
        {

            return new DDetalleTrabajo().Mostrar();
        }

        public static DataTable BuscarNombre(int idOrden)
        {
            DDetalleTrabajo Obj = new DDetalleTrabajo();
            Obj.IdOrden = idOrden;
            return Obj.BuscarNombre(Obj);
        }

    }
}
