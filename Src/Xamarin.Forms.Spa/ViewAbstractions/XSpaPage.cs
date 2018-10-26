using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Xamarin.Forms.Spa.ViewAbstractions
{
	public class XSpaPage : ContentPage
	{
		public XSpaPage ()
		{
            Content = new XSpaView();
        }
	}
}