using System;
using System.Collections.Generic;
using System.Text;

namespace QRCodeTeste.ViewModels
{
    public class GerarQRCodeViewModel : BaseViewModel
    {
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

        public GerarQRCodeViewModel(string codigo)
        {
            Title = "QRCode Gerado";
            CodigoInformado = codigo;
        }  
    }
}
