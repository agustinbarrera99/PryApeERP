// UIHelper.cs
using System.Windows.Forms;

namespace PryApeERP
{
    public static class UIHelper
    {
        public static void AplicarIcono(Form frm)
        {
            frm.Icon = new System.Drawing.Icon(
                System.IO.Path.Combine(
                    Application.StartupPath, "iconoPrincipal.ico"
                )
            );
        }
    }
}