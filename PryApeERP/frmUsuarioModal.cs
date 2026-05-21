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

        #region Windows Forms Designer generated code

        private void InitializeComponent()
        {
            // Inicialización de controles basados en tu arquitectura original
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.pnlBotonesAccion = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();

            // Sección 1
            this.lblSeccion1 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblErrNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblErrEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblErrPassword = new System.Windows.Forms.Label();
            this.lblActivo = new System.Windows.Forms.Label();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblErrDni = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblErrTelefono = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();

            // Sección 2
            this.lblSeccion2 = new System.Windows.Forms.Label();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.cmbProvincia = new System.Windows.Forms.ComboBox();
            this.lblErrProvincia = new System.Windows.Forms.Label();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.cmbLocalidad = new System.Windows.Forms.ComboBox();
            this.lblLat = new System.Windows.Forms.Label();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.lblErrLat = new System.Windows.Forms.Label();
            this.lblLng = new System.Windows.Forms.Label();
            this.txtLng = new System.Windows.Forms.TextBox();
            this.lblErrLng = new System.Windows.Forms.Label();

            // Sección 3
            this.lblSeccion3 = new System.Windows.Forms.Label();
            this.lblRedes = new System.Windows.Forms.Label();
            this.cmbRedes = new System.Windows.Forms.ComboBox();
            this.txtUrlRed = new System.Windows.Forms.TextBox();
            this.btnAgregarRed = new System.Windows.Forms.Button();
            this.lblErrUrlRed = new System.Windows.Forms.Label();
            this.dgvRedesUsuario = new System.Windows.Forms.DataGridView();

            this.pnlTop.SuspendLayout();
            this.pnlFormulario.SuspendLayout();
            this.pnlBotonesAccion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRedesUsuario)).BeginInit();
            this.SuspendLayout();

            // ── Cabecera Modal ───────────────────────────────────────────
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(30, 41, 59); // Un gris azulado elegante
            this.pnlTop.Controls.Add(this.lblTitulo);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 45;

            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Text = "  👤  Detalle de Usuario";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // ── Contenedor del Cuerpo (Scroll) ───────────────────────────
            this.pnlFormulario.AutoScroll = true;
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFormulario.Location = new System.Drawing.Point(0, 45);
            this.pnlFormulario.Size = new System.Drawing.Size(810, 410);
            this.pnlFormulario.Padding = new System.Windows.Forms.Padding(20);

            // [LÓGICA DE POSICIONAMIENTO ORIGINAL DE TU FORMULARIO EN BASE A yBase]
            int yBase = 15;
            ConfigurarSeparador(this.lblSeccion1, "Datos del usuario", 20, yBase);

            yBase += 30;
            ConfigurarLabel(this.lblId, "ID", 20, yBase);
            ConfigurarLabel(this.lblNombre, "Nombre *", 150, yBase);
            ConfigurarLabel(this.lblApellido, "Apellido", 490, yBase);

            yBase += 20;
            ConfigurarTextBox(this.txtId, 20, yBase, 100, true);
            ConfigurarTextBox(this.txtNombre, 150, yBase, 310);
            ConfigurarTextBox(this.txtApellido, 490, yBase, 280);

            yBase += 28;
            ConfigurarErrLabel(this.lblErrNombre, 150, yBase);

            yBase += 18;
            ConfigurarLabel(this.lblEmail, "Email *", 20, yBase);
            ConfigurarLabel(this.lblPassword, "Contraseña *", 380, yBase);
            ConfigurarLabel(this.lblActivo, "Activo", 680, yBase);

            yBase += 20;
            ConfigurarTextBox(this.txtEmail, 20, yBase, 340);
            ConfigurarTextBox(this.txtPassword, 380, yBase, 270);
            this.txtPassword.PasswordChar = '●';
            this.chkActivo.Location = new System.Drawing.Point(680, yBase + 1);
            this.chkActivo.Size = new System.Drawing.Size(20, 20);

            yBase += 28;
            ConfigurarErrLabel(this.lblErrEmail, 20, yBase);
            ConfigurarErrLabel(this.lblErrPassword, 380, yBase);

            yBase += 18;
            ConfigurarLabel(this.lblDni, "DNI", 20, yBase);
            ConfigurarLabel(this.lblTelefono, "Teléfono", 220, yBase);
            ConfigurarLabel(this.lblDireccion, "Dirección", 420, yBase);

            yBase += 20;
            ConfigurarTextBox(this.txtDni, 20, yBase, 180);
            ConfigurarTextBox(this.txtTelefono, 220, yBase, 180);
            ConfigurarTextBox(this.txtDireccion, 420, yBase, 350);

            yBase += 28;
            ConfigurarErrLabel(this.lblErrDni, 20, yBase);
            ConfigurarErrLabel(this.lblErrTelefono, 220, yBase);

            // Ubicación
            yBase += 18;
            ConfigurarSeparador(this.lblSeccion2, "Ubicación y geolocalización", 20, yBase);

            yBase += 30;
            ConfigurarLabel(this.lblProvincia, "Provincia", 20, yBase);
            ConfigurarLabel(this.lblLocalidad, "Localidad", 240, yBase);
            ConfigurarLabel(this.lblLat, "Latitud", 490, yBase);
            ConfigurarLabel(this.lblLng, "Longitud", 640, yBase);

            yBase += 20;
            ConfigurarCombo(this.cmbProvincia, 20, yBase, 200);
            ConfigurarCombo(this.cmbLocalidad, 240, yBase, 210);
            ConfigurarTextBox(this.txtLat, 490, yBase, 120);
            ConfigurarTextBox(this.txtLng, 640, yBase, 120);
            this.cmbProvincia.SelectedIndexChanged += new System.EventHandler(this.cmbProvincia_SelectedIndexChanged);

            yBase += 28;
            ConfigurarErrLabel(this.lblErrProvincia, 20, yBase);
            ConfigurarErrLabel(this.lblErrLat, 490, yBase);
            ConfigurarErrLabel(this.lblErrLng, 640, yBase);

            // Redes Sociales
            yBase += 18;
            ConfigurarSeparador(this.lblSeccion3, "Redes sociales", 20, yBase);

            yBase += 30;
            ConfigurarLabel(this.lblRedes, "Red", 20, yBase);

            yBase += 20;
            ConfigurarCombo(this.cmbRedes, 20, yBase, 180);
            ConfigurarTextBox(this.txtUrlRed, 210, yBase, 360);

            // Botón Agregar Red inline
            this.btnAgregarRed.Location = new System.Drawing.Point(580, yBase);
            this.btnAgregarRed.Size = new System.Drawing.Size(140, 26);
            this.btnAgregarRed.Text = "➕  Agregar red";
            this.btnAgregarRed.Click += new System.EventHandler(this.btnAgregarRed_Click);

            yBase += 32;
            this.dgvRedesUsuario.Location = new System.Drawing.Point(20, yBase);
            this.dgvRedesUsuario.Size = new System.Drawing.Size(740, 90);
            this.dgvRedesUsuario.BackgroundColor = System.Drawing.Color.FromArgb(248, 250, 252);

            this.pnlFormulario.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblSeccion1, lblId, txtId, lblNombre, txtNombre, lblErrNombre, lblApellido, txtApellido,
                lblEmail, txtEmail, lblErrEmail, lblPassword, txtPassword, lblErrPassword, lblActivo, chkActivo,
                lblDni, txtDni, lblErrDni, lblTelefono, txtTelefono, lblErrTelefono, lblDireccion, txtDireccion,
                lblSeccion2, lblProvincia, cmbProvincia, lblErrProvincia, lblLocalidad, cmbLocalidad, lblLat, txtLat, lblErrLat, lblLng, txtLng, lblErrLng,
                lblSeccion3, lblRedes, cmbRedes, txtUrlRed, btnAgregarRed, dgvRedesUsuario
            });

            // ── Footer con Botones de Confirmación ───────────────────────
            this.pnlBotonesAccion.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlBotonesAccion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotonesAccion.Height = 55;

            // Botón Guardar
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(5, 150, 105); // Verde Esmeralda
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Location = new System.Drawing.Point(670, 12);
            this.btnGuardar.Size = new System.Drawing.Size(120, 32);
            this.btnGuardar.Text = "💾  Guardar";
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // Botón Cancelar
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(148, 163, 184); // Gris pizarra neutro
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.Location = new System.Drawing.Point(540, 12);
            this.btnCancelar.Size = new System.Drawing.Size(120, 32);
            this.btnCancelar.Text = "✖  Cancelar";
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            this.pnlBotonesAccion.Controls.AddRange(new System.Windows.Forms.Control[] { this.btnGuardar, this.btnCancelar });

            // ── frmUsuarioModal Base Config ──────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 520);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.pnlBotonesAccion);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUsuarioModal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Formulario de Usuario";
            this.Load += new System.EventHandler(this.frmUsuarioModal_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.pnlBotonesAccion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRedesUsuario)).EndInit();
            this.ResumeLayout(false);
        }

        // Helpers de Estilos rápidos nativos para simplificar el código generado
        private void ConfigurarLabel(System.Windows.Forms.Label lbl, string texto, int x, int y)
        {
            lbl.Text = texto; lbl.Location = new System.Drawing.Point(x, y); lbl.AutoSize = true;
            lbl.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105); lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
        }
        private void ConfigurarTextBox(System.Windows.Forms.TextBox txt, int x, int y, int w, bool readOnly = false)
        {
            txt.Location = new System.Drawing.Point(x, y); txt.Width = w; txt.ReadOnly = readOnly;
            txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; txt.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            if (readOnly) txt.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
        }
        private void ConfigurarCombo(System.Windows.Forms.ComboBox cmb, int x, int y, int w)
        {
            cmb.Location = new System.Drawing.Point(x, y); cmb.Width = w; cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }
        private void ConfigurarSeparador(System.Windows.Forms.Label lbl, string titulo, int x, int y)
        {
            lbl.Text = "─── " + titulo + " ──────────────────────────────────"; lbl.Location = new System.Drawing.Point(x, y);
            lbl.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold); lbl.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59); lbl.AutoSize = true;
        }
        private void ConfigurarErrLabel(System.Windows.Forms.Label lbl, int x, int y)
        {
            lbl.Location = new System.Drawing.Point(x, y); lbl.ForeColor = System.Drawing.Color.Red; lbl.Font = new System.Drawing.Font("Segoe UI", 8F); lbl.Visible = false; lbl.AutoSize = true;
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Panel pnlBotonesAccion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        // Elementos Dinámicos
        private System.Windows.Forms.Label lblSeccion1, lblSeccion2, lblSeccion3;
        private System.Windows.Forms.Label lblId, lblNombre, lblApellido, lblEmail, lblPassword, lblActivo, lblDni, lblTelefono, lblDireccion;
        private System.Windows.Forms.TextBox txtId, txtNombre, txtApellido, txtEmail, txtPassword, txtDni, txtTelefono, txtDireccion;
        private System.Windows.Forms.Label lblErrNombre, lblErrEmail, lblErrPassword, lblErrDni, lblErrTelefono;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Label lblProvincia, lblLocalidad, lblLat, lblLng;
        private System.Windows.Forms.ComboBox cmbProvincia, cmbLocalidad, cmbRedes;
        private System.Windows.Forms.Label lblErrProvincia, lblErrLat, lblErrLng, lblErrUrlRed;
        private System.Windows.Forms.TextBox txtLat, txtLng, txtUrlRed;
        private System.Windows.Forms.Button btnAgregarRed;
        private System.Windows.Forms.DataGridView dgvRedesUsuario;
    }
}