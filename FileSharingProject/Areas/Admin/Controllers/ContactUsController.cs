using FileSharingProject.Areas.Admin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FileSharingProject.Areas.Admin.Controllers
{
    public class ContactUsController : AdminBaseController
    {
        private readonly IContactUsService contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            this.contactUsService = contactUsService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await contactUsService.GetAll()
                .ToListAsync();

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int id, bool isClosed)
        {
            await contactUsService.ChangeStatusAsync(id, isClosed);
            return RedirectToAction("Index");
        }


    }
}
