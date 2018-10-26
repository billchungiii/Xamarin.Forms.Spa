using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Spa.Animations
{
    public class FadeAndMoveDown : IXSpaTransition
    {
        public Func<View, Task> StartAnimation => (async (x) =>
        {
            x.FadeTo(0, 250, Easing.CubicInOut);
            await x.TranslateTo(0, 500, 250, Easing.CubicInOut);
        });

        public Func<View, Task> FinishedAnimation => (async (x) =>
        {
            await x.FadeTo(1, 0);
            await x.TranslateTo(0, 0, 0);
        });
    }
}
