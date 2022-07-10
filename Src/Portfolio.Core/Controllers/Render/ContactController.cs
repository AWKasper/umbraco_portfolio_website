using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Portfolio.Core.Extensions;
using Portfolio.Core.Models.Umbraco;
using Portfolio.Core.Models.ViewModels;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Extensions;

namespace Portfolio.Core.Controllers.Render
{
    public class ContactController : RenderController
    {
        
        public IActionResult Contact()
        {
            var contact = (Contact)CurrentPage;
            var viewModel = new ContactViewModel();
            viewModel.Build(CurrentPage);
            viewModel.BodyText = new HtmlString(contact.BodyText?.ToHtmlString() ??
                                                string.Empty);
            viewModel.MetaDescription = new HtmlString(contact.MetaDescription?.ToHtmlString() ??
                                                string.Empty);
            viewModel.MetaImage = new HtmlString(contact.MetaImage?.GetCropUrl() ??
                                                 string.Empty);
            return CurrentTemplate(viewModel);
        }
        
        public ContactController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
        }
    }
}