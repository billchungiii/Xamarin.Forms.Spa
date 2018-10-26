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
	public partial class XSpaView : TemplatedView, IXSpaContainer
    {
        public XSpaView()
        {
            InitializeComponent();
            OutsideContainer = this.FindTemplateElementByName<Grid>("outsideContainer");          
            InsideConatiner =this.FindTemplateElementByName<Grid>("insideContainer");
            FirstPresenter = this.FindTemplateElementByName<ContentPresenter>("firstPresenter");
            SecondPresenter = this.FindTemplateElementByName<ContentPresenter>("secondPresenter");
        }

        public Grid OutsideContainer { get; private set; }

        public Grid InsideConatiner { get; private set; }

        public static readonly BindableProperty FirstContentProperty = BindableProperty.Create(nameof(FirstContent), typeof(View), typeof(XSpaView), null);
        public View FirstContent
        {
            get { return (View)GetValue(FirstContentProperty); }
            set { SetValue(FirstContentProperty, value); }
        }

        public static readonly BindableProperty SecondContentProperty = BindableProperty.Create(nameof(SecondContent), typeof(View), typeof(XSpaView), null);
        public View SecondContent
        {
            get { return (View)GetValue(SecondContentProperty); }
            set { SetValue(SecondContentProperty, value); }
        }

        public static readonly BindableProperty IsFirstVisibleProperty = BindableProperty.Create(nameof(IsFirstVisible), typeof(bool), typeof(XSpaView), false);
        public bool IsFirstVisible
        {
            get { return (bool)GetValue(IsFirstVisibleProperty); }
            set { SetValue(IsFirstVisibleProperty, value); }
        }

        public static readonly BindableProperty IsSecondVisibleProperty = BindableProperty.Create(nameof(IsSecondVisible), typeof(bool), typeof(XSpaView), false);
        public bool IsSecondVisible
        {
            get { return (bool)GetValue(IsSecondVisibleProperty); }
            set { SetValue(IsSecondVisibleProperty, value); }
        }

        public ContentPresenter FirstPresenter { get; private set; }

        public ContentPresenter SecondPresenter { get; private set; }

        public void RaiseFristContent()
        {
            InsideConatiner.RaiseChild(FirstPresenter);
        }

        public void RaiseSecondContent()
        {
            InsideConatiner.RaiseChild(SecondPresenter);
        }
    }
}