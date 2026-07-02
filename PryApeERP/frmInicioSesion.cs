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
            UIHelper.AplicarIcono(this);
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
                ResultadoLogin resultado = _dao.ValidarLogin(mail, password, out idUsuario, out idPerfil);

                bool exitoso = resultado == ResultadoLogin.Ok;
                _auditoria.RegistrarIntento(
                    exitoso ? idUsuario : 0,
                    mail,
                    exitoso,
                    exitoso ? intentos : intentos - 1
                );

                switch (resultado)
                {
                    case ResultadoLogin.Ok:
                        Sesion.IdUsuario = idUsuario;
                        Sesion.Mail = mail;
                        Sesion.IdPerfil = idPerfil;

                        frmPrincipal frm = new frmPrincipal();
                        frm.UsuarioActivo = mail;
                        frm.PerfilActivo = idPerfil;
                        this.Hide();
                        frm.ShowDialog();
                        this.Close();
                        break;

                    case ResultadoLogin.UsuarioInactivo:
                        // No consumimos intentos ni mostramos "credenciales incorrectas":
                        // el usuario y la contraseña son correctos, el problema es otro.
                        MessageBox.Show(
                            "El usuario está deshabilitado. Contactá a un administrador para reactivarlo.",
                            "Usuario deshabilitado",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPassword.Clear();
                        txtPassword.Focus();
                        break;

                    case ResultadoLogin.CredencialesInvalidas:
                    default:
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
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void chkMostrarPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkMostrarPassword.Checked ? '\0' : '●';
        }
        private void btnSalir_Click(object sender, EventArgs e) => Application.Exit();
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnIngresar.PerformClick();
        }
    }
}