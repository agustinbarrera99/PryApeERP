using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace PryApeERP
{
    public partial class frmAuditoria : Form
    {
        private readonly AuditoriaDAO _dao = new AuditoriaDAO();
        private DataTable _datosCompletos;

        public frmAuditoria()
        {
            InitializeComponent();
            UIHelper.AplicarIcono(this);
            this.Text = "Auditoría de Sesiones";

            // CAPA 3 (defensa en profundidad): ver el mismo comentario en frmUsuarios.cs
            if (!SeguridadHelper.PuedeAccederModuloSeguridad(Sesion.IdPerfil))
            {
                this.BeginInvoke(new Action(() =>
                {
                    MessageBox.Show("No tenés permisos para acceder a este módulo.",
                        "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }));
                return;
            }
        }

        private void frmAuditoria_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Today;
            chkFiltrarFecha.Checked = false;
            dtpDesde.Enabled = false;
            dtpHasta.Enabled = false;
            btnFiltrarFecha.Enabled = false;

            CargarDatos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            chkFiltrarFecha.Checked = false; // dispara FiltroFecha_Changed, que ya reaplica filtros
            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Today;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        /// <summary>
        /// Habilita/deshabilita los controles de fecha según el checkbox.
        /// El filtro de fecha en sí solo se aplica al presionar btnFiltrarFecha,
        /// salvo cuando se destilda el checkbox, que lo quita al instante.
        /// </summary>
        private void FiltroFecha_Changed(object sender, EventArgs e)
        {
            dtpDesde.Enabled = chkFiltrarFecha.Checked;
            dtpHasta.Enabled = chkFiltrarFecha.Checked;
            btnFiltrarFecha.Enabled = chkFiltrarFecha.Checked;

            if (!chkFiltrarFecha.Checked)
                AplicarFiltros();
        }

        private void btnFiltrarFecha_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser posterior a la fecha 'Hasta'.",
                    "Rango inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AplicarFiltros();
        }

        private void CargarDatos()
        {
            _datosCompletos = _dao.ObtenerTodos();
            dgvAuditoria.DataSource = _datosCompletos;

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
            AplicarFiltros();
        }

        /// <summary>
        /// Arma el RowFilter combinando texto (mail) y rango de fechas (fecha_hora),
        /// y lo aplica sobre el DataView sin volver a consultar la base de datos.
        /// </summary>
        private void AplicarFiltros()
        {
            if (_datosCompletos == null) return;

            DataView dv = _datosCompletos.DefaultView;
            string filtroTexto = txtBuscar.Text.Trim().Replace("'", "''");
            string expresion = "";

            if (!string.IsNullOrEmpty(filtroTexto))
            {
                expresion = $"mail LIKE '%{filtroTexto}%'";
            }

            if (chkFiltrarFecha.Checked)
            {
                // Los literales de fecha en RowFilter van entre # # con formato invariante MM/dd/yyyy
                DateTime desde = dtpDesde.Value.Date;
                DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1); // hasta las 23:59:59

                string desdeStr = desde.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                string hastaStr = hasta.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                string filtroFecha = $"fecha_hora >= #{desdeStr}# AND fecha_hora <= #{hastaStr}#";

                expresion = string.IsNullOrEmpty(expresion)
                    ? filtroFecha
                    : $"{expresion} AND {filtroFecha}";
            }

            dv.RowFilter = expresion;
            dgvAuditoria.DataSource = dv;
            ActualizarContador(dv.Count);
        }

        private void ActualizarContador(int cantidad)
        {
            lblContador.Text = $"Total de registros: {cantidad}";
        }
    }
}