using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Spa.Common;
using Xamarin.Forms.Spa.Managers;

namespace NavigationInVM.ViewModels
{
    public class ViewModel1 : NavigableViewModel
    {
        private ICommand _backMain;
        public ICommand BackMain
        {
            get
            {
                if (_backMain == null)
                {
                    _backMain = new Command(() =>
                    {
                        PageManager.Manager.NavigateBack("從 View1 回來");
                    });
                }
                return _backMain;
            }
        }
    }
}
