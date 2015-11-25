using Microsoft.AspNet.Html.Abstractions;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomPage.Core.Render.Provider
{
    public class ComponentRenderer : RendererBase
    {
        private readonly string _componentName;

        public ComponentRenderer(IDictionary<string, object> model)
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