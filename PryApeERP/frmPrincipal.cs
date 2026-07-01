using System;
using System.Drawing;
using System.Windows.Forms;

namespace PryApeERP
{
    public partial class frmPrincipal : Form
    {
        public string UsuarioActivo { get; set; } = "Admin";
        public int PerfilActivo { get; set; } = 0;

        public frmPrincipal()
        {
            InitializeComponent();
            UIHelper.AplicarIcono(this);
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuarioActivo.Text = $"👤 {UsuarioActivo}";
            ActualizarReloj();

            mnuAuditoria.Visible = (PerfilActivo == 2);  

            MostrarBienvenida();
        }

        private void mnuAuditoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmAuditoria()); 
        }
        private void mnuUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmUsuarios());
        }

        private void mnuPerfiles_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmPerfiles());
        }

        private void mnuRelUsuarioPerfil_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmRelUsuarioPerfil());
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    "¿Desea cerrar el sistema?",
                    "Salir",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void timerReloj_Tick(object sender, EventArgs e)
        {
            ActualizarReloj();
        }

        private void ActualizarReloj()
        {
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy  HH:mm:ss");
        }

        private void AbrirFormulario(Form hijo)
        {
            // Evitar duplicados
            foreach (Control c in pnlContenido.Controls)
            {
                if (c is Form f && f.GetType() == hijo.GetType())
                {
                    hijo.Dispose();
                    f.BringToFront();
                    return;
                }
            }

            pnlContenido.Controls.Clear();
            hijo.TopLevel = false;
            hijo.FormBorderStyle = FormBorderStyle.None;
            hijo.Dock = DockStyle.Fill;
            pnlContenido.Controls.Add(hijo);
            hijo.Show();

            lblEstado.Text = $"Módulo activo: {hijo.Text}";
        }

        private void MostrarBienvenida()
        {
            pnlContenido.Controls.Clear();

            var pnl = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(243, 244, 246) };

            var lbl = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Top,
                Height = 120,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 41, 55),
                Text = $"Bienvenido, {UsuarioActivo} 👋"
            };

            var flp = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(40),
                WrapContents = true
            };

            flp.Controls.Add(CrearTarjeta("👤", "Usuarios",
                "Altas, bajas y modificaciones\nde cuentas de acceso.",
                Color.FromArgb(59, 130, 246), mnuUsuarios_Click));

            flp.Controls.Add(CrearTarjeta("🛡️", "Perfiles",
                "Definición de roles y\nniveles de acceso.",
                Color.FromArgb(16, 185, 129), mnuPerfiles_Click));

            flp.Controls.Add(CrearTarjeta("🔗", "Asignación",
                "Vincular usuarios con\nsus perfiles de seguridad.",
                Color.FromArgb(245, 158, 11), mnuRelUsuarioPerfil_Click));

            if (PerfilActivo == 2)
            {
                flp.Controls.Add(CrearTarjeta("🔍", "Auditoría",
                    "Historial de intentos\nde inicio de sesión.",
                    Color.FromArgb(139, 92, 246), mnuAuditoria_Click));
            }

            pnl.Controls.Add(flp);
            pnl.Controls.Add(lbl);
            pnlContenido.Controls.Add(pnl);
        }

        private Panel CrearTarjeta(string icono, string titulo, string descripcion,
                                   Color color, EventHandler onClick)
        {
            var tarjeta = new Panel
            {
                Width = 220,
                Height = 180,
                Margin = new Padding(16),
                BackColor = Color.White,
                Cursor = Cursors.Hand
            };

            var borde = new Panel
            {
                Height = 6,
                Dock = DockStyle.Top,
                BackColor = color
            };

            var lblIcono = new Label
            {
                AutoSize = false,
                Width = 220,
                Height = 50,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI Emoji", 24F),
                Text = icono,
                Top = 14
            };

            var lblTitulo = new Label
            {
                AutoSize = false,
                Width = 200,
                Height = 26,
                Left = 10,
                Top = 68,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 41, 55),
                Text = titulo
            };

            var lblDesc = new Label
            {
                AutoSize = false,
                Width = 200,
                Height = 50,
                Left = 10,
                Top = 98,
                TextAlign = ContentAlignment.TopCenter,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(107, 114, 128),
                Text = descripcion
            };

            tarjeta.Controls.AddRange(new Control[] { borde, lblIcono, lblTitulo, lblDesc });
            tarjeta.Click += onClick;
            lblIcono.Click += onClick;
            lblTitulo.Click += onClick;
            lblDesc.Click += onClick;

            // Sombra / hover
            tarjeta.MouseEnter += (s, e) => tarjeta.BackColor = Color.FromArgb(248, 250, 252);
            tarjeta.MouseLeave += (s, e) => tarjeta.BackColor = Color.White;

            return tarjeta;
        }
    }
}