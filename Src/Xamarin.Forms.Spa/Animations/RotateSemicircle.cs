using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Spa.Animations
{
    public class RotateSemicircle : IXSpaTransition
    {
        public Func<View, Task> StartAnimation => (async (x) =>
        {            
            await x.RotateTo(180, 250, Easing.CubicInOut);
        });

        public Func<View, Task> FinishedAnimation => (async (x) =>
        {
            await x.RotateTo(0, 0);
        });
    }
}
