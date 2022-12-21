using ClosedXML.Excel;
using FileSharingProject.Areas.Admin.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;

namespace FileSharingProject.Areas.Admin
{
    public static class AdminStartup
    {
        //Extention Methods
        public static IServiceCollection AddAdminServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IXLWorkbook, XLWorkbook>();

            services.AddTransient<IContactUsService, ContactUsService>();


            return services;
        }
    }
}
