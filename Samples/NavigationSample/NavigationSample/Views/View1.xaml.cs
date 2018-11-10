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
	public partial class View1 : ContentView
	{
		public View1 ()
		{
			InitializeComponent();
		}

        async private void Button_Clicked(object sender, EventArgs e)
        {         
            var next = new View2();          
            IXSpaTransition transition = new FadeAndMoveDown();
            await PageManager.Manager.NavigateToAsync(next, null, transition);
        }

        async private void ShowButton_Clicked(object sender, EventArgs e)
        {
            Alert a = new Alert() {TitleText = "標題文字", MessageText = "訊息內容"};
            var result = await a.ShowAsync();
            System.Diagnostics.Debug.WriteLine(result);
        }
    }
}