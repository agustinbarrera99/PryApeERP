namespace PryApeERP
{
    partial class frmUsuarioModal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // ── Controles ─────────────────────────────────────────
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();

            // Panel izquierdo (formulario) y derecho (mapa) dentro de un SplitContainer
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.pnlCuerpo = new System.Windows.Forms.Panel();

            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.cboLocalidad = new System.Windows.Forms.ComboBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();

            // Panel del mapa (lado derecho)
            this.pnlMapa = new System.Windows.Forms.Panel();
            this.lblMapaTitulo = new System.Windows.Forms.Label();
            this.webMapa = new System.Windows.Forms.WebBrowser();
            this.pnlCoords = new System.Windows.Forms.Panel();
            this.lblLatLabel = new System.Windows.Forms.Label();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.lblLngLabel = new System.Windows.Forms.Label();
            this.txtLng = new System.Windows.Forms.TextBox();
            this.lblMapaHint = new System.Windows.Forms.Label();

            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblToast = new System.Windows.Forms.Label();
            this.timerToast = new System.Windows.Forms.Timer(this.components);

            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.pnlCuerpo.SuspendLayout();
            this.pnlMapa.SuspendLayout();
            this.pnlCoords.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();

            // ════════════════════════════════════════════════════
            // pnlTop — Header
            // ════════════════════════════════════════════════════
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlTop.Controls.Add(this.lblTitulo);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 52;

            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Text = "  👤   Usuario";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitulo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);

            // ════════════════════════════════════════════════════
            // splitMain — divide formulario | mapa
            // ════════════════════════════════════════════════════
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            // SplitterDistance se setea en Load para evitar InvalidOperationException
            this.splitMain.SplitterWidth = 6;
            this.splitMain.IsSplitterFixed = false;
            this.splitMain.Panel1MinSize = 50;
            this.splitMain.Panel2MinSize = 50;

            // Panel1 → formulario
            this.splitMain.Panel1.Controls.Add(this.pnlCuerpo);

            // Panel2 → mapa
            this.splitMain.Panel2.Controls.Add(this.pnlMapa);

            // ════════════════════════════════════════════════════
            // pnlCuerpo — formulario de campos
            // ════════════════════════════════════════════════════
            this.pnlCuerpo.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCuerpo.Padding = new System.Windows.Forms.Padding(20, 14, 16, 8);
            this.pnlCuerpo.AutoScroll = true;
            this.pnlCuerpo.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblNombre,    this.txtNombre,
                this.lblApellido,  this.txtApellido,
                this.lblMail,      this.txtMail,
                this.lblPassword,  this.txtPassword,
                this.lblDni,       this.txtDni,
                this.lblDireccion, this.txtDireccion,
                this.lblTelefono,  this.txtTelefono,
                this.lblProvincia, this.cboProvincia,
                this.lblLocalidad, this.cboLocalidad,
                this.chkActivo
            });

            // ── Grilla de 2 columnas dentro del panel izquierdo ──
            int col1X = 20, col2X = 220;
            int txtW = 180;
            int rowH = 54;
            int cboW = txtW * 2 + (col2X - col1X - txtW); // ancho "full row" = 380px aprox

            // Fila 0 — Nombre / Apellido
            EstiloLabel(this.lblNombre, "Nombre *", col1X, 14);
            EstiloTextBox(this.txtNombre, col1X, 30, txtW);
            EstiloLabel(this.lblApellido, "Apellido *", col2X, 14);
            EstiloTextBox(this.txtApellido, col2X, 30, txtW);

            // Fila 1 — Mail / Teléfono
            EstiloLabel(this.lblMail, "Email *", col1X, 14 + rowH);
            EstiloTextBox(this.txtMail, col1X, 30 + rowH, txtW);
            EstiloLabel(this.lblTelefono, "Teléfono", col2X, 14 + rowH);
            EstiloTextBox(this.txtTelefono, col2X, 30 + rowH, txtW);

            // Fila 2 — Contraseña / DNI
            this.lblPassword.Text = "Contraseña *";
            this.lblPassword.Location = new System.Drawing.Point(col1X, 14 + rowH * 2);
            this.lblPassword.AutoSize = true;
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            EstiloTextBox(this.txtPassword, col1X, 30 + rowH * 2, txtW);
            this.txtPassword.PasswordChar = '●';
            EstiloLabel(this.lblDni, "DNI", col2X, 14 + rowH * 2);
            EstiloTextBox(this.txtDni, col2X, 30 + rowH * 2, txtW);

            // Fila 3 — Dirección (ancho completo)
            EstiloLabel(this.lblDireccion, "Dirección", col1X, 14 + rowH * 3);
            EstiloTextBox(this.txtDireccion, col1X, 30 + rowH * 3, cboW);

            // Fila 4 — Provincia
            EstiloLabel(this.lblProvincia, "Provincia *", col1X, 14 + rowH * 4);
            EstiloComboBox(this.cboProvincia, col1X, 30 + rowH * 4, cboW);
            this.cboProvincia.SelectedIndexChanged += new System.EventHandler(this.cboProvincia_SelectedIndexChanged);

            // Fila 5 — Localidad (deshabilitada hasta elegir provincia)
            EstiloLabel(this.lblLocalidad, "Localidad *", col1X, 14 + rowH * 5);
            EstiloComboBox(this.cboLocalidad, col1X, 30 + rowH * 5, cboW);
            this.cboLocalidad.Enabled = false;
            this.cboLocalidad.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);

            // Fila 6 — Activo
            this.chkActivo.Text = "Usuario activo";
            this.chkActivo.Location = new System.Drawing.Point(col1X, 18 + rowH * 6);
            this.chkActivo.AutoSize = true;
            this.chkActivo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.chkActivo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.chkActivo.Checked = true;

            // ════════════════════════════════════════════════════
            // pnlMapa — panel derecho completo
            // ════════════════════════════════════════════════════
            this.pnlMapa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMapa.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlMapa.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblMapaTitulo, this.webMapa, this.pnlCoords, this.lblMapaHint
            });

            // Título del panel mapa
            this.lblMapaTitulo.Text = "📍  Ubicación geográfica";
            this.lblMapaTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMapaTitulo.Height = 36;
            this.lblMapaTitulo.AutoSize = false;
            this.lblMapaTitulo.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblMapaTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMapaTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMapaTitulo.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);

            // Hint bajo el mapa
            this.lblMapaHint.Text = "Hacé clic en el mapa para fijar la ubicación";
            this.lblMapaHint.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMapaHint.Height = 24;
            this.lblMapaHint.AutoSize = false;
            this.lblMapaHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblMapaHint.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblMapaHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Panel de coordenadas (debajo del mapa)
            this.pnlCoords.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCoords.Height = 44;
            this.pnlCoords.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.pnlCoords.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblLatLabel, this.txtLat, this.lblLngLabel, this.txtLng
            });

            this.lblLatLabel.Text = "Lat:";
            this.lblLatLabel.Location = new System.Drawing.Point(8, 14);
            this.lblLatLabel.AutoSize = true;
            this.lblLatLabel.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblLatLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);

            this.txtLat.Location = new System.Drawing.Point(35, 10);
            this.txtLat.Size = new System.Drawing.Size(110, 24);
            this.txtLat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLat.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.txtLat.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.txtLat.TextChanged += new System.EventHandler(this.txtCoords_TextChanged);

            this.lblLngLabel.Text = "Lng:";
            this.lblLngLabel.Location = new System.Drawing.Point(155, 14);
            this.lblLngLabel.AutoSize = true;
            this.lblLngLabel.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblLngLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);

            this.txtLng.Location = new System.Drawing.Point(182, 10);
            this.txtLng.Size = new System.Drawing.Size(110, 24);
            this.txtLng.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLng.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLng.BackColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.txtLng.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.txtLng.TextChanged += new System.EventHandler(this.txtCoords_TextChanged);

            // WebBrowser — ocupa el espacio restante del panel mapa
            this.webMapa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webMapa.ScrollBarsEnabled = false;
            this.webMapa.IsWebBrowserContextMenuEnabled = false;
            this.webMapa.WebBrowserShortcutsEnabled = false;
            this.webMapa.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webMapa_DocumentCompleted);

            // ════════════════════════════════════════════════════
            // pnlBotones
            // ════════════════════════════════════════════════════
            this.pnlBotones.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Height = 52;
            this.pnlBotones.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnGuardar, this.btnCancelar
            });

            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Location = new System.Drawing.Point(20, 10);
            this.btnGuardar.Size = new System.Drawing.Size(130, 32);
            this.btnGuardar.Text = "💾  Guardar";
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.Location = new System.Drawing.Point(160, 10);
            this.btnCancelar.Size = new System.Drawing.Size(120, 32);
            this.btnCancelar.Text = "✖  Cancelar";
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // ════════════════════════════════════════════════════
            // Toast & Timer
            // ════════════════════════════════════════════════════
            this.lblToast.AutoSize = false;
            this.lblToast.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblToast.Height = 34;
            this.lblToast.ForeColor = System.Drawing.Color.White;
            this.lblToast.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblToast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblToast.Visible = false;

            this.timerToast.Interval = 3500;
            this.timerToast.Tick += new System.EventHandler(this.timerToast_Tick);

            // ════════════════════════════════════════════════════
            // Form
            // ════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 520);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(780, 480);
            this.MaximizeBox = true;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmUsuarioModal";
            this.Text = "Usuario";
            this.Load += new System.EventHandler(this.frmUsuarioModal_Load);

            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.lblToast);

            this.pnlTop.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            this.splitMain.Panel1.Controls.Add(this.pnlCuerpo);
            this.splitMain.Panel2.Controls.Add(this.pnlMapa);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.pnlCuerpo.ResumeLayout(false);
            this.pnlCuerpo.PerformLayout();
            this.pnlMapa.ResumeLayout(false);
            this.pnlCoords.ResumeLayout(false);
            this.pnlCoords.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        // ── Helpers de estilo ────────────────────────────────────
        private static void EstiloLabel(System.Windows.Forms.Label lbl, string texto, int x, int y)
        {
            lbl.Text = texto;
            lbl.Location = new System.Drawing.Point(x, y);
            lbl.AutoSize = true;
            lbl.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lbl.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        }

        private static void EstiloTextBox(System.Windows.Forms.TextBox txt, int x, int y, int w)
        {
            txt.Location = new System.Drawing.Point(x, y);
            txt.Size = new System.Drawing.Size(w, 26);
            txt.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private static void EstiloComboBox(System.Windows.Forms.ComboBox cbo, int x, int y, int w)
        {
            cbo.Location = new System.Drawing.Point(x, y);
            cbo.Size = new System.Drawing.Size(w, 28);
            cbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            cbo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        }

        #endregion

        // ── Campos ───────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblProvincia;
        private System.Windows.Forms.ComboBox cboProvincia;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.ComboBox cboLocalidad;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Panel pnlMapa;
        private System.Windows.Forms.Label lblMapaTitulo;
        private System.Windows.Forms.WebBrowser webMapa;
        private System.Windows.Forms.Panel pnlCoords;
        private System.Windows.Forms.Label lblLatLabel;
        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.Label lblLngLabel;
        private System.Windows.Forms.TextBox txtLng;
        private System.Windows.Forms.Label lblMapaHint;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblToast;
        private System.Windows.Forms.Timer timerToast;
    }
}