using System;
using System.Diagnostics;
using System.Windows.Input;
using FlyCar.Models.Ruta;
using FlyCar.Views;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace FlyCar.ViewModels
{
    public class RutaViewModel
    {
        #region Properties
        public Ruta Ruta
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public RutaViewModel(Ruta ruta)
        {
            this.Ruta = ruta;
        }
        #endregion

        #region Commands
        public ICommand CerrarCommand
        {
            get
            {
                return new RelayCommand(CerrarVista);
            }
        }

        public ICommand IniciarCommand
        {
            get
            {
                return new RelayCommand(Iniciar);
            }
        }

        #endregion

        #region Methods
        private async void CerrarVista()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        private async void Iniciar()
        {
            //var mapPage = new MapPage();
            //mapPage.BindingContext = this.Ruta;
            MainViewModel.GetInstance().Map = new MapViewModel(this);
            await Application.Current.MainPage.Navigation.PushModalAsync(new MapPage(MainViewModel.GetInstance().Map));
        }
       
        #endregion
    }
}
