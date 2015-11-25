using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using System.Threading.Tasks;

namespace CustomPages.Core.Widgets.Descriptor.Models
{
    /// <summary>
    /// ΢����Դ��
    /// </summary>
    public sealed class WidgetResource
    {
        /// <summary>
        /// ���ʱ��Դ��
        /// </summary>
        public WidgetResourceItem[] Designer { get; set; }

        /// <summary>
        /// ��Ⱦʱ��Դ��
        /// </summary>
        public WidgetResourceItem[] View { get; set; }
    }

    /// <summary>
    /// ΢����Դ�
    /// </summary>
    public abstract class WidgetResourceItem
    {
        protected WidgetResourceItem(string path)
        {
            //            Path = path.NotEmptyOrWhiteSpace("path");
            Path = path;
        }

        /// <summary>
        /// ��Դ·����
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// ��Ⱦ��Դ��
        /// </summary>
        /// <param name="urlHelper">Url ���֡�</param>
        /// <returns>��ԴHtml���ݡ�</returns>
        public abstract Task<HtmlString> Render(IUrlHelper urlHelper);
    }

    /// <summary>
    /// �ű���Դ�
    /// </summary>
    public sealed class ScriptWidgetResourceItem : WidgetResourceItem
    {
        #region Overrides of WidgetResource

        public ScriptWidgetResourceItem(string path)
            : base(path)
        {
        }

        /// <summary>
        /// ��Ⱦ��Դ��
        /// </summary>
        /// <param name="urlHelper">Url ���֡�</param>
        /// <returns>��ԴHtml���ݡ�</returns>
        public override Task<HtmlString> Render(IUrlHelper urlHelper)
        {
            return Task.Run(() => new HtmlString($"<script src=\"{urlHelper.Content(Path)}\"></script>"));
        }

        #endregion Overrides of WidgetResource
    }

    /// <summary>
    /// ��ʽ����Դ�
    /// </summary>
    public sealed class StyleWidgetResourceItem : WidgetResourceItem
    {
        #region Overrides of WidgetResource

        public StyleWidgetResourceItem(string path)
            : base(path)
        {
        }

        /// <summary>
        /// ��Ⱦ��Դ��
        /// </summary>
        /// <param name="urlHelper">Url ���֡�</param>
        /// <returns>��ԴHtml���ݡ�</returns>
        public override Task<HtmlString> Render(IUrlHelper urlHelper)
        {
            return Task.Run(() => new HtmlString($"<link href=\"{urlHelper.Content(Path)}\" rel=\"stylesheet\" />"));
        }

        #endregion Overrides of WidgetResource
    }
}