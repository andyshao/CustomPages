using CustomPage.Core.Pages;
using System.IO;

namespace CustomPage.Core.Event
{
    /// <summary>
    /// 页面渲染上下文。
    /// </summary>
    /// <typeparam name="T">页面类型。</typeparam>
    public abstract class RenderContext<T> where T : class,IPage
    {
        #region Constructor

        /// <summary>
        /// 初始化一个新的页面渲染上下文。
        /// </summary>
        /// <param name="page">页面信息。</param>
        protected RenderContext(T page)
        {
            //            Page = page.NotNull("page");
            Page = page;
        }

        #endregion Constructor

        #region Property

        /// <summary>
        /// 页面信息。
        /// </summary>
        public T Page { get; set; }

        /// <summary>
        /// 是否完全终止事件的执行（如果为 true 则终止后续的时间执行）。
        /// </summary>
        public bool IsFinish { get; set; }

        #endregion Property

        #region Public Method

        /// <summary>
        /// 终止后续事件的执行。
        /// </summary>
        public void Finish()
        {
            IsFinish = true;
        }

        #endregion Public Method
    }

    /// <summary>
    /// 页面渲染前上下文。
    /// </summary>
    public class RenderingContext : RenderContext<Page>
    {
        #region Constructor

        /// <summary>
        /// 初始化一个新的页面渲染前上下文。
        /// </summary>
        /// <param name="page">页面信息。</param>
        public RenderingContext(Page page)
            : base(page)
        {
        }

        #endregion Constructor

        #region Property

        /// <summary>
        /// 用来替换渲染结果的内容。
        /// </summary>

        public TextWriter Result { get; set; }

        #endregion Property
    }

    /// <summary>
    /// 页面渲染后上下文。
    /// </summary>
    public class RenderedContext : RenderContext<Page>
    {
        #region Constructor

        /// <summary>
        /// 初始化一个新的页面渲染后上下文。
        /// </summary>
        /// <param name="page">页面信息。</param>
        /// <param name="isReplaced">渲染结果是否被替换。</param>

        public RenderedContext(Page page, bool isReplaced)
            : base(page)
        {
            IsReplaced = isReplaced;
        }

        #endregion Constructor

        /// <summary>
        /// 渲染结果是否被替换。
        /// </summary>
        public bool IsReplaced { get; private set; }
    }
}