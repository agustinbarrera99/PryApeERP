using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace PryApeERP
{
    public partial class frmRedSocialModal : Form
    {
        private readonly RedSocialDAO _redSocialDao = new RedSocialDAO();

        public RedSocialItem Resultado { get; private set; }

        // idsUsados: redes que el usuario ya tiene cargadas (para no repetir).
        // Si estás editando una existente, excluí su propio IdRed de esa lista
        // antes de pasarla, así sigue apareciendo en el combo.
        public frmRedSocialModal(RedSocialItem redSocial, List<int> idsUsados)
        {
            InitializeComponent();
            UIHelper.AplicarIcono(this);

            CargarCombo(idsUsados);

            if (redSocial != null)
            {
                this.Text = "Editar Red Social";
                lblTitulo.Text = "  ✏️   Editar Red Social";
                cboRed.SelectedValue = redSocial.IdRed;
                txtUrl.Text = redSocial.UrlPerfil;
            }
            else
            {
                this.Text = "Nueva Red Social";
                lblTitulo.Text = "  ➕   Nueva Red Social";
            }
        }

        private void CargarCombo(List<int> idsUsados)
        {
            try
            {
                DataTable dt = _redSocialDao.ObtenerTodos();
                DataView view = dt.DefaultView;

                if (idsUsados != null && idsUsados.Count > 0)
                    view.RowFilter = "Id NOT IN (" + string.Join(",", idsUsados) + ")";

                cboRed.DisplayMember = "nombre";
                cboRed.ValueMember = "Id";
                cboRed.DataSource = view;
                cboRed.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar redes sociales: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Validar()
        {
            if (cboRed.SelectedValue == null)
            { MostrarAviso("Seleccioná una red social."); cboRed.Focus(); return false; }

            if (string.IsNullOrWhiteSpace(txtUrl.Text))
            { MostrarAviso("Ingresá la URL del perfil."); txtUrl.Focus(); return false; }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            var rowView = cboRed.SelectedItem as DataRowView;

            Resultado = new RedSocialItem
            {
                IdRed = Convert.ToInt32(cboRed.SelectedValue),
                NombreRed = rowView?["nombre"].ToString(),
                UrlPerfil = txtUrl.Text.Trim()
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void MostrarAviso(string mensaje)
        {
            lblToast.Text = "ℹ  " + mensaje;
            lblToast.BackColor = System.Drawing.Color.FromArgb(245, 158, 11);
            lblToast.Visible = true;
            timerToast.Start();
        }

        private void timerToast_Tick(object sender, EventArgs e)
        {
            timerToast.Stop();
            lblToast.Visible = false;
        }
    }
}