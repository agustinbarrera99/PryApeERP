using System.Windows.Forms;

namespace PryApeERP
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public class MapaScriptHelper
    {
        private readonly frmDomicilioModal _form;

        public MapaScriptHelper(frmDomicilioModal form)
        {
            _form = form;
        }

        public void SetCoordenadas(string lat, string lng)
        {
            _form.RecibirCoordenadas(lat, lng);
        }
    }
}