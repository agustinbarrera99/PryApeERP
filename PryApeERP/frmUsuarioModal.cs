using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PryApeERP
{
    public partial class frmUsuarioModal : Form
    {
        private readonly int _idUsuario;
        private readonly UsuarioDAO _dao = new UsuarioDAO();
        private readonly DomicilioDAO _domicilioDao = new DomicilioDAO();
        private readonly RedSocialDAO _redDao = new RedSocialDAO();

        // Lista en memoria de domicilios que el usuario va armando antes de guardar
        private readonly List<DomicilioItem> _domicilios = new List<DomicilioItem>();
        // Contador negativo para IDs temporales (nuevos domicilios no guardados aún)
        private int _idTemporal = -1;

        // Lista en memoria de redes sociales que el usuario va armando antes de guardar
        private readonly List<RedSocialItem> _redesSociales = new List<RedSocialItem>();
        // Contador negativo para IDs temporales (nuevas redes no guardadas aún)
        private int _idTemporalRed = -1;

        public frmUsuarioModal(int idUsuario)
        {
            InitializeComponent();
            UIHelper.AplicarIcono(this);
            _idUsuario = idUsuario;
        }
        private void frmUsuarioModal_Load(object sender, EventArgs e)
        {
            ConfigurarGrillaDomicilios();
            ConfigurarGrillaRedes();

            if (_idUsuario > 0)
            {
                this.Text = "Editar Usuario";
                lblTitulo.Text = "  ✏️   Editar Usuario";
                // Ya no tocamos lblPassword.Text (queda fijo "Contraseña *" siempre).
                // En su lugar mostramos el hint aparte, que no compite por ancho con lblDni.
                lblPassword.Visible = true;
                txtPassword.Visible = true;
                lblPasswordHint.Text = "Dejar vacío para no cambiar";
                lblPasswordHint.Location = new System.Drawing.Point(
                    lblPasswordHint.Location.X, txtPassword.Bottom + 4);
                lblPasswordHint.Visible = true;
                CargarDatosUsuario();
                CargarDomiciliosExistentes();
                CargarRedesExistentes();
            }
            else
            {
                this.Text = "Nuevo Usuario";
                lblTitulo.Text = "  ➕   Nuevo Usuario";
                // La contraseña ya no la elige quien crea el usuario: se genera
                // sola a partir de nombre/apellido/DNI. Ocultamos el campo para
                // que no parezca editable, y usamos el hint para avisarlo.
                lblPassword.Visible = false;
                txtPassword.Visible = false;
                lblPasswordHint.Text = "La contraseña se genera automáticamente";
                lblPasswordHint.Location = lblPassword.Location;
                lblPasswordHint.Visible = true;
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
        // GRILLA DE REDES SOCIALES
        // ══════════════════════════════════════════════════════

        private void ConfigurarGrillaRedes()
        {
            dgvRedes.AutoGenerateColumns = false;
            dgvRedes.Columns.Clear();

            dgvRedes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRed",
                HeaderText = "Red Social",
                DataPropertyName = "NombreRed",
                Width = 120
            });
            dgvRedes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colUrl",
                HeaderText = "URL / Usuario",
                DataPropertyName = "UrlPerfil",
                Width = 220
            });
        }

        private void CargarRedesExistentes()
        {
            try
            {
                var dt = _redDao.ObtenerPorUsuario(_idUsuario);
                _redesSociales.Clear();

                foreach (DataRow r in dt.Rows)
                {
                    _redesSociales.Add(new RedSocialItem
                    {
                        Id = Convert.ToInt32(r["Id"]),
                        IdRed = Convert.ToInt32(r["Id_red"]),
                        NombreRed = r["nombre"].ToString(),
                        UrlPerfil = r["url_perfil"].ToString()
                    });
                }

                RefrescarGrillaRedes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar redes sociales: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefrescarGrillaRedes()
        {
            var bs = new BindingSource();
            bs.DataSource = new System.ComponentModel.BindingList<RedSocialItem>(_redesSociales);
            dgvRedes.DataSource = bs;
        }

        private RedSocialItem ObtenerRedSeleccionada()
        {
            if (dgvRedes.CurrentRow == null) return null;
            int idx = dgvRedes.CurrentRow.Index;
            if (idx < 0 || idx >= _redesSociales.Count) return null;
            return _redesSociales[idx];
        }

        private void dgvRedes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnEditarRed_Click(sender, EventArgs.Empty);
        }

        // ══════════════════════════════════════════════════════
        // BOTONES DE REDES SOCIALES
        // ══════════════════════════════════════════════════════

        private void btnAgregarRed_Click(object sender, EventArgs e)
        {
            var idsUsados = _redesSociales.Select(r => r.IdRed).ToList();

            using (var frm = new frmRedSocialModal(null, idsUsados))
            {
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                var nueva = frm.Resultado;
                nueva.Id = _idTemporalRed--; // ID temporal negativo
                _redesSociales.Add(nueva);
                RefrescarGrillaRedes();
            }
        }

        private void btnEditarRed_Click(object sender, EventArgs e)
        {
            var red = ObtenerRedSeleccionada();
            if (red == null)
            {
                MostrarAviso("Seleccioná una red social para editar.");
                return;
            }

            // Excluye todas las usadas menos la que se está editando
            var idsUsados = _redesSociales.Where(r => r != red).Select(r => r.IdRed).ToList();

            using (var frm = new frmRedSocialModal(red, idsUsados))
            {
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                var editada = frm.Resultado;
                editada.Id = red.Id; // conserva el ID original

                int idx = _redesSociales.IndexOf(red);
                _redesSociales[idx] = editada;
                RefrescarGrillaRedes();
            }
        }

        private void btnQuitarRed_Click(object sender, EventArgs e)
        {
            var red = ObtenerRedSeleccionada();
            if (red == null)
            {
                MostrarAviso("Seleccioná una red social para quitar.");
                return;
            }

            using (var dlg = new frmConfirmacion(
                "¿Quitar red social?",
                $"Se quitará «{red.NombreRed}»."))
            {
                if (dlg.ShowDialog(this) != DialogResult.Yes) return;
            }

            _redesSociales.Remove(red);
            RefrescarGrillaRedes();
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

            if (_idUsuario == 0 && string.IsNullOrWhiteSpace(txtDni.Text))
            { MostrarAviso("El DNI es obligatorio: se usa para generar la contraseña."); txtDni.Focus(); return false; }

            if (_domicilios.Count == 0)
            { MostrarAviso("Agregá al menos un domicilio."); return false; }

            if (!_domicilios.Exists(d => d.Principal))
            { MostrarAviso("Marcá un domicilio como principal."); return false; }

            // Las redes sociales son opcionales. Si querés forzar al menos una,
            // descomentá lo siguiente (misma lógica que domicilios):
            // if (_redesSociales.Count == 0)
            // { MostrarAviso("Agregá al menos una red social."); return false; }

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
                bool activo = chkActivo.Checked;
                string dni = txtDni.Text.Trim();
                string telefono = txtTelefono.Text.Trim();

                int idFinal;
                string passwordGenerada = null;

                if (_idUsuario == 0)
                {
                    // La contraseña no la tipea quien crea el usuario: se arma
                    // sola con la regla inicial + apellido + últimos 3 dígitos del DNI.
                    passwordGenerada = GenerarPassword(nombre, apellido, dni);
                    idFinal = _dao.Insertar(nombre, apellido, mail, passwordGenerada, activo, dni, telefono);
                }
                else
                {
                    string password = txtPassword.Text.Trim();
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

                // Estrategia borrar-y-reinsertar para las redes sociales, igual que domicilios
                _redDao.EliminarPorUsuario(idFinal);
                foreach (var red in _redesSociales)
                {
                    _redDao.InsertarUsuarioRed(idFinal, red.IdRed, red.UrlPerfil);
                }

                if (passwordGenerada != null)
                {
                    MessageBox.Show(
                        $"Usuario creado.\nContraseña generada: {passwordGenerada}",
                        "Usuario creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // ══════════════════════════════════════════════════════
        // GENERACIÓN DE CONTRASEÑA
        // ══════════════════════════════════════════════════════

        // Regla: primera letra del nombre (mayúscula) + apellido + últimos 3
        // dígitos del DNI. Si el DNI tiene menos de 3 dígitos, se usan todos
        // los que haya. Se descarta cualquier carácter no numérico del DNI
        // (puntos, espacios, etc.) antes de tomar los últimos 3.
        private static string GenerarPassword(string nombre, string apellido, string dni)
        {
            string inicial = nombre.Trim().Length > 0
                ? nombre.Trim().Substring(0, 1).ToUpper()
                : "";

            string apellidoLimpio = apellido.Trim();

            string dniSoloDigitos = new string((dni ?? "").Where(char.IsDigit).ToArray());
            string ultimos3 = dniSoloDigitos.Length >= 3
                ? dniSoloDigitos.Substring(dniSoloDigitos.Length - 3)
                : dniSoloDigitos;

            return inicial + apellidoLimpio + ultimos3;
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
}