namespace PryApeERP
{
    partial class frmRedSocialModal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No modifique
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblRed = new System.Windows.Forms.Label();
            this.cboRed = new System.Windows.Forms.ComboBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblToast = new System.Windows.Forms.Label();
            this.timerToast = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(30, 144, 255);
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(400, 45);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "  ➕   Nueva Red Social";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblRed
            //
            this.lblRed.AutoSize = true;
            this.lblRed.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblRed.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblRed.Location = new System.Drawing.Point(24, 66);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(75, 20);
            this.lblRed.TabIndex = 1;
            this.lblRed.Text = "Red Social *";
            //
            // cboRed
            //
            this.cboRed.BackColor = System.Drawing.Color.FromArgb(30, 30, 46);
            this.cboRed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRed.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboRed.ForeColor = System.Drawing.Color.White;
            this.cboRed.FormattingEnabled = true;
            this.cboRed.Location = new System.Drawing.Point(24, 89);
            this.cboRed.Name = "cboRed";
            this.cboRed.Size = new System.Drawing.Size(352, 28);
            this.cboRed.TabIndex = 2;
            //
            // lblUrl
            //
            this.lblUrl.AutoSize = true;
            this.lblUrl.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblUrl.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblUrl.Location = new System.Drawing.Point(24, 134);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(133, 20);
            this.lblUrl.TabIndex = 3;
            this.lblUrl.Text = "URL / Usuario *";
            //
            // txtUrl
            //
            this.txtUrl.BackColor = System.Drawing.Color.FromArgb(30, 30, 46);
            this.txtUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUrl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUrl.ForeColor = System.Drawing.Color.White;
            this.txtUrl.Location = new System.Drawing.Point(24, 157);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(352, 27);
            this.txtUrl.TabIndex = 4;
            //
            // btnGuardar
            //
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(196, 210);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 34);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // btnCancelar
            //
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(60, 60, 76);
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(292, 210);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 34);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            //
            // lblToast
            //
            this.lblToast.BackColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.lblToast.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblToast.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblToast.ForeColor = System.Drawing.Color.White;
            this.lblToast.Location = new System.Drawing.Point(0, 253);
            this.lblToast.Name = "lblToast";
            this.lblToast.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblToast.Size = new System.Drawing.Size(400, 32);
            this.lblToast.TabIndex = 7;
            this.lblToast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblToast.Visible = false;
            //
            // timerToast
            //
            this.timerToast.Interval = 3000;
            this.timerToast.Tick += new System.EventHandler(this.timerToast_Tick);
            //
            // frmRedSocialModal
            //
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 30);
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(400, 285);
            this.Controls.Add(this.lblToast);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.cboRed);
            this.Controls.Add(this.lblRed);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRedSocialModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nueva Red Social";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblRed;
        private System.Windows.Forms.ComboBox cboRed;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblToast;
        private System.Windows.Forms.Timer timerToast;
    }
}