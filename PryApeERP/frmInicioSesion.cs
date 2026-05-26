using System;
using System.Windows.Forms;

namespace PryApeERP
{
    public partial class frmInicioSesion : Form
    {
        private readonly UsuarioDAO _dao = new UsuarioDAO();
        private readonly AuditoriaDAO _auditoria = new AuditoriaDAO();
        private int intentos = 3;

        public frmInicioSesion()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string mail = txtMail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(mail) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Complete todos los campos.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idUsuario;
                int idPerfil;
                (idUsuario, idPerfil) = _dao.ValidarLogin(mail, password);
                bool exitoso = idUsuario > 0;
                _auditoria.RegistrarIntento(
                    exitoso ? idUsuario : 0,
                    mail,
                    exitoso,
                    exitoso ? intentos : intentos - 1
                );

                if (exitoso)
                {
                    frmPrincipal frm = new frmPrincipal();
                    frm.UsuarioActivo = mail;
                    frm.PerfilActivo = idPerfil; 
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    intentos--;
                    lblIntentos.Text = $"Intentos restantes: {intentos}";
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Acceso denegado",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Clear();
                    txtPassword.Focus();

                    if (intentos <= 0)
                    {
                        MessageBox.Show("Se agotaron los intentos permitidos.", "Sistema bloqueado",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) => Application.Exit();

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnIngresar.PerformClick();
        }
    }
}