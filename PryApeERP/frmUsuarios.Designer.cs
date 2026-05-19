namespace PryApeERP
{
    partial class frmUsuarios
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblActivo = new System.Windows.Forms.Label();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlFormulario.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.pnlTop.Controls.Add(this.lblTitulo);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 50;

            // lblTitulo
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Text = "👤  Gestión de Usuarios";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitulo.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);

            // pnlFormulario
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.pnlFormulario.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFormulario.Height = 180;
            this.pnlFormulario.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblId, this.txtId,
                this.lblNombre, this.txtNombre,
                this.lblApellido, this.txtApellido,
                this.lblEmail, this.txtEmail,
                this.lblPassword, this.txtPassword,
                this.lblActivo, this.chkActivo });

            // Fila 1 — ID
            this.lblId.Text = "ID:"; this.lblId.AutoSize = true; this.lblId.Location = new System.Drawing.Point(20, 20);
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtId.Location = new System.Drawing.Point(100, 17); this.txtId.Width = 80; this.txtId.ReadOnly = true;
            this.txtId.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.txtId.Name = "txtId";

            // Fila 1 — Nombre
            this.lblNombre.Text = "Nombre:"; this.lblNombre.AutoSize = true; this.lblNombre.Location = new System.Drawing.Point(210, 20);
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombre.Location = new System.Drawing.Point(290, 17); this.txtNombre.Width = 180;
            this.txtNombre.Name = "txtNombre";

            // Fila 1 — Apellido
            this.lblApellido.Text = "Apellido:"; this.lblApellido.AutoSize = true; this.lblApellido.Location = new System.Drawing.Point(490, 20);
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtApellido.Location = new System.Drawing.Point(570, 17); this.txtApellido.Width = 180;
            this.txtApellido.Name = "txtApellido";

            // Fila 2 — Email
            this.lblEmail.Text = "Email:"; this.lblEmail.AutoSize = true; this.lblEmail.Location = new System.Drawing.Point(20, 65);
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.Location = new System.Drawing.Point(100, 62); this.txtEmail.Width = 250;
            this.txtEmail.Name = "txtEmail";

            // Fila 2 — Password
            this.lblPassword.Text = "Contraseña:"; this.lblPassword.AutoSize = true; this.lblPassword.Location = new System.Drawing.Point(370, 65);
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.Location = new System.Drawing.Point(460, 62); this.txtPassword.Width = 180;
            this.txtPassword.PasswordChar = '●'; this.txtPassword.Name = "txtPassword";

            // Fila 3 — Activo
            this.lblActivo.Text = "Activo:"; this.lblActivo.AutoSize = true; this.lblActivo.Location = new System.Drawing.Point(20, 110);
            this.lblActivo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkActivo.Location = new System.Drawing.Point(100, 108); this.chkActivo.Name = "chkActivo";
            this.chkActivo.Text = ""; this.chkActivo.Checked = true;

            // pnlBotones
            this.pnlBotones.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotones.Height = 50;
            this.pnlBotones.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnNuevo, this.btnGuardar, this.btnEliminar, this.btnCancelar });

            // Botones
            ConfigurarBoton(this.btnNuevo, "➕ Nuevo", System.Drawing.Color.FromArgb(59, 130, 246), 8);
            ConfigurarBoton(this.btnGuardar, "💾 Guardar", System.Drawing.Color.FromArgb(16, 185, 129), 128);
            ConfigurarBoton(this.btnEliminar, "🗑️ Eliminar", System.Drawing.Color.FromArgb(239, 68, 68), 248);
            ConfigurarBoton(this.btnCancelar, "✖ Cancelar", System.Drawing.Color.FromArgb(107, 114, 128), 368);
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // dgvUsuarios
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarios.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvUsuarios.RowHeadersVisible = false;
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvUsuarios.EnableHeadersVisualStyles = false;
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);

            // frmUsuarios
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.ClientSize = new System.Drawing.Size(900, 560);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmUsuarios";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
        }

        private void ConfigurarBoton(System.Windows.Forms.Button btn, string texto,
                                     System.Drawing.Color color, int left)
        {
            btn.Text = texto;
            btn.BackColor = color;
            btn.ForeColor = System.Drawing.Color.White;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btn.Size = new System.Drawing.Size(110, 34);
            btn.Location = new System.Drawing.Point(left, 8);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Label lblId, lblNombre, lblApellido, lblEmail, lblPassword, lblActivo;
        private System.Windows.Forms.TextBox txtId, txtNombre, txtApellido, txtEmail, txtPassword;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnNuevo, btnGuardar, btnEliminar, btnCancelar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
    }
}