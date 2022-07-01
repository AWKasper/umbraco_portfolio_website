using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Portfolio.Core.Extensions;
using Portfolio.Core.Models.Umbraco;
using Portfolio.Core.Models.ViewModels;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace Portfolio.Core.Controllers.Render
{
    public class HomeController: RenderController
    {
        public IActionResult Home()
        {
            var home = (Home)CurrentPage;
            var viewModel = new HomeViewModel();
            viewModel.Build(CurrentPage);
            viewModel.BodyText = new HtmlString(home.BodyText?.ToHtmlString() ??
                                                string.Empty);
            return CurrentTemplate(viewModel);
        }
        
        public HomeController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            
        }
    }
}