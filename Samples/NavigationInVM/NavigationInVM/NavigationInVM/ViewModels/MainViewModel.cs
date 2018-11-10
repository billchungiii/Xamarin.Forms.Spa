using NavigationInVM.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Spa.Common;
using Xamarin.Forms.Spa.Managers;

namespace NavigationInVM.ViewModels
{
    public class MainViewModel : NavigableViewModel
    {
        public MainViewModel ()
        {
            Title = "Spa ViewModel Navigation";
        }

        private ICommand _nextPage;
        public ICommand NextPage
        {
            get
            {
                if (_nextPage == null )
                {
                    _nextPage = new Command(() =>
                   {
                       var next = new View1();
                       PageManager.Manager.NavigateTo(next, null);
                   });
                }
                return _nextPage;
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }



        public override void OnBacked(object state)
        {
            if (state is string words)
            {
                Title = words;
            }
        }

        public override void OnDirected(object state)
        {
            if (state is string words)
            {
                Title = words;
            }
        }
    }
}
