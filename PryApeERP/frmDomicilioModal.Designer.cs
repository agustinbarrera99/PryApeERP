namespace PryApeERP
{
    partial class frmDomicilioModal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlCuerpo = new System.Windows.Forms.Panel();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.cboLocalidad = new System.Windows.Forms.ComboBox();
            this.chkPrincipal = new System.Windows.Forms.CheckBox();
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
            this.pnlCuerpo.SuspendLayout();
            this.pnlMapa.SuspendLayout();
            this.pnlCoords.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.SuspendLayout();

            // ════════════════════════════════════════════════════
            // pnlTop
            // ════════════════════════════════════════════════════
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlTop.Controls.Add(this.lblTitulo);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 52;

            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Text = "  🏠   Domicilio";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitulo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);

            // ════════════════════════════════════════════════════
            // pnlCuerpo — campos del domicilio (izquierda)
            // ════════════════════════════════════════════════════
            this.pnlCuerpo.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlCuerpo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCuerpo.Width = 340;
            this.pnlCuerpo.AutoScroll = true;
            this.pnlCuerpo.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlCuerpo.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblDescripcion, this.txtDescripcion,
                this.lblDireccion,   this.txtDireccion,
                this.lblProvincia,   this.cboProvincia,
                this.lblLocalidad,   this.cboLocalidad,
                this.chkPrincipal
            });

            int x = 20;
            int w = 295;
            int topY = 14;
            int rowH = 54;

            EstiloLabel(this.lblDescripcion, "Descripción * (ej: Casa, Trabajo)", x, topY);
            EstiloTextBox(this.txtDescripcion, x, topY + 16, w);

            EstiloLabel(this.lblDireccion, "Dirección *", x, topY + rowH);
            EstiloTextBox(this.txtDireccion, x, topY + rowH + 16, w);

            EstiloLabel(this.lblProvincia, "Provincia *", x, topY + rowH * 2);
            EstiloComboBox(this.cboProvincia, x, topY + rowH * 2 + 16, w);
            this.cboProvincia.SelectedIndexChanged += new System.EventHandler(this.cboProvincia_SelectedIndexChanged);

            EstiloLabel(this.lblLocalidad, "Localidad *", x, topY + rowH * 3);
            EstiloComboBox(this.cboLocalidad, x, topY + rowH * 3 + 16, w);
            this.cboLocalidad.Enabled = false;
            this.cboLocalidad.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);

            this.chkPrincipal.Text = "Marcar como domicilio principal";
            this.chkPrincipal.Location = new System.Drawing.Point(x, topY + rowH * 4 + 4);
            this.chkPrincipal.AutoSize = true;
            this.chkPrincipal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.chkPrincipal.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);

            // ════════════════════════════════════════════════════
            // pnlMapa — panel derecho con mapa + coordenadas
            // ════════════════════════════════════════════════════
            this.pnlMapa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMapa.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.pnlMapa.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblMapaTitulo, this.webMapa, this.pnlCoords, this.lblMapaHint
            });

            this.lblMapaTitulo.Text = "📍  Ubicación geográfica";
            this.lblMapaTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMapaTitulo.Height = 36;
            this.lblMapaTitulo.AutoSize = false;
            this.lblMapaTitulo.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblMapaTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMapaTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMapaTitulo.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);

            this.lblMapaHint.Text = "Hacé clic en el mapa para fijar la ubicación";
            this.lblMapaHint.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMapaHint.Height = 24;
            this.lblMapaHint.AutoSize = false;
            this.lblMapaHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblMapaHint.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblMapaHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

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
            this.ClientSize = new System.Drawing.Size(820, 480);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(700, 440);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmDomicilioModal";
            this.Text = "Domicilio";
            this.Load += new System.EventHandler(this.frmDomicilioModal_Load);

            // Orden Fill antes que Left
            this.Controls.Add(this.pnlMapa);     // Fill
            this.Controls.Add(this.pnlCuerpo);   // Left
            this.Controls.Add(this.pnlBotones);  // Bottom
            this.Controls.Add(this.pnlTop);      // Top
            this.Controls.Add(this.lblToast);    // Bottom

            this.pnlTop.ResumeLayout(false);
            this.pnlCuerpo.ResumeLayout(false);
            this.pnlCuerpo.PerformLayout();
            this.pnlMapa.ResumeLayout(false);
            this.pnlCoords.ResumeLayout(false);
            this.pnlCoords.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);
        }

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

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlCuerpo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblProvincia;
        private System.Windows.Forms.ComboBox cboProvincia;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.ComboBox cboLocalidad;
        private System.Windows.Forms.CheckBox chkPrincipal;
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