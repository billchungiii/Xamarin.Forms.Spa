using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Spa.ViewAbstractions;

namespace Xamarin.Forms.Spa.Common
{
    public abstract class NavigableViewModel : INavigable
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
