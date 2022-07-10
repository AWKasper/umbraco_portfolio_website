using System.Linq;
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
    public class ProjectOverviewController : RenderController
    {
        
        public IActionResult ProjectOverview()
        {
            var projectOverview = (ProjectOverview)CurrentPage;
            var viewModel = new ProjectOverviewViewModel();
            viewModel.Build(CurrentPage);
            viewModel.BodyText = new HtmlString(projectOverview.BodyText?.ToHtmlString() ??
                                                string.Empty);
            viewModel.Children = viewModel.Content.ChildrenOfType("projectDetail").ToList();
            viewModel.MetaDescription = new HtmlString(projectOverview.MetaDescription?.ToHtmlString() ??
                                                       string.Empty);
            viewModel.MetaImage = new HtmlString(projectOverview.MetaImage?.GetCropUrl() ??
                                                 string.Empty);
            return CurrentTemplate(viewModel);
        }
        
        public ProjectOverviewController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
        }
    }
}