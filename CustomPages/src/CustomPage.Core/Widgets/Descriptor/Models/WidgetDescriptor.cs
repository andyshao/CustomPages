using System.ComponentModel.DataAnnotations;

namespace CustomPage.Core.Widgets.Descriptor.Models
{
    /// <summary>
    /// 微件描述符。
    /// </summary>
    public sealed class WidgetDescriptor
    {
        public WidgetDescriptor()
        {
            Visible = true;
        }

        /// <summary>
        /// 微件标题。
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// 微件名称。
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 分类。
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 微件描述。
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 微件预览图。
        /// </summary>
        public string PreviewImage { get; set; }

        /// <summary>
        /// 相关资源。
        /// </summary>
        public WidgetResource Resource { get; set; }

        /// <summary>
        /// 微件渲染器描述符。
        /// </summary>
        public WidgetRendererDescriptor RendererDescriptor { get; set; }

        /// <summary>
        /// 是否可见。
        /// </summary>
        public bool Visible { get; set; }
    }
}