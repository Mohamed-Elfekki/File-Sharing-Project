using FileSharingProject.Models;
using System;

namespace FileSharingProject.Areas.Admin.Models
{
    public class ContactUsViewModel : ContactViewModel
    {
        public int Id { get; set; }
        public bool IsClosed { get; set; }
        public DateTime SentDate { get; set; }
    }
}
