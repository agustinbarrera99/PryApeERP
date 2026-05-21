namespace PryApeERP
{
    partial class frmConfirmacion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.pnlAlertTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.btnSi = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();

            this.pnlAlertTop.SuspendLayout();
            this.SuspendLayout();

            // ── pnlAlertTop (Franja superior de advertencia) ─────────────────
            this.pnlAlertTop.BackColor = System.Drawing.Color.FromArgb(254, 242, 242); // Fondo rojo sutil
            this.pnlAlertTop.Controls.Add(this.lblTitulo);
            this.pnlAlertTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAlertTop.Location = new System.Drawing.Point(0, 0);
            this.pnlAlertTop.Name = "pnlAlertTop";
            this.pnlAlertTop.Size = new System.Drawing.Size(430, 45);
            this.pnlAlertTop.TabIndex = 0;

            // ── lblTitulo ──────────────────────────────────────────────────
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(153, 27, 27); // Texto rojo oscuro
            this.lblTitulo.Location = new System.Drawing.Point(14, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(135, 20);
            this.lblTitulo.Text = "¿Eliminar usuario?";

            // ── lblMensaje (Cuerpo de la advertencia) ──────────────────────
            this.lblMensaje.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81); // Gris carbón
            this.lblMensaje.Location = new System.Drawing.Point(15, 65);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(400, 60);
            this.lblMensaje.Text = "Cuerpo del mensaje de confirmación.";

            // ── btnSi (Confirmar eliminación) ──────────────────────────────
            this.btnSi.BackColor = System.Drawing.Color.FromArgb(220, 38, 38); // Rojo peligro
            this.btnSi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSi.FlatAppearance.BorderSize = 0;
            this.btnSi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSi.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnSi.ForeColor = System.Drawing.Color.White;
            this.btnSi.Location = new System.Drawing.Point(310, 140);
            this.btnSi.Name = "btnSi";
            this.btnSi.Size = new System.Drawing.Size(105, 32);
            this.btnSi.TabIndex = 1;
            this.btnSi.Text = "⚠️ Sí, eliminar";
            this.btnSi.UseVisualStyleBackColor = false;
            this.btnSi.Click += new System.EventHandler(this.btnSi_Click);

            // ── btnNo (Cancelar acción) ────────────────────────────────────
            this.btnNo.BackColor = System.Drawing.Color.FromArgb(241, 245, 249); // Gris claro neutro
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNo.FlatAppearance.BorderSize = 0;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnNo.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnNo.Location = new System.Drawing.Point(200, 140);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(100, 32);
            this.btnNo.TabIndex = 2;
            this.btnNo.Text = "No, cancelar";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);

            // ── frmConfirmacion ────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(430, 188);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnSi);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.pnlAlertTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfirmacion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Confirmación";
            this.pnlAlertTop.ResumeLayout(false);
            this.pnlAlertTop.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlAlertTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnSi;
        private System.Windows.Forms.Button btnNo;
    }
}