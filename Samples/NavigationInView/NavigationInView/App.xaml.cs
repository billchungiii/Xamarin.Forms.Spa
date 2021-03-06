﻿using NavigationInView.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Spa.Managers;
using Xamarin.Forms.Spa.ViewAbstractions;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NavigationInView
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var page = new XSpaPage();
            PageManager.Initial(this, (IXSpaContainer)page.Content);
            PageManager.Manager.DirectTo(new MainView(), null);
            MainPage = page;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
