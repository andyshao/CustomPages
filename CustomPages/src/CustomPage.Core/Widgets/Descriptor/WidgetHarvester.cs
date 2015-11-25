using CustomPage.Core.Widgets.Descriptor.Models;
using System.Collections.Generic;

namespace CustomPage.Core.Widgets.Descriptor
{
    /// <summary>
    /// 一个抽象的微件收集者。
    /// </summary>
    public interface IWidgetHarvester 
    {
        /// <summary>
        /// 收集微件。
        /// </summary>
        /// <returns>微件集合。</returns>
        IEnumerable<WidgetDescriptor> HarvestWidgets();
    }

    internal sealed class WidgetHarvester : IWidgetHarvester
    {
        private readonly IEnumerable<IWidgetProvider> _providers;
        private WidgetDescriptor[] _widgets;

        public WidgetHarvester(IEnumerable<IWidgetProvider> providers)
        {
            _providers = providers;
        }

        #region Implementation of IWidgetHarvester

        /// <summary>
        /// 收集微件。
        /// </summary>
        /// <returns>微件集合。</returns>
        public IEnumerable<WidgetDescriptor> HarvestWidgets()
        {
            if (_widgets != null)
                return _widgets;

            var widgets = new List<WidgetDescriptor>();
            foreach (var provider in _providers)
                provider.GetWidgets(widgets);
            return _widgets = widgets.ToArray();
        }

        #endregion Implementation of IWidgetHarvester
    }
}