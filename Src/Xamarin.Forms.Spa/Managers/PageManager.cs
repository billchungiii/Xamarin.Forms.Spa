using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Spa.Animations;
using Xamarin.Forms.Spa.ViewAbstractions;

namespace Xamarin.Forms.Spa.Managers
{
    public class PageManager
    {        
        private static PageManager _manager;
        public static PageManager Manager
        {
            get
            {
                if (_manager == null)
                {
                    throw new Exception("please initialize pagemanager first");
                }
                return _manager;
            }
            set => _manager = value;
        }

        public IXSpaContainer XSpaContainer { get; private set; }

        private Stack<View> States { get; set; }

        private ContentStateManager StateManager { get; set; }

        private View Current { get; set; }

        protected PageManager()
        { }
        public static void Initial(Application app, IXSpaContainer xspaContainer)
        {           
            PageManager.Manager = new PageManager
            {
                XSpaContainer = xspaContainer,
                States = new Stack<View>(),
                StateManager = new ContentStateManager(xspaContainer),
            };
        }

        public bool IsViewOnStackTop<T>()
        {
            if (States.Count > 0)
            {
                return (States.Peek().GetType() == typeof(T));
            }
            return false;
        }

        private View Pop()
        {
            if (States.Count > 0)
            {
                return States.Pop();
            }
            return null;
        }

        private void Push()
        {
            if (Current != null)
            {
                States.Push(Current);
            }

        }

        public void ClearStack()
        {
            if (States != null && States.Count > 0)
            {
                States.Clear();
            }
        }
        private void OnDirecting()
        {
            if (Current is INavigable navigatedObject)
            {
                navigatedObject.OnDirecting();
            }
        }
        async public Task DirectToAsync(View view, object state, IXSpaTransition transition)
        {
            OnDirecting();
            await GoContentViewAsync(view, transition);
            OnDirected(view, state);
        }

        public void DirectTo(View view, object state)
        {
            OnDirecting();
            GoContentView(view);
            OnDirected(view, state);
        }

        private void OnDirected(View view, object state)
        {
            if (view is INavigable navigatedObject)
            {
                navigatedObject.OnDirected(state);
            }
        }

        private void OnNavigating()
        {
            if (Current is INavigable navigatedObject)
            {
                navigatedObject.OnNavigating();
            }
        }

        async public Task NavigateToAsync(View view, object state, IXSpaTransition transition)
        {
            OnNavigating();
            Push();
            await GoContentViewAsync(view, transition);
            OnNavigated(view,state);
        }

        public void NavigateTo(View view, object state)
        {
            OnNavigating();
            Push();
            GoContentView(view);
            OnNavigated(view,state);
        }


        private void OnNavigated(View view, object state)
        {
            if (view is INavigable navigatedObject)
            {
                navigatedObject.OnNavigated(state);
            }
        }

        private void OnBacking()
        {
            if (Current is INavigable navigatedObject)
            {
                navigatedObject.OnBacking();
            }
        }

        async public Task NavigateBackAsync(object state, IXSpaTransition transition)
        {
            OnBacking();
            var view = Pop();
            if (view != null)
            {
                await GoContentViewAsync(view, transition);
                OnBacked(view, state);
            }
        }
        public void NavigateBack(object state)
        {
            OnBacking();
            var view = Pop();
            if (view != null)
            {
                GoContentView(view);
                OnBacked(view, state);
            }
        }

        private void OnBacked(View view, object state)
        {
            if (view is INavigable navigatedObject)
            {
                navigatedObject.OnBacked(state);
            }
        }

        private void GoContentView(View view)
        {
            StateManager.ChangeState(view);
            Current = view;
        }

        async private Task GoContentViewAsync(View view, IXSpaTransition transition)
        {
            await StateManager.ChangeStateAsync(view, transition);
            Current = view;
        }

        public void AttatchDialog(View dialog)
        {
            XSpaContainer.OutsideContainer.Children.Add(dialog);
        }

        public void DetachDialog(View dialog)
        {
            XSpaContainer.OutsideContainer.Children.Remove(dialog);
        }

        public void ClearDialogs()
        {
            XSpaContainer.OutsideContainer.Children.Clear();
        }
    }
}
