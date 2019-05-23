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
    public partial class FrmServicio : Form
    {

        private bool IsNuevo = false;
        private bool IsEditar = false;
        private int fila = 0;
        private bool agregar = true;
        private float suma = 0;
        private DataTable dtTrabajo;
        private DataTable dtEquipo;
        private DataTable dtRepuesto;
        private bool usar = false;

        private string descripcion = "";
        private string modelo = "";
        private string marca = "";
        private string serie = "";

        private string precio = "";
        public FrmServicio()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtRepuesto, "Ingrese el Repuesto");
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
            this.txtIdOrden.Text = string.Empty;
            // this.txtFecha.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            this.txtEmpleado.Text = string.Empty;
            this.txtRepuesto.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtPrecio.Text = string.Empty;
            this.txtTotal.Text = string.Empty;
        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns["idOrden"].DisplayIndex = 0;
            this.dataListado.Columns["idOrden"].HeaderText = "id";
            this.dataListado.Columns["fechaEntrada"].DisplayIndex = 1;
            this.dataListado.Columns["fechaSalida"].DisplayIndex = 2;
            this.dataListado.Columns["Monto"].DisplayIndex = 3;
            this.dataListado.Columns["cliente_nombre"].DisplayIndex = 4;
            this.dataListado.Columns["cliente_paterno"].DisplayIndex = 5;
            this.dataListado.Columns["tecnico_nombre"].DisplayIndex = 6;
            this.dataListado.Columns["tecnico_paterno"].DisplayIndex = 7;
            this.dataListado.Columns["empleado_nombre"].DisplayIndex = 8;
            this.dataListado.Columns["empleado_paterno"].DisplayIndex = 9;
            this.dataListado.Columns["Edita"].DisplayIndex = 10;
            this.dataListado.Columns["Eliminar"].DisplayIndex = 11;
            this.dataListado.Columns["idCliente"].DisplayIndex = 12;
            this.dataListado.Columns["idEmpleado"].DisplayIndex = 13;
            this.dataListado.Columns["idTecnico"].DisplayIndex = 14;
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
        private void cargarComboTecnico()
        {

            this.txtTecnico.DropDownList.Columns.Clear();
            this.txtTecnico.DropDownList.Columns.Add("nombre").Width = 80;
            this.txtTecnico.DropDownList.Columns.Add("paterno").Width = 80;
            this.txtTecnico.DropDownList.Columns.Add("materno").Width = 80;
            this.txtTecnico.DropDownList.Columns["nombre"].Caption = "Nombre";
            this.txtTecnico.DropDownList.Columns["paterno"].Caption = "Paterno";
            this.txtTecnico.DropDownList.Columns["materno"].Caption = "Materno";
            this.txtTecnico.ValueMember = "idTecnico";
            this.txtTecnico.DisplayMember = "nombre";

            this.txtTecnico.DataSource = NTecnico.BuscarNombre(this.txtTecnico.Text.Trim());
            this.txtTecnico.Refresh();
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

        private void cargarComboRespuesto()
        {
            this.txtRepuesto.DropDownList.Columns.Clear();
            this.txtRepuesto.DropDownList.Columns.Add("descripcion").Width = 300;
            this.txtRepuesto.DropDownList.Columns.Add("modelo").Width = 200;
            this.txtRepuesto.DropDownList.Columns.Add("marca").Width = 100;
            this.txtRepuesto.DropDownList.Columns.Add("precio").Width = 100;
            this.txtRepuesto.DropDownList.Columns["descripcion"].Caption = "Descripcion";
            this.txtRepuesto.DropDownList.Columns["modelo"].Caption = "Modelo";
            this.txtRepuesto.DropDownList.Columns["marca"].Caption = "Marca";
            this.txtRepuesto.ValueMember = "idRepuesto";
            this.txtRepuesto.DisplayMember = "modelo";
            this.descripcion = txtRepuesto.Text;
            this.txtRepuesto.DisplayMember = "marca";
            this.marca = txtRepuesto.Text;
            this.txtRepuesto.DisplayMember = "precio";
            this.precio = txtRepuesto.Text;
            this.txtRepuesto.DisplayMember = "descripcion";

            this.txtRepuesto.DataSource = NRepuesto.BuscarNombre(this.txtRepuesto.Text.Trim());
            this.txtRepuesto.Refresh();
        }

        private void cargarComboTrabajo()
        {
            this.txtTrabajo.DropDownList.Columns.Clear();
            this.txtTrabajo.DropDownList.Columns.Add("nombre").Width = 200;
            this.txtTrabajo.DropDownList.Columns.Add("precio").Width = 100;      
            this.txtTrabajo.DropDownList.Columns["nombre"].Caption = "Nombre";        
            this.txtTrabajo.DropDownList.Columns["precio"].Caption = "Precio";         
            this.txtTrabajo.ValueMember = "idTrabajo";
            this.txtTrabajo.DisplayMember = "precio";
            this.precio = txtTrabajo.Text;
            this.txtTrabajo.DisplayMember = "nombre";
            this.txtTrabajo.DataSource = NTrabajo.BuscarNombre(this.txtTrabajo.Text.Trim());

            this.txtTrabajo.Refresh();
        }
        private void cargarComboEquipo()
        {
            this.txtEquipo.DropDownList.Columns.Clear();
            this.txtEquipo.DropDownList.Columns.Add("nombre").Width = 100;
            this.txtEquipo.DropDownList.Columns.Add("descripcion").Width = 100;
            this.txtEquipo.DropDownList.Columns.Add("modelo").Width = 100;
            this.txtEquipo.DropDownList.Columns.Add("marca").Width = 100;
            this.txtEquipo.DropDownList.Columns.Add("serie").Width = 100;
            this.txtEquipo.ValueMember = "idEquipo";
            this.txtEquipo.DisplayMember = "descripcion";
            this.descripcion = txtEquipo.Text;
            this.txtEquipo.DisplayMember = "modelo";
            this.modelo = txtEquipo.Text;
            this.txtEquipo.DisplayMember = "marca";
            this.marca = txtEquipo.Text;
            this.txtEquipo.DisplayMember = "serie";
            this.serie = txtEquipo.Text;
            this.txtEquipo.DisplayMember = "nombre";
            this.txtEquipo.DataSource = NEquipo.BuscarNombre(this.txtEquipo.Text.Trim());

            this.txtEquipo.Refresh();
        }

        private void crearTablaEquipo()
        {
            this.dtEquipo = new DataTable("detalleEquipo");
            this.dtEquipo.Columns.Add("idEquipo", System.Type.GetType("System.Int32"));
            this.dtEquipo.Columns.Add("Nombre", System.Type.GetType("System.String"));
            this.dtEquipo.Columns.Add("Descripcion", System.Type.GetType("System.String"));
            this.dtEquipo.Columns.Add("Modelo", System.Type.GetType("System.String"));
            this.dtEquipo.Columns.Add("Marca", System.Type.GetType("System.String"));
            this.dtEquipo.Columns.Add("Serie", System.Type.GetType("System.String"));
            this.detalleEquipo.DataSource = this.dtEquipo;
         //   this.ocultarDetalle();
        }

        private void crearTablaRepuesto()
        {
            this.dtRepuesto = new DataTable("detalleRepuesto");
            this.dtRepuesto.Columns.Add("idRepuesto", System.Type.GetType("System.Int32"));
            this.dtRepuesto.Columns.Add("Descripcion", System.Type.GetType("System.String"));
            this.dtRepuesto.Columns.Add("Modelo", System.Type.GetType("System.String"));
            this.dtRepuesto.Columns.Add("Marca", System.Type.GetType("System.String"));
            this.dtRepuesto.Columns.Add("Cantidad", System.Type.GetType("System.Int32"));
            this.dtRepuesto.Columns.Add("Precio", System.Type.GetType("System.Single"));
            this.dtRepuesto.Columns.Add("Total", System.Type.GetType("System.Single"));
            this.detalleRepuesto.DataSource = this.dtRepuesto;
            //   this.ocultarDetalle();
        }
        private void crearTablaTrabajo()
        {
            this.dtTrabajo = new DataTable("detalleTrabajo");
            this.dtTrabajo.Columns.Add("idTrabajo", System.Type.GetType("System.Int32"));
            this.dtTrabajo.Columns.Add("Nombre", System.Type.GetType("System.String"));
            this.dtTrabajo.Columns.Add("Precio", System.Type.GetType("System.Single"));
            this.detalleTrabajo.DataSource = this.dtTrabajo;
            //   this.ocultarDetalle();
        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NOrden.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registro: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void FrmServicio_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.cargarComboEquipo();
            this.cargarComboEmpleado();
            this.cargarComboRespuesto();
            this.cargarComboCliente();
            this.cargarComboTecnico();
            this.cargarComboTrabajo();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Limpiar();
            this.txtFecha.Focus();
            this.cargarComboEquipo();
            this.cargarComboRespuesto();
            this.cargarComboTrabajo();
            this.cargarComboCliente();
            this.cargarComboEmpleado();
            this.cargarComboTecnico();

            this.crearTablaRepuesto();
            this.crearTablaTrabajo();
            this.crearTablaEquipo();
            this.agregar = true;
            this.pRegistro.Visible = true;
            this.pListas.Visible = false;
            this.usar = false;
            this.ordenarDetalle();
        }

        private void txtCliente_ValueChanged(object sender, EventArgs e)
        {
            this.cargarComboCliente();
        }

        private void txtEquipo_ValueChanged(object sender, EventArgs e)
        {
            this.cargarComboEquipo();
        }
        private void txtRepuesto_ValueChanged(object sender, EventArgs e)
        {
            this.cargarComboRespuesto();
        }

        private void txtTabajo_ValueChanged(object sender, EventArgs e)
        {
            this.cargarComboTrabajo();
        }

        private void txtEmpleado_ValueChanged(object sender, EventArgs e)
        {
            this.cargarComboEmpleado();
        }
        private void txtTecnico_ValueChanged(object sender, EventArgs e)
        {
            this.cargarComboTecnico();
        }


        private void detalleEquipo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == detalleEquipo.Columns["QuitarEquipo"].Index)
            {
                DialogResult Opcion;

                Opcion = MessageBox.Show("Realmente desea Quitar el Equipo", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int indiceFila = this.detalleEquipo.CurrentCell.RowIndex;
                    this.detalleEquipo.Rows.Remove(this.detalleEquipo.Rows[indiceFila]);

                }
            }
            else
            {
                if (e.ColumnIndex == detalleEquipo.Columns["EditarEquipo"].Index)
                {
                    //   this.txtProducto.ValueMember = Convert.ToString(this.dataDetalle.CurrentRow.Cells["id"].Value);
                    this.txtEquipo.Text = Convert.ToString(this.detalleEquipo.CurrentRow.Cells["Nombre"].Value);
                    int indiceFila = this.detalleEquipo.CurrentCell.RowIndex;
                    this.detalleEquipo.Rows.Remove(this.detalleEquipo.Rows[indiceFila]);
                    // this.dataDetalle.Rows.Remove(dataDetalle.CurrentRow);


                }
            }
          //  sumartotal();
        }

        private void btnEquipo_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                suma = 0;
                if (this.txtEquipo.Text.Trim() != string.Empty)
                {
                    for (int i = 0; i < this.detalleEquipo.RowCount; i++)
                    {
                        if (Convert.ToInt32(this.detalleEquipo["idEquipo", i].Value) == Convert.ToInt32(this.txtEquipo.Value))
                        {
                            agregar = false;
                            this.MensajeError("Ya se encuentra el Producto en el detalle");
                        }
                    }

                    if (agregar)
                    {
                        if (usar)
                        {
                            for (int i = 0; i < detalleEquipo.RowCount; i++)
                            {
                                DataRow rows = this.dtEquipo.NewRow();
                                rows["idEquipo"] = Convert.ToInt32(this.detalleEquipo["idEquipo", i].Value);
                                rows["Nombre"] = Convert.ToString(this.detalleEquipo["Nombre", i].Value);
                                rows["Descripcion"] = Convert.ToString(this.detalleEquipo["Descipcion", i].Value);
                                rows["Modelo"] = Convert.ToString(this.detalleEquipo["Modelo", i].Value);
                                rows["Marca"] = Convert.ToString(this.detalleEquipo["Marca", i].Value);
                                rows["Serie"] = Convert.ToString(this.detalleEquipo["Serie", i].Value);
                                this.dtEquipo.Rows.Add(rows);

                            }
                            usar = false;
                        }
                        DataRow row = this.dtEquipo.NewRow();
                        row["idEquipo"] = Convert.ToInt32(this.txtEquipo.Value);
                        row["Nombre"] = Convert.ToString(this.txtEquipo.Text);
                        row["Descripcion"] = descripcion;
                        row["Modelo"] = modelo;
                        row["Marca"] =marca;
                        row["Serie"] = serie;

                        this.dtEquipo.Rows.Add(row);
                        this.detalleEquipo.DataSource = dtEquipo;

                    }

                    this.txtEquipo.Text = string.Empty;
                    this.txtCantidad.Text = string.Empty;
                   // this.sumartotal();
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

        private void btnTrabajo_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                suma = 0;
                if (this.txtTrabajo.Text.Trim() != string.Empty)
                {
                    for (int i = 0; i < this.detalleTrabajo.RowCount; i++)
                    {
                        if (Convert.ToInt32(this.detalleTrabajo["idTrabajo", i].Value) == Convert.ToInt32(this.txtTrabajo.Value))
                        {
                            agregar = false;
                            this.MensajeError("Ya se encuentra el Producto en el detalle");
                        }
                    }

                    if (agregar)
                    {
                        if (usar)
                        {
                            for (int i = 0; i < detalleTrabajo.RowCount; i++)
                            {
                                DataRow rows = this.dtTrabajo.NewRow();
                                rows["idTrabajo"] = Convert.ToInt32(this.detalleTrabajo["idTrabajo", i].Value);
                                rows["Nombre"] = Convert.ToString(this.detalleTrabajo["Nombre", i].Value);
                                rows["Precio"] = Convert.ToSingle(this.detalleTrabajo["Precio", i].Value);
                                this.dtTrabajo.Rows.Add(rows);

                            }
                            usar = false;
                        }
                        DataRow row = this.dtTrabajo.NewRow();
                        row["idTrabajo"] = Convert.ToInt32(this.txtTrabajo.Value);
                        row["Nombre"] = Convert.ToString(this.txtTrabajo.Text);
                        row["Precio"] = precio;
                        this.dtTrabajo.Rows.Add(row);
                        this.detalleTrabajo.DataSource = dtTrabajo;

                    }

                    this.txtTrabajo.Text = string.Empty;
                    this.txtCantidad.Text = string.Empty;
                    this.sumarMontoTotal();
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

        private void btnRepuesto_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                suma = 0;
                if (this.txtRepuesto.Text.Trim() != string.Empty && this.txtCantidad.Text.Trim() != string.Empty)
                {
                    for (int i = 0; i < this.detalleRepuesto.RowCount; i++)
                    {
                        if (Convert.ToInt32(this.detalleRepuesto["idRepuesto", i].Value) == Convert.ToInt32(this.txtRepuesto.Value))
                        {
                            agregar = false;
                            this.MensajeError("Ya se encuentra el Producto en el detalle");
                        }
                    }

                    if (agregar)
                    {
                        if (usar)
                        {
                            for (int i = 0; i < detalleRepuesto.RowCount; i++)
                            {
                                DataRow rowsr = this.dtRepuesto.NewRow();
                                rowsr["idRepuesto"] = Convert.ToInt32(this.detalleRepuesto["idRepuesto", i].Value);
                                rowsr["Descripcion"] = Convert.ToString(this.detalleRepuesto["Descripcion", i].Value);
                                rowsr["Modelo"] = Convert.ToString(this.detalleRepuesto["Modelo", i].Value);
                                rowsr["Marca"] = Convert.ToString(this.detalleRepuesto["Marca", i].Value);
                                rowsr["Cantidad"] = Convert.ToInt32(this.detalleRepuesto["Cantidad", i].Value);
                                rowsr["Precio"] = Convert.ToSingle(this.detalleRepuesto["Precio", i].Value);
                                rowsr["Total"] = Convert.ToSingle(this.detalleRepuesto["Cantidad", i].Value) * Convert.ToInt32(this.detalleRepuesto["Precio_Unitario", i].Value);
                                this.dtRepuesto.Rows.Add(rowsr);

                            }
                            usar = false;
                        }
                        DataRow rowr = this.dtRepuesto.NewRow();
                        rowr["idRepuesto"] = Convert.ToInt32(this.txtRepuesto.Value);
                        rowr["Descripcion"] = txtRepuesto.Text;
                        rowr["Modelo"] = descripcion;
                        rowr["Marca"] = marca;
                        rowr["Cantidad"] = Convert.ToInt32(txtCantidad.Text);
                        rowr["Precio"] = Convert.ToSingle(precio);
                        rowr["Total"] = Convert.ToSingle(precio) * Convert.ToInt32(txtCantidad.Text);

                        this.dtRepuesto.Rows.Add(rowr);
                        this.detalleRepuesto.DataSource = dtRepuesto;
                        this.sumarMontoTotal();
                    }

                    this.txtRepuesto.Text = string.Empty;
                    this.txtCantidad.Text = string.Empty;
                 //   this.sumartotal();
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

        private void sumarMontoTotal()
        {
            suma = 0;
            foreach (DataGridViewRow row in detalleRepuesto.Rows)
            {
                suma = Convert.ToInt32(row.Cells["Total"].Value) + suma;
            }
            
            foreach (DataGridViewRow row in detalleTrabajo.Rows)
            {
                suma = Convert.ToInt32(row.Cells["Precio"].Value) + suma;
            }
            this.txtTotal.Text = Convert.ToString(suma);
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
                        rpta = NOrden.Insertar(Convert.ToDateTime(txtFecha.Text), Convert.ToSingle(txtTotal.Text),
                           Convert.ToInt32(txtEmpleado.Value), Convert.ToInt32(txtCliente.Value), Convert.ToInt32(txtTecnico.Value));
                        ///detalle
                        for (int i = 0; i < detalleEquipo.RowCount; i++)
                        {
                            NDetalleEquipo.Insertar(Convert.ToInt32(detalleEquipo.Rows[i].Cells["id"].Value));
                        }
                        ///detalle
                        for (int i = 0; i < detalleTrabajo.RowCount; i++)
                        {
                            NDetalleTrabajo.Insertar(Convert.ToInt32(detalleTrabajo.Rows[i].Cells["id"].Value));
                        }
                        ///detalle Repuestp
                        for (int i = 0; i < detalleRepuesto.RowCount; i++)
                        {
                            cantidad = Convert.ToInt32(detalleRepuesto.Rows[i].Cells["Cantidad"].Value);
                            precioUnitario = Convert.ToSingle(detalleRepuesto.Rows[i].Cells["Precio"].Value);
                            NDetalleRepuesto.Insertar(cantidad, precioUnitario, Convert.ToInt32(detalleRepuesto.Rows[i].Cells["id"].Value));
                        }


                    }
                    else
                    {
                        rpta = NVenta.Editar(Convert.ToInt32(txtIdOrden.Text), Convert.ToDateTime(txtFecha.Text), Convert.ToSingle(txtTotal.Text), Convert.ToInt32(txtCliente.Value), Convert.ToInt32(txtEmpleado.Value));
                        NDetalleEquipo.Eliminar(Convert.ToInt32(this.txtIdOrden.Text));
                        NDetalleTrabajo.Eliminar(Convert.ToInt32(this.txtIdOrden.Text));
                        NDetalleRepuesto.Eliminar(Convert.ToInt32(this.txtIdOrden.Text));
                        ///detalle
                        for (int i = 0; i < detalleEquipo.RowCount; i++)
                        {
                            NDetalleEquipo.Editar(Convert.ToInt32(detalleEquipo.Rows[i].Cells["id"].Value), Convert.ToInt32(txtIdOrden.Text));
                        }
                        ///detalle
                        for (int i = 0; i < detalleTrabajo.RowCount; i++)
                        {
                            NDetalleTrabajo.Editar(Convert.ToInt32(detalleTrabajo.Rows[i].Cells["id"].Value), Convert.ToInt32(txtIdOrden.Text));
                        }
                        ///detalle
                        for (int i = 0; i < detalleRepuesto.RowCount; i++)
                        {
                            cantidad = Convert.ToInt32(detalleRepuesto.Rows[i].Cells["Cantidad"].Value);
                            precioUnitario = Convert.ToSingle(detalleRepuesto.Rows[i].Cells["Precio"].Value);
                            NDetalleRepuesto.Editar(cantidad, precioUnitario, Convert.ToInt32(detalleRepuesto.Rows[i].Cells["id"].Value), Convert.ToInt32(txtIdOrden.Text));
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void detalleTrabajo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == detalleTrabajo.Columns["QuitarTrabajo"].Index)
            {
                DialogResult Opcion;

                Opcion = MessageBox.Show("Realmente desea Quitar el Trabajo", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int indiceFila = this.detalleTrabajo.CurrentCell.RowIndex;
                    this.detalleTrabajo.Rows.Remove(this.detalleTrabajo.Rows[indiceFila]);

                }
            }
            else
            {
                if (e.ColumnIndex == detalleTrabajo.Columns["EditarTrabajo"].Index)
                {
                    this.txtTrabajo.Text = Convert.ToString(this.detalleTrabajo.CurrentRow.Cells["Nombre"].Value);
                    int indiceFila = this.detalleTrabajo.CurrentCell.RowIndex;
                    this.detalleTrabajo.Rows.Remove(this.detalleTrabajo.Rows[indiceFila]);


                }
            }
            //  sumartotal();
        }

        private void detalleRepuesto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == detalleRepuesto.Columns["QuitarRepuesto"].Index)
            {
                DialogResult Opcion;

                Opcion = MessageBox.Show("Realmente desea Quitar el Equipo", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int indiceFila = this.detalleRepuesto.CurrentCell.RowIndex;
                    this.detalleRepuesto.Rows.Remove(this.detalleRepuesto.Rows[indiceFila]);

                }
            }
            else
            {
                if (e.ColumnIndex == detalleRepuesto.Columns["EditarRepuesto"].Index)
                {
                    //   this.txtProducto.ValueMember = Convert.ToString(this.dataDetalle.CurrentRow.Cells["id"].Value);
                    this.txtRepuesto.Text = Convert.ToString(this.detalleRepuesto.CurrentRow.Cells["Descripcion"].Value);
                    int indiceFila = this.detalleRepuesto.CurrentCell.RowIndex;
                    this.detalleRepuesto.Rows.Remove(this.detalleRepuesto.Rows[indiceFila]);
                    // this.dataDetalle.Rows.Remove(dataDetalle.CurrentRow);


                }
            }
            //  sumartotal();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            this.pRegistro.Visible = false;
            this.pListas.Visible = true;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["EliminarServicio"].Index)
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente desea Eliminar El Registro", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {

                    String Codigo;
                    String Rpta = "";

                    Codigo = Convert.ToString(this.dataListado.CurrentRow.Cells["id"].Value);
                    NDetalleEquipo.Eliminar(Convert.ToInt32(Codigo));
                    NDetalleRepuesto.Eliminar(Convert.ToInt32(Codigo));
                    NDetalleTrabajo.Eliminar(Convert.ToInt32(Codigo));
                    Rpta = NOrden.Eliminar(Convert.ToInt32(Codigo));


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
                if (e.ColumnIndex == dataListado.Columns["EditarServicio"].Index)
                {
                    this.txtIdOrden.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idOrden"].Value);
                    // this.txtFecha.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["fecha"].Value);
                    // this.txtPrecio.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["precio"].Value);                      
                    this.txtCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cliente_nombre"].Value);
                    this.txtEmpleado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["empleado_nombre"].Value);
                    this.txtTecnico.Text= Convert.ToString(this.dataListado.CurrentRow.Cells["tecnico_nombre"].Value);
                    this.crearTablas();
                    this.buscarDetalles();
                    this.ordenarDetalle();
                    usar = true;
                    this.pListas.Visible = false;
                    this.IsEditar = true;
                    this.IsNuevo = false;
                    this.pRegistro.Visible = true;
                    this.txtFecha.Focus();
                    this.cargarComboTecnico();
                    this.cargarComboCliente();
                    this.cargarComboEmpleado();
                    this.sumarMontoTotal();
                    
                }
            }
        }

        private void crearTablas()
        {
            crearTablaEquipo();
            crearTablaRepuesto();
            crearTablaTrabajo();
        }
         private void buscarDetalles()
        {
            this.detalleEquipo.DataSource = NDetalleEquipo.BuscarNombre(Convert.ToInt32(this.txtIdOrden.Text));
            this.ordenarDetalleEquipo();
            this.detalleRepuesto.DataSource = NDetalleRepuesto.BuscarNombre(Convert.ToInt32(this.txtIdOrden.Text));
            this.ordenarDetallaRepuesto();
            this.detalleTrabajo.DataSource = NDetalleTrabajo.BuscarNombre(Convert.ToInt32(this.txtIdOrden.Text));
            this.ordenarDetalleTrabajo();
        }

        private void ordenarDetalleEquipo()
        {
            this.detalleEquipo.Columns["idEquipo"].DisplayIndex = 0;
            this.detalleEquipo.Columns["idEquipo"].HeaderText = "id";
            this.detalleEquipo.Columns["Nombre"].DisplayIndex = 1;
            this.detalleEquipo.Columns["Descripcion"].DisplayIndex = 2;
            this.detalleEquipo.Columns["Modelo"].DisplayIndex = 3;
            this.detalleEquipo.Columns["Marca"].DisplayIndex = 4;
            this.detalleEquipo.Columns["Serie"].DisplayIndex = 5;
            this.detalleEquipo.Columns["EditarEquipo"].DisplayIndex = 6;
            this.detalleEquipo.Columns["QuitarEquipo"].DisplayIndex = 7;
        }

        private void ordenarDetalleTrabajo()
        {
            this.detalleTrabajo.Columns["idTrabajo"].DisplayIndex = 0;
            this.detalleTrabajo.Columns["idTrabajo"].HeaderText = "id";
            this.detalleTrabajo.Columns["Nombre"].DisplayIndex = 1;
            this.detalleTrabajo.Columns["Precio"].DisplayIndex = 2;
            this.detalleTrabajo.Columns["EditarTrabajo"].DisplayIndex = 3;
            this.detalleTrabajo.Columns["QuitarTrabajo"].DisplayIndex = 4;
        }
        private void ordenarDetallaRepuesto()
        {
            this.detalleRepuesto.Columns["idRepuesto"].DisplayIndex = 0;
            this.detalleRepuesto.Columns["idRepuesto"].HeaderText = "id";
            this.detalleRepuesto.Columns["Descripcion"].DisplayIndex = 1;
            this.detalleRepuesto.Columns["Modelo"].DisplayIndex = 2;
            this.detalleRepuesto.Columns["Marca"].DisplayIndex = 3;           
            this.detalleRepuesto.Columns["Cantidad"].DisplayIndex = 4;
            this.detalleRepuesto.Columns["Precio"].DisplayIndex = 5;
         //   this.detalleRepuesto.Columns["Total"].DisplayIndex = 6;

            this.detalleRepuesto.Columns["EditarRepuesto"].DisplayIndex = 6;
            this.detalleRepuesto.Columns["QuitarRepuesto"].DisplayIndex = 7;
        }

        private void ordenarDetalle()
        {
            this.ordenarDetallaRepuesto();
            this.ordenarDetalleEquipo();
            this.ordenarDetalleTrabajo();
        }
    }
}
