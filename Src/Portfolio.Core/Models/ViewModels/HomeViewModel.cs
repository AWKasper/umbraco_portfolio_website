using Microsoft.AspNetCore.Html;

namespace Portfolio.Core.Models.ViewModels
{
    public class HomeViewModel : MainViewModel
    {
        public HtmlString BodyText { get; set; }
    }
}