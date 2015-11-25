using CustomPage.Core.Widgets.Descriptor.Models;
using Microsoft.AspNet.Html.Abstractions;
using Microsoft.AspNet.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomPage.Core.Widgets.Render.Provider
{
    public sealed class ViewWidgetRenderer : WidgetRenderer
    {
        private readonly string _viewName;

        public ViewWidgetRenderer(WidgetRenderContext renderContext, IDictionary<string,object> model) : base(renderContext)
        {
            _viewName = (string)model["ViewName"];
        }

        #region Overrides of WidgetRenderer

        /// <summary>
        /// 渲染。
        /// </summary>
        /// <param name="model">渲染模型。</param>
        /// <returns>渲染后的 Html 代码。</returns>
        protected override async Task<IHtmlContent> Render(dynamic model)
        {
            var helper = (IHtmlHelper)model.HtmlHelper;
            return await helper.PartialAsync(_viewName, (object)model);
        }

        #endregion Overrides of WidgetRenderer
    }
}