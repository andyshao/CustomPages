using CustomPage.Core.Event;
using CustomPage.Core.Widgets;
using Microsoft.AspNet.Html.Abstractions;
using Microsoft.Extensions.WebEncoders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CustomPage.Core.Pages
{
    /// <summary>
    /// 一个抽象的页面。
    /// </summary>
    public interface IPage
    {
        /// <summary>
        /// 标题。
        /// </summary>
        string Title { get; }

        /// <summary>
        /// 说明。
        /// </summary>
        string Description { get; }

        /// <summary>
        /// 分类。
        /// </summary>
        long[] Categorys { get; set; }

        /// <summary>
        /// 背景颜色。
        /// </summary>
        string BackgroundColor { get; }

        /// <summary>
        /// 页面类型。
        /// </summary>
        string Type { get; set; }

        /// <summary>
        /// 微件数组。
        /// </summary>
        IWidget[] Widgets { get; }

        /// <summary>
        /// 渲染页面。
        /// </summary>
        /// <param name="model">渲染模型。</param>
        /// <returns>Html内容。</returns>
        Task<TextWriter> Render(dynamic model);
    }

    /// <summary>
    /// 页面抽象基类。
    /// </summary>
    public abstract class PageBase : IPage
    {
        #region Implementation of IPage

        /// <summary>
        /// 标题。
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 说明。
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 分类。
        /// </summary>
        public long[] Categorys { get; set; }

        /// <summary>
        /// 背景颜色。
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// 页面类型。
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 微件数组。
        /// </summary>
        public IWidget[] Widgets { get; set; }

        /// <summary>
        /// 渲染页面。
        /// </summary>
        /// <param name="display">显示者。</param>
        /// <returns>Html内容。</returns>
        public virtual async Task<TextWriter> Render(dynamic display)
        {
            if (Widgets == null || !Widgets.Any())
                return null;
            var writer = new StringWriter();
            foreach (var widget in Widgets.OrderBy(i => i.Position).Where(i => i.Renderer != null))
            {
                IHtmlContent content = await widget.Renderer.Render(display);
                content.WriteTo(writer, HtmlEncoder.Default);
            }
            return writer;
        }

        #endregion Implementation of IPage
    }

    /// <summary>
    /// 页面。
    /// </summary>
    public sealed class Page : PageBase
    {
        #region Field

        private readonly Func<IEnumerable<IPageRenderEvents>> _renderEventses;

        #endregion Field

        #region Constructor

        public Page(Func<IEnumerable<IPageRenderEvents>> renderEventses)
        {
            _renderEventses = renderEventses;
        }

        #endregion Constructor

        #region Property

        /// <summary>
        /// 页面标识。
        /// </summary>
        public long Id { get; set; }

        #endregion Property

        #region Overrides of PageBase

        /// <summary>
        /// 渲染页面。
        /// </summary>
        /// <param name="display">显示者。</param>
        /// <returns>Html 字符串。</returns>
        public override async Task<TextWriter> Render(dynamic display)
        {
            //执行页面渲染前事件。
            var renderingContext = InvokeEvents(new RenderingContext(this), (context, eventse) => eventse.Rendering(context));

            TextWriter result;
            bool isReplaced;
            //如果渲染结果需要替换则进行替换
            if (renderingContext.Result != null)
            {
                isReplaced = true;
                result = renderingContext.Result;
            }
            else
            {
                isReplaced = false;
                //得到页面结果
                result = await base.Render((object)display);
            }

            //执行页面渲染后事件。
            InvokeEvents(new RenderedContext(this, isReplaced), (context, eventse) => eventse.Rendered(context));

            return result;
        }

        #endregion Overrides of PageBase

        #region Private Method

        private T InvokeEvents<T>(T context, Action<T, IPageRenderEvents> action) where T : RenderContext<Page>
        {
            var renderEventses = _renderEventses().OrderByDescending(i => i.Priority);
            foreach (var eventse in renderEventses)
            {
                action(context, eventse);
                //是否终止执行。
                if (context.IsFinish)
                    return context;
            }
            return context;
        }

        #endregion Private Method
    }
}