using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Core.Controllers
{
    [Route("Test")]
    public class TestController : Controller
    {
        public class TestViewModel
        {
            public string Message { get; set; }
        }
        
        [HttpGet("View")]
        public IActionResult GetView()
        {
            return View("TestView", new TestViewModel
            {
                Message = "Rendering this partial from a view!"
            });
        }
        
        [HttpGet("Json")]
        public IActionResult Json()
        {
            return Json(new
            {
                Test = "Hello World!"
            });
        }
        
        [HttpGet("Partial")]
        public IActionResult GetPartial()
        {
            return PartialView("TestPartial", "Rendering this partial as-is!");
        }
    }
}