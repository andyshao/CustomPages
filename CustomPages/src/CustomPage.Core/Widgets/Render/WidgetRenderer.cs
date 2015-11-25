using CustomPage.Core.Render;
using CustomPage.Core.Widgets.Descriptor.Models;
using Microsoft.AspNet.Html.Abstractions;
using Microsoft.AspNet.Mvc.Rendering;
using System.Threading.Tasks;

namespace CustomPage.Core.Widgets.Render
{
    /// <summary>
    /// һ���������ͼ��Ⱦ����
    /// </summary>
    public interface IWidgetRenderer : IRenderer
    {
    }

    /// <summary>
    /// ��ͼ��Ⱦ�����ࡣ
    /// </summary>
    public class WidgetRenderer : IWidgetRenderer
    {
        private readonly WidgetRenderContext _renderContext;

        public WidgetRenderer(WidgetRenderContext renderContext)
        {
            _renderContext = renderContext;
        }

        #region Implementation of IWidgetRenderer

        /// <summary>
        /// ��Ⱦ��
        /// </summary>
        /// <param name="model">��Ⱦģ�͡�</param>
        /// <returns>��Ⱦ��� Html ���롣</returns>
        public async Task<IHtmlContent> Render(dynamic model)
        {
            var renderer = _renderContext.Renderer;
            IHtmlContent html = await renderer.Render(model);

            var widgetContainer = new TagBuilder("div");
            widgetContainer.InnerHtml.SetContent(html);
            widgetContainer.GenerateId(_renderContext.ElementId, "_");
            widgetContainer.AddCssClass("widgth-" + _renderContext.Name);
            return widgetContainer;
        }

        #endregion Implementation of IWidgetRenderer
    }
}