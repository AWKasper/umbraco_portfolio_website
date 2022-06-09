using Microsoft.AspNetCore.Mvc;
using Portfolio.Core.Models.FormModels;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace Portfolio.Core.Controllers.Surface
{
    public class ContactSurfaceController: SurfaceController
    {
        [HttpPost]
        public IActionResult Submit([Bind(Prefix = "contactFormModel")] ContactFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }
            return RedirectToCurrentUmbracoPage();
        }
        
        public ContactSurfaceController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
        }
    }
}