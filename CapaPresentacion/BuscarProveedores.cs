using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class BuscarProveedores : Form
    {
        private static BuscarProveedores frmInstance = null;
        ProveedoresNegocio proveedoresNegocio = new ProveedoresNegocio();
        List<proc_CargarTodosProveedores_Result> proc_CargarTodosProveedores_Results;
        public static int proveedorID;
        Proveedore proveedorEntidad = new Proveedore();
        public static bool verificar = false;

        public static BuscarProveedores Instance()
        {
            if (((frmInstance == null) || (frmInstance.IsDisposed == true)))
            {
                frmInstance = new BuscarProveedores();
            }
            else
            {
                frmInstance.BringToFront();
            }
            return frmInstance;
        }

        public BuscarProveedores()
        {
            InitializeComponent();
        }

        private void BuscarProovedores_Load(object sender, EventArgs e)
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

        private void btnEditarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                proveedorID = (int)dgvProveedor.Rows[dgvProveedor.CurrentRow.Index].Cells[0].Value;
                EditarProveedor editarProveedor = null;
                editarProveedor = EditarProveedor.Instance();
                editarProveedor.ShowDialog();
                dgvProveedor.RefreshEdit();

            }
            catch (Exception exc)
            {
                MessageBox.Show("Haga clic en un proveedor" + exc.ToString(), "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                loggeator.EscribeEnArchivo(exc.ToString());
            }

        }
        private void btnCompra_Click(object sender, EventArgs e)
        {
            try
            {
                proveedorID = (int)dgvProveedor.Rows[dgvProveedor.CurrentRow.Index].Cells[0].Value;
                DetallesOrdenCompra.abiertoDesdeBuscarProveedorForm = true;
                DetallesOrdenCompra detallesOrdenCompra = null;
                detallesOrdenCompra = DetallesOrdenCompra.Instance();
                detallesOrdenCompra.MdiParent = this.MdiParent;
                detallesOrdenCompra.Show();
                this.Close();
            }
            catch (Exception exc)
            {

                MessageBox.Show("Haga clic en un proveedor" + exc.ToString(), "Error!",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                loggeator.EscribeEnArchivo(exc.ToString());

            }

        }

        private void CargarDataGridView()
        {
            proc_CargarTodosProveedores_Results = proveedoresNegocio.CargarTodosProveedores().ToList();
            dgvProveedor.DataSource = proc_CargarTodosProveedores_Results;
        }
        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbtnNombre.Checked == true)
                    dgvProveedor.DataSource = proc_CargarTodosProveedores_Results.Where(p => p.Nombre.Contains(txtBuscar.Text)).ToList();
                if (rbtnCedulaORnc.Checked == true)
                    dgvProveedor.DataSource = proc_CargarTodosProveedores_Results.Where(p => p.CedulaORnc.Contains(txtBuscar.Text)).ToList();
                if (rbtnCodigo.Checked == true)
                    dgvProveedor.DataSource = proc_CargarTodosProveedores_Results.Where(p => p.ProveedorID.ToString().Contains(txtBuscar.Text)).ToList();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loggeator.EscribeEnArchivo(exc.ToString());
            }
           
        }

        private void BuscarProveedores_Activated(object sender, EventArgs e)
        {
            try
            {
                if (verificar)
                {
                    CargarDataGridView();
                    verificar = false;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loggeator.EscribeEnArchivo(exc.ToString());
            }
            
        }

        

        private void dgvProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvProveedor.Rows[dgvProveedor.CurrentRow.Index].Selected = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.ToString(),
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loggeator.EscribeEnArchivo(exc.ToString()); 
            }
        }
    }
}
