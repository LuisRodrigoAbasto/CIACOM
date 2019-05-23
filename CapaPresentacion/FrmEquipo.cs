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
    public partial class FrmEquipo : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public FrmEquipo()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtModelo, "Ingrese el Modelo del Producto");
        }
        
        // Mostrar Mensaje de Confirmacion
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
            this.txtIdEquipo.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtModelo.Text = string.Empty;
            this.txtMarca.Text = string.Empty;
            this.txtSerie.Text = string.Empty;

        }

        // habilitar los controles del Formulario
        private void Habilitar(bool valor)
        {
            this.txtIdEquipo.ReadOnly = !valor;
            this.txtModelo.ReadOnly = !valor;
            //this.txtMarca.AutoCompleteCustomSource =(this.dgProducto.CurrentRow.Cells["marca"].Value);

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
            this.dataListado.Columns["idEquipo"].DisplayIndex = 0;
            this.dataListado.Columns["idEquipo"].HeaderText = "id";
            this.dataListado.Columns["nombre"].DisplayIndex = 1;
            this.dataListado.Columns["descripcion"].DisplayIndex = 2;
            this.dataListado.Columns["modelo"].DisplayIndex = 3;
            this.dataListado.Columns["marca"].DisplayIndex = 4;
            this.dataListado.Columns["serie"].DisplayIndex = 5;
            this.dataListado.Columns["Editar"].DisplayIndex = 6;
            this.dataListado.Columns["Eliminar"].DisplayIndex = 7;

        }

        //Metodo Mostrar 
        private void Mostrar()
        {
            this.dataListado.DataSource = NEquipo.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registro: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void FrmEquipo_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();

        }
        // Metodo BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NEquipo.BuscarNombre(this.txtBuscar.Text.Trim());
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registro: " + Convert.ToString(dataListado.Rows.Count);
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
            this.txtModelo.Focus();
            this.pRegistro.Visible = true;
            this.pListas.Visible = false;


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (this.txtModelo.Text == string.Empty)
                {
                    MensajeError("Falta ingresar Algunos Datos, seran Remarcados");
                    errorIcono.SetError(txtModelo, "Ingrese un Nombre");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NEquipo.Insertar(this.txtNombre.Text.Trim(),this.txtDescripcion.Text.Trim(),this.txtModelo.Text.Trim(),this.txtMarca.Text.Trim(), this.txtSerie.Text.Trim());
                    }
                    else
                    {
                        rpta = NEquipo.Editar(Convert.ToInt32(this.txtIdEquipo.Text), this.txtNombre.Text.Trim(),
                            this.txtDescripcion.Text.Trim(), this.txtModelo.Text.Trim(), this.txtMarca.Text.Trim(), this.txtSerie.Text.Trim());
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
                    this.pRegistro.Visible = false;
                    this.pListas.Visible = true;
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
            this.pRegistro.Visible = false;
            this.pListas.Visible = true;
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

                    Codigo = Convert.ToString(this.dataListado.CurrentRow.Cells["idEquipo"].Value);
                    Rpta = NEquipo.Eliminar(Convert.ToInt32(Codigo));

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
                    this.txtIdEquipo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idEquipo"].Value);
                    this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
                    this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);
                    this.txtModelo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["modelo"].Value);
                    this.txtMarca.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["marca"].Value);
                    this.txtSerie.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["serie"].Value);
                  

                    pListas.Visible = false;
                    Habilitar(true);
                    pRegistro.Visible = true;

                }
            }

        }

    
    }
}