using Microsoft.AspNetCore.Identity;
using System;

namespace FileSharingProject.Data
{
    public class Uploads
    {
        public Uploads()
        {
            //Made ID Not Repeatable!
            Id = Guid.NewGuid().ToString();

            UploadDate = DateTime.Now;
        }

        public string Id { get; set; }

        public string OriginalFileName { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public decimal Size { get; set; }
        public string UserId { get; set; }

        public DateTime UploadDate { get; set; }

        public long DownloadCount { get; set; }


        //bind user table with uploads table
        public ApplicationUser User { get; set; }
    }
}
