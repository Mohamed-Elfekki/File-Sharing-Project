using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace FileSharingProject.Models
{
    public class InputFile
    {
        [Required]
        public IFormFile File { get; set; }


    }



    public class InputUpload
    {
        public string OriginalFileName { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public long Size { get; set; }
        public string UserId { get; set; }

    }




    public class UploadViewModel
    {
        [Display(Name = "Original File Name")]
        public string OriginalFileName { get; set; }
        [Display(Name = "File Name")]
        public string FileName { get; set; }
        public decimal Size { get; set; }
        [Display(Name = "Content Type")]
        public string ContentType { get; set; }
        [Display(Name = "Upload Date")]
        public DateTime UploadDate { get; set; }
        public string Id { get; set; }
        [Display(Name = "Download Count")]
        public long DownloadCount { get; set; }
    }
}
