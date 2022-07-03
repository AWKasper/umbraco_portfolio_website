using Microsoft.AspNetCore.Html;

namespace Portfolio.Core.Models.ViewModels
{
    public class ProjectDetailViewModel : MainViewModel
    {
        public HtmlString Title { get; set; }
        public HtmlString Project { get; set; }
    }
}