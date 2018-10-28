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
	public partial class MainView : NavigableView
    {
		public MainView ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            // Navigate to View1 without animation and state
            var next = new View1();
            PageManager.Manager.NavigateTo(next, null);
        }

        /// <summary>
        /// do something after backed to mainview
        /// </summary>
        /// <param name="state"></param>
        public override void OnBacked(object state)
        {
            System.Diagnostics.Debug.WriteLine(".......after backed to mainview");
        }
    }
}