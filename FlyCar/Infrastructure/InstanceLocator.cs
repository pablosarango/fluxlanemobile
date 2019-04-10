using System;
using FlyCar.ViewModels;
namespace FlyCar.Infrastructure
{
    
    public class InstanceLocator
    {
        #region Properties
        public MainViewModel MainViewModel
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public InstanceLocator()
        {
            this.MainViewModel = new MainViewModel();

        }
        #endregion

    }
}
