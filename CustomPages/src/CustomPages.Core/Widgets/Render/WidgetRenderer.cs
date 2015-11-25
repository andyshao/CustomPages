using CustomPages.Core.Widgets.Descriptor.Models;
using Microsoft.AspNet.Html.Abstractions;
using Microsoft.AspNet.Mvc.Rendering;
using System.Threading.Tasks;

namespace CustomPages.Core.Widgets.Render
{
    /// <summary>
    /// 一个抽象的视图渲染器。
    /// </summary>
    public interface IWidgetRenderer
    {
        /// <summary>
        /// 渲染。
        /// </summary>
        /// <param name="model">渲染模型。</param>
        /// <returns>渲染后的 Html 代码。</returns>
        Task<IHtmlContent> Render(dynamic model);
    }
    /// <summary>
    /// 视图渲染器基类。
    /// </summary>
    public abstract class WidgetRenderer : IWidgetRenderer
    {
        private readonly WidgetRenderContext _renderContext;

        protected WidgetRenderer(WidgetRenderContext renderContext)
        {
            _renderContext = renderContext;
        }

        #region Implementation of IWidgetRenderer

        /// <summary>
        /// 渲染。
        /// </summary>
        /// <param name="model">渲染模型。</param>
        /// <returns>渲染后的 Html 代码。</returns>
        async Task<IHtmlContent> IWidgetRenderer.Render(dynamic model)
        {
            IHtmlContent html = await Render(model);

            var widgetContainer = new TagBuilder("div");
            widgetContainer.InnerHtml.SetContent(html);
            widgetContainer.GenerateId(_renderContext.ElementId, "_");
            widgetContainer.AddCssClass("widgth-" + _renderContext.Name);
            return widgetContainer.InnerHtml;
        }

        #endregion Implementation of IWidgetRenderer

        /// <summary>
        /// 渲染。
        /// </summary>
        /// <param name="model">渲染模型。</param>
        /// <returns>渲染后的 Html 代码。</returns>
        protected abstract Task<IHtmlContent> Render(dynamic model);
    }
}