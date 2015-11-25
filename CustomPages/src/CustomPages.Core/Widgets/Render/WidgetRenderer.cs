using CustomPages.Core.Widgets.Descriptor.Models;
using Microsoft.AspNet.Html.Abstractions;
using Microsoft.AspNet.Mvc.Rendering;
using System.Threading.Tasks;

namespace CustomPages.Core.Widgets.Render
{
    /// <summary>
    /// һ���������ͼ��Ⱦ����
    /// </summary>
    public interface IWidgetRenderer
    {
        /// <summary>
        /// ��Ⱦ��
        /// </summary>
        /// <param name="model">��Ⱦģ�͡�</param>
        /// <returns>��Ⱦ��� Html ���롣</returns>
        Task<IHtmlContent> Render(dynamic model);
    }
    /// <summary>
    /// ��ͼ��Ⱦ�����ࡣ
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
        /// ��Ⱦ��
        /// </summary>
        /// <param name="model">��Ⱦģ�͡�</param>
        /// <returns>��Ⱦ��� Html ���롣</returns>
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
        /// ��Ⱦ��
        /// </summary>
        /// <param name="model">��Ⱦģ�͡�</param>
        /// <returns>��Ⱦ��� Html ���롣</returns>
        protected abstract Task<IHtmlContent> Render(dynamic model);
    }
}