using Microsoft.AspNetCore.Html;

namespace Portfolio.Core.Models.ViewModels
{
    public class BlogOverviewViewModel: MainViewModel
    {
        public HtmlString BodyText { get; set; }
    }
}