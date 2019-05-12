using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class TiposDeFacturas : Form
    {
        private static TiposDeFacturas frmInstance = null;
        List<proc_CargarTodosTiposFactura_Result> proc_CargarTodosTiposFactura_Results;
        TiposFacturaNegocio tiposFacturaNegocio = new TiposFacturaNegocio();
        TiposFactura tiposFacturaEntidad = new TiposFactura();
        bool resultado;
        int tipoFacturaId;
        public static TiposDeFacturas Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new TiposDeFacturas();
            }
            else
            {
                frmInstance.BringToFront();
            }
            return frmInstance;
        }
            public TiposDeFacturas()
            {
                InitializeComponent();
            }
        

        private void TiposDePago_Load(object sender, EventArgs e)
        {
            try
            {
                CargarDataGridView();

            }
            catch (Exception exc)
            {

                MessageBox.Show("Error: " + exc.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loggeator.EscribeEnArchivo(exc.ToString());
            }
        }
        private void CargarDataGridView()
        {
            proc_CargarTodosTiposFactura_Results = tiposFacturaNegocio.CargarTodosTiposFactura().ToList();
            dgvTipoDeFacturas.DataSource = proc_CargarTodosTiposFactura_Results;
        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                LlenarTextBoxs();

            }
            catch (Exception exc)
            {

                MessageBox.Show("Error: " + exc.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loggeator.EscribeEnArchivo(exc.ToString());
            }
        }

        private void LlenarTextBoxs()
        {
            txtIDFactura.Text = Convert.ToString(dgvTipoDeFacturas.Rows[dgvTipoDeFacturas.CurrentRow.Index].Cells[0].Value);
            txtTipoFactura.Text = Convert.ToString(dgvTipoDeFacturas.Rows[dgvTipoDeFacturas.CurrentRow.Index].Cells[1].Value);
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                LlenarTextBoxs();

            }
            catch (Exception exc)
            {

                MessageBox.Show("Error: " + exc.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loggeator.EscribeEnArchivo(exc.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                tiposFacturaEntidad.TipoFactura = txtTipoFactura.Text;
                var result = tiposFacturaNegocio.AgregarTiposFactura(tiposFacturaEntidad);

                if (result.Item1)
                {
                    MessageBox.Show(string.Format("El Tipo de Factura con codigo {0}, ha sido agregada correctamente", result.Item2.ToString()), "Tipo de Factura Agregada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDataGridView();
                }
                else
                    MessageBox.Show("Tipo de Factura no pudo ser agregada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                LimpiarTxt();
            }
            catch (Exception exc)
            {

                MessageBox.Show("Error: " + exc.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loggeator.EscribeEnArchivo(exc.ToString());
            }
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                tiposFacturaEntidad.TipoFacturaID = Convert.ToInt32(txtIDFactura.Text);
                tiposFacturaEntidad.TipoFactura = txtTipoFactura.Text;
                var result = tiposFacturaNegocio.EditarTipoFactura(tiposFacturaEntidad);

                if (result)
                {
                    MessageBox.Show("El Tipo de factura ha sido editada correctamente", "Tipo de factura Editada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDataGridView();
                }
                else
                    MessageBox.Show("Tipo de Factura no pudo ser editada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                LimpiarTxt();
            }
            catch (Exception exc)
            {

                MessageBox.Show("Error: " + exc.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loggeator.EscribeEnArchivo(exc.ToString());
            }
            
        }
        private void LimpiarTxt()
        {
            try
            {
                txtIDFactura.Clear();
                txtTipoFactura.Clear();
            }
            catch (Exception exc)
            {

                MessageBox.Show("Error: " + exc.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loggeator.EscribeEnArchivo(exc.ToString());
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                tipoFacturaId = Convert.ToInt32(txtIDFactura.Text);

                var result = tiposFacturaNegocio.BorrarTipoFactura(tipoFacturaId);

                if (result)
                {
                    MessageBox.Show("El Tipo de factura ha sido eliminada correctamente", "Tipo de Factura Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDataGridView();
                }
                else
                    MessageBox.Show("Tipo de factura no pudo ser eliminada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                LimpiarTxt();
            }
            catch (Exception exc)
            {

                MessageBox.Show("Error: " + exc.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loggeator.EscribeEnArchivo(exc.ToString());
            }
            
        }

        private void dgvTipoDeFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvTipoDeFacturas.Rows[dgvTipoDeFacturas.CurrentRow.Index].Selected = true;

            }
            catch (Exception exc)
            {

                MessageBox.Show("Error: " + exc.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loggeator.EscribeEnArchivo(exc.ToString());
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}