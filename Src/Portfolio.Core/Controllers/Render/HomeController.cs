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
    public class HomeController : RenderController
    {
        public IActionResult Home()
        {
            var home = (Home)CurrentPage;
            var viewModel = new HomeViewModel();
            viewModel.Build(CurrentPage);
            viewModel.BodyText = new HtmlString(home.BodyText?.ToHtmlString() ??
                                                string.Empty);

            var metaDescription = home.MetaDescription?.ToString();
            viewModel.MetaDescription = metaDescription;

            if (!string.IsNullOrEmpty(metaDescription))
            {
                viewModel.MetaDescription = metaDescription.Remove(0, 3)
                    .Remove(metaDescription.Length - 7);
            }

            viewModel.MetaImage = new HtmlString(home.MetaImage?.GetCropUrl() ??
                                                 string.Empty);
            return CurrentTemplate(viewModel);
        }

        public HomeController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
        }
    }
}