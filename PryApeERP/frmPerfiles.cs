using System;
using System.Data;
using System.Windows.Forms;

namespace PryApeERP
{
    public partial class frmPerfiles : Form
    {
        private int _idSeleccionado = 0;
        private readonly PerfilDAO _dao = new PerfilDAO();

        public frmPerfiles()
        {
            InitializeComponent();
            dgvPerfiles.CellClick += dgvPerfiles_CellClick;
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnCancelar.Click += btnCancelar_Click;
            CargarGrilla();
            EstadoFormulario(false);
        }

        private void frmPerfiles_Load(object sender, EventArgs e)
        {

        }

        // ── Grilla ────────────────────────────────────────
        private void CargarGrilla()
        {
            try
            {
                var dt = _dao.ObtenerTodos();
                dgvPerfiles.DataSource = dt;

                if (dgvPerfiles.Columns["Id_perfil"] != null)
                    dgvPerfiles.Columns["Id_perfil"].Visible = false;

                if (dgvPerfiles.Columns["nombre"] != null)
                    dgvPerfiles.Columns["nombre"].HeaderText = "Perfil";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar perfiles:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPerfiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var fila = dgvPerfiles.Rows[e.RowIndex];
            _idSeleccionado = Convert.ToInt32(fila.Cells["Id_perfil"].Value);
            txtId.Text = _idSeleccionado.ToString();
            txtNombre.Text = fila.Cells["nombre"].Value?.ToString();

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
                    _dao.Insertar(txtNombre.Text);
                else
                    _dao.Actualizar(_idSeleccionado, txtNombre.Text);

                MessageBox.Show("Perfil guardado correctamente.", "Éxito",
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
                MessageBox.Show("Seleccioná un perfil primero.");
                return;
            }

            if (MessageBox.Show("¿Eliminar el perfil seleccionado?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    _dao.Eliminar(_idSeleccionado);
                    MessageBox.Show("Perfil eliminado.", "Información",
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
                MessageBox.Show("El nombre del perfil es obligatorio.", "Validación",
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
        }

        private void EstadoFormulario(bool edicion)
        {
            txtNombre.Enabled = edicion;
            btnGuardar.Enabled = edicion;
            btnEliminar.Enabled = edicion && _idSeleccionado > 0;
            btnCancelar.Enabled = edicion;
        }
    }
}