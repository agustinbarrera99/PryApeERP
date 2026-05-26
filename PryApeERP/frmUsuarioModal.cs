using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace PryApeERP
{
    public partial class frmUsuarioModal : Form
    {
        private readonly int _idUsuario;
        private readonly UsuarioDAO _dao = new UsuarioDAO();
        private readonly ProvinciaDAO _provinciaDao = new ProvinciaDAO();
        private readonly LocalidadDAO _localidadDao = new LocalidadDAO();

        private int _idLocalidadPendiente = 0;
        private bool _mapaListo = false;
        private bool _actualizandoDesdeJs = false;

        public frmUsuarioModal(int idUsuario)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
        }

        private void splitMain_SizeChanged(object sender, EventArgs e)
        {
            int ancho = splitMain.Width;
            int min = splitMain.Panel1MinSize + splitMain.Panel2MinSize + splitMain.SplitterWidth;

            if (ancho <= min) return;

            int distancia = (int)(ancho * 0.50);
            distancia = Math.Max(distancia, splitMain.Panel1MinSize);
            distancia = Math.Min(distancia, ancho - splitMain.Panel2MinSize - splitMain.SplitterWidth);

            splitMain.SplitterDistance = distancia;
        }

        private void frmUsuarioModal_Load(object sender, EventArgs e)
        {
            try
            {
                int ancho = splitMain.Width;
                int distancia = (int)(ancho * 0.50);
                distancia = Math.Max(distancia, splitMain.Panel1MinSize);
                distancia = Math.Min(distancia, ancho - splitMain.Panel2MinSize - splitMain.SplitterWidth);
                if (distancia > splitMain.Panel1MinSize)
                    splitMain.SplitterDistance = distancia;
            }
            catch { /* ignorar si el tamaño aún no está listo */ }

            CargarProvincias();
            CargarMapa();

            if (_idUsuario > 0)
            {
                this.Text = "Editar Usuario";
                lblTitulo.Text = "  ✏️   Editar Usuario";
                lblPassword.Text = "Nueva contraseña (dejar vacío para no cambiar)";
                CargarDatosUsuario();
            }
            else
            {
                this.Text = "Nuevo Usuario";
                lblTitulo.Text = "  ➕   Nuevo Usuario";
            }
        }
        private void CargarMapa()
        {
            string html = @"<!DOCTYPE html>
<html>
<head>
<meta charset='utf-8'/>
<style>
  html, body, #map { margin:0; padding:0; width:100%; height:100%; }
</style>
<link rel='stylesheet' href='https://unpkg.com/leaflet@1.9.4/dist/leaflet.css'/>
<script src='https://unpkg.com/leaflet@1.9.4/dist/leaflet.js'></script>
</head>
<body>
<div id='map'></div>
<script>
  var map = L.map('map').setView([-31.4, -64.18], 7); // Centro en Córdoba, Argentina
  L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '© OpenStreetMap contributors',
    maxZoom: 19
  }).addTo(map);

  var marker = null;

  map.on('click', function(e) {
    var lat = e.latlng.lat.toFixed(6);
    var lng = e.latlng.lng.toFixed(6);

    if (marker) {
      marker.setLatLng(e.latlng);
    } else {
      marker = L.marker(e.latlng, { draggable: true }).addTo(map);
      marker.on('dragend', function(ev) {
        var p = ev.target.getLatLng();
        notificarCoordenadas(p.lat.toFixed(6), p.lng.toFixed(6));
      });
    }
    notificarCoordenadas(lat, lng);
  });

  function notificarCoordenadas(lat, lng) {
    // Llama a C# a través del objeto window.external
    window.external.SetCoordenadas(lat, lng);
  }

  // Llamado desde C# para poner el marcador en coordenadas conocidas
  function irACoordenadas(lat, lng) {
    var latlng = L.latLng(lat, lng);
    map.setView(latlng, 14);
    if (marker) {
      marker.setLatLng(latlng);
    } else {
      marker = L.marker(latlng, { draggable: true }).addTo(map);
      marker.on('dragend', function(ev) {
        var p = ev.target.getLatLng();
        notificarCoordenadas(p.lat.toFixed(6), p.lng.toFixed(6));
      });
    }
  }
</script>
</body>
</html>";

            webMapa.Navigate("about:blank");
            webMapa.Document?.OpenNew(true);
            webMapa.DocumentText = html;
        }

        private void webMapa_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            _mapaListo = true;

            webMapa.ObjectForScripting = new MapaScriptHelper(this);

            if (double.TryParse(txtLat.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double lat)
             && double.TryParse(txtLng.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double lng)
             && lat != 0 && lng != 0)
            {
                MoverMarcador(lat, lng);
            }
        }
        internal void RecibirCoordenadas(string lat, string lng)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string, string>(RecibirCoordenadas), lat, lng);
                return;
            }
            _actualizandoDesdeJs = true;
            txtLat.Text = lat;
            txtLng.Text = lng;
            _actualizandoDesdeJs = false;
        }
        private void txtCoords_TextChanged(object sender, EventArgs e)
        {
            if (_actualizandoDesdeJs || !_mapaListo) return;

            if (double.TryParse(txtLat.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double lat)
             && double.TryParse(txtLng.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double lng))
            {
                MoverMarcador(lat, lng);
            }
        }

        private void MoverMarcador(double lat, double lng)
        {
            try
            {
                webMapa.Document?.InvokeScript("irACoordenadas",
                    new object[] {
                        lat.ToString(CultureInfo.InvariantCulture),
                        lng.ToString(CultureInfo.InvariantCulture)
                    });
            }
            catch { /* el documento puede no estar listo aún */ }
        }
        private void CargarProvincias()
        {
            try
            {
                var dt = _provinciaDao.ObtenerTodas();
                cboProvincia.DisplayMember = "Nombre";
                cboProvincia.ValueMember = "Id_provincia";
                cboProvincia.DataSource = dt;
                cboProvincia.SelectedIndex = -1;

                cboLocalidad.Enabled = false;
                cboLocalidad.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar provincias: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedValue == null) return;

            try
            {
                var rowView = cboProvincia.SelectedItem as System.Data.DataRowView;
                if (rowView == null) return;
                int idProvincia = Convert.ToInt32(rowView["Id_provincia"]);

                var dt = _localidadDao.ObtenerPorProvincia(idProvincia);
                cboLocalidad.DisplayMember = "nombre";
                cboLocalidad.ValueMember = "Id_localidad";
                cboLocalidad.DataSource = dt;
                cboLocalidad.SelectedIndex = -1;
                cboLocalidad.Enabled = true;
                cboLocalidad.BackColor = System.Drawing.SystemColors.Window;

                if (_idLocalidadPendiente > 0)
                {
                    cboLocalidad.SelectedValue = _idLocalidadPendiente;
                    _idLocalidadPendiente = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar localidades: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                txtDireccion.Text = r["direccion"].ToString();
                txtTelefono.Text = r["telefono"].ToString();
                chkActivo.Checked = Convert.ToBoolean(r["activo"]);

                if (r["geolocalizacion_lat"] != DBNull.Value)
                    txtLat.Text = r["geolocalizacion_lat"].ToString();
                if (r["geolocalizacion_lng"] != DBNull.Value)
                    txtLng.Text = r["geolocalizacion_lng"].ToString();

                if (r["Id_localidad"] != DBNull.Value)
                    _idLocalidadPendiente = Convert.ToInt32(r["Id_localidad"]);

                if (r["Id_provincia"] != DBNull.Value)
                    cboProvincia.SelectedValue = Convert.ToInt32(r["Id_provincia"]);
                else
                    SeleccionarProvinciaPorLocalidad(_idLocalidadPendiente);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el usuario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarProvinciaPorLocalidad(int idLocalidad)
        {
            try
            {
                int idProvincia = _localidadDao.ObtenerIdProvinciaPorLocalidad(idLocalidad);
                if (idProvincia > 0)
                    cboProvincia.SelectedValue = idProvincia;
            }
            catch { }
        }
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

            if (cboProvincia.SelectedValue == null)
            { MostrarAviso("Seleccioná una provincia."); cboProvincia.Focus(); return false; }

            if (cboLocalidad.SelectedValue == null)
            { MostrarAviso("Seleccioná una localidad."); cboLocalidad.Focus(); return false; }

            return true;
        }
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
                string direccion = txtDireccion.Text.Trim();
                string telefono = txtTelefono.Text.Trim();
                int idLoc = Convert.ToInt32(cboLocalidad.SelectedValue);

                double.TryParse(txtLat.Text.Replace(",", "."), NumberStyles.Any,
                    CultureInfo.InvariantCulture, out double lat);
                double.TryParse(txtLng.Text.Replace(",", "."), NumberStyles.Any,
                    CultureInfo.InvariantCulture, out double lng);

                if (_idUsuario == 0)
                    _dao.Insertar(nombre, apellido, mail, password, activo, dni, direccion, telefono, idLoc, lat, lng);
                else
                    _dao.Actualizar(_idUsuario, nombre, apellido, mail, password, activo, dni, direccion, telefono, idLoc, lat, lng);

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
        private readonly frmUsuarioModal _form;

        public MapaScriptHelper(frmUsuarioModal form)
        {
            _form = form;
        }

        public void SetCoordenadas(string lat, string lng)
        {
            _form.RecibirCoordenadas(lat, lng);
        }
    }
}