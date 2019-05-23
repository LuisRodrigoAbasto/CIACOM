using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion;

namespace CIACOM
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
          //  Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new FrmPrincipale());
            // Application.Run(new FrmCategoria());
            //  Application.Run(new FrmMarca());
            // Application.Run(new FrmCliente());
            // Application.Run(new FrmProducto());
            // Application.Run(new FrmEmpleado());
            //Application.Run(new FrmEquipo());
            // Application.Run(new FrmTecnico());
            // Application.Run(new FrmRepuesto());
            // Application.Run(new FrmTrabajo());
            // Application.Run(new FrmVenta());
            Application.Run(new FrmPrincipal());
        }
    }
}
