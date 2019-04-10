using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using FlyCar.ViewModels;
using GalaSoft.MvvmLight.Command;
using Plugin.Permissions;
using Xamarin.Forms;

namespace FlyCar.Views
{
    public partial class RutasPage : ContentPage
    {
        
        public RutasPage()
        {
            InitializeComponent();


        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();

            try 
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Location);
                if (status != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Plugin.Permissions.Abstractions.Permission.Location))
                    {
                        await DisplayAlert("Localización necesaria", "Necesitamos tú localización", "Ok");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Plugin.Permissions.Abstractions.Permission.Location);
                    if (results.ContainsKey(Plugin.Permissions.Abstractions.Permission.Location))
                    {
                        status = results[Plugin.Permissions.Abstractions.Permission.Location];
                    }
                }

                /*if (status == Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                {
                    Debug.WriteLine("Permiso concedido!!!!");
                }
                else if (status != Plugin.Permissions.Abstractions.PermissionStatus.Unknown)
                {
                    await DisplayAlert("Localización denegada", "No podemos continuar", "OK");
                }
                */
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR: " + ex);
            }
        }

    }
}
