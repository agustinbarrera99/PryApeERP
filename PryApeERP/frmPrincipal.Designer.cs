namespace PryApeERP
{
    partial class frmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuSeguridad = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPerfiles = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRelUsuarioPerfil = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUsuarioActivo = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.timerReloj = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();

            // ──────────────────────────────────────────
            // menuStrip1
            // ──────────────────────────────────────────
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.menuStrip1.ForeColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuSeguridad });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1100, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";

            // ──────────────────────────────────────────
            // mnuSeguridad
            // ──────────────────────────────────────────
            this.mnuSeguridad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuUsuarios,
                this.mnuPerfiles,
                this.mnuRelUsuarioPerfil,
                this.toolStripSeparator1,
                this.mnuSalir });
            this.mnuSeguridad.ForeColor = System.Drawing.Color.White;
            this.mnuSeguridad.Name = "mnuSeguridad";
            this.mnuSeguridad.Size = new System.Drawing.Size(75, 20);
            this.mnuSeguridad.Text = "🔐 Seguridad";

            // mnuUsuarios
            this.mnuUsuarios.Name = "mnuUsuarios";
            this.mnuUsuarios.Size = new System.Drawing.Size(200, 22);
            this.mnuUsuarios.Text = "👤 Usuarios";
            this.mnuUsuarios.Click += new System.EventHandler(this.mnuUsuarios_Click);

            // mnuPerfiles
            this.mnuPerfiles.Name = "mnuPerfiles";
            this.mnuPerfiles.Size = new System.Drawing.Size(200, 22);
            this.mnuPerfiles.Text = "🛡️ Perfiles";
            this.mnuPerfiles.Click += new System.EventHandler(this.mnuPerfiles_Click);

            // mnuRelUsuarioPerfil
            this.mnuRelUsuarioPerfil.Name = "mnuRelUsuarioPerfil";
            this.mnuRelUsuarioPerfil.Size = new System.Drawing.Size(200, 22);
            this.mnuRelUsuarioPerfil.Text = "🔗 Asignación Usuario-Perfil";
            this.mnuRelUsuarioPerfil.Click += new System.EventHandler(this.mnuRelUsuarioPerfil_Click);

            // toolStripSeparator1
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(197, 6);

            // mnuSalir
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(200, 22);
            this.mnuSalir.Text = "🚪 Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);

            // ──────────────────────────────────────────
            // statusStrip1
            // ──────────────────────────────────────────
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.statusStrip1.ForeColor = System.Drawing.Color.White;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.lblEstado,
                this.lblUsuarioActivo,
                this.lblFecha });
            this.statusStrip1.Location = new System.Drawing.Point(0, 618);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1100, 22);
            this.statusStrip1.TabIndex = 1;

            // lblEstado
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(39, 17);
            this.lblEstado.Text = "Listo";
            this.lblEstado.Spring = true;
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblUsuarioActivo
            this.lblUsuarioActivo.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblUsuarioActivo.Name = "lblUsuarioActivo";
            this.lblUsuarioActivo.Size = new System.Drawing.Size(100, 17);
            this.lblUsuarioActivo.Text = "Usuario: Admin";

            // lblFecha
            this.lblFecha.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(130, 17);
            this.lblFecha.Text = "00/00/0000 00:00:00";

            // ──────────────────────────────────────────
            // pnlHeader
            // ──────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 24);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 80);
            this.pnlHeader.TabIndex = 2;

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(99, 179, 237);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "⚡ Sistema ERP";

            // lblSubtitulo
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(156, 163, 175);
            this.lblSubtitulo.Location = new System.Drawing.Point(24, 52);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Text = "Módulo de Seguridad  •  Gestión de Usuarios, Perfiles y Permisos";

            // ──────────────────────────────────────────
            // pnlContenido  (área MDI / dashboard)
            // ──────────────────────────────────────────
            this.pnlContenido.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(0, 104);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(1100, 514);
            this.pnlContenido.TabIndex = 3;

            // ──────────────────────────────────────────
            // timerReloj
            // ──────────────────────────────────────────
            this.timerReloj.Enabled = true;
            this.timerReloj.Interval = 1000;
            this.timerReloj.Tick += new System.EventHandler(this.timerReloj_Tick);

            // ──────────────────────────────────────────
            // frmPrincipal
            // ──────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.ClientSize = new System.Drawing.Size(1100, 640);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema ERP — Módulo de Seguridad";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // ── controles ──────────────────────────────────
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuSeguridad;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mnuPerfiles;
        private System.Windows.Forms.ToolStripMenuItem mnuRelUsuarioPerfil;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblEstado;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuarioActivo;
        private System.Windows.Forms.ToolStripStatusLabel lblFecha;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Timer timerReloj;
    }
}