using FileSharingProject.Areas.Admin.Models;
using System.Linq;
using System.Threading.Tasks;

namespace FileSharingProject.Areas.Admin.Services
{
    public interface IUserService
    {

        IQueryable<AdminUserViewModel> GetAll();
        IQueryable<AdminUserViewModel> GetBlockedUsers();
        IQueryable<AdminUserViewModel> Search(string term);

        Task<OperationResult> ToggleBlockUserAsync(string userId);
        Task<int> UserRegistrationCountAsync();
        Task<int> UserRegistrationCountAsync(int month);

        Task IntializeAsync();

    }
}
