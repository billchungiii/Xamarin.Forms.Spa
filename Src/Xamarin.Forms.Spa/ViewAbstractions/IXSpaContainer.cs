using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.Spa.ViewAbstractions
{
    public interface IXSpaContainer
    {
        Grid OutsideContainer { get; }
        Grid InsideConatiner { get; }

        ContentPresenter FirstPresenter { get; }
        ContentPresenter SecondPresenter { get; }

        View FirstContent { get; set; }
        View SecondContent { get; set; }

        bool IsFirstVisible { get; set; }
        bool IsSecondVisible { get; set; }

        void RaiseFristContent();
        void RaiseSecondContent();
    }
}
