using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace PryApeERP
{
    public partial class frmRelUsuarioPerfil : Form
    {
        private int _idSeleccionado = 0;  // id de usuario_perfil seleccionado

        public frmRelUsuarioPerfil()
        {
            InitializeComponent();
        }

        private void frmRelUsuarioPerfil_Load(object sender, EventArgs e)
        {
            btnAsignar.Click += btnAsignar_Click;
            btnEliminar.Click += btnEliminar_Click;
            dgvAsignaciones.CellClick += dgvAsignaciones_CellClick;

            CargarCombos();
            CargarGrilla();
        }

        // ── Carga de datos ────────────────────────────────
        private void CargarCombos()
        {
            try
            {
                using (var cx = new clsConexion())
                {
                    // Usuarios
                    var dtU = new DataTable();
                    new OleDbDataAdapter(
                        new OleDbCommand(
                            "SELECT Id_usuario, nombre & ' ' & apellido AS nombreCompleto FROM usuario ORDER BY nombre",
                            cx.ObtenerConexion())).Fill(dtU);

                    cmbUsuario.DataSource = dtU;
                    cmbUsuario.DisplayMember = "nombreCompleto";
                    cmbUsuario.ValueMember = "Id_usuario";
                    cmbUsuario.SelectedIndex = -1;

                    // Perfiles
                    var dtP = new DataTable();
                    new OleDbDataAdapter(
                        new OleDbCommand(
                            "SELECT Id_perfil, nombre FROM perfil ORDER BY nombre",
                            cx.ObtenerConexion())).Fill(dtP);

                    cmbPerfil.DataSource = dtP;
                    cmbPerfil.DisplayMember = "nombre";
                    cmbPerfil.ValueMember = "Id_perfil";
                    cmbPerfil.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar combos:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrilla()
        {
            try
            {
                var dt = new DataTable();
                using (var cx = new clsConexion())
                {
                    string sql = @"
                        SELECT up.id,
                               u.nombre & ' ' & u.apellido AS Usuario,
                               p.nombre AS Perfil
                        FROM   (usuario_perfil up
                                INNER JOIN usuario u ON up.Id_usuario = u.Id_usuario)
                                INNER JOIN perfil  p ON up.Id_perfil  = p.Id_perfil
                        ORDER BY u.nombre";

                    new OleDbDataAdapter(
                        new OleDbCommand(sql, cx.ObtenerConexion())).Fill(dt);
                }

                dgvAsignaciones.DataSource = dt;

                if (dgvAsignaciones.Columns["id"] != null)
                    dgvAsignaciones.Columns["id"].Visible = false;

                if (dgvAsignaciones.Columns["Usuario"] != null)
                    dgvAsignaciones.Columns["Usuario"].HeaderText = "Usuario";

                if (dgvAsignaciones.Columns["Perfil"] != null)
                    dgvAsignaciones.Columns["Perfil"].HeaderText = "Perfil";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar asignaciones:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Selección en grilla ───────────────────────────
        private void dgvAsignaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            _idSeleccionado = Convert.ToInt32(
                dgvAsignaciones.Rows[e.RowIndex].Cells["id"].Value);
        }

        // ── Botones ───────────────────────────────────────
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedValue == null || cmbPerfil.SelectedValue == null)
            {
                MessageBox.Show("Seleccioná un usuario y un perfil.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idUsuario = Convert.ToInt32(cmbUsuario.SelectedValue);
                int idPerfil = Convert.ToInt32(cmbPerfil.SelectedValue);

                using (var cx = new clsConexion())
                {
                    // Evitar duplicados
                    string sqlCheck = "SELECT COUNT(*) FROM usuario_perfil WHERE Id_usuario=? AND Id_perfil=?";
                    var cmdCheck = new OleDbCommand(sqlCheck, cx.ObtenerConexion());
                    cmdCheck.Parameters.AddWithValue("?", idUsuario);
                    cmdCheck.Parameters.AddWithValue("?", idPerfil);

                    int existe = Convert.ToInt32(cmdCheck.ExecuteScalar());
                    if (existe > 0)
                    {
                        MessageBox.Show("Esa combinación ya existe.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    string sql = "INSERT INTO usuario_perfil (Id_usuario, Id_perfil) VALUES (?, ?)";
                    var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
                    cmd.Parameters.AddWithValue("?", idUsuario);
                    cmd.Parameters.AddWithValue("?", idPerfil);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Asignación guardada.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al asignar:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == 0)
            {
                MessageBox.Show("Seleccioná una fila primero.");
                return;
            }

            if (MessageBox.Show("¿Quitar la asignación seleccionada?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (var cx = new clsConexion())
                    {
                        string sql = "DELETE FROM usuario_perfil WHERE id = ?";
                        var cmd = new OleDbCommand(sql, cx.ObtenerConexion());
                        cmd.Parameters.AddWithValue("?", _idSeleccionado);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Asignación eliminada.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _idSeleccionado = 0;
                    CargarGrilla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar:\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Necesario para que el Load se dispare
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            frmRelUsuarioPerfil_Load(this, e);
        }
    }
}