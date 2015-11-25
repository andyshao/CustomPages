using CustomPage.Core.Widgets.Descriptor;
using CustomPage.Core.Widgets.Descriptor.Models;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Web.Services
{
    public class JsonWidgetProvider : IWidgetProvider
    {
        private readonly IApplicationEnvironment _applicationEnvironment;

        public JsonWidgetProvider(IApplicationEnvironment applicationEnvironment)
        {
            _applicationEnvironment = applicationEnvironment;
        }

        #region Implementation of IWidgetProvider

        /// <summary>
        /// 得到可用的微件。
        /// </summary>
        /// <param name="widgets">微件集合。</param>
        public void GetWidgets(ICollection<WidgetDescriptor> widgets)
        {
            var json = File.ReadAllText(_applicationEnvironment.ApplicationBasePath + "/../widgets.json");

            foreach (var descriptor in JsonConvert.DeserializeObject<WidgetDescriptor[]>(json))
            {
                widgets.Add(descriptor);
            }
        }

        #endregion Implementation of IWidgetProvider
    }
}