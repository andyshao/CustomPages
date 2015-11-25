using CustomPages.Core.Widgets.Descriptor.Models;
using CustomPages.Core.Widgets.Render;
using System.Collections.Generic;

namespace CustomPages.Core.Widgets
{
    /// <summary>
    /// 一个抽象的微件。
    /// </summary>
    public interface IWidget
    {
        /// <summary>
        /// 微件描述符。
        /// </summary>
        WidgetDescriptor Descriptor { get; }

        /// <summary>
        /// 排序。
        /// </summary>
        uint Position { get; }

        /// <summary>
        /// 设置信息。
        /// </summary>
        IDictionary<string, string> Settings { get; }

        /// <summary>
        /// 渲染器。
        /// </summary>
        IWidgetRenderer Renderer { get; }
    }

    /// <summary>
    /// 微件抽象基类。
    /// </summary>
    public abstract class WidgetBase : IWidget
    {
        #region Constructor

        protected WidgetBase(WidgetDescriptor descriptor, IWidgetRenderer renderer)
        {
            Descriptor = descriptor;
            Renderer = renderer;
            Settings = new Dictionary<string, string>();
        }

        #endregion Constructor

        #region Implementation of IWidget

        /// <summary>
        /// 微件描述符。
        /// </summary>
        public WidgetDescriptor Descriptor { get; }

        /// <summary>
        /// 排序。
        /// </summary>
        public uint Position { get; set; }

        /// <summary>
        /// 设置信息。
        /// </summary>
        public IDictionary<string, string> Settings { get; }

        /// <summary>
        /// 渲染器。
        /// </summary>
        public IWidgetRenderer Renderer { get; }

        #endregion Implementation of IWidget
    }

    /// <summary>
    /// 微件。
    /// </summary>
    public sealed class Widget : WidgetBase
    {
        public Widget(WidgetDescriptor descriptor, IWidgetRenderer render)
            : base(descriptor, render)
        {
        }
    }
}