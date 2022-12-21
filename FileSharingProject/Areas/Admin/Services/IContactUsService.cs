using FileSharingProject.Areas.Admin.Models;
using System.Linq;
using System.Threading.Tasks;

namespace FileSharingProject.Areas.Admin.Services
{
    public interface IContactUsService
    {
        IQueryable<ContactUsViewModel> GetAll();

        Task ChangeStatusAsync(int id, bool status);
    }
}
