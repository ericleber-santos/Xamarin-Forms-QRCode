using QRCodeTeste.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace QRCodeTeste.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GerarQRCodePage : ContentPage
    {
        readonly GerarQRCodeViewModel _viewModel;
        ZXingBarcodeImageView barcodeQRCode;      

        public GerarQRCodePage(string codigo)
        {
            InitializeComponent();           
            BindingContext = _viewModel = new GerarQRCodeViewModel(codigo);
            ExibirCodigos();
        }
       
        public void ExibirCodigos()
        {
            barcodeQRCode = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingBarcodeImageView",
                Margin = new Thickness(10)
            };

            barcodeQRCode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            barcodeQRCode.BarcodeOptions.Width = 400;
            barcodeQRCode.BarcodeOptions.Height = 400;
            barcodeQRCode.BarcodeOptions.Margin = 0;
            barcodeQRCode.BarcodeValue = _viewModel.CodigoInformado;
            stackQRCode.Children.Add(barcodeQRCode);
        }
       
    }
}