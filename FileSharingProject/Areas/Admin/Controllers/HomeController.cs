using Microsoft.AspNetCore.Mvc;

namespace FileSharingProject.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
