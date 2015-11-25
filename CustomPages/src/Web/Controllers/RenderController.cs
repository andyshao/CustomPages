using Autofac;
using CustomPage.Core.Pages;
using CustomPage.Core.Pages.Events;
using CustomPage.Core.Render;
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

            var renderer = _lifetimeScope.ResolveNamed<Lazy<IRenderer>>(descriptor.RendererDescriptor.RendererName,new PositionalParameter(0, descriptor.RendererDescriptor.Model));
            var context = new WidgetRenderContext(renderer,"Page1", "page", "Widget1", descriptor.Name, new Dictionary<string, object>());

            var widgetRenderer = _lifetimeScope.Resolve<Lazy<IWidgetRenderer>>(new PositionalParameter(0, context));

            var page = new Page(() => _pageRenderEventses.Value)
            {
                Widgets = new IWidget[]
                {
                    new Widget(descriptor,widgetRenderer)
                }
            };
            return View(page);
        }
    }
}