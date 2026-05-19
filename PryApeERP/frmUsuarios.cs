using System;
using System.Data;
using System.Windows.Forms;

namespace PryApeERP
{
    public partial class frmUsuarios : Form
    {
        private int _idSeleccionado = 0;
        private readonly UsuarioDAO _dao = new UsuarioDAO();

        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            EstadoFormulario(false);
        }

        // ── Grilla ────────────────────────────────────────
        private void CargarGrilla()
        {
            try
            {
                var dt = _dao.ObtenerTodos();
                dgvUsuarios.DataSource = dt;

                // Ocultar ID
                if (dgvUsuarios.Columns["Id_usuario"] != null)
                    dgvUsuarios.Columns["Id_usuario"].Visible = false;

                // Renombrar encabezados
                if (dgvUsuarios.Columns["nombre"] != null)
                    dgvUsuarios.Columns["nombre"].HeaderText = "Nombre";
                if (dgvUsuarios.Columns["apellido"] != null)
                    dgvUsuarios.Columns["apellido"].HeaderText = "Apellido";
                if (dgvUsuarios.Columns["mail"] != null)
                    dgvUsuarios.Columns["mail"].HeaderText = "Email";
                if (dgvUsuarios.Columns["Contraseña"] != null)
                    dgvUsuarios.Columns["Contraseña"].Visible = false; // nunca mostrar
                if (dgvUsuarios.Columns["activo"] != null)
                    dgvUsuarios.Columns["activo"].HeaderText = "Activo";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var fila = dgvUsuarios.Rows[e.RowIndex];
            _idSeleccionado = Convert.ToInt32(fila.Cells["Id_usuario"].Value);
            txtId.Text = _idSeleccionado.ToString();
            txtNombre.Text = fila.Cells["nombre"].Value?.ToString();
            txtApellido.Text = fila.Cells["apellido"].Value?.ToString();
            txtEmail.Text = fila.Cells["mail"].Value?.ToString();
            txtPassword.Text = "";  // nunca se muestra la contraseña
            chkActivo.Checked = Convert.ToBoolean(fila.Cells["activo"].Value);

            EstadoFormulario(true);
        }

        // ── Botones ───────────────────────────────────────
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            EstadoFormulario(true);
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            try
            {
                if (_idSeleccionado == 0)
                    _dao.Insertar(txtNombre.Text, txtApellido.Text,
                                  txtEmail.Text, txtPassword.Text, chkActivo.Checked);
                else
                    _dao.Actualizar(_idSeleccionado, txtNombre.Text, txtApellido.Text,
                                    txtEmail.Text, txtPassword.Text, chkActivo.Checked);

                MessageBox.Show("Usuario guardado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarGrilla();
                LimpiarFormulario();
                EstadoFormulario(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == 0)
            {
                MessageBox.Show("Seleccioná un usuario primero.");
                return;
            }

            if (MessageBox.Show("¿Eliminar el usuario seleccionado?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    _dao.Eliminar(_idSeleccionado);
                    MessageBox.Show("Usuario eliminado.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarGrilla();
                    LimpiarFormulario();
                    EstadoFormulario(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar:\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            EstadoFormulario(false);
        }

        // ── Helpers ───────────────────────────────────────
        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("El email es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (_idSeleccionado == 0 && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("La contraseña es obligatoria para usuarios nuevos.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void LimpiarFormulario()
        {
            _idSeleccionado = 0;
            txtId.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            chkActivo.Checked = true;
        }

        private void EstadoFormulario(bool edicion)
        {
            txtNombre.Enabled = edicion;
            txtApellido.Enabled = edicion;
            txtEmail.Enabled = edicion;
            txtPassword.Enabled = edicion;
            chkActivo.Enabled = edicion;
            btnGuardar.Enabled = edicion;
            btnEliminar.Enabled = edicion && _idSeleccionado > 0;
            btnCancelar.Enabled = edicion;
        }
    }
}