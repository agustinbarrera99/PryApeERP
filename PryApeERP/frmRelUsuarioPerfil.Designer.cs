namespace PryApeERP
{
    partial class frmRelUsuarioPerfil
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.cmbUsuario = new System.Windows.Forms.ComboBox();
            this.lblPerfil = new System.Windows.Forms.Label();
            this.cmbPerfil = new System.Windows.Forms.ComboBox();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvAsignaciones = new System.Windows.Forms.DataGridView();

            this.pnlTop.SuspendLayout();
            this.pnlFormulario.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignaciones)).BeginInit();
            this.SuspendLayout();

            // pnlTop
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.pnlTop.Controls.Add(this.lblTitulo);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 50;

            // lblTitulo
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblTitulo.Text = "🔗 Asignación Usuario-Perfil";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // pnlFormulario
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFormulario.Height = 80;
            this.pnlFormulario.Padding = new System.Windows.Forms.Padding(20, 20, 20, 0);
            this.pnlFormulario.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblUsuario, this.cmbUsuario,
                this.lblPerfil,  this.cmbPerfil });

            // lblUsuario
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsuario.Location = new System.Drawing.Point(20, 28);
            this.lblUsuario.Text = "Usuario:";

            // cmbUsuario
            this.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuario.Location = new System.Drawing.Point(90, 25);
            this.cmbUsuario.Size = new System.Drawing.Size(220, 23);
            this.cmbUsuario.Name = "cmbUsuario";

            // lblPerfil
            this.lblPerfil.AutoSize = true;
            this.lblPerfil.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPerfil.Location = new System.Drawing.Point(340, 28);
            this.lblPerfil.Text = "Perfil:";

            // cmbPerfil
            this.cmbPerfil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPerfil.Location = new System.Drawing.Point(400, 25);
            this.cmbPerfil.Size = new System.Drawing.Size(220, 23);
            this.cmbPerfil.Name = "cmbPerfil";

            // pnlBotones
            this.pnlBotones.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBotones.Height = 50;
            this.pnlBotones.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnAsignar, this.btnEliminar });

            // btnAsignar
            this.btnAsignar.Text = "🔗 Asignar";
            this.btnAsignar.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.btnAsignar.ForeColor = System.Drawing.Color.White;
            this.btnAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignar.FlatAppearance.BorderSize = 0;
            this.btnAsignar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAsignar.Size = new System.Drawing.Size(110, 34);
            this.btnAsignar.Location = new System.Drawing.Point(8, 8);
            this.btnAsignar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsignar.Name = "btnAsignar";

            // btnEliminar
            this.btnEliminar.Text = "🗑️ Quitar";
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.Size = new System.Drawing.Size(110, 34);
            this.btnEliminar.Location = new System.Drawing.Point(128, 8);
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Name = "btnEliminar";

            // dgvAsignaciones
            this.dgvAsignaciones.AllowUserToAddRows = false;
            this.dgvAsignaciones.AllowUserToDeleteRows = false;
            this.dgvAsignaciones.ReadOnly = true;
            this.dgvAsignaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAsignaciones.MultiSelect = false;
            this.dgvAsignaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAsignaciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvAsignaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAsignaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAsignaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvAsignaciones.RowHeadersVisible = false;
            this.dgvAsignaciones.EnableHeadersVisualStyles = false;
            this.dgvAsignaciones.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.dgvAsignaciones.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvAsignaciones.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvAsignaciones.Name = "dgvAsignaciones";

            // frmRelUsuarioPerfil
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.ClientSize = new System.Drawing.Size(900, 560);
            this.Controls.Add(this.dgvAsignaciones);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmRelUsuarioPerfil";
            this.Text = "Asignación Usuario-Perfil";

            this.pnlTop.ResumeLayout(false);
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignaciones)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Label lblPerfil;
        private System.Windows.Forms.ComboBox cmbPerfil;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvAsignaciones;
    }
}