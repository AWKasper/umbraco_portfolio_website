using System;
using Microsoft.AspNetCore.Html;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Portfolio.Core.Models.ViewModels
{
    public class MainViewModel
    {
        public string PageTitle { get; set; }
        public HtmlString MetaDescription { get; set; }
        public HtmlString MetaImage { get; set; }

//NOTE: In order to not break all pages, allow access to Umbracomethods.
        [Obsolete] public IPublishedContent Content { get; set; }
    }
}