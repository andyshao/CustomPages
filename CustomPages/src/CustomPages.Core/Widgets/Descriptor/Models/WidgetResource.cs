using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using System.Threading.Tasks;

namespace CustomPages.Core.Widgets.Descriptor.Models
{
    /// <summary>
    /// 微件资源。
    /// </summary>
    public sealed class WidgetResource
    {
        /// <summary>
        /// 设计时资源。
        /// </summary>
        public WidgetResourceItem[] Designer { get; set; }

        /// <summary>
        /// 渲染时资源。
        /// </summary>
        public WidgetResourceItem[] View { get; set; }
    }

    /// <summary>
    /// 微件资源项。
    /// </summary>
    public abstract class WidgetResourceItem
    {
        protected WidgetResourceItem(string path)
        {
            //            Path = path.NotEmptyOrWhiteSpace("path");
            Path = path;
        }

        /// <summary>
        /// 资源路径。
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 渲染资源。
        /// </summary>
        /// <param name="urlHelper">Url 助手。</param>
        /// <returns>资源Html内容。</returns>
        public abstract Task<HtmlString> Render(IUrlHelper urlHelper);
    }

    /// <summary>
    /// 脚本资源项。
    /// </summary>
    public sealed class ScriptWidgetResourceItem : WidgetResourceItem
    {
        #region Overrides of WidgetResource

        public ScriptWidgetResourceItem(string path)
            : base(path)
        {
        }

        /// <summary>
        /// 渲染资源。
        /// </summary>
        /// <param name="urlHelper">Url 助手。</param>
        /// <returns>资源Html内容。</returns>
        public override Task<HtmlString> Render(IUrlHelper urlHelper)
        {
            return Task.Run(() => new HtmlString($"<script src=\"{urlHelper.Content(Path)}\"></script>"));
        }

        #endregion Overrides of WidgetResource
    }

    /// <summary>
    /// 样式表资源项。
    /// </summary>
    public sealed class StyleWidgetResourceItem : WidgetResourceItem
    {
        #region Overrides of WidgetResource

        public StyleWidgetResourceItem(string path)
            : base(path)
        {
        }

        /// <summary>
        /// 渲染资源。
        /// </summary>
        /// <param name="urlHelper">Url 助手。</param>
        /// <returns>资源Html内容。</returns>
        public override Task<HtmlString> Render(IUrlHelper urlHelper)
        {
            return Task.Run(() => new HtmlString($"<link href=\"{urlHelper.Content(Path)}\" rel=\"stylesheet\" />"));
        }

        #endregion Overrides of WidgetResource
    }
}