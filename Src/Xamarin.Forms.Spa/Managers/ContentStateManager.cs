using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Spa.Animations;
using Xamarin.Forms.Spa.ViewAbstractions;

namespace Xamarin.Forms.Spa.Managers
{
    internal class ContentStateManager
    {
        public ContentState Current { get; set; }
        public ContentState FirstState { get; private set; }
        public ContentState SecondState { get; private set; }
        public IXSpaContainer XspaContainer { get; private set; }

        public ContentStateManager(IXSpaContainer xspaContainer)
        {
            XspaContainer = xspaContainer;
            FirstState = new FirstGridState(this);
            SecondState = new SecondGridState(this);
            Current = SecondState;
        }

        /// <summary>
        /// Change view to next without animation
        /// </summary>
        /// <param name="view"></param>
        public void ChangeState(View view)
        {            
            Current.SetRearView(view);          
            Current.SetRearVisible();         
            Current.RaiseRear();           
            Current.SetFrontUnvisible();          
            Current.GoNextState();            
        }
        /// <summary>
        /// Change view to next with animation
        /// </summary>
        /// <param name="view"></param>
        /// <param name="animation"></param>
        /// <param name="finishedAnimation"></param>
        /// <returns></returns>
        async public Task ChangeStateAsync(View view, IXSpaTransition transition)
        {
            Current.SetRearView(view);
            Current.SetRearVisible();
            if (transition != null)
            {
                await Current.RunAnimationAsync(transition.StartAnimation);
            }
            Current.RaiseRear();
            Current.SetFrontUnvisible();
            if (transition != null)
            {
                await Current.RunFinishedAnimationAsync(transition.FinishedAnimation);
            }
            
            Current.GoNextState();
        }
    }
}
