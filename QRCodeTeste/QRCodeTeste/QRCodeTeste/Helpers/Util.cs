

using System.Collections.Generic;
using System.Threading.Tasks;
using ZXing.Net.Mobile.Forms;

namespace QRCodeTeste.Helpers
{
    public class Util
    {
        public static bool IsNumeric(string texto)
        {
            double numero = 0;

            if (double.TryParse(texto, out numero))
                return true;
            else
            {
                return false;
            }
        }

        public async static Task<ZXingScannerPage> CapturarCodigoAsync(ZXingScannerPage scanPage, string titulo, ZXing.BarcodeFormat formato)
        {
            if (scanPage == null)
            {
                var options = new ZXing.Mobile.MobileBarcodeScanningOptions();
                options.PossibleFormats = new List<ZXing.BarcodeFormat>() { formato };
#if __ANDROID__
                //INITIALIZE THE SCANNER FIRST SO IT CAN TRACK THE CURRENT CONTEXT
                MobileBarcodeScanner.Initialize(Application);
#endif
                scanPage = new ZXingScannerPage(options);
                scanPage.IsScanning = true;
            }

            scanPage.Title = titulo;

            return scanPage;
        }
    }
}
