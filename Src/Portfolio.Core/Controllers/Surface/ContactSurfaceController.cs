using Microsoft.AspNetCore.Mvc;
using Portfolio.Core.Models.FormModels;
using Portfolio.Core.Services;
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
        private readonly ITestService _testService;
        
        [HttpPost]
        public IActionResult Submit([Bind(Prefix = "contactFormModel")] ContactFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }
            _testService.Add($"{formModel.Name} | {formModel.Email} |{formModel.Comment}");
            return RedirectToCurrentUmbracoPage();
        }
        public ContactSurfaceController(IUmbracoContextAccessor umbracoContextAccessor, ITestService testService, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _testService = testService;
        }
    }
}