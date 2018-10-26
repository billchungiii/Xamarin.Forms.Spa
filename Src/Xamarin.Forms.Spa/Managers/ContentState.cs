using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Spa.Managers
{
    internal abstract class ContentState
    {
        protected ContentState(ContentStateManager manager)
        {
            Manager = manager;
            ContentContainer = manager.XspaContainer.InsideConatiner;
        }

        protected ContentStateManager Manager { get; private set; }

        internal Grid ContentContainer { get; private set; }
        public abstract void SetRearView(View view);
        async public Task RunAnimationAsync(Func<View, Task> animation)
        {
            await InnerRunAnimationAsync(animation);
        }
        async public Task RunFinishedAnimationAsync(Func<View, Task> animation)
        {
            await InnerRunAnimationAsync(animation);
        }

        protected abstract Task InnerRunAnimationAsync(Func<View, Task> animation);
        public abstract void GoNextState();

        public abstract void SetRearVisible();
        public abstract void SetFrontUnvisible();

        public abstract void RaiseRear();


    }

    internal class FirstGridState : ContentState
    {
        public FirstGridState(ContentStateManager manager) : base(manager)
        {

        }
        public override void SetRearVisible()
        {
            Manager.XspaContainer.IsSecondVisible = true;
        }

        public override void SetFrontUnvisible()
        {
            Manager.XspaContainer.IsFirstVisible = false;
        }


        public override void GoNextState()
        {
            Manager.Current = Manager.SecondState;
        }

        public override void SetRearView(View view)
        {
            Manager.XspaContainer.SecondContent = view;
        }

        public override void RaiseRear()
        {
            Manager.XspaContainer.RaiseSecondContent();
        }
       
        async protected override Task InnerRunAnimationAsync(Func<View, Task> animation)
        {
            if (animation != null)
            {
                await animation.Invoke(Manager.XspaContainer.FirstPresenter);
            }

        }
    }

    internal class SecondGridState : ContentState
    {
        public override void SetRearVisible()
        {
            Manager.XspaContainer.IsFirstVisible = true;
        }

        public override void SetFrontUnvisible()
        {
            Manager.XspaContainer.IsSecondVisible = false;
        }
        public SecondGridState(ContentStateManager manager) : base(manager)
        {

        }

        public override void GoNextState()
        {
            Manager.Current = Manager.FirstState;
        }

        public override void SetRearView(View view)
        {
            Manager.XspaContainer.FirstContent = view;
        }

        public override void RaiseRear()
        {
            Manager.XspaContainer.RaiseFristContent();
        }       

        async protected override Task InnerRunAnimationAsync(Func<View, Task> animation)
        {
            if (animation != null)
            {
                await animation.Invoke(Manager.XspaContainer.SecondPresenter);
            }

        }
    }
}
