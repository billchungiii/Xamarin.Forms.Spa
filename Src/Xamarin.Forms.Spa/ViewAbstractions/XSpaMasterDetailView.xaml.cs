using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Spa.Extensions;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.Spa.ViewAbstractions
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class XSpaMasterDetailView : NavigableView
	{
	    public static readonly BindableProperty MenuViewProperty =
	        BindableProperty.Create(nameof(MenuContent), typeof(View), typeof(XSpaMasterDetailView), null);
	  

	    public View MenuContent
	    {
	        get => (View)GetValue(MenuProperty);
	        set => SetValue(MenuViewProperty, value);
	    }
	


	    public static readonly BindableProperty ToolBarContentProperty = BindableProperty.Create(nameof(ToolBarContent), typeof(View), typeof(XSpaPage), null);
	    public View ToolBarContent
	    {
	        get => (View)GetValue(ToolBarContentProperty);
	        set => SetValue(ToolBarContentProperty, value);
	    }

	    public static readonly BindableProperty MenuButtonContentProperty = BindableProperty.Create(nameof(MenuButtonContent), typeof(View), typeof(XSpaPage), null);
	    public View MenuButtonContent
	    {
	        get => (View)GetValue(MenuButtonContentProperty);
	        set => SetValue(MenuButtonContentProperty, value);
	    }
	    public XSpaMasterDetailView()
	    {
	        InitializeComponent();
	      
	    }
	}
}