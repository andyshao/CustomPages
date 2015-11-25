using Autofac;
using CustomPage.Core;
using CustomPage.Core.Event;
using CustomPage.Core.Widgets;
using CustomPage.Core.Widgets.Descriptor;
using CustomPage.Core.Widgets.Descriptor.Models;
using CustomPage.Core.Widgets.Render;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    public class RenderController : Controller
    {
        private readonly IWidgetHarvester _widgetHarvester;
        private readonly Lazy<IEnumerable<IPageRenderEvents>> _pageRenderEventses;
        private readonly ILifetimeScope _lifetimeScope;

        public RenderController(IWidgetHarvester widgetHarvester, Lazy<IEnumerable<IPageRenderEvents>> pageRenderEventses, ILifetimeScope lifetimeScope)
        {
            _widgetHarvester = widgetHarvester;
            _pageRenderEventses = pageRenderEventses;
            _lifetimeScope = lifetimeScope;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var descriptor = _widgetHarvester.HarvestWidgets().Last();

            var context = new WidgetRenderContext("Page1", "page", "Widget1", descriptor.Name, new Dictionary<string, object>());

            var renderer = _lifetimeScope.ResolveNamed<IWidgetRenderer>(descriptor.RendererDescriptor.RendererName, new PositionalParameter(0, context),
                new PositionalParameter(1, descriptor.RendererDescriptor.Model));

            var page = new Page(() => _pageRenderEventses.Value)
            {
                Widgets = new IWidget[]
                {
                    new Widget(descriptor,renderer)
                }
            };
            return View(page);
        }
    }
}