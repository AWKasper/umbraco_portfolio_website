﻿using Microsoft.AspNetCore.Html;
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
    public class ProjectDetailController : RenderController
    {
        public IActionResult ProjectDetail()
        {
            var projectDetail = (ProjectDetail)CurrentPage;
            var viewModel = new ProjectDetailViewModel();
            viewModel.Build(CurrentPage);
            viewModel.Title = new HtmlString(projectDetail.Title?.ToHtmlString() ??
                                             string.Empty);
            viewModel.Author = new HtmlString(projectDetail.Author?.ToHtmlString() ??
                                              string.Empty);
            viewModel.Project = new HtmlString(projectDetail.Project?.ToHtmlString() ??
                                               string.Empty);

            var metaDescription = projectDetail.MetaDescription?.ToString();
            viewModel.MetaDescription = metaDescription;

            if (!string.IsNullOrEmpty(metaDescription))
            {
                viewModel.MetaDescription = metaDescription.Remove(0, 3)
                    .Remove(metaDescription.Length - 7);
            }

            viewModel.MetaImage = new HtmlString(projectDetail.MetaImage?.GetCropUrl() ??
                                                 string.Empty);
            return CurrentTemplate(viewModel);
        }

        public ProjectDetailController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
        }
    }
}