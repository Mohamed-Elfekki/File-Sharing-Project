using AutoMapper;
using AutoMapper.QueryableExtensions;
using FileSharingProject.Areas.Admin.Models;
using FileSharingProject.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FileSharingProject.Areas.Admin.Services
{
    public class ContactUsService : IContactUsService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ContactUsService(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task ChangeStatusAsync(int id, bool status)
        {
            var selectedItem = await context.Contacts.FindAsync(id);
            if (selectedItem != null)
            {
                selectedItem.IsClosed = status;
                context.Update(selectedItem);
                await context.SaveChangesAsync();
            }
        }

        public IQueryable<ContactUsViewModel> GetAll()
        {
            var result = context.Contacts
                .ProjectTo<ContactUsViewModel>(mapper.ConfigurationProvider);
            return result;
        }
    }
}
