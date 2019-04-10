using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using FlyCar.ViewModels;
using GalaSoft.MvvmLight.Command;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace FlyCar.Views
{
    
    public partial class MapPage : ContentPage, INotifyPropertyChanged
    {

        #region Attributes
        private MapViewModel mapViewModel;
        private IList<Pin> listPin;
        private double totalHeight;
        private string latitud;
        private string longitud;
        private string velocidad;
        private IList<string> data;
        private string obj;
        private string text;
        private bool isEnabled;
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
            {
                return;
            }

            backingField = value;
            OnPropertyChanged(propertyName);
        }

        #region Properties
        bool IsListening 
        { 
            get; 
        }

        public string Latitud
        {
            get { return this.latitud; }
            set { SetValue(ref this.latitud, value); }
        }

        public string Longitud
        {
            get { return this.longitud; }
            set { SetValue(ref this.longitud, value); }
        }

        public string Velocidad
        {
            get { return this.velocidad; }
            set { SetValue(ref this.velocidad, value); }
        }

        public string Text
        {
            get { return this.text; }
            set { SetValue(ref this.text, value); }
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        #endregion

        #region Constructors
        public MapPage()
        {
            InitializeComponent();
        }


        public MapPage(MapViewModel mapViewModel)
        {
            InitializeComponent();

            BindingContext = this;

            this.Text = "Iniciar";

            this.IsEnabled = false;

            this.mapViewModel = mapViewModel;
            listPin = new List<Pin>();

            listPin = mapViewModel.GetPins();

            customMap.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Xamarin.Forms.Maps.Position(listPin[0].Position.Latitude, listPin[0].Position.Longitude), Distance.FromMiles(0.1)));

        }
        #endregion

        #region Override Methods
        protected override void OnAppearing()
        {
            base.OnAppearing();

            foreach (var item in listPin)
            {
                customMap.RouteCoordinates.Add(new Xamarin.Forms.Maps.Position(item.Position.Latitude, item.Position.Longitude));
                customMap.Pins.Add(item);
            }

        }
        #endregion


        #region Methods
        private async void Enjoy()
        {
            if (this.Text == "Iniciar") {
                this.Text = "Parar";
                data = new List<string>();
                bool repetir = true;
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 2;

                while (repetir)
                {

                    var position = await locator.GetPositionAsync(TimeSpan.FromMilliseconds(100));
                    var speed = position.Speed * 3.6;
                    var time = string.Format("{0:HH:mm:ss}", DateTime.Now);

                    obj = "{" + position.Latitude.ToString() + ","
                                        + position.Longitude.ToString() + ","
                                        + speed.ToString() + ","
                                        + time + "}";
                    data.Add(obj);

                    Latitud = position.Latitude.ToString();
                    Longitud = position.Longitude.ToString();
                    Velocidad = speed.ToString();

                    customMap.MoveToRegion(
                        MapSpan.FromCenterAndRadius(
                            new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude), Distance.FromMiles(0.1)));

                    if (repetir)
                    {
                        await Task.Delay(TimeSpan.FromMilliseconds(1000));
                    }
                }
            }
            else
            {
                this.Text = "Iniciar";
            }

        }

        private async void CerrarVista()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        private async void Enviar()
        {
            await DisplayAlert("CORRECTO", "Datos enviados correctamente", "Ok");
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
                return new RelayCommand(Enjoy);
            }
        }

        public ICommand EnviarCommand
        {
            get
            {
                return new RelayCommand(Enviar);
            }
        }

        #endregion




    }
}
