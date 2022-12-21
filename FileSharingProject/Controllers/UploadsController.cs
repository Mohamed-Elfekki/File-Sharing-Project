using FileSharingProject.Data;
using FileSharingProject.Models;
using FileSharingProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FileSharingProject.Controllers
{
    [Authorize]
    public class UploadsController : Controller
    {
        private readonly IUploadService uploadService;
        private readonly IWebHostEnvironment env;

        public UploadsController(IUploadService uploadService, IWebHostEnvironment env)
        {
            this.uploadService = uploadService;
            this.env = env;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Results(string term, int requiredPage = 1)
        {
            var result = uploadService.Search(term);
            var model = await GetPagedData(result, requiredPage);
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Browse(int requiredPage = 1)
        {

            var result = uploadService.GetAll();
            var model = await GetPagedData(result, requiredPage);

            return View(model);
        }


        private async Task<List<UploadViewModel>> GetPagedData(IQueryable<UploadViewModel> result, int requiredPage = 1)
        {
            const int pageSize = 2;
            decimal rowsCount = await uploadService.GetUploadsCount();

            var pagesCount = Math.Ceiling(rowsCount / pageSize);


            if (requiredPage > pagesCount)
            {
                requiredPage = 1;
            }

            requiredPage = requiredPage <= 0 ? 1 : requiredPage;

            int skipCount = (requiredPage - 1) * pageSize;

            //select count(*) from Uploads;


            var pagedData = await result
                .Skip(skipCount)
                .Take(pageSize)
                    .ToListAsync();
            ViewBag.CurrentPage = requiredPage;
            ViewBag.PagesCount = pagesCount;
            return pagedData;
        }



        public IActionResult Index()
        {
            var result = uploadService.GetBy(UserId);
            return View(result);
        }

        private string UserId
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(InputFile model)
        {
            if (ModelState.IsValid)
            {
                var newName = Guid.NewGuid().ToString();
                var extention = Path.GetExtension(model.File.FileName);
                var fileName = string.Concat(newName, extention);
                var root = env.WebRootPath;
                var path = Path.Combine(root, "Uploads", fileName);

                using (var fs = System.IO.File.Create(path))
                {
                    await model.File.CopyToAsync(fs);

                }

                await uploadService.CreateAsync(new InputUpload
                {
                    OriginalFileName = model.File.FileName,
                    FileName = fileName,
                    ContentType = model.File.ContentType,
                    Size = model.File.Length,
                    UserId = UserId,
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var selectedUpload = await uploadService.FindAsync(id, UserId);

            if (selectedUpload == null)
            {
                return NotFound();
            }
            return View(selectedUpload);
        }


        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmation(string id)
        {
            var selectedUpload = await uploadService.FindAsync(id, UserId);

            if (selectedUpload == null)
            {
                return NotFound();
            }
            //tools->postman, fiddler, httpclient >> for sending request
            await uploadService.DeleteAsync(id, UserId);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Download(string id)
        {
            var selectedFile = await uploadService.FindAsync(id);
            if (selectedFile == null)
            {
                return NotFound();
            }

            await uploadService.IncreamentDownloadCount(id);

            var path = "~/Uploads/" + selectedFile.FileName;

            Response.Headers.Add("Expires", DateTime.Now.AddDays(-3).ToLongDateString());
            Response.Headers.Add("Cache-Control", "no-cache");

            return File(path, selectedFile.ContentType, selectedFile.OriginalFileName);

        }

    }


}
