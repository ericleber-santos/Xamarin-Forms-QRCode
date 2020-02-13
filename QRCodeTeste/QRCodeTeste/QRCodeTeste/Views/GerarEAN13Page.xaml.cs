using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QRCodeTeste.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace QRCodeTeste.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GerarEAN13Page : ContentPage
    {
        readonly GerarEAN13ViewModel _viewModel;
        ZXingBarcodeImageView barcodeEAN13;

        public GerarEAN13Page(string codigo)
        {
            InitializeComponent();
            BindingContext = _viewModel = new GerarEAN13ViewModel(codigo);
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ExibirCodigos();
        }

        public async Task ExibirCodigos()
        {
            barcodeEAN13 = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingBarcodeImageView",
                Margin = new Thickness(10)
            };

            barcodeEAN13.BarcodeFormat = ZXing.BarcodeFormat.EAN_13;
            barcodeEAN13.BarcodeOptions.Width = 400;
            barcodeEAN13.BarcodeOptions.Height = 400;
            barcodeEAN13.BarcodeOptions.Margin = 0;
            barcodeEAN13.BarcodeValue = _viewModel.CodigoInformado.Trim();

            try
            {
                stackEAN13.Children.Add(barcodeEAN13);
            }
            catch(Exception e)
            {
                await App.Current.MainPage.DisplayAlert("ATENÇÃO", $"EAN13 inválido!{e.Message}", "Ok");
            }

           
        }
    }
}