using System.Collections.Generic;

namespace CustomPage.Core.Widgets.Descriptor.Models
{
    public class WidgetRendererDescriptor
    {
        public string RendererName { get; set; }
        public IDictionary<string, object> Model { get; set; }
    }
}