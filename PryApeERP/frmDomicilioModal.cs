using System;
using System.Globalization;
using System.Windows.Forms;

namespace PryApeERP
{
    public partial class frmDomicilioModal : Form
    {
        private readonly ProvinciaDAO _provinciaDao = new ProvinciaDAO();
        private readonly LocalidadDAO _localidadDao = new LocalidadDAO();

        private bool _mapaListo = false;
        private bool _actualizandoDesdeJs = false;
        private int _idLocalidadPendiente = 0;

        public DomicilioItem Resultado { get; private set; }
        public frmDomicilioModal(DomicilioItem domicilio = null)
        {
            InitializeComponent();
            UIHelper.AplicarIcono(this);

            if (domicilio != null)
            {
                // Modo edición: precargar campos
                this.Text = "Editar Domicilio";
                lblTitulo.Text = "  ✏️   Editar Domicilio";
                txtDescripcion.Text = domicilio.Descripcion;
                txtDireccion.Text = domicilio.Direccion;
                chkPrincipal.Checked = domicilio.Principal;

                if (domicilio.Lat != 0)
                    txtLat.Text = domicilio.Lat.ToString(CultureInfo.InvariantCulture);
                if (domicilio.Lng != 0)
                    txtLng.Text = domicilio.Lng.ToString(CultureInfo.InvariantCulture);

                // La provincia/localidad se carga al completar el form
                _idLocalidadPendiente = domicilio.IdLocalidad;
            }
            else
            {
                this.Text = "Nuevo Domicilio";
                lblTitulo.Text = "  ➕   Nuevo Domicilio";
            }
        }


        private void frmDomicilioModal_Load(object sender, EventArgs e)
        {
            CargarProvincias();
            CargarMapa();
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

                if (_idLocalidadPendiente > 0)
                {
                    int idProv = _localidadDao.ObtenerIdProvinciaPorLocalidad(_idLocalidadPendiente);
                    if (idProv > 0)
                        cboProvincia.SelectedValue = idProv;
                }
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
  var map = L.map('map').setView([-31.4, -64.18], 7);
  L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '© OpenStreetMap contributors', maxZoom: 19
  }).addTo(map);

  var marker = null;

  map.on('click', function(e) {
    var lat = e.latlng.lat.toFixed(6);
    var lng = e.latlng.lng.toFixed(6);
    if (marker) { marker.setLatLng(e.latlng); }
    else {
      marker = L.marker(e.latlng, { draggable: true }).addTo(map);
      marker.on('dragend', function(ev) {
        var p = ev.target.getLatLng();
        notificarCoordenadas(p.lat.toFixed(6), p.lng.toFixed(6));
      });
    }
    notificarCoordenadas(lat, lng);
  });

  function notificarCoordenadas(lat, lng) {
    window.external.SetCoordenadas(lat, lng);
  }

  function irACoordenadas(lat, lng) {
    var latlng = L.latLng(lat, lng);
    map.setView(latlng, 14);
    if (marker) { marker.setLatLng(latlng); }
    else {
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
                webMapa.Document?.InvokeScript("irACoordenadas", new object[] {
                    lat.ToString(CultureInfo.InvariantCulture),
                    lng.ToString(CultureInfo.InvariantCulture)
                });
            }
            catch { }
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            { MostrarAviso("La descripción es obligatoria (ej: Casa, Trabajo)."); txtDescripcion.Focus(); return false; }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            { MostrarAviso("La dirección es obligatoria."); txtDireccion.Focus(); return false; }

            if (cboProvincia.SelectedValue == null)
            { MostrarAviso("Seleccioná una provincia."); cboProvincia.Focus(); return false; }

            if (cboLocalidad.SelectedValue == null)
            { MostrarAviso("Seleccioná una localidad."); cboLocalidad.Focus(); return false; }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            double.TryParse(txtLat.Text.Replace(",", "."), NumberStyles.Any,
                CultureInfo.InvariantCulture, out double lat);
            double.TryParse(txtLng.Text.Replace(",", "."), NumberStyles.Any,
                CultureInfo.InvariantCulture, out double lng);

            // Obtener nombre de localidad para mostrarlo en la grilla sin ir a la BD
            string nomLocalidad = string.Empty;
            var rowView = cboLocalidad.SelectedItem as System.Data.DataRowView;
            if (rowView != null)
                nomLocalidad = rowView["nombre"].ToString();

            Resultado = new DomicilioItem
            {
                Descripcion = txtDescripcion.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                IdProvincia = Convert.ToInt32(cboProvincia.SelectedValue),
                IdLocalidad = Convert.ToInt32(cboLocalidad.SelectedValue),
                NombreLocalidad = nomLocalidad,
                Lat = lat,
                Lng = lng,
                Principal = chkPrincipal.Checked
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
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
    public class DomicilioItem   // ← acá, mismo archivo, mismo namespace
    {
        public int IdDomicilio { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public int IdLocalidad { get; set; }
        public int IdProvincia { get; set; }
        public string NombreLocalidad { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public bool Principal { get; set; }
    }
}