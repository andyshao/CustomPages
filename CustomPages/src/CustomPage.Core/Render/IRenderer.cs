using Microsoft.AspNet.Html.Abstractions;
using System.Threading.Tasks;

namespace CustomPage.Core.Render
{
    public interface IRenderer
    {
        /// <summary>
        /// 渲染。
        /// </summary>
        /// <param name="model">渲染模型。</param>
        /// <returns>渲染后的 Html 代码。</returns>
        Task<IHtmlContent> Render(object model);
    }
}