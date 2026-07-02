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
        // NOTA: este formulario se edita a mano (no abrir la vista de diseñador visual),
        // por eso conservamos variables/llamadas a métodos acá adentro sin problema.

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
            this.lblPasswordHint = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();

            this.tabDerecha = new System.Windows.Forms.TabControl();
            this.tabPageDomicilios = new System.Windows.Forms.TabPage();
            this.tabPageRedes = new System.Windows.Forms.TabPage();

            this.pnlDomicilios = new System.Windows.Forms.Panel();
            this.lblDomiciliosTit = new System.Windows.Forms.Label();
            this.dgvDomicilios = new System.Windows.Forms.DataGridView();
            this.pnlBtnDomicilios = new System.Windows.Forms.Panel();
            this.btnAgregarDomicilio = new System.Windows.Forms.Button();
            this.btnEditarDomicilio = new System.Windows.Forms.Button();
            this.btnQuitarDomicilio = new System.Windows.Forms.Button();

            this.pnlRedes = new System.Windows.Forms.Panel();
            this.lblRedesTit = new System.Windows.Forms.Label();
            this.dgvRedes = new System.Windows.Forms.DataGridView();
            this.pnlBtnRedes = new System.Windows.Forms.Panel();
            this.btnAgregarRed = new System.Windows.Forms.Button();
            this.btnEditarRed = new System.Windows.Forms.Button();
            this.btnQuitarRed = new System.Windows.Forms.Button();

            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblToast = new System.Windows.Forms.Label();
            this.timerToast = new System.Windows.Forms.Timer(this.components);

            this.pnlTop.SuspendLayout();
            this.pnlCuerpo.SuspendLayout();
            this.tabDerecha.SuspendLayout();
            this.tabPageDomicilios.SuspendLayout();
            this.tabPageRedes.SuspendLayout();
            this.pnlDomicilios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDomicilios)).BeginInit();
            this.pnlBtnDomicilios.SuspendLayout();
            this.pnlRedes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRedes)).BeginInit();
            this.pnlBtnRedes.SuspendLayout();
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
                this.lblPassword, this.txtPassword, this.lblPasswordHint,
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
            // FIX: el texto de lblPassword queda FIJO ("Contraseña *"), nunca se
            // reemplaza en runtime por una frase larga. Así nunca invade la columna
            // de lblDni (antes esto era la causa de que el DNI quedara tapado).
            EstiloLabel(this.lblPassword, "Contraseña *", col1X, 14 + rowH * 2);
            EstiloTextBox(this.txtPassword, col1X, 30 + rowH * 2, txtW);
            this.txtPassword.PasswordChar = '●';

            // Hint aparte, chico, debajo del textbox de contraseña. Solo se muestra
            // en modo edición (se controla desde el Load). No compite por ancho
            // con ningún otro control de la fila.
            this.lblPasswordHint.Text = "Dejar vacío para no cambiar";
            this.lblPasswordHint.Location = new System.Drawing.Point(col1X, 30 + rowH * 2 + 28);
            this.lblPasswordHint.AutoSize = true;
            this.lblPasswordHint.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblPasswordHint.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Italic);
            this.lblPasswordHint.Visible = false;

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
            // tabDerecha — pestañas Domicilios / Redes Sociales
            // ════════════════════════════════════════════════════
            this.tabDerecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDerecha.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.tabDerecha.Controls.Add(this.tabPageDomicilios);
            this.tabDerecha.Controls.Add(this.tabPageRedes);

            this.tabPageDomicilios.Text = "  🏠  Domicilios  ";
            this.tabPageDomicilios.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.tabPageDomicilios.Padding = new System.Windows.Forms.Padding(0);
            this.tabPageDomicilios.Controls.Add(this.pnlDomicilios);

            this.tabPageRedes.Text = "  🌐  Redes Sociales  ";
            this.tabPageRedes.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.tabPageRedes.Padding = new System.Windows.Forms.Padding(0);
            this.tabPageRedes.Controls.Add(this.pnlRedes);

            // ════════════════════════════════════════════════════
            // pnlDomicilios — grilla + botones (dentro de tabPageDomicilios)
            // ════════════════════════════════════════════════════
            this.pnlDomicilios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDomicilios.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            // z-order: el control agregado PRIMERO queda AL FRENTE.
            this.pnlDomicilios.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.dgvDomicilios,      // Fill — se agrega primero
                this.pnlBtnDomicilios,   // Bottom
                this.lblDomiciliosTit    // Top — al final, no tapa nada
            });

            this.lblDomiciliosTit.Text = "  🏠  Domicilios";
            this.lblDomiciliosTit.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDomiciliosTit.Height = 36;
            this.lblDomiciliosTit.AutoSize = false;
            this.lblDomiciliosTit.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblDomiciliosTit.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblDomiciliosTit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDomiciliosTit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDomiciliosTit.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);

            this.pnlBtnDomicilios.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBtnDomicilios.Height = 48;
            this.pnlBtnDomicilios.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlBtnDomicilios.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnAgregarDomicilio,
                this.btnEditarDomicilio,
                this.btnQuitarDomicilio
            });

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
            this.dgvDomicilios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDomicilios_CellDoubleClick);

            // ════════════════════════════════════════════════════
            // pnlRedes — grilla + botones (dentro de tabPageRedes)
            // ════════════════════════════════════════════════════
            this.pnlRedes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRedes.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlRedes.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.dgvRedes,      // Fill — se agrega primero
                this.pnlBtnRedes,   // Bottom
                this.lblRedesTit    // Top — al final, no tapa nada
            });

            this.lblRedesTit.Text = "  🌐  Redes Sociales";
            this.lblRedesTit.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRedesTit.Height = 36;
            this.lblRedesTit.AutoSize = false;
            this.lblRedesTit.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblRedesTit.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblRedesTit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRedesTit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRedesTit.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);

            this.pnlBtnRedes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBtnRedes.Height = 48;
            this.pnlBtnRedes.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.pnlBtnRedes.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnAgregarRed,
                this.btnEditarRed,
                this.btnQuitarRed
            });

            this.btnAgregarRed.Text = "➕  Agregar";
            this.btnAgregarRed.Location = new System.Drawing.Point(8, 8);
            this.btnAgregarRed.Size = new System.Drawing.Size(110, 30);
            this.btnAgregarRed.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnAgregarRed.ForeColor = System.Drawing.Color.White;
            this.btnAgregarRed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarRed.FlatAppearance.BorderSize = 0;
            this.btnAgregarRed.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarRed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarRed.Click += new System.EventHandler(this.btnAgregarRed_Click);

            this.btnEditarRed.Text = "✏️  Editar";
            this.btnEditarRed.Location = new System.Drawing.Point(126, 8);
            this.btnEditarRed.Size = new System.Drawing.Size(110, 30);
            this.btnEditarRed.BackColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnEditarRed.ForeColor = System.Drawing.Color.White;
            this.btnEditarRed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarRed.FlatAppearance.BorderSize = 0;
            this.btnEditarRed.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditarRed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarRed.Click += new System.EventHandler(this.btnEditarRed_Click);

            this.btnQuitarRed.Text = "🗑  Quitar";
            this.btnQuitarRed.Location = new System.Drawing.Point(244, 8);
            this.btnQuitarRed.Size = new System.Drawing.Size(110, 30);
            this.btnQuitarRed.BackColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnQuitarRed.ForeColor = System.Drawing.Color.White;
            this.btnQuitarRed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarRed.FlatAppearance.BorderSize = 0;
            this.btnQuitarRed.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnQuitarRed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarRed.Click += new System.EventHandler(this.btnQuitarRed_Click);

            this.dgvRedes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRedes.BackgroundColor = System.Drawing.Color.White;
            this.dgvRedes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRedes.RowHeadersVisible = false;
            this.dgvRedes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRedes.AllowUserToAddRows = false;
            this.dgvRedes.AllowUserToDeleteRows = false;
            this.dgvRedes.ReadOnly = true;
            this.dgvRedes.AutoGenerateColumns = false;
            this.dgvRedes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRedes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvRedes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRedes_CellDoubleClick);

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
            this.Controls.Add(this.tabDerecha);      // Fill — ocupa el resto (domicilios + redes)
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
            this.pnlRedes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRedes)).EndInit();
            this.pnlBtnRedes.ResumeLayout(false);
            this.tabPageDomicilios.ResumeLayout(false);
            this.tabPageRedes.ResumeLayout(false);
            this.tabDerecha.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblPasswordHint;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.CheckBox chkActivo;

        private System.Windows.Forms.TabControl tabDerecha;
        private System.Windows.Forms.TabPage tabPageDomicilios;
        private System.Windows.Forms.TabPage tabPageRedes;

        private System.Windows.Forms.Panel pnlDomicilios;
        private System.Windows.Forms.Label lblDomiciliosTit;
        private System.Windows.Forms.DataGridView dgvDomicilios;
        private System.Windows.Forms.Panel pnlBtnDomicilios;
        private System.Windows.Forms.Button btnAgregarDomicilio;
        private System.Windows.Forms.Button btnEditarDomicilio;
        private System.Windows.Forms.Button btnQuitarDomicilio;

        private System.Windows.Forms.Panel pnlRedes;
        private System.Windows.Forms.Label lblRedesTit;
        private System.Windows.Forms.DataGridView dgvRedes;
        private System.Windows.Forms.Panel pnlBtnRedes;
        private System.Windows.Forms.Button btnAgregarRed;
        private System.Windows.Forms.Button btnEditarRed;
        private System.Windows.Forms.Button btnQuitarRed;

        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblToast;
        private System.Windows.Forms.Timer timerToast;
    }
}