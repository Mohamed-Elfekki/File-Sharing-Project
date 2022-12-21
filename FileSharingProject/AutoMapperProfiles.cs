using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FileSharingProject
{
    public class UploadProfile : Profile
    {
        public UploadProfile()
        {
            CreateMap<Models.InputUpload, Data.Uploads>()
                .ForMember(u => u.Id, op => op.Ignore())
                .ForMember(u => u.UploadDate, op => op.Ignore());
            CreateMap<Data.Uploads, Models.UploadViewModel>();
        }
    }

    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<Data.ApplicationUser, Models.UserViewModel>()
                .ForMember(u => u.HasPassword, op => op.MapFrom(u => u.PasswordHash != null));

            CreateMap<Data.ApplicationUser, Areas.Admin.Models.AdminUserViewModel>()
                .ForMember(u => u.UserId, op => op.MapFrom(u => u.Id));

        }

    }



    public class ContactUsProfile : Profile
    {

        public ContactUsProfile()
        {
            CreateMap<Data.Contact, Areas.Admin.Models.ContactUsViewModel>();
        }

    }

}
