using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using FlyCar.Models.Ruta;
using FlyCar.Views;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace FlyCar.ViewModels
{
    public class RutaItemViewModel : Ruta 
    {
        
        #region Commands
        public ICommand SelectRutaCommand
        {
            get
            {
                return new RelayCommand(SelectRuta);
            }
        }







        #endregion

        #region Methods
        public async void SelectRuta()
        {
            
            MainViewModel.GetInstance().Ruta = new RutaViewModel(this);
            //await navigation.PushAsync(new RutaPage());
            await Application.Current.MainPage.Navigation.PushModalAsync(new RutaPage());
            //Debug.WriteLine("Instance");
        }





        #endregion
    }
}
