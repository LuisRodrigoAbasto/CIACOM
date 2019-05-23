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
    public partial class FrmProducto : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public FrmProducto()
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
            this.txtIdProducto.Text = string.Empty;
            this.txtModelo.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtPrecio.Text = string.Empty;
            this.txtStock.Text = string.Empty;
            this.txtMarca.Text = string.Empty;
            this.txtCategoria.Text = string.Empty;
        }

        // habilitar los controles del Formulario
        private void Habilitar(bool valor)
        {
            this.txtIdProducto.ReadOnly = !valor;
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
            this.dataListado.Columns["id"].DisplayIndex = 0;
            this.dataListado.Columns["modelo"].DisplayIndex = 1;
            this.dataListado.Columns["descripcion"].DisplayIndex = 2;
            this.dataListado.Columns["precio"].DisplayIndex = 3;
            this.dataListado.Columns["stock"].DisplayIndex = 4;
            this.dataListado.Columns["marca"].DisplayIndex = 5;
            this.dataListado.Columns["categoria"].DisplayIndex = 6;
            this.dataListado.Columns["Editar"].DisplayIndex = 7;
            this.dataListado.Columns["Eliminar"].DisplayIndex =8;                 
        }

        //Metodo Mostrar 
        private void Mostrar()
        {            
            this.dataListado.DataSource = NProducto.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registro: " + Convert.ToString(dataListado.Rows.Count);           
        }


        // Metodo BuscarNombre
        private void BuscarNombre()
        {          
            this.dataListado.DataSource = NProducto.BuscarNombre(this.txtBuscar.Text,"Marca");
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registro: " + Convert.ToString(dataListado.Rows.Count);            
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;           
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.cargarComboMarca();
            this.cargarComboCategoria();            

        }
        private void cargarComboMarca() {

            this.txtMarca.DropDownList.Columns.Clear();
            this.txtMarca.DropDownList.Columns.Add("nombre").Width = 200;
            this.txtMarca.DropDownList.Columns["nombre"].Caption = "";
            this.txtMarca.ValueMember = "nombre";
            this.txtMarca.DisplayMember = "nombre";

            this.txtMarca.DataSource = NMarca.BuscarNombre(this.txtMarca.Text.Trim());
            this.txtMarca.Refresh();
        }

        private void cargarComboCategoria()
        {

            this.txtCategoria.DropDownList.Columns.Clear();
            this.txtCategoria.DropDownList.Columns.Add("nombre").Width = 200;
            this.txtCategoria.DropDownList.Columns["nombre"].Caption = "";
            this.txtCategoria.ValueMember = "nombre";
            this.txtCategoria.DisplayMember = "nombre";

            this.txtCategoria.DataSource = NCategoria.BuscarNombre(this.txtCategoria.Text.Trim());
            this.txtCategoria.Refresh();
            
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
        private bool errores()
        {
            bool sw = true; ;

            if (this.txtModelo.Text == string.Empty)
            {
                MensajeError("Falta ingresar Algunos Datos, seran Remarcados");
                errorIcono.SetError(txtModelo, "Ingrese un Nombre");
                sw = false;
            }
            else
            {
                if (this.txtMarca.Text == string.Empty)
                {
                    MensajeError("Falta ingresar Algunos Datos, seran Remarcados");
                    errorIcono.SetError(txtMarca, "Ingrese una Marca");
                    sw = false;
                }
                else
                {
                    if (this.txtStock.Text == string.Empty)
                    {
                        MensajeError("Falta ingresar Algunos Datos, seran Remarcados");
                        errorIcono.SetError(txtStock, "Un Stock");
                        sw = false;
                    }
                }
            }

            return sw;
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                this.errores();
               
                if (this.errores())
                  {
                    if (this.IsNuevo)
                    {
                        rpta = NProducto.Insertar(this.txtModelo.Text.Trim(),
                            this.txtDescripcion.Text.Trim(), Convert.ToSingle(this.txtPrecio.Text), Convert.ToInt32(txtStock.Text)
                            , this.txtMarca.Text.Trim(),this.txtCategoria.Text.Trim());
                    }
                    else
                    {
                        rpta = NProducto.Editar(Convert.ToInt32(this.txtIdProducto.Text), this.txtModelo.Text.Trim(),
                            this.txtDescripcion.Text.Trim(), Convert.ToSingle(this.txtPrecio.Text), Convert.ToInt32(txtStock.Text)
                            , this.txtMarca.Text.Trim(), this.txtCategoria.Text.Trim());
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

                    Codigo = Convert.ToString(this.dataListado.CurrentRow.Cells["idProducto"].Value);
                    Rpta = NProducto.Eliminar(Convert.ToInt32(Codigo));

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
                    this.txtIdProducto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id"].Value);
                    this.txtModelo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["modelo"].Value);
                    this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);
                    this.txtPrecio.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["precio"].Value);
                    this.txtStock.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["stock"].Value);
                    this.txtMarca.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["marca"].Value);
                    this.txtCategoria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["categoria"].Value);
                
                    pListas.Visible = false;
                    Habilitar(true);
                    pRegistro.Visible = true;
                  

                }
            }

        }

        private void txtMarca_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}