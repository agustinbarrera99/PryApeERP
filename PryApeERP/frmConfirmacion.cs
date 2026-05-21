using System;
using System.Windows.Forms;

namespace PryApeERP
{
    public partial class frmConfirmacion : Form
    {
        // Constructor que acepta el título y el cuerpo del mensaje de confirmación
        public frmConfirmacion(string titulo, string mensaje)
        {
            InitializeComponent();

            this.Text = titulo;
            this.lblTitulo.Text = titulo;
            this.lblMensaje.Text = mensaje;
        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}