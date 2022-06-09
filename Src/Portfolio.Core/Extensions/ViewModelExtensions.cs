using Portfolio.Core.Models.Umbraco;
using Portfolio.Core.Models.ViewModels;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Portfolio.Core.Extensions
{
    public static class ViewModelExtensions
    {
        public static void Build(this MainViewModel model, IPublishedContent
            content)
        {
            var home = content.AncestorOrSelf<Home>();
            model.PageTitle = content.Name;
            model.Content = content;
        }
    }
}