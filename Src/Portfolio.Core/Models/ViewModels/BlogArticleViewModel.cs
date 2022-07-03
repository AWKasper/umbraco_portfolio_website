using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Portfolio.Core.Models.ViewModels
{
    public class BlogArticleViewModel : MainViewModel
    {
        public HtmlString Title { get; set; }
        public HtmlString Thumbnail { get; set; }
        public HtmlString Author { get; set; }
        public HtmlString PublishDate { get; set; }
        public HtmlString AuthorPicture { get; set; }
        public HtmlString BodyText { get; set; }
        public List<IPublishedContent> MultiNode { get; set; }
    }
}