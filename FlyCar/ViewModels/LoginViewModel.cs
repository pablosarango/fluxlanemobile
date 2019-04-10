using System.Diagnostics;
using System.Windows.Input;
using FlyCar.Models;
using FlyCar.Services;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace FlyCar.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        #region Events
        #endregion

        #region Attributes
        private string correo;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Correo
        {
            get { return this.correo; }
            set { SetValue(ref this.correo, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Correo)) 
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingresa tú correo",
                    "Ok");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingresa tu password",
                    "Ok");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            var response = await this.userService.Login<UserResponse>(this.Correo, this.Password);
            Debug.WriteLine(response.Message);
            var login = (UserResponse)response.Result;
            Debug.WriteLine(login._id);
            Debug.WriteLine(login.token);
            

            this.IsRunning = false;
            this.IsEnabled = true;
            this.Correo = string.Empty;
            this.Password = string.Empty;

            // MainViewModel.GetInstance().Home = new HomeViewModel();
            // await Application.Current.MainPage.Navigation.PushAsync(new HomePage());
            // await Application.Current.MainPage.Navigation.PopModalAsync();
        }
        #endregion

        #region Constructor
        public LoginViewModel()
        {
            this.IsEnabled = true;
            this.Correo = "blinish@blinish.com";
            this.Password = "123456";
            this.userService = new UserService();
        }
        #endregion

        #region Services
        private UserService userService;
        #endregion

    }
}
