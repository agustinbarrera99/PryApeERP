using System;
using System.Data;
using System.Windows.Forms;

namespace PryApeERP
{
    public partial class frmAuditoria : Form
    {
        private readonly AuditoriaDAO _dao = new AuditoriaDAO();

        public frmAuditoria()
        {
            InitializeComponent();
            UIHelper.AplicarIcono(this);
            this.Text = "Auditoría de Sesiones";
        }

        private void frmAuditoria_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarDatos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(filtro))
            {
                CargarDatos();
                return;
            }

            DataTable dt = _dao.ObtenerTodos();
            DataView dv = dt.DefaultView;
            dv.RowFilter = $"mail LIKE '%{filtro}%'";
            dgvAuditoria.DataSource = dv.ToTable();
            ActualizarContador(dgvAuditoria.RowCount);
        }

        private void CargarDatos()
        {
            DataTable dt = _dao.ObtenerTodos();
            dgvAuditoria.DataSource = dt;

            // Renombrar columnas
            if (dgvAuditoria.Columns.Contains("Id_auditoria"))
                dgvAuditoria.Columns["Id_auditoria"].HeaderText = "ID";
            if (dgvAuditoria.Columns.Contains("Id_usuario"))
                dgvAuditoria.Columns["Id_usuario"].HeaderText = "ID Usuario";
            if (dgvAuditoria.Columns.Contains("mail"))
                dgvAuditoria.Columns["mail"].HeaderText = "Correo";
            if (dgvAuditoria.Columns.Contains("fecha_hora"))
                dgvAuditoria.Columns["fecha_hora"].HeaderText = "Fecha y Hora";
            if (dgvAuditoria.Columns.Contains("exitoso"))
                dgvAuditoria.Columns["exitoso"].HeaderText = "Exitoso";
            if (dgvAuditoria.Columns.Contains("intentos_restantes"))
                dgvAuditoria.Columns["intentos_restantes"].HeaderText = "Intentos Rest.";

            dgvAuditoria.AutoResizeColumns();
            ActualizarContador(dgvAuditoria.RowCount);
        }

        private void ActualizarContador(int cantidad)
        {
            lblContador.Text = $"Total de registros: {cantidad}";
        }
    }
}