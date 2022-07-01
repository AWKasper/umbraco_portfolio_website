using Microsoft.AspNetCore.Html;
using Umbraco.Cms.Core.Models.PublishedContent;
using System.Collections.Generic;

namespace Portfolio.Core.Models.ViewModels
{
    public class ProjectOverviewViewModel : MainViewModel
    {
        public HtmlString BodyText { get; set; }

        public List<IPublishedContent> Children { get; set; }
    }
}