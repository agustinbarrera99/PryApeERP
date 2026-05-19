namespace PryApeERP
{
    partial class frmPerfiles
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();

            this.pnlFormulario = new System.Windows.Forms.Panel();

            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();

            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();

            this.pnlBotones = new System.Windows.Forms.Panel();

            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            this.dgvPerfiles = new System.Windows.Forms.DataGridView();

            this.pnlTop.SuspendLayout();
            this.pnlFormulario.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerfiles)).BeginInit();

            this.SuspendLayout();

            // =========================================================
            // pnlTop
            // =========================================================
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.pnlTop.Controls.Add(this.lblTitulo);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(900, 50);

            // =========================================================
            // lblTitulo
            // =========================================================
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblTitulo.Size = new System.Drawing.Size(900, 50);
            this.lblTitulo.Text = "🛡️ Gestión de Perfiles";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // =========================================================
            // pnlFormulario
            // =========================================================
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Controls.Add(this.lblId);
            this.pnlFormulario.Controls.Add(this.txtId);
            this.pnlFormulario.Controls.Add(this.lblNombre);
            this.pnlFormulario.Controls.Add(this.txtNombre);

            this.pnlFormulario.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFormulario.Height = 120;
            this.pnlFormulario.Padding = new System.Windows.Forms.Padding(20);

            // =========================================================
            // lblId
            // =========================================================
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblId.Location = new System.Drawing.Point(20, 25);
            this.lblId.Name = "lblId";
            this.lblId.Text = "ID:";

            // =========================================================
            // txtId
            // =========================================================
            this.txtId.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.txtId.Location = new System.Drawing.Point(90, 22);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 23);

            // =========================================================
            // lblNombre
            // =========================================================
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombre.Location = new System.Drawing.Point(220, 25);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Text = "Perfil:";

            // =========================================================
            // txtNombre
            // =========================================================
            this.txtNombre.Location = new System.Drawing.Point(280, 22);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(250, 23);

            // =========================================================
            // pnlBotones
            // =========================================================
            this.pnlBotones.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.pnlBotones.Controls.Add(this.btnNuevo);
            this.pnlBotones.Controls.Add(this.btnGuardar);
            this.pnlBotones.Controls.Add(this.btnEliminar);
            this.pnlBotones.Controls.Add(this.btnCancelar);

            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotones.Height = 50;

            // =========================================================
            // Botones
            // =========================================================
            ConfigurarBoton(this.btnNuevo,
                "➕ Nuevo",
                System.Drawing.Color.FromArgb(59, 130, 246),
                8);

            ConfigurarBoton(this.btnGuardar,
                "💾 Guardar",
                System.Drawing.Color.FromArgb(16, 185, 129),
                128);

            ConfigurarBoton(this.btnEliminar,
                "🗑️ Eliminar",
                System.Drawing.Color.FromArgb(239, 68, 68),
                248);

            ConfigurarBoton(this.btnCancelar,
                "✖ Cancelar",
                System.Drawing.Color.FromArgb(107, 114, 128),
                368);

            // =========================================================
            // dgvPerfiles
            // =========================================================
            this.dgvPerfiles.AllowUserToAddRows = false;
            this.dgvPerfiles.AllowUserToDeleteRows = false;
            this.dgvPerfiles.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvPerfiles.BackgroundColor = System.Drawing.Color.White;
            this.dgvPerfiles.BorderStyle = System.Windows.Forms.BorderStyle.None;

            this.dgvPerfiles.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(31, 41, 55);

            this.dgvPerfiles.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;

            this.dgvPerfiles.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9F,
                System.Drawing.FontStyle.Bold);

            this.dgvPerfiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPerfiles.EnableHeadersVisualStyles = false;
            this.dgvPerfiles.Font =
                new System.Drawing.Font("Segoe UI", 9F);

            this.dgvPerfiles.MultiSelect = false;
            this.dgvPerfiles.Name = "dgvPerfiles";
            this.dgvPerfiles.ReadOnly = true;
            this.dgvPerfiles.RowHeadersVisible = false;

            this.dgvPerfiles.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // =========================================================
            // frmPerfiles
            // =========================================================
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.BackColor =
                System.Drawing.Color.FromArgb(243, 244, 246);

            this.ClientSize = new System.Drawing.Size(900, 560);

            this.Controls.Add(this.dgvPerfiles);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.pnlTop);

            this.Font =
                new System.Drawing.Font("Segoe UI", 9F);

            this.Name = "frmPerfiles";
            this.Text = "Perfiles";

            this.pnlTop.ResumeLayout(false);
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.pnlBotones.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)(this.dgvPerfiles)).EndInit();

            this.ResumeLayout(false);
        }

        private void ConfigurarBoton(
            System.Windows.Forms.Button btn,
            string texto,
            System.Drawing.Color color,
            int left)
        {
            btn.Text = texto;
            btn.BackColor = color;
            btn.ForeColor = System.Drawing.Color.White;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

            btn.Font =
                new System.Drawing.Font("Segoe UI", 9F,
                System.Drawing.FontStyle.Bold);

            btn.Size = new System.Drawing.Size(110, 34);
            btn.Location = new System.Drawing.Point(left, 8);

            btn.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitulo;

        private System.Windows.Forms.Panel pnlFormulario;

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;

        private System.Windows.Forms.Panel pnlBotones;

        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;

        private System.Windows.Forms.DataGridView dgvPerfiles;
    }
}