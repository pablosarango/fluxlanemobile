using System;
namespace FlyCar.ViewModels
{
    public class MainViewModel
    {

        #region ViewModels
        public LoginViewModel Login
        {
            get;
            set;
        }

        public HomeViewModel Home
        {
            get;
            set;
        }

        public RutasViewModel Rutas
        {
            get;
            set;
        }

        public RutaViewModel Ruta
        {
            get;
            set;
        }

        public MapViewModel Map
        {
            get;
            set;
        }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            instance = this;
            // this.Rutas = new RutasViewModel();
            this.Login = new LoginViewModel();

        }
        #endregion


        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance() 
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion
    }

}
