using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.Spa.ViewAbstractions
{
    /// <summary>
    /// view want to support pre/post behaviors need to implement this interface
    /// </summary>
    public interface INavigable
    {
        void OnDirecting();
        void OnDirected(object state);
        void OnBacking();
        void OnBacked(object state);

        void OnNavigating();
        void OnNavigated(object state);
    }
}
