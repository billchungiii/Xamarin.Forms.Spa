using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.Spa.ViewAbstractions
{
    /// <summary>
    /// the content view support pre behaviors before move to the other view, and support post behaviors after move in this view 
    /// </summary>
    public class NavigableView : ContentView, INavigable
    {
        public virtual void OnBacked(object state)
        { }

        public virtual void OnBacking()
        { }

        public virtual void OnDirected(object state)
        { }

        public virtual void OnDirecting()
        { }

        public virtual void OnNavigated(object state)
        { }

        public virtual void OnNavigating()
        { }
    }
}
