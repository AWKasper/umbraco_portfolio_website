﻿using System.Linq;
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
    public class BlogOverviewController: RenderController
    {
        public IActionResult BlogOverview()
        {
            var blogOverview = (BlogOverview)CurrentPage;
            var viewModel = new BlogOverviewViewModel();
            viewModel.Build(CurrentPage);
            viewModel.BodyText = new HtmlString(blogOverview.BodyText?.ToHtmlString() ??
                                                string.Empty);
            viewModel.Children = viewModel.Content.ChildrenOfType("blogArticle").ToList();
            return CurrentTemplate(viewModel);
        }
        
        public BlogOverviewController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
        }
    }
}