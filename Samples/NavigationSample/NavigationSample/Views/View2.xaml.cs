using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Spa.Animations;
using Xamarin.Forms.Spa.Managers;
using Xamarin.Forms.Xaml;

namespace NavigationSample.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class View2 : ContentView
	{
		public View2 ()
		{
			InitializeComponent ();
		}

        async private void Button_Clicked(object sender, EventArgs e)
        {           
            await PageManager.Manager.NavigateBackAsync(null, new RotateSemicircle());
        }
    }
}