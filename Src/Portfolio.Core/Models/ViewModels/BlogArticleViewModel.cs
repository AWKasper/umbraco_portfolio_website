using System;
using Microsoft.AspNetCore.Html;

namespace Portfolio.Core.Models.ViewModels
{
    public class BlogArticleViewModel: MainViewModel
    {
        public HtmlString Title { get; set; }
        public HtmlString Thumbnail { get; set; }
        public HtmlString Author { get; set; }
        public HtmlString PublishDate { get; set; }
        public HtmlString AuthorPicture { get; set; }
        public HtmlString BodyText { get; set; }
    }
}