using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIACOM
{
    public partial class FrmPrincipale : Form
    {
        public FrmPrincipale()
        {
            InitializeComponent();
        }
               

        private void FrmPrincipale_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
        }

        private void cargarCombo()
        {
           // data.Columns["Respuesto"].DataGridView.DataSource = NRepuesto.BuscarNombre(Convert.ToString(data[0, 0].Value));
        }

    }
}
