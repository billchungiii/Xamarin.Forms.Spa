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
            if (xspaContainer is null)
            {
                throw new ArgumentNullException("xspaContainer can not be null");
            }
            PageManager.Manager = new PageManager
            {
                XSpaContainer = xspaContainer,
                States = new Stack<View>(),
                StateManager = new ContentStateManager(xspaContainer),
            };
        }

        public static void Initial(Application app, IXSpaContainer xspaContainer, View mainView)
        {
            Initial(app, xspaContainer);
            if (mainView == null)
            {
                throw new ArgumentNullException("mainView can not be null");
            }
            PageManager.Manager.DirectTo(mainView, null);
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

        private INavigable CheckCurrent()
        {
            if (Current is INavigable)
            {
                return Current as INavigable;
            }
            else
            {
                return NullNavigable.Empty;
            }
        }

        private INavigable CheckCurrentBindingContext()
        {
            if (Current != null && Current.BindingContext is INavigable)
            {
                return Current.BindingContext as INavigable;
            }
            else
            {
                return NullNavigable.Empty;
            }
        }

        private static bool IsNullNavigatable(INavigable navigable)
        {
            return navigable.GetType() == typeof(NullNavigable);
        }

        private INavigable GetNavigable()
        {
            var result = CheckCurrent();
            if (IsNullNavigatable(result))
            {
                result = CheckCurrentBindingContext();
            }
            return result;
        }


        private void OnDirecting()
        {
            GetNavigable().OnDirecting();
        }
        async public Task DirectToAsync(View view, object state, IXSpaTransition transition)
        {
            OnDirecting();
            await GoContentViewAsync(view, transition);
            OnDirected(state);
        }

        public void DirectTo(View view, object state)
        {
            OnDirecting();
            GoContentView(view);
            OnDirected(state);
        }



        private void OnDirected(object state)
        {
            GetNavigable().OnDirected(state);
        }





        private void OnNavigating()
        {
            GetNavigable().OnNavigating();
        }

        async public Task NavigateToAsync(View view, object state, IXSpaTransition transition)
        {
            OnNavigating();
            Push();
            await GoContentViewAsync(view, transition);
            OnNavigated(state);
        }

        public void NavigateTo(View view, object state)
        {
            OnNavigating();
            Push();
            GoContentView(view);
            OnNavigated(state);
        }


        private void OnNavigated(object state)
        {
            GetNavigable().OnNavigated(state);
        }

        private void OnBacking()
        {
            GetNavigable().OnBacking();
        }

        async public Task NavigateBackAsync(object state, IXSpaTransition transition)
        {
            OnBacking();
            var view = Pop();
            if (view != null)
            {
                await GoContentViewAsync(view, transition);
                OnBacked(state);
            }
        }
        public void NavigateBack(object state)
        {
            OnBacking();
            var view = Pop();
            if (view != null)
            {
                GoContentView(view);
                OnBacked(state);
            }
        }

        private void OnBacked(object state)
        {
            GetNavigable().OnBacked(state);
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


        private class NullNavigable : INavigable
        {

            public static readonly NullNavigable Empty = new NullNavigable();

            public void OnBacked(object state)
            { }

            public void OnBacking()
            { }

            public void OnDirected(object state)
            { }

            public void OnDirecting()
            { }

            public void OnNavigated(object state)
            { }

            public void OnNavigating()
            { }
        }
    }
}
