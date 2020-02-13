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
    public class LerEAN13ViewModel : BaseViewModel
    {
        public ICommand LerEAN13Command => new Command(async () => await Capturar());
        public ICommand GerarEAN13Command => new Command(async () => await GerarEAN13());

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

        public LerEAN13ViewModel()
        {
            Title = "EAN13";
        }

        public async Task Capturar()
        {
            ZXingScannerPage scanPage = null;
            CodigoCapturado = string.Empty;

            scanPage = await Util.CapturarCodigoAsync(scanPage, "Ler EAN13", ZXing.BarcodeFormat.EAN_13);
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


        public async Task GerarEAN13()
        {
            if (string.IsNullOrEmpty(CodigoInformado))
            {
                await App.Current.MainPage.DisplayAlert("ATENÇÃO", "Informe o valor do EAN13 a ser gerado!", "Ok");
                return;
            }

            if (!Util.IsNumeric(CodigoInformado))
            {
                await App.Current.MainPage.DisplayAlert("ATENÇÃO", "O EAN13 informado não é um número!", "Ok");
                return;
            }

            if (CodigoInformado.Length != 13 )
            {                     
                await App.Current.MainPage.DisplayAlert("ATENÇÃO", "O EAN13 informado deve ter 13 números!", "Ok");
                return;
            }
              
            await Shell.Current.Navigation.PushAsync(new GerarEAN13Page(CodigoInformado));
        }
    }
}
