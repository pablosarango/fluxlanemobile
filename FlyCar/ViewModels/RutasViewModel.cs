using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using FlyCar.Models.Ruta;
using FlyCar.Services;
using FlyCar.Views;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace FlyCar.ViewModels
{
    public class RutasViewModel : BaseViewModel
    {
        // id_user = 5b44e603c44af70f3e5debcf

        #region Attributes
        private ObservableCollection<RutaItemViewModel> rutas;
        private bool isRefreshing;
        private string filter;
        private List<Ruta> list;
        #endregion

        #region Properties
        public ObservableCollection<RutaItemViewModel> Rutas
        {
            get { return this.rutas; }
            set { SetValue(ref this.rutas, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public string Filter
        {
            get { return this.filter; }
            set 
            { 
                SetValue(ref this.filter, value);
                this.Search();
            }
        }
        #endregion

        #region Constructor

        public RutasViewModel()
        {
            this.apiService = new ApiService();
            this.LoadRutas();

        }

        #endregion

        #region Methods
        private async void LoadRutas()
        {
            string[] ids = { "5bf3049a3a0de251ac26c870" };
            this.IsRefreshing = true;

            /*var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", 
                                                                connection.Message, 
                                                                "Aceptar");
                
                //MainViewModel.GetInstance().Login = new LoginViewModel();
                //await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                return;
            }
            */

            //var response = await this.apiService.GetList<Ruta>("http://api.fluxlane.com", "", "/ruta", ids, "5");
            var response = await this.apiService.GetList<Ruta>("http://api.fluxlane.com", "", "/ruta", ids, "5");
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error",
                                                                response.Message, 
                                                                "Aceptar");
                //MainViewModel.GetInstance().Login = new LoginViewModel();
                //await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                return;
            }

            this.list = (List<Ruta>)response.Result;
            this.Rutas = new ObservableCollection<RutaItemViewModel>(
                this.ToRutaItemViewModel());
            this.IsRefreshing = false;
        }

        private IEnumerable<RutaItemViewModel> ToRutaItemViewModel()
        {
            return this.list.Select(r => new RutaItemViewModel
            {
                fecha_hora = r.fecha_hora,
                clima = r.clima,
                conductor_id = r.conductor_id,
                descripcion = r.descripcion,
                estado = r.estado,
                int_captura = r.int_captura,
                nombre = r.nombre,
                referencias = r.referencias,
                subpuntos = r.subpuntos,
                velocidad_promedio = r.velocidad_promedio,
                _id = r._id
            });
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Rutas = new ObservableCollection<RutaItemViewModel>(this.ToRutaItemViewModel());
            }
            else
            {
                this.Rutas = new ObservableCollection<RutaItemViewModel>(
                    this.ToRutaItemViewModel().Where(r => r.nombre.ToLower().Contains(this.Filter.ToLower())));
            }
        }

        public async void CheckLogin()
        {
            MainViewModel.GetInstance().Login = new LoginViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
        #endregion

        #region Services
        private ApiService apiService;
        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadRutas);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }
        #endregion
    }
}
