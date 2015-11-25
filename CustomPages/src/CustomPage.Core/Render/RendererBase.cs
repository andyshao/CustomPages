using Microsoft.AspNet.Html.Abstractions;
using System.Threading.Tasks;

namespace CustomPage.Core.Render
{
    public abstract class RendererBase : IRenderer
    {
        #region Implementation of IRenderer

        /// <summary>
        /// 渲染。
        /// </summary>
        /// <param name="model">渲染模型。</param>
        /// <returns>渲染后的 Html 代码。</returns>
        Task<IHtmlContent> IRenderer.Render(object model)
        {
            return Render(model);
        }

        #endregion Implementation of IRenderer

        /// <summary>
        /// 渲染。
        /// </summary>
        /// <param name="model">渲染模型。</param>
        /// <returns>渲染后的 Html 代码。</returns>
        protected abstract Task<IHtmlContent> Render(object model);
    }
}