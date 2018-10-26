using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Spa.Animations
{
    public interface IXSpaTransition
    {
        Func<View, Task> StartAnimation { get; }
        Func<View, Task> FinishedAnimation { get; }
    }
}
