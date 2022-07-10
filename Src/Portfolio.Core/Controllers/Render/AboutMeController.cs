using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Portfolio.Core.Extensions;
using Portfolio.Core.Models.Umbraco;
using Portfolio.Core.Models.ViewModels;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Extensions;

namespace Portfolio.Core.Controllers.Render
{
    public class AboutMeController : RenderController
    {
        
        public IActionResult AboutMe()
        {
            var aboutMe = (AboutMe)CurrentPage;
            var viewModel = new AboutMeViewModel();
            viewModel.Build(CurrentPage);
            viewModel.BodyText = new HtmlString(aboutMe.BodyText?.ToHtmlString() ??
                                                string.Empty);
            viewModel.MetaDescription = new HtmlString(aboutMe.MetaDescription?.ToHtmlString() ??
                                                       string.Empty);
            viewModel.MetaImage = new HtmlString(aboutMe.MetaImage?.GetCropUrl() ??
                                                 string.Empty);
            return CurrentTemplate(viewModel);
        }
        
        public AboutMeController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
        }
    }
}