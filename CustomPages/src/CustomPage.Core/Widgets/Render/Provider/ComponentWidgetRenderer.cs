using CustomPage.Core.Widgets.Descriptor.Models;
using Microsoft.AspNet.Html.Abstractions;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomPage.Core.Widgets.Render.Provider
{
    public sealed class ComponentWidgetRenderer : WidgetRenderer
    {
        private readonly string _componentName;

        public ComponentWidgetRenderer(WidgetRenderContext renderContext, IDictionary<string, object> model) : base(renderContext)
        {
            _componentName = (string)model["ComponentName"];
        }

        #region Overrides of WidgetRenderer

        /// <summary>
        /// 渲染。
        /// </summary>
        /// <param name="model">渲染模型。</param>
        /// <returns>渲染后的 Html 代码。</returns>
        protected override async Task<IHtmlContent> Render(dynamic model)
        {
            var helper = (IViewComponentHelper)model.ComponentHelper;
            return await helper.InvokeAsync(_componentName, model);
        }

        #endregion Overrides of WidgetRenderer
    }
}