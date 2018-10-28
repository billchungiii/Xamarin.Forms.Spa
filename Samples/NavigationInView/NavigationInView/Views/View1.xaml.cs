using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Spa.Managers;
using Xamarin.Forms.Spa.ViewAbstractions;
using Xamarin.Forms.Xaml;

namespace NavigationInView.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class View1 : NavigableView
    {
		public View1 ()
		{
			InitializeComponent ();
		}

        private void NextButton_Clicked(object sender, EventArgs e)
        {

        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            // back to MainView without animation and state
            PageManager.Manager.NavigateBack(null);
        }


        /// <summary>
        /// do something before back to MainView
        /// </summary>
        public override void OnBacking()
        {
            System.Diagnostics.Debug.WriteLine(".......before view1 back to mainview");
        }
    }
}