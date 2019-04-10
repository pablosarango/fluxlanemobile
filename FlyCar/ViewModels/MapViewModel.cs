using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using FlyCar.Models.Ruta;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace FlyCar.ViewModels
{
    public class MapViewModel
    {
        #region Properties
        public RutaViewModel RutaViewModel
        {
            get;
            set;
        }

        public Ruta Ruta
        {
            get;
            set;
        }

        #endregion


        #region Attributes
        private IList<Pin> pins;
        private double lat;
        private double lng;
        #endregion

        #region Constructors
        public MapViewModel()
        {
        }

        public MapViewModel(RutaViewModel rutaViewModel)
        {
            this.RutaViewModel = rutaViewModel;
            this.Ruta = RutaViewModel.Ruta;

        }
        #endregion

        #region Methods
        public IList<Pin> GetPins()
        {
            pins = new List<Pin>();

            return null;
            /*if (Ruta.Coordenadas != null)
            {
                lat = double.Parse(Ruta.Coordenadas.CoorInicial.LatInicial, System.Globalization.CultureInfo.InvariantCulture);
                lng = double.Parse(Ruta.Coordenadas.CoorInicial.LongInicial, System.Globalization.CultureInfo.InvariantCulture);
                var pin1 = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(lat, lng),
                    Label = "INICIO"
                };

                pins.Add(pin1);


                if (Ruta.Referencias != null)
                {

                    string[] coords;
                    var i = 1;
                    Pin pin;

                    foreach (var item in Ruta.Referencias)
                    {
                        coords = item.Split('/');
                        lat = double.Parse(coords[0], System.Globalization.CultureInfo.InvariantCulture);
                        lng = double.Parse(coords[1], System.Globalization.CultureInfo.InvariantCulture);
                        pin = new Pin();
                        pin.Type = PinType.Place;
                        pin.Position = new Position(lat, lng);
                        pin.Label = "" + i;
                        i++;
                        pins.Add(pin);
                        Array.Clear(coords, 0, coords.Length);
                    }
                }

                var pin2 = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(double.Parse(Ruta.Coordenadas.CoorFinal.LatFinal, System.Globalization.CultureInfo.InvariantCulture),
                                        double.Parse(Ruta.Coordenadas.CoorFinal.LongFinal, System.Globalization.CultureInfo.InvariantCulture)),
                    Label = "FINAL"
                };

                pins.Add(pin2);

                return pins;
            }
            else
            {
                return null;
            }

             */
        }

        private async void CerrarVista()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        private async void Iniciar()
        {
            
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
    }
}
