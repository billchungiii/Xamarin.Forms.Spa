using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xamarin.Forms.Spa.Extensions
{
    internal static class TemplateExtension
    {
        /// <summary>
        /// Find element in page
        /// </summary>
        /// <typeparam name="T">target element type</typeparam>
        /// <param name="page">which page want to search</param>
        /// <param name="name">target element name</param>
        /// <returns>T</returns>
        public static T FindTemplateElementByName<T>(this Page page, string name) where T : Element
        {
            if (page == null)
            {
                throw new ArgumentNullException();
            }
            var controller = (IPageController)page;
            T result = null;
            result = controller.InternalChildren.FirstOrDefault()?.FindByName<T>(name);
            return result;
        }

        /// <summary>
        /// Find element in layout (ContentPresenter, Layout(of T), ScrollView, TemplatedView...)
        /// </summary>
        /// <typeparam name="T">target element type</typeparam>
        /// <param name="layout">>which layout want to search</param>
        /// <param name="name">target element name</param>
        /// <returns>T</returns>
        public static T FindTemplateElementByName<T>(this Layout layout, string name) where T : Element
        {
            if (layout == null)
            {
                throw new ArgumentNullException();
            }
            T result = null;
            result = layout.Children.FirstOrDefault()?.FindByName<T>(name);
            return result;
        }
    }
}
