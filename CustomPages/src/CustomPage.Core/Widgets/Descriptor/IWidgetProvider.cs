using CustomPage.Core.Widgets.Descriptor.Models;
using System.Collections.Generic;

namespace CustomPage.Core.Widgets.Descriptor
{
    /// <summary>
    /// 一个抽象的微件提供程序。
    /// </summary>
    public interface IWidgetProvider
    {
        /// <summary>
        /// 得到可用的微件。
        /// </summary>
        /// <param name="widgets">微件集合。</param>
        void GetWidgets(ICollection<WidgetDescriptor> widgets);
    }
}