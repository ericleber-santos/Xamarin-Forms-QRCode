using QRCodeTeste.Helpers;
using QRCodeTeste.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace QRCodeTeste.ViewModels
{
    public class LerQRCodeViewModel : BaseViewModel
    {
        public ICommand LerQRCodeCommand => new Command(async () => await Capturar());
        public ICommand GerarQRCodeCommand => new Command(async () => await GerarQRCode());

        private string _codigoCapturado;

        public string CodigoCapturado
        {
            get { return _codigoCapturado; }
            set
            {                
                SetProperty(ref _codigoCapturado, value);
                OnPropertyChanged(nameof(CodigoCapturado));
            }
        }

        private string _codigoInformado;

        public string CodigoInformado
        {
            get { return _codigoInformado; }
            set
            {
                SetProperty(ref _codigoInformado, value);
                OnPropertyChanged(nameof(CodigoInformado));
            }
        }

        public LerQRCodeViewModel()
        {
            Title = "QRCode";
        }

        public async Task Capturar()
        {                     
            ZXingScannerPage scanPage = null;
            CodigoCapturado = string.Empty;

            scanPage = await Util.CapturarCodigoAsync(scanPage, "Ler QRCode", ZXing.BarcodeFormat.QR_CODE);
            if (!IsBusy)
            {
                scanPage.OnScanResult += (result) =>
                {
                    IsBusy = true;

                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        try
                        {   
                            scanPage.IsScanning = false;
                            CodigoCapturado = result.Text;
                            await Shell.Current.Navigation.PopAsync();
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e);
                        }
                        finally
                        {
                            IsBusy = false;
                        }
                    });

                    IsBusy = false;
                };
            }

            //abrir tela leitura
            await Shell.Current.Navigation.PushAsync(scanPage);
        }


        public async Task GerarQRCode()
        {
            if(!string.IsNullOrEmpty(CodigoInformado) )
            {
                await Shell.Current.Navigation.PushAsync(new GerarQRCodePage(CodigoInformado));
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("ATENÇÃO", "Informe o valor do codigo a ser gerado!", "Ok");
            }
            
        }
    }
}
