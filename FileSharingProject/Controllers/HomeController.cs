using FileSharingProject.Constants;
using FileSharingProject.Data;
using FileSharingProject.Helpers.Mail;
using FileSharingProject.Hubs;
using FileSharingProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FileSharingProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IMailHelper _mailHelper;
        private readonly IHubContext<NotificationHub> notificationHub;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IMailHelper mailHelper, IHubContext<NotificationHub> notificationHub, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            this._db = context;
            this._mailHelper = mailHelper;
            this.notificationHub = notificationHub;
            this.userManager = userManager;
        }

        private string UserId
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }

        public IActionResult Index()
        {
            var highestDownloads = _db.Uploads.OrderByDescending(u => u.DownloadCount)
                .Select(u => new UploadViewModel
                {
                    Id = u.Id,
                    FileName = u.FileName,
                    OriginalFileName = u.OriginalFileName,
                    ContentType = u.ContentType,
                    Size = u.Size,
                    UploadDate = u.UploadDate,
                    DownloadCount = u.DownloadCount

                })
                .Take(3);
            ViewBag.Popular = highestDownloads;

            return View();
        }

       /* public IActionResult Privacy()
        {
            return View();
        }*/

        /*public IActionResult About()
        {
            return View();
        }*/





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactViewModel model)
        {

            if (ModelState.IsValid)
            {
                //AutoMapper .
                //Save
                _db.Contacts.Add(new Data.Contact
                {
                    Email = model.Email,
                    Message = model.Message,
                    Name = model.Name,
                    Subject = model.Subject,
                    UserId = UserId
                });
                await _db.SaveChangesAsync();
                TempData["Message"] = "Message has been sent successfully";

                //Send Mail

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<h1>File Sharing - Unread Message</h1>");
                sb.AppendFormat($"Name : {model.Name}");
                sb.AppendFormat($"Email : {model.Email}");
                sb.AppendLine();
                sb.AppendFormat($"Subject : {model.Subject}");
                sb.AppendFormat($"Message :{model.Message}");


                _mailHelper.SendMail(new InputEmailMessage
                {
                    Subject = "You have unread Message",
                    Email = "info@siet.com",
                    Body = sb.ToString(),
                });

                var adminUsers = await userManager.GetUsersInRoleAsync(UserRoles.Admin);
                var adminIds = adminUsers.Select(x => x.Id);

                if (adminIds.Any())
                {
                    await notificationHub.Clients.User("")
                           .SendAsync("ReceivedNotification", "You have unread contact us message");
                }
                return RedirectToAction("Contact");
            }
            return View(model);
        }



    }
}
