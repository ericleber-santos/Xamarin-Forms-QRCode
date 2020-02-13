using System;
using System.Collections.Generic;
using System.Text;

namespace QRCodeTeste.ViewModels
{
    public class GerarEAN13ViewModel : BaseViewModel
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

        public GerarEAN13ViewModel(string codigo)
        {
            Title = "EAN13 Gerado";
            CodigoInformado = codigo;
        }
    }
}
