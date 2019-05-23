using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmTrabajo : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public FrmTrabajo()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre de la Categoria");
        }

        private void MensajeOk(String mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // limpiar Todos los Controles del Formulario
        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtIdTrabajo.Text = string.Empty;
        }

        // habilitar los controles del Formulario
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtIdTrabajo.ReadOnly = !valor;
        }

        // habilitar los Botones

        private void Botones()
        {

            this.Habilitar(true);
            this.btnGuardar.Enabled = true;
            this.btnCancelar.Enabled = true;

        }

        // metodo para ocultar Columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns["idTrabajo"].DisplayIndex = 0;
            this.dataListado.Columns["idTrabajo"].HeaderText = "id";
            this.dataListado.Columns["nombre"].DisplayIndex = 1;
            this.dataListado.Columns["precio"].DisplayIndex = 2;
            this.dataListado.Columns["Editar"].DisplayIndex = 3;
            this.dataListado.Columns["Eliminar"].DisplayIndex = 4;

        }

        //Metodo Mostrar 
        private void Mostrar()
        {
            this.dataListado.DataSource = NTrabajo.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registro: " + Convert.ToString(dataListado.Rows.Count);
        }

        // Metodo BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NTrabajo.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registro: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmTrabajo_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
            this.pListas.Visible = false;
            this.pRegistro.Visible = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text == string.Empty)
                {
                    MensajeError("Falta ingresar Algunos Datos, seran Remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Nombre");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NTrabajo.Insertar(this.txtNombre.Text.Trim(), Convert.ToSingle(this.txtPrecio.Text.Trim()));
                    }
                    else
                    {
                        rpta = NTrabajo.Editar(Convert.ToInt32(this.txtIdTrabajo.Text), this.txtNombre.Text.Trim(), Convert.ToSingle(this.txtPrecio.Text.Trim()));
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se inserto Correctamente El Registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizo Correctamente El Registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                    this.pListas.Visible = true;
                    this.pRegistro.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.pListas.Visible = true;
            this.pRegistro.Visible = false;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea Eliminar El Registro", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {

                    String Codigo;
                    String Rpta = "";

                    Codigo = Convert.ToString(this.dataListado.CurrentRow.Cells["idTrabajo"].Value);
                    Rpta = NTrabajo.Eliminar(Convert.ToInt32(Codigo));

                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se ELimino Correctamente el Registro");
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }

                    this.Mostrar();
                }
            }
            else
            {
                if (e.ColumnIndex == dataListado.Columns["Editar"].Index)
                {
                    this.txtIdTrabajo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idTrabajo"].Value);
                    this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
                    this.txtPrecio.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["precio"].Value);
                    pRegistro.Visible = true;
                    Habilitar(true);
                    pListas.Visible = false;
                }
            }
        }


    }
}
