using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileSharingProject.Data
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public bool IsClosed { get; set; }
        public DateTime SentDate { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }


        public virtual ApplicationUser User { get; set; }

    }
}
