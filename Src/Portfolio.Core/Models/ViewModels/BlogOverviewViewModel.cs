using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Portfolio.Core.Models.Umbraco;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Portfolio.Core.Models.ViewModels
{
    public class BlogOverviewViewModel: MainViewModel
    {
        public HtmlString BodyText { get; set; }
        public List<IPublishedContent> Children { get; set; }
    }
}