using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Spa.Managers;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.Spa.ViewAbstractions
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class XSpaDialogPanel : TemplatedView
    {
        public static readonly BindableProperty PanelColorProperty =
        BindableProperty.Create(nameof(PanelColor), typeof(Color), typeof(XSpaDialogPanel), defaultValue: Color.Black);

        public Color PanelColor
        {
            get { return (Color)GetValue(PanelColorProperty); }
            set { SetValue(PanelColorProperty, value); }
        }


        public static readonly BindableProperty PanelOpacityProperty =
        BindableProperty.Create(nameof(PanelOpacity), typeof(double), typeof(XSpaDialogPanel), defaultValue: 0.5);

        public double PanelOpacity
        {
            get { return (double)GetValue(PanelOpacityProperty); }
            set { SetValue(PanelOpacityProperty, value); }
        }

        public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(View), typeof(XSpaDialogPanel), null);
        public View Content
        {
            get { return (View)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        protected EventHandler<int> Closed;
        private void OnClosed(int arg)
        {
            Closed?.Invoke(this, arg);
            Closed = null;
        }

        public XSpaDialogPanel()
        {
            InitializeComponent();
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            View content = Content;
            ControlTemplate controlTemplate = ControlTemplate;
            if (content != null && controlTemplate != null)
            {
                SetInheritedBindingContext(content, BindingContext);
            }
        }

        /// <summary>
        /// content call this method to close dialog
        /// </summary>
        /// <param name="arg"></param>
        public void Close(int arg)
        {
            OnClosed(arg);
            PageManager.Manager.DetachDialog(this);
        }

        public void Show()
        {
            PageManager.Manager.AttatchDialog(this);
        }

        async public Task<int> ShowAsync()
        {
            this.Show();
            TaskCompletionSource<int> taskSource = new TaskCompletionSource<int>();
            this.Closed += (sender, args) =>
            {
                taskSource.SetResult(args);
            };
            var result = await taskSource.Task;
            return result;
        }
    }
}