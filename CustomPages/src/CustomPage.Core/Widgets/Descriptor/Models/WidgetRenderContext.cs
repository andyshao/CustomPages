using System.Collections.Generic;

namespace CustomPage.Core.Widgets.Descriptor.Models
{
    /// <summary>
    /// 微件渲染上下文。
    /// </summary>
    public class WidgetRenderContext
    {
        /// <summary>
        /// 微件元素Id。
        /// </summary>
        public string ElementId { get; private set; }

        /// <summary>
        /// 微件名称。
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 微件的配置信息。
        /// </summary>
        public IDictionary<string, object> Settings { get; }

        /// <summary>
        /// 初始化一个微件渲染上下文。
        /// </summary>
        /// <param name="pageId">页面Id。</param>
        /// <param name="pageType">页面类型。</param>
        /// <param name="elementId">微件元素Id。</param>
        /// <param name="name">微件名称。</param>
        /// <param name="settings">微件的配置信息。</param>
        public WidgetRenderContext(string pageId, string pageType, string elementId, string name, IDictionary<string, object> settings)
        {
            /*ElementId = elementId.NotEmptyOrWhiteSpace("elementId");
            Name = name.NotEmptyOrWhiteSpace("name");
            Settings = settings.NotNull("settings");*/
            ElementId = elementId;
            Name = name;
            Settings = settings;
            Settings["System_PageId"] = pageId;
            Settings["System_PageType"] = pageType;
            Settings["System_ElementId"] = elementId;
            Settings["System_Name"] = name;
        }
    }
}