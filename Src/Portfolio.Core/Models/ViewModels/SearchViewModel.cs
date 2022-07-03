using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Portfolio.Core.Models.ViewModels
{
    public class SearchViewModel : MainViewModel
    {
        public List<IPublishedContent> Results { get; set; }
        
        public HtmlString Search { get; set; }
    }
}