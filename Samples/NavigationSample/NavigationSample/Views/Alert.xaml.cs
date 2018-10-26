using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Spa.ViewAbstractions;
using Xamarin.Forms.Xaml;

namespace NavigationSample.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Alert : XSpaDialogPanel
	{

	    public static readonly BindableProperty TitleTextProperty =
	        BindableProperty.Create(nameof(TitleText), typeof(string), typeof(Alert), defaultValue: null, propertyChanged: OnTitleTextPropertyChanged);

        private static void OnTitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var dialog = bindable as Alert;
            dialog.Title.Text  = (string) newValue;
        }

	    public string TitleText
	    {
	        get { return (string)GetValue(TitleTextProperty); }
	        set { SetValue(TitleTextProperty, value); }
	    }


	    public static readonly BindableProperty MessageTextProperty =
	        BindableProperty.Create(nameof(MessageText), typeof(string), typeof(Alert), defaultValue: null, propertyChanged: OnMessageTextPropertyChanged);
        public string MessageText
	    {
	        get { return (string)GetValue(MessageTextProperty); }
	        set { SetValue(MessageTextProperty, value); }
	    }

	    
        private static void OnMessageTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var dialog = bindable as Alert;
            dialog.Message.Text = (string)newValue;
        }

       


        public Alert ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            Close(0);
        }
    }
}