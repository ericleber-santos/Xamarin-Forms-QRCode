using QRCodeTeste.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRCodeTeste.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LerEAN13Page : ContentPage
    {
        readonly LerEAN13ViewModel _viewModel;

        public LerEAN13Page()
        {
            InitializeComponent();
            BindingContext = _viewModel = new LerEAN13ViewModel();
        }
    }
}