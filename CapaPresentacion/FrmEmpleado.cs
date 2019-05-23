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
    public partial class FrmEmpleado : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public FrmEmpleado()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Cliente");
            this.ttMensaje.SetToolTip(this.txtPaterno, "Ingrese el Apellido del Cliente");
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
            this.txtIdEmpleado.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtPaterno.Text = string.Empty;
            this.txtMaterno.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtCI.Text = string.Empty;

        }

        // habilitar los controles del Formulario
        private void Habilitar(bool valor)
        {
           // this.txtIdEmpleado.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtPaterno.ReadOnly = !valor;
            this.txtMaterno.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtCI.ReadOnly = !valor;
        }

        private void Botones()
        {

            this.Habilitar(true);
            this.btnGuardar.Enabled = true;
            this.btnCancelar.Enabled = true;

        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns["idEmpleado"].DisplayIndex = 0;
            this.dataListado.Columns["idEmpleado"].HeaderText = "id";            
            this.dataListado.Columns["nombre"].DisplayIndex = 1;
            this.dataListado.Columns["paterno"].DisplayIndex = 2;
            this.dataListado.Columns["materno"].DisplayIndex = 3;
            this.dataListado.Columns["telefono"].DisplayIndex = 4;
            this.dataListado.Columns["ci"].DisplayIndex = 5;
            this.dataListado.Columns["Editar"].DisplayIndex = 6;
            this.dataListado.Columns["Eliminar"].DisplayIndex = 7;
        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NEmpleado.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registro: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarNombre()
        {
            this.dataListado.DataSource = NEmpleado.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registro: " + Convert.ToString(dataListado.Rows.Count);
        }



        private void FrmEmpleado_Load(object sender, EventArgs e)
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
                if (this.txtNombre.Text == string.Empty && this.txtPaterno.Text == string.Empty)
                {
                    MensajeError("Falta ingresar Algunos Datos, seran Remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Nombre");
                    errorIcono.SetError(txtPaterno, "Ingrese un Apellido Paterno");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NEmpleado.Insertar(this.txtNombre.Text.Trim(), this.txtPaterno.Text.Trim(), this.txtMaterno.Text.Trim(), Convert.ToInt32(this.txtTelefono.Text.Trim()), this.txtCI.Text.Trim());
                    }
                    else
                    {
                        rpta = NEmpleado.Editar(Convert.ToInt32(this.txtIdEmpleado.Text), this.txtNombre.Text.Trim(), this.txtPaterno.Text.Trim(), this.txtMaterno.Text.Trim(), Convert.ToInt32(this.txtTelefono.Text.Trim()), this.txtCI.Text.Trim());
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

                    Codigo = Convert.ToString(this.dataListado.CurrentRow.Cells["idEmpleado"].Value);
                    Rpta = NEmpleado.Eliminar(Convert.ToInt32(Codigo));

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
                    this.txtIdEmpleado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idEmpleado"].Value);
                    this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
                    this.txtPaterno.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["paterno"].Value);
                    this.txtMaterno.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["materno"].Value);
                    this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
                    this.txtCI.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ci"].Value);
                    pRegistro.Visible = true;
                    Habilitar(true);
                    pListas.Visible = false;
                }
            }
        }
    }
}