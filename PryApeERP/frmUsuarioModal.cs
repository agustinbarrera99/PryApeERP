using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace PryApeERP
{
    public partial class frmUsuarioModal : Form
    {
        private readonly int _idUsuario;
        private readonly UsuarioDAO _dao = new UsuarioDAO();
        private readonly DomicilioDAO _domicilioDao = new DomicilioDAO();

        // Lista en memoria de domicilios que el usuario va armando antes de guardar
        private readonly List<DomicilioItem> _domicilios = new List<DomicilioItem>();
        // Contador negativo para IDs temporales (nuevos domicilios no guardados aún)
        private int _idTemporal = -1;

        public frmUsuarioModal(int idUsuario)
        {
            InitializeComponent();
            UIHelper.AplicarIcono(this);
            _idUsuario = idUsuario;
        }
        private void frmUsuarioModal_Load(object sender, EventArgs e)
        {
            ConfigurarGrillaDomicilios();

            if (_idUsuario > 0)
            {
                this.Text = "Editar Usuario";
                lblTitulo.Text = "  ✏️   Editar Usuario";
                lblPassword.Text = "Nueva contraseña (dejar vacío para no cambiar)";
                CargarDatosUsuario();
                CargarDomiciliosExistentes();
            }
            else
            {
                this.Text = "Nuevo Usuario";
                lblTitulo.Text = "  ➕   Nuevo Usuario";
            }
        }

        private void dgvDomicilios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnEditarDomicilio_Click(sender, EventArgs.Empty);
        }

        private void ConfigurarGrillaDomicilios()
        {
            dgvDomicilios.AutoGenerateColumns = false;
            dgvDomicilios.Columns.Clear();

            dgvDomicilios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDescripcion",
                HeaderText = "Descripción",
                DataPropertyName = "Descripcion",
                Width = 100
            });
            dgvDomicilios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDireccion",
                HeaderText = "Dirección",
                DataPropertyName = "Direccion",
                Width = 160
            });
            dgvDomicilios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLocalidad",
                HeaderText = "Localidad",
                DataPropertyName = "NombreLocalidad",
                Width = 120
            });
            dgvDomicilios.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colPrincipal",
                HeaderText = "Principal",
                DataPropertyName = "Principal",
                Width = 65
            });
        }

        private void CargarDatosUsuario()
        {
            try
            {
                var dt = _dao.ObtenerTodos();
                DataRow[] rows = dt.Select($"Id_usuario = {_idUsuario}");
                if (rows.Length == 0) return;

                DataRow r = rows[0];
                txtNombre.Text = r["nombre"].ToString();
                txtApellido.Text = r["apellido"].ToString();
                txtMail.Text = r["mail"].ToString();
                txtDni.Text = r["dni"].ToString();
                txtTelefono.Text = r["telefono"].ToString();
                chkActivo.Checked = Convert.ToBoolean(r["activo"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el usuario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDomiciliosExistentes()
        {
            try
            {
                var dt = _domicilioDao.ObtenerPorUsuario(_idUsuario);
                _domicilios.Clear();

                foreach (DataRow r in dt.Rows)
                {
                    _domicilios.Add(new DomicilioItem
                    {
                        IdDomicilio = Convert.ToInt32(r["Id_domicilio"]),
                        Descripcion = r["descripcion"].ToString(),
                        Direccion = r["direccion"].ToString(),
                        IdLocalidad = r["Id_localidad"] != DBNull.Value ? Convert.ToInt32(r["Id_localidad"]) : 0,
                        IdProvincia = r["Id_provincia"] != DBNull.Value ? Convert.ToInt32(r["Id_provincia"]) : 0,
                        NombreLocalidad = r["localidad"].ToString(),
                        Lat = r["geo_lat"] != DBNull.Value ? Convert.ToDouble(r["geo_lat"]) : 0,
                        Lng = r["geo_lng"] != DBNull.Value ? Convert.ToDouble(r["geo_lng"]) : 0,
                        Principal = Convert.ToBoolean(r["principal"])
                    });
                }

                RefrescarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar domicilios: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════
        // GRILLA DE DOMICILIOS
        // ══════════════════════════════════════════════════════

        private void RefrescarGrilla()
        {
            // Usamos BindingSource para no perder la selección al refrescar
            var bs = new System.Windows.Forms.BindingSource();
            bs.DataSource = new System.ComponentModel.BindingList<DomicilioItem>(_domicilios);
            dgvDomicilios.DataSource = bs;
        }

        private DomicilioItem ObtenerDomicilioSeleccionado()
        {
            if (dgvDomicilios.CurrentRow == null) return null;
            int idx = dgvDomicilios.CurrentRow.Index;
            if (idx < 0 || idx >= _domicilios.Count) return null;
            return _domicilios[idx];
        }

        // ══════════════════════════════════════════════════════
        // BOTONES DE DOMICILIOS
        // ══════════════════════════════════════════════════════

        private void btnAgregarDomicilio_Click(object sender, EventArgs e)
        {
            using (var frm = new frmDomicilioModal(null))
            {
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                var nuevo = frm.Resultado;
                nuevo.IdDomicilio = _idTemporal--; // ID temporal negativo

                // Si es el primero, marcarlo como principal automáticamente
                if (_domicilios.Count == 0)
                    nuevo.Principal = true;

                // Si el nuevo se marcó como principal, desmarcar los demás
                if (nuevo.Principal)
                    _domicilios.ForEach(d => d.Principal = false);

                _domicilios.Add(nuevo);
                RefrescarGrilla();
            }
        }

        private void btnEditarDomicilio_Click(object sender, EventArgs e)
        {
            var dom = ObtenerDomicilioSeleccionado();
            if (dom == null)
            {
                MostrarAviso("Seleccioná un domicilio para editar.");
                return;
            }

            using (var frm = new frmDomicilioModal(dom))
            {
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                var editado = frm.Resultado;
                editado.IdDomicilio = dom.IdDomicilio; // conservar el ID original

                // Si se marcó como principal, desmarcar los demás
                if (editado.Principal)
                    _domicilios.ForEach(d => d.Principal = false);

                int idx = _domicilios.IndexOf(dom);
                _domicilios[idx] = editado;
                RefrescarGrilla();
            }
        }

        private void btnQuitarDomicilio_Click(object sender, EventArgs e)
        {
            var dom = ObtenerDomicilioSeleccionado();
            if (dom == null)
            {
                MostrarAviso("Seleccioná un domicilio para quitar.");
                return;
            }

            using (var dlg = new frmConfirmacion(
                "¿Quitar domicilio?",
                $"Se quitará el domicilio «{dom.Descripcion} – {dom.Direccion}»."))
            {
                if (dlg.ShowDialog(this) != DialogResult.Yes) return;
            }

            bool eraPrincipal = dom.Principal;
            _domicilios.Remove(dom);

            // Si se eliminó el principal y quedan domicilios, asignar el primero
            if (eraPrincipal && _domicilios.Count > 0)
                _domicilios[0].Principal = true;

            RefrescarGrilla();
        }

        // ══════════════════════════════════════════════════════
        // VALIDACIÓN
        // ══════════════════════════════════════════════════════

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            { MostrarAviso("El nombre es obligatorio."); txtNombre.Focus(); return false; }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            { MostrarAviso("El apellido es obligatorio."); txtApellido.Focus(); return false; }

            if (string.IsNullOrWhiteSpace(txtMail.Text) || !txtMail.Text.Contains("@"))
            { MostrarAviso("Ingresá un email válido."); txtMail.Focus(); return false; }

            if (_idUsuario == 0 && string.IsNullOrWhiteSpace(txtPassword.Text))
            { MostrarAviso("La contraseña es obligatoria para nuevos usuarios."); txtPassword.Focus(); return false; }

            if (_domicilios.Count == 0)
            { MostrarAviso("Agregá al menos un domicilio."); return false; }

            if (!_domicilios.Exists(d => d.Principal))
            { MostrarAviso("Marcá un domicilio como principal."); return false; }

            return true;
        }

        // ══════════════════════════════════════════════════════
        // GUARDAR
        // ══════════════════════════════════════════════════════

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            try
            {
                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string mail = txtMail.Text.Trim();
                string password = txtPassword.Text.Trim();
                bool activo = chkActivo.Checked;
                string dni = txtDni.Text.Trim();
                string telefono = txtTelefono.Text.Trim();

                int idFinal;

                if (_idUsuario == 0)
                {
                    // Insertar usuario y obtener el ID generado
                    idFinal = _dao.Insertar(nombre, apellido, mail, password, activo, dni, telefono);
                }
                else
                {
                    idFinal = _idUsuario;
                    _dao.Actualizar(_idUsuario, nombre, apellido, mail, password, activo, dni, telefono);
                }

                // Estrategia borrar-y-reinsertar para los domicilios
                _domicilioDao.EliminarPorUsuario(idFinal);
                foreach (var dom in _domicilios)
                {
                    _domicilioDao.Insertar(
                        idFinal,
                        dom.Descripcion,
                        dom.Direccion,
                        dom.IdLocalidad,
                        dom.Lat,
                        dom.Lng,
                        dom.Principal);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void MostrarAviso(string mensaje)
        {
            lblToast.Text = "ℹ  " + mensaje;
            lblToast.BackColor = System.Drawing.Color.FromArgb(245, 158, 11);
            lblToast.Visible = true;
            timerToast.Start();
        }

        private void timerToast_Tick(object sender, EventArgs e)
        {
            timerToast.Stop();
            lblToast.Visible = false;
        }
    }

    [System.Runtime.InteropServices.ComVisible(true)]
    public class MapaScriptHelper
    {
        private readonly frmDomicilioModal _form;

        public MapaScriptHelper(frmDomicilioModal form)
        {
            _form = form;
        }

        public void SetCoordenadas(string lat, string lng)
        {
            _form.RecibirCoordenadas(lat, lng);
        }
    }
}