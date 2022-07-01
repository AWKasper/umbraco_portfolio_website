using Microsoft.AspNetCore.Html;

namespace Portfolio.Core.Models.ViewModels
{
    public class ContactViewModel : MainViewModel
    {
        public HtmlString BodyText { get; set; }
    }
}