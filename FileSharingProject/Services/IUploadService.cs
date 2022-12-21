using FileSharingProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace FileSharingProject.Services
{
    public interface IUploadService
    {
        IQueryable<UploadViewModel> GetAll();
        IQueryable<UploadViewModel> GetBy(string userId);
        IQueryable<UploadViewModel> Search(string term);
        Task CreateAsync(InputUpload model);
        Task<UploadViewModel> FindAsync(string id);

        Task<UploadViewModel> FindAsync(string id, string userId);
        Task DeleteAsync(string id, string userId);

        Task IncreamentDownloadCount(string id);
        Task<int> GetUploadsCount();

    }
}
