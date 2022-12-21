using System.ComponentModel.DataAnnotations;

namespace FileSharingProject.Areas.Admin.Models
{
    public class InputSearch
    {
        [MinLength(3)]
        [Required]
        public string Term { get; set; }
    }
}
