using System.Threading.Tasks;

namespace CustomPage.Core.Pages.Events
{
    /// <summary>
    /// 一个抽象的页面渲染事件。
    /// </summary>
    public interface IPageRenderEvents
    {
        /// <summary>
        /// 事件优先级。
        /// </summary>
        int Priority { get; }

        /// <summary>
        /// 渲染之前执行。
        /// </summary>
        /// <param name="context">渲染前上下文。</param>
        /// <returns>任务。</returns>
        Task Rendering(PageRenderingContext context);

        /// <summary>
        /// 渲染完成后执行。
        /// </summary>
        /// <param name="context">渲染后上下文。</param>
        /// <returns>任务。</returns>
        Task Rendered(PageRenderedContext context);
    }

    /// <summary>
    /// 一个抽象的页面渲染事件。
    /// </summary>
    public abstract class PageRenderEvents : IPageRenderEvents
    {
        #region Implementation of IPageRenderEvents

        /// <summary>
        /// 事件优先级。
        /// </summary>
        public virtual int Priority => 50;

        /// <summary>
        /// 渲染之前执行。
        /// </summary>
        /// <param name="context">渲染前上下文。</param>
        /// <returns>任务。</returns>
        public virtual Task Rendering(PageRenderingContext context)
        {
            return Task.Run(() => { });
        }

        /// <summary>
        /// 渲染完成后执行。
        /// </summary>
        /// <param name="context">渲染后上下文。</param>
        /// <returns>任务。</returns>
        public virtual Task Rendered(PageRenderedContext context)
        {
            return Task.Run(() => { });
        }

        #endregion Implementation of IPageRenderEvents
    }
}