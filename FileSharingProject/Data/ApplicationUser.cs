using Microsoft.AspNetCore.Identity;
using System;

namespace FileSharingProject.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
