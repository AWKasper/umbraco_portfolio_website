using Microsoft.AspNetCore.Mvc;
using Portfolio.Core.Services;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.Common.Controllers;

namespace Portfolio.Core.Controllers.Api
{
    public class ContactApiController: UmbracoAuthorizedApiController
    {
        private readonly ITestService _testService;
        
        public ContactApiController(ITestService testService)
        {
            _testService = testService;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return new JsonResult(_testService.GetAll());
        }
    }
}