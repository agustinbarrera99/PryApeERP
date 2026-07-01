namespace PryApeERP
{
    partial class frmAuditoria
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblIcono = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();

            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();

            this.dgvAuditoria = new System.Windows.Forms.DataGridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblContador = new System.Windows.Forms.Label();

            this.pnlHeader.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoria)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // ── pnlHeader ──────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.pnlHeader.Controls.Add(this.lblIcono);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 90;

            // lblIcono
            this.lblIcono.AutoSize = true;
            this.lblIcono.Font = new System.Drawing.Font("Segoe UI Emoji", 28F);
            this.lblIcono.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250);
            this.lblIcono.Location = new System.Drawing.Point(24, 16);
            this.lblIcono.Text = "🔍";

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(80, 14);
            this.lblTitulo.Text = "Auditoría de Sesiones";

            // lblSubtitulo
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(156, 163, 175);
            this.lblSubtitulo.Location = new System.Drawing.Point(82, 52);
            this.lblSubtitulo.Text = "Historial de intentos de inicio de sesión";

            // ── pnlToolbar ─────────────────────────────────────────
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.pnlToolbar.Controls.Add(this.lblBuscar);
            this.pnlToolbar.Controls.Add(this.txtBuscar);
            this.pnlToolbar.Controls.Add(this.btnActualizar);
            this.pnlToolbar.Controls.Add(this.btnLimpiar);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Height = 60;

            // lblBuscar
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblBuscar.Location = new System.Drawing.Point(20, 22);
            this.lblBuscar.Text = "🔎 Buscar por correo:";

            // txtBuscar
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscar.Location = new System.Drawing.Point(158, 18);
            this.txtBuscar.Size = new System.Drawing.Size(260, 25);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);

            // btnActualizar
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(438, 16);
            this.btnActualizar.Size = new System.Drawing.Size(110, 30);
            this.btnActualizar.Text = "⟳  Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);

            // btnLimpiar
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(558, 16);
            this.btnLimpiar.Size = new System.Drawing.Size(90, 30);
            this.btnLimpiar.Text = "✕  Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            // ── dgvAuditoria ───────────────────────────────────────
            this.dgvAuditoria.AllowUserToAddRows = false;
            this.dgvAuditoria.AllowUserToDeleteRows = false;
            this.dgvAuditoria.ReadOnly = true;
            this.dgvAuditoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuditoria.MultiSelect = false;
            this.dgvAuditoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAuditoria.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAuditoria.RowHeadersVisible = false;
            this.dgvAuditoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAuditoria.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            // Estilo encabezado
            this.dgvAuditoria.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.dgvAuditoria.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvAuditoria.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.dgvAuditoria.ColumnHeadersHeight = 38;
            this.dgvAuditoria.EnableHeadersVisualStyles = false;
            // Estilo filas
            this.dgvAuditoria.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvAuditoria.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.dgvAuditoria.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254);
            this.dgvAuditoria.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.dgvAuditoria.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.dgvAuditoria.RowTemplate.Height = 32;
            this.dgvAuditoria.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.dgvAuditoria.Name = "dgvAuditoria";

            // ── pnlFooter ──────────────────────────────────────────
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.pnlFooter.Controls.Add(this.lblContador);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 36;

            // lblContador
            this.lblContador.AutoSize = true;
            this.lblContador.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblContador.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblContador.Location = new System.Drawing.Point(20, 10);
            this.lblContador.Text = "Total de registros: 0";
            this.lblContador.Name = "lblContador";

            // ── frmAuditoria ───────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 560);
            this.Controls.Add(this.dgvAuditoria);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmAuditoria";
            this.Text = "Auditoría de Sesiones";
            this.Load += new System.EventHandler(this.frmAuditoria_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoria)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblIcono;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;

        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnLimpiar;

        private System.Windows.Forms.DataGridView dgvAuditoria;

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblContador;
    }
}