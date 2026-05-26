using System;
using System.Windows.Forms;

namespace PryApeERP
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            WebBrowserHelper.ActivarIE11();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new frmInicioSesion());
        }
    }
}
