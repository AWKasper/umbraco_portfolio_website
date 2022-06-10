using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Portfolio.Core.Extensions;
using Portfolio.Core.Models.ViewModels;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace Portfolio.Core.Controllers.Render
{
    public class ContentController: RenderController
    {
        public override IActionResult Index()
        {
            var viewModel = new MainViewModel();
            viewModel.Build(CurrentPage);
            return CurrentTemplate(viewModel);
        }
        
        public ContentController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
        }
    }
}