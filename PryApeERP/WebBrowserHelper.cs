using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Forms;

namespace PryApeERP
{

    public static class WebBrowserHelper
    {
        public static void ActivarIE11()
        {
            try
            {
                string exeName = Path.GetFileName(Application.ExecutablePath);
                using (var key = Registry.CurrentUser.OpenSubKey(
                    @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION",
                    writable: true) ?? Registry.CurrentUser.CreateSubKey(
                    @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION"))
                {
                    // 11001 = IE11 edge mode
                    key?.SetValue(exeName, 11001, RegistryValueKind.DWord);
                }
            }
            catch (Exception ex)
            {
                // No es crítico; el mapa puede funcionar igual si IE11 ya está activo
                System.Diagnostics.Debug.WriteLine("WebBrowserHelper: " + ex.Message);
            }
        }
    }
}