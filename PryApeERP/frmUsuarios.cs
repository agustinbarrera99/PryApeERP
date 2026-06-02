using System;
using System.Data;
using System.Windows.Forms;

namespace PryApeERP
{
    public partial class frmUsuarios : Form
    {
        private int _idSeleccionado = 0;
        private readonly UsuarioDAO _dao = new UsuarioDAO();
        private readonly RedSocialDAO _redDao = new RedSocialDAO();

        public frmUsuarios()
        {
            InitializeComponent();
            UIHelper.AplicarIcono(this);
        }

     
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }
        private void CargarGrilla()
        {
            try
            {
                var dt = _dao.ObtenerTodos();
                dgvUsuarios.DataSource = dt;

                string[] ocultar = {
                    "Id_usuario", "Contraseña", "Id_localidad",
                    "geolocalizacion_lat", "geolocalizacion_lng", "dni",
                    "direccion", "telefono"
                };

                foreach (var col in ocultar)
                {
                    if (dgvUsuarios.Columns[col] != null)
                        dgvUsuarios.Columns[col].Visible = false;
                }

                // Renombrado estético de las columnas visibles
                RenombrarColumna("nombre", "Nombre");
                RenombrarColumna("apellido", "Apellido");
                RenombrarColumna("mail", "Email");
                RenombrarColumna("activo", "Activo");
                RenombrarColumna("localidad", "Localidad");
                RenombrarColumna("provincia", "Provincia");
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar usuarios", ex.Message);
            }
        }

        private void RenombrarColumna(string nombre, string header)
        {
            if (dgvUsuarios.Columns[nombre] != null)
                dgvUsuarios.Columns[nombre].HeaderText = header;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (var frmModal = new frmUsuarioModal(0)) // 0 significa nuevo usuario
            {
                if (frmModal.ShowDialog(this) == DialogResult.OK)
                {
                    MostrarExito("Usuario creado correctamente.");
                    CargarGrilla(); 
                }
            }
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var fila = dgvUsuarios.Rows[e.RowIndex];
            _idSeleccionado = Convert.ToInt32(fila.Cells["Id_usuario"].Value);

            using (var frmModal = new frmUsuarioModal(_idSeleccionado)) // Pasa el ID seleccionado
            {
                if (frmModal.ShowDialog(this) == DialogResult.OK)
                {
                    MostrarExito("Usuario actualizado correctamente.");
                    CargarGrilla(); // Refresca la lista con los cambios
                }
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MostrarAviso("Seleccioná un usuario de la lista primero.");
                return;
            }

            var fila = dgvUsuarios.CurrentRow;
            _idSeleccionado = Convert.ToInt32(fila.Cells["Id_usuario"].Value);
            string nombreCompleto = $"{fila.Cells["nombre"].Value} {fila.Cells["apellido"].Value}";

            using (var dlg = new frmConfirmacion(
                "¿Eliminar usuario?",
                $"Se eliminará al usuario «{nombreCompleto}» y todas sus redes sociales. Esta acción no se puede deshacer."))
            {
                if (dlg.ShowDialog(this) == DialogResult.Yes)
                {
                    try
                    {
                        _redDao.EliminarPorUsuario(_idSeleccionado);
                        _dao.Eliminar(_idSeleccionado);

                        MostrarExito("Usuario eliminado correctamente.");
                        CargarGrilla();
                        _idSeleccionado = 0;
                    }
                    catch (Exception ex)
                    {
                        MostrarError("No se pudo eliminar el usuario", ex.Message);
                    }
                }
            }
        }

        private void MostrarExito(string mensaje)
        {
            lblToast.Text = "✔  " + mensaje;
            lblToast.BackColor = System.Drawing.Color.FromArgb(16, 185, 129); // Esmeralda
            lblToast.Visible = true;
            timerToast.Start();
        }

        private void MostrarAviso(string mensaje)
        {
            lblToast.Text = "ℹ  " + mensaje;
            lblToast.BackColor = System.Drawing.Color.FromArgb(245, 158, 11); // Ámbar
            lblToast.Visible = true;
            timerToast.Start();
        }

        private void MostrarError(string titulo, string detalle)
        {
            lblToast.Text = $"✖  {titulo}: {detalle}";
            lblToast.BackColor = System.Drawing.Color.FromArgb(220, 38, 38); // Rojo peligro
            lblToast.Visible = true;
            timerToast.Start();
        }

        private void timerToast_Tick(object sender, EventArgs e)
        {
            timerToast.Stop();
            lblToast.Visible = false;
        }
    }
}