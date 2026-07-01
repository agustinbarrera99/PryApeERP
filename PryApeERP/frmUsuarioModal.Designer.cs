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
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.pnlDomicilios = new System.Windows.Forms.Panel();
            this.lblDomiciliosTit = new System.Windows.Forms.Label();
            this.dgvDomicilios = new System.Windows.Forms.DataGridView();
            this.pnlBtnDomicilios = new System.Windows.Forms.Panel();
            this.btnAgregarDomicilio = new System.Windows.Forms.Button();
            this.btnEditarDomicilio = new System.Windows.Forms.Button();
            this.btnQuitarDomicilio = new System.Windows.Forms.Button();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblToast = new System.Windows.Forms.Label();
            this.timerToast = new System.Windows.Forms.Timer(this.components);

            this.pnlTop.SuspendLayout();
            this.pnlCuerpo.SuspendLayout();
            this.pnlDomicilios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDomicilios)).BeginInit();
            this.pnlBtnDomicilios.SuspendLayout();
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
            // pnlCuerpo — datos personales (izquierda, ancho fijo)
            // ════════════════════════════════════════════════════
            this.pnlCuerpo.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlCuerpo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlCuerpo.Width = 420;
            this.pnlCuerpo.Padding = new System.Windows.Forms.Padding(20, 14, 16, 8);
            this.pnlCuerpo.AutoScroll = true;
            this.pnlCuerpo.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblNombre,   this.txtNombre,
                this.lblApellido, this.txtApellido,
                this.lblMail,     this.txtMail,
                this.lblPassword, this.txtPassword,
                this.lblDni,      this.txtDni,
                this.lblTelefono, this.txtTelefono,
                this.chkActivo
            });

            // ── Layout de 2 columnas ──────────────────────────
            int col1X = 20, col2X = 220;
            int txtW = 170;
            int rowH = 54;

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

            // Fila 3 — Activo
            this.chkActivo.Text = "Usuario activo";
            this.chkActivo.Location = new System.Drawing.Point(col1X, 18 + rowH * 3);
            this.chkActivo.AutoSize = true;
            this.chkActivo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.chkActivo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.chkActivo.Checked = true;

            // ════════════════════════════════════════════════════
            // pnlDomicilios — panel derecho con grilla + botones
            // ════════════════════════════════════════════════════
            this.pnlDomicilios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDomicilios.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlDomicilios.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblDomiciliosTit,
                this.dgvDomicilios,
                this.pnlBtnDomicilios
            });

            // Título del panel domicilios
            this.lblDomiciliosTit.Text = "  🏠  Domicilios";
            this.lblDomiciliosTit.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDomiciliosTit.Height = 36;
            this.lblDomiciliosTit.AutoSize = false;
            this.lblDomiciliosTit.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblDomiciliosTit.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblDomiciliosTit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDomiciliosTit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDomiciliosTit.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);

            // Panel de botones de domicilios (abajo del panel)
            this.pnlBtnDomicilios.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBtnDomicilios.Height = 48;
            this.pnlBtnDomicilios.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlBtnDomicilios.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnAgregarDomicilio,
                this.btnEditarDomicilio,
                this.btnQuitarDomicilio
            });

            // Botón Agregar domicilio
            this.btnAgregarDomicilio.Text = "➕  Agregar";
            this.btnAgregarDomicilio.Location = new System.Drawing.Point(8, 8);
            this.btnAgregarDomicilio.Size = new System.Drawing.Size(110, 30);
            this.btnAgregarDomicilio.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnAgregarDomicilio.ForeColor = System.Drawing.Color.White;
            this.btnAgregarDomicilio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarDomicilio.FlatAppearance.BorderSize = 0;
            this.btnAgregarDomicilio.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarDomicilio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarDomicilio.Click += new System.EventHandler(this.btnAgregarDomicilio_Click);

            // Botón Editar domicilio
            this.btnEditarDomicilio.Text = "✏️  Editar";
            this.btnEditarDomicilio.Location = new System.Drawing.Point(126, 8);
            this.btnEditarDomicilio.Size = new System.Drawing.Size(110, 30);
            this.btnEditarDomicilio.BackColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnEditarDomicilio.ForeColor = System.Drawing.Color.White;
            this.btnEditarDomicilio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarDomicilio.FlatAppearance.BorderSize = 0;
            this.btnEditarDomicilio.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditarDomicilio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarDomicilio.Click += new System.EventHandler(this.btnEditarDomicilio_Click);

            // Botón Quitar domicilio
            this.btnQuitarDomicilio.Text = "🗑  Quitar";
            this.btnQuitarDomicilio.Location = new System.Drawing.Point(244, 8);
            this.btnQuitarDomicilio.Size = new System.Drawing.Size(110, 30);
            this.btnQuitarDomicilio.BackColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnQuitarDomicilio.ForeColor = System.Drawing.Color.White;
            this.btnQuitarDomicilio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarDomicilio.FlatAppearance.BorderSize = 0;
            this.btnQuitarDomicilio.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnQuitarDomicilio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarDomicilio.Click += new System.EventHandler(this.btnQuitarDomicilio_Click);

            // DataGridView de domicilios
            this.dgvDomicilios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDomicilios.BackgroundColor = System.Drawing.Color.White;
            this.dgvDomicilios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDomicilios.RowHeadersVisible = false;
            this.dgvDomicilios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDomicilios.AllowUserToAddRows = false;
            this.dgvDomicilios.AllowUserToDeleteRows = false;
            this.dgvDomicilios.ReadOnly = true;
            this.dgvDomicilios.AutoGenerateColumns = false;
            this.dgvDomicilios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDomicilios.Font = new System.Drawing.Font("Segoe UI", 9F);
            // Doble clic abre edición directamente
            this.dgvDomicilios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDomicilios_CellDoubleClick);

            // ════════════════════════════════════════════════════
            // pnlBotones — Guardar / Cancelar
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
            this.ClientSize = new System.Drawing.Size(860, 500);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(720, 460);
            this.MaximizeBox = true;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmUsuarioModal";
            this.Text = "Usuario";
            this.Load += new System.EventHandler(this.frmUsuarioModal_Load);

            // Orden de apilado: Fill va antes que Left para que convivan bien
            this.Controls.Add(this.pnlDomicilios);  // Fill — ocupa el resto
            this.Controls.Add(this.pnlCuerpo);       // Left — ancho fijo 420px
            this.Controls.Add(this.pnlBotones);      // Bottom
            this.Controls.Add(this.pnlTop);          // Top
            this.Controls.Add(this.lblToast);        // Bottom (toast encima de botones)

            this.pnlTop.ResumeLayout(false);
            this.pnlCuerpo.ResumeLayout(false);
            this.pnlCuerpo.PerformLayout();
            this.pnlDomicilios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDomicilios)).EndInit();
            this.pnlBtnDomicilios.ResumeLayout(false);
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

        #endregion

        // ── Campos ───────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitulo;
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
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Panel pnlDomicilios;
        private System.Windows.Forms.Label lblDomiciliosTit;
        private System.Windows.Forms.DataGridView dgvDomicilios;
        private System.Windows.Forms.Panel pnlBtnDomicilios;
        private System.Windows.Forms.Button btnAgregarDomicilio;
        private System.Windows.Forms.Button btnEditarDomicilio;
        private System.Windows.Forms.Button btnQuitarDomicilio;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblToast;
        private System.Windows.Forms.Timer timerToast;
    }
}