using Microsoft.AspNetCore.Mvc;
using Portfolio.Core.Models.FormModels;
using Portfolio.Core.Services;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Mail;
using Umbraco.Cms.Core.Models.Email;
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
        private readonly IEmailSender _emailSender;
        
        [HttpPost]
        public IActionResult Submit([Bind(Prefix = "contactFormModel")] ContactFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }
            _testService.Add($"{formModel.Name} | {formModel.Email} |{formModel.Comment}");
            var email = new EmailMessage(
                formModel.Email,
                "abe.kasper@hva.nl",
                "Contact form",
                $"{formModel.Name ?? "Unknown"}: {formModel.Comment}",
                false
            );
            _emailSender.SendAsync(email, string.Empty);
            return RedirectToCurrentUmbracoPage();
        }
        public ContactSurfaceController(IUmbracoContextAccessor umbracoContextAccessor, IEmailSender emailSender, ITestService testService, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _testService = testService;
            _emailSender = emailSender;
        }
    }
}