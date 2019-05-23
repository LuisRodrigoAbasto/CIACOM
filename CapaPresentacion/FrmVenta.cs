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
    public partial class FrmVenta : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        private int fila = 0;
        private bool agregar = true;
        private float suma = 0;
        private DataTable dtDetalle;
        private bool usar=false;

        public FrmVenta()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtFecha, "Ingrese el Modelo del Producto");
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
            this.txtIdVenta.Text = string.Empty;
           // this.txtFecha.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            this.txtEmpleado.Text = string.Empty;
            this.txtProducto.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtPrecio.Text = string.Empty;
            this.txtTotal.Text = string.Empty;            
        }

       

        // habilitar los Botones

       
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //this.crearTabla();
            this.Limpiar();
            this.pRegistro.Visible = false;
            this.pListas.Visible = true;
            this.Mostrar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                int cantidad = 0;
                float precioUnitario = 0;
                if (this.txtEmpleado.Text == string.Empty && this.txtCliente.Text == string.Empty)
                {
                    MensajeError("Falta ingresar Algunos Datos, seran Remarcados");
                    errorIcono.SetError(this.txtEmpleado, "Ingrese Nombre del Empleado");
                    errorIcono.SetError(this.txtCliente, "Ingrese Nombre del Cliente");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NVenta.Insertar(Convert.ToDateTime(txtFecha.Text), Convert.ToSingle(txtTotal.Text), Convert.ToInt32(txtCliente.Value), Convert.ToInt32(txtEmpleado.Value));
                        for (int i = 0; i < dataDetalle.RowCount ; i++)
                        {
                           
                                cantidad = Convert.ToInt32(dataDetalle.Rows[i].Cells["Cantidad"].Value);
                                precioUnitario = Convert.ToSingle(dataDetalle.Rows[i].Cells["Precio_Unitario"].Value);
                                NDetalleVenta.Insertar(cantidad, precioUnitario, Convert.ToInt32(dataDetalle.Rows[i].Cells["id"].Value));

                            
                        }

                    }
                    else
                    {
                        rpta = NVenta.Editar(Convert.ToInt32(txtIdVenta.Text), Convert.ToDateTime(txtFecha.Text), Convert.ToSingle(txtTotal.Text), Convert.ToInt32(txtCliente.Value), Convert.ToInt32(txtEmpleado.Value));
                        NDetalleVenta.Eliminar(Convert.ToInt32(this.txtIdVenta.Text));
                        for (int i = 0; i < dataDetalle.RowCount; i++)
                        {
                           
                            
                                cantidad = Convert.ToInt32(dataDetalle.Rows[i].Cells["Cantidad"].Value);
                                precioUnitario = Convert.ToSingle(dataDetalle.Rows[i].Cells["Precio_Unitario"].Value);
                                NDetalleVenta.Editar(cantidad, precioUnitario, Convert.ToInt32(this.txtIdVenta.Text), Convert.ToInt32(dataDetalle.Rows[i].Cells["id"].Value));

                            
                        }
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
                        this.Limpiar();
                        this.usar = false;
                        this.pRegistro.Visible = false;
                        this.pListas.Visible = true;
                        this.Mostrar();

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private void crearTabla()
        {
            this.dtDetalle = new DataTable("detalleVenta");
            this.dtDetalle.Columns.Clear();           
            this.dtDetalle.Columns.Add("id", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Producto", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Cantidad", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Precio_Unitario", System.Type.GetType("System.Single"));
            this.dtDetalle.Columns.Add("Total", System.Type.GetType("System.Single"));
            this.dataDetalle.DataSource=this.dtDetalle;
            this.ocultarDetalle();
        }

        private void buscarDetalle()
        {
            this.dataDetalle.DataSource = NDetalleVenta.Buscar(Convert.ToInt32(this.txtIdVenta.Text));
            this.ocultarDetalle();
        }
        private void mostrarDetalle()
        {
            this.dataDetalle.DataSource = NDetalleVenta.Mostrar();
            this.ocultarDetalle();
         //   this.limpiarDetalle();
        }

        private void cargarComboCliente()
        {

            this.txtCliente.DropDownList.Columns.Clear();
            this.txtCliente.DropDownList.Columns.Add("nombre").Width = 80;
            this.txtCliente.DropDownList.Columns.Add("paterno").Width = 80;
            this.txtCliente.DropDownList.Columns.Add("materno").Width = 80;
            this.txtCliente.DropDownList.Columns["nombre"].Caption = "Nombre";
            this.txtCliente.DropDownList.Columns["paterno"].Caption = "Paterno";
            this.txtCliente.DropDownList.Columns["materno"].Caption = "Materno";
            this.txtCliente.ValueMember = "idCliente";
            this.txtCliente.DisplayMember = "nombre";

            this.txtCliente.DataSource = NCliente.BuscarNombre(this.txtCliente.Text.Trim());
            this.txtCliente.Refresh();
        }

        private void cargarComboEmpleado()
        {

            this.txtEmpleado.DropDownList.Columns.Clear();
            this.txtEmpleado.DropDownList.Columns.Add("nombre").Width = 80;
            this.txtEmpleado.DropDownList.Columns.Add("paterno").Width = 80;
            this.txtEmpleado.DropDownList.Columns.Add("materno").Width = 80;
            this.txtEmpleado.DropDownList.Columns["nombre"].Caption = "Nombre";
            this.txtEmpleado.DropDownList.Columns["paterno"].Caption = "Paterno";
            this.txtEmpleado.DropDownList.Columns["materno"].Caption = "Materno";
            this.txtEmpleado.ValueMember = "idEmpleado";
            this.txtEmpleado.DisplayMember = "nombre";

            this.txtEmpleado.DataSource = NEmpleado.BuscarNombre(this.txtEmpleado.Text.Trim());
            this.txtEmpleado.Refresh();

        }

        private void cargarComboModelo()
        {

            this.txtProducto.DropDownList.Columns.Clear();
            this.txtProducto.DropDownList.Columns.Add("modelo").Width = 100;
            this.txtProducto.DropDownList.Columns.Add("descripcion").Width = 100;
            this.txtProducto.DropDownList.Columns.Add("marca").Width = 80;
            this.txtProducto.DropDownList.Columns.Add("categoria").Width = 80;
            this.txtProducto.DropDownList.Columns.Add("precio").Width = 80;
            this.txtProducto.DropDownList.Columns["modelo"].Caption = "Modelo";
            this.txtProducto.DropDownList.Columns["descripcion"].Caption = "descripcion";
            this.txtProducto.DropDownList.Columns["Marca"].Caption = "Marca";
            this.txtProducto.DropDownList.Columns["categoria"].Caption = "Categoria";
            this.txtProducto.DropDownList.Columns["precio"].Caption = "Precio";
            this.txtProducto.ValueMember = "id";
            this.txtProducto.DisplayMember = "precio";
            this.txtPrecio.Text = txtProducto.Text;
            this.txtProducto.DisplayMember = "modelo";
            this.txtProducto.DataSource = NProducto.BuscarNombre(this.txtProducto.Text.Trim(),"Modelo");

            this.txtProducto.Refresh();

        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.crearTabla();
        }
        private void OcultarColumnas()
        {            
                this.dataListado.Columns["id"].DisplayIndex = 0;
                this.dataListado.Columns["fecha"].DisplayIndex = 1;
                this.dataListado.Columns["Monto"].DisplayIndex = 2;
                this.dataListado.Columns["cliente_nombre"].DisplayIndex = 3;
                this.dataListado.Columns["cliente_paterno"].DisplayIndex = 4;
                this.dataListado.Columns["empleado_nombre"].DisplayIndex = 5;
                this.dataListado.Columns["empleado_paterno"].DisplayIndex = 6;
                this.dataListado.Columns["EditarVenta"].DisplayIndex = 7;
                this.dataListado.Columns["Eliminar"].DisplayIndex = 8;
                this.dataListado.Columns["idCliente"].DisplayIndex = 9;
                this.dataListado.Columns["idEmpleado"].DisplayIndex = 10;
                this.dataListado.Columns["idCliente"].Visible = false;
                this.dataListado.Columns["idEmpleado"].Visible = false;

            this.cargarComboCliente();
            this.cargarComboEmpleado();
            this.cargarComboModelo();
        }
       
        private void ocultarDetalle()
        {
            this.dataDetalle.Columns["id"].DisplayIndex = 0;
            this.dataDetalle.Columns["Producto"].DisplayIndex = 1;
            this.dataDetalle.Columns["Cantidad"].DisplayIndex = 2;
            this.dataDetalle.Columns["Precio_Unitario"].DisplayIndex = 3;
            this.dataDetalle.Columns["Total"].DisplayIndex = 4;
            this.dataDetalle.Columns["Editar"].DisplayIndex = 5;
            this.dataDetalle.Columns["Quitar"].DisplayIndex = 6;
        }
        private void Mostrar()
        {
            this.dataListado.DataSource = NVenta.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registro: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarNombre()
        {
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registro: " + Convert.ToString(dataListado.Rows.Count);
        }

       

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Limpiar();
            this.txtFecha.Focus();
            this.cargarComboModelo();
            this.cargarComboCliente();
            this.cargarComboEmpleado();
            this.crearTabla();
            this.pRegistro.Visible = true;
            this.pListas.Visible = false;
            this.usar = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                suma = 0;
                if (this.txtProducto.Text.Trim()!= string.Empty && this.txtCantidad.Text.Trim()!= string.Empty)
                {
                    for (int i = 0; i < this.dataDetalle.RowCount; i++)
                    {
                        if (Convert.ToInt32(this.dataDetalle["id",i].Value) == Convert.ToInt32(this.txtProducto.Value))
                        {
                            agregar = false;
                            this.MensajeError("Ya se encuentra el Producto en el detalle");
                        }
                    }
                   
                    if (agregar)
                    {
                        if (usar)
                        {
                            for (int i = 0; i < dataDetalle.RowCount; i++)
                            {
                                DataRow rows = this.dtDetalle.NewRow();
                                rows["id"] = Convert.ToInt32(this.dataDetalle["id", i].Value);
                                rows["Producto"] = Convert.ToString(this.dataDetalle["Producto", i].Value);
                                rows["Cantidad"] = Convert.ToInt32(this.dataDetalle["Cantidad", i].Value);
                                rows["Precio_Unitario"] = Convert.ToSingle(this.dataDetalle["Precio_Unitario", i].Value);
                                rows["Total"] = Convert.ToSingle(this.dataDetalle["Cantidad", i].Value) * Convert.ToInt32(this.dataDetalle["Precio_Unitario", i].Value);
                                this.dtDetalle.Rows.Add(rows);
                                
                            }
                            usar = false;
                        }                     
                            DataRow row = this.dtDetalle.NewRow();
                            row["id"] = Convert.ToInt32(this.txtProducto.Value);
                            row["Producto"] = Convert.ToString(this.txtProducto.Text);
                            row["Cantidad"] = Convert.ToInt32(this.txtCantidad.Text);
                            row["Precio_Unitario"] = Convert.ToSingle(this.txtPrecio.Text);
                            row["Total"] = Convert.ToSingle(this.txtPrecio.Text) * Convert.ToInt32(txtCantidad.Text);

                            this.dtDetalle.Rows.Add(row);
                            this.dataDetalle.DataSource = dtDetalle;
                                                   
                      }

                    this.txtProducto.Text = string.Empty;
                    this.txtCantidad.Text = string.Empty;                  
                    this.sumartotal();                   
                    agregar = true;
                }
                else
                {
                    MensajeError("Falta ingresar Algunos Datos, seran Remarcados");
                    
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

       private void sumartotal()
        {
            suma = 0;
            foreach (DataGridViewRow row in dataDetalle.Rows)
            {
                suma = Convert.ToInt32(row.Cells["Total"].Value) + suma;
            }
            this.txtTotal.Text = Convert.ToString(suma);
        }     


        private void dataDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataDetalle.Columns["Quitar"].Index)
            {
                DialogResult Opcion;

                Opcion = MessageBox.Show("Realmente desea Quitar el Producto", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(Opcion == DialogResult.OK)
                {
                    int indiceFila = this.dataDetalle.CurrentCell.RowIndex;
                    this.dataDetalle.Rows.Remove(this.dataDetalle.Rows[indiceFila]);
                   
                }
            }
            else
            {
                if (e.ColumnIndex == dataDetalle.Columns["Editar"].Index)
                {
                 //   this.txtProducto.ValueMember = Convert.ToString(this.dataDetalle.CurrentRow.Cells["id"].Value);
                    this.txtProducto.Text = Convert.ToString(this.dataDetalle.CurrentRow.Cells["Producto"].Value);
                    this.txtCantidad.Text = Convert.ToString(this.dataDetalle.CurrentRow.Cells["Cantidad"].Value);
                    int indiceFila = this.dataDetalle.CurrentCell.RowIndex;
                    this.dataDetalle.Rows.Remove(this.dataDetalle.Rows[indiceFila]);                   
                    // this.dataDetalle.Rows.Remove(dataDetalle.CurrentRow);
                   
                   
                }
            }
            sumartotal();
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

                    Codigo = Convert.ToString(this.dataListado.CurrentRow.Cells["id"].Value);
                    NDetalleVenta.Eliminar(Convert.ToInt32(Codigo));
                    Rpta = NVenta.Eliminar(Convert.ToInt32(Codigo));
                    

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
                if (e.ColumnIndex == dataListado.Columns["EditarVenta"].Index)
                {
                    this.txtIdVenta.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id"].Value);
                    // this.txtFecha.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["fecha"].Value);
                    // this.txtPrecio.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["precio"].Value);                      
                    this.txtCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cliente_nombre"].Value);                   
                    this.txtEmpleado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["empleado_nombre"].Value);
                    this.crearTabla();
                    this.buscarDetalle();
                    this.ocultarDetalle();
                    usar = true;
                    this.pListas.Visible = false;
                    this.IsEditar = true;
                    this.IsNuevo = false;
                    this.pRegistro.Visible = true;                   
                    this.txtFecha.Focus();
                    this.cargarComboModelo();
                    this.cargarComboCliente();
                    this.cargarComboEmpleado();
                    this.sumartotal();

                }
            }
                      
            this.cargarComboModelo();
        }

        private void txtProducto_ValueChanged(object sender, EventArgs e)
        {
            this.cargarComboModelo();
        }

        private void txtCliente_ValueChanged(object sender, EventArgs e)
        {
            this.cargarComboCliente();
        }

        private void txtEmpleado_ValueChanged(object sender, EventArgs e)
        {
            this.cargarComboEmpleado();
        }

       
    }
}
