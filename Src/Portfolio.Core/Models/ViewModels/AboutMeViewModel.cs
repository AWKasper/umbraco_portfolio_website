using Microsoft.AspNetCore.Html;

namespace Portfolio.Core.Models.ViewModels
{
    public class AboutMeViewModel : MainViewModel
    {
        public HtmlString BodyText { get; set; }
    }
}