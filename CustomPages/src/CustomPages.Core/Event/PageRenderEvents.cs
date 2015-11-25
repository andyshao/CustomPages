using System.Threading.Tasks;

namespace CustomPages.Core.Event
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
        Task Rendering(RenderingContext context);

        /// <summary>
        /// 渲染完成后执行。
        /// </summary>
        /// <param name="context">渲染后上下文。</param>
        /// <returns>任务。</returns>
        Task Rendered(RenderedContext context);
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
        public virtual Task Rendering(RenderingContext context)
        {
            return Task.Run(() => { });
        }

        /// <summary>
        /// 渲染完成后执行。
        /// </summary>
        /// <param name="context">渲染后上下文。</param>
        /// <returns>任务。</returns>
        public virtual Task Rendered(RenderedContext context)
        {
            return Task.Run(() => { });
        }

        #endregion Implementation of IPageRenderEvents
    }
}