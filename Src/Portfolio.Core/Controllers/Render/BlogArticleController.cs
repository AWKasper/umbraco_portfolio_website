using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Portfolio.Core.Extensions;
using Portfolio.Core.Models.Umbraco;
using Portfolio.Core.Models.ViewModels;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Extensions;

namespace Portfolio.Core.Controllers.Render
{
    public class BlogArticleController: RenderController
    {
        public IActionResult BlogArticle()
        {
            var blogArticle = (BlogArticle)CurrentPage;
            var viewModel = new BlogArticleViewModel();
            viewModel.Build(CurrentPage);
            viewModel.Title = new HtmlString(blogArticle.Title?.ToHtmlString() ??
                                                string.Empty);
            viewModel.Thumbnail = new HtmlString(blogArticle.Thumbnail.GetCropUrl() ??
                                                     string.Empty);
            viewModel.Author = new HtmlString(blogArticle.Author?.ToHtmlString() ??
                                                string.Empty);
            viewModel.PublishDate = new HtmlString(blogArticle.PublishDate.ToLongDateString());
            viewModel.AuthorPicture = new HtmlString(blogArticle.AuthorPicture?.GetCropUrl() ??
                                                string.Empty);
            viewModel.BodyText = new HtmlString(blogArticle.BodyText?.ToHtmlString() ??
                                                string.Empty);
            viewModel.MultiNode = blogArticle.MultiNode as List<IPublishedContent>;
            return CurrentTemplate(viewModel);
        }
        
        public BlogArticleController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
        }
    }
}