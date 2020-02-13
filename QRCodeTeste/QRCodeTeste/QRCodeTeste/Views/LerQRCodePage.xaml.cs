using QRCodeTeste.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRCodeTeste.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LerQRCodePage : ContentPage
    {
        readonly LerQRCodeViewModel _viewModel;     

        public LerQRCodePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new LerQRCodeViewModel();
        }           
    }
}