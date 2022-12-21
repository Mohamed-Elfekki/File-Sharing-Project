using AutoMapper;
using AutoMapper.QueryableExtensions;
using FileSharingProject.Data;
using FileSharingProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FileSharingProject.Services
{
    public class UploadService : IUploadService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public UploadService(ApplicationDbContext context, IMapper mapper)
        {
            this._db = context;
            this._mapper = mapper;
        }



        public async Task CreateAsync(InputUpload model)
        {
            var mapperObj = _mapper.Map<Uploads>(model);
            await _db.Uploads.AddAsync(mapperObj);
            //await _db.Uploads.AddAsync(new Uploads
            //{
            //    OriginalFileName = model.OriginalFileName,
            //    FileName = model.FileName,
            //    ContentType = model.ContentType,
            //    Size = model.Size,
            //    UserId = model.UserId,
            //    UploadDate = DateTime.Now
            //});
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id, string userId)
        {
            var selectedUpload = await _db.Uploads.FirstOrDefaultAsync(u => u.Id == id && u.UserId == userId);

            if (selectedUpload != null)
            {
                _db.Uploads.Remove(selectedUpload);
                await _db.SaveChangesAsync();
            }
        }



        public async Task<UploadViewModel> FindAsync(string id, string userId)
        {
            var selectedUpload = await _db.Uploads.FirstOrDefaultAsync(u => u.Id == id && u.UserId == userId);

            if (selectedUpload != null)
            {

                //AutoMapper
                return _mapper.Map<UploadViewModel>(selectedUpload);

                //return new UploadViewModel
                //{
                //    Id = selectedUpload.Id,
                //    FileName = selectedUpload.FileName,
                //    OriginalFileName = selectedUpload.OriginalFileName,
                //    ContentType = selectedUpload.ContentType,
                //    Size = selectedUpload.Size,
                //    UploadDate = selectedUpload.UploadDate,
                //    DownloadCount = selectedUpload.DownloadCount,
                //};

            }
            return null;
        }

        public async Task<UploadViewModel> FindAsync(string id)
        {
            var selectedUpload = await _db.Uploads.FindAsync(id);

            if (selectedUpload != null)
            {
                //AutoMapper
                return _mapper.Map<UploadViewModel>(selectedUpload);


                //return new UploadViewModel
                //{
                //    Id = selectedUpload.Id,
                //    FileName = selectedUpload.FileName,
                //    OriginalFileName = selectedUpload.OriginalFileName,
                //    ContentType = selectedUpload.ContentType,
                //    Size = selectedUpload.Size,
                //    UploadDate = selectedUpload.UploadDate,
                //    DownloadCount = selectedUpload.DownloadCount,
                //};

            }
            return null;
        }

        public IQueryable<UploadViewModel> GetAll()
        {
            var result = _db.Uploads
            .OrderByDescending(u => u.DownloadCount)
            .ProjectTo<UploadViewModel>(_mapper.ConfigurationProvider);

            //.Select(u => new UploadViewModel
            //{
            //    FileName = u.FileName,
            //    OriginalFileName = u.OriginalFileName,
            //    ContentType = u.ContentType,
            //    Size = u.Size,
            //    UploadDate = u.UploadDate,
            //    DownloadCount = u.DownloadCount
            //});

            return result;

        }

        public IQueryable<UploadViewModel> GetBy(string userId)
        {
            var result = _db.Uploads.Where(u => u.UserId == userId)
                  .OrderByDescending(u => u.UploadDate)
                  .ProjectTo<UploadViewModel>(_mapper.ConfigurationProvider);
            //.Select(u => new UploadViewModel
            //{
            //    Id = u.Id,
            //    FileName = u.FileName,
            //    OriginalFileName = u.OriginalFileName,
            //    ContentType = u.ContentType,
            //    Size = u.Size,
            //    UploadDate = u.UploadDate,
            //    DownloadCount = u.DownloadCount
            //});
            return result;
        }

        public async Task<int> GetUploadsCount()
        {
            return await _db.Uploads.CountAsync();
        }

        public async Task IncreamentDownloadCount(string id)
        {
            var selectedUpload = await _db.Uploads.FindAsync(id);

            if (selectedUpload != null)
            {
                selectedUpload.DownloadCount++;

                _db.Update(selectedUpload);
                await _db.SaveChangesAsync();
            }
        }

        public IQueryable<UploadViewModel> Search(string term)
        {
            var result = _db.Uploads
                .Where(u => u.OriginalFileName.Contains(term))
                .OrderByDescending(u => u.DownloadCount)
                .ProjectTo<UploadViewModel>(_mapper.ConfigurationProvider);
            //.Select(u => new UploadViewModel
            //{
            //    Id = u.Id,
            //    FileName = u.FileName,
            //    OriginalFileName = u.OriginalFileName,
            //    ContentType = u.ContentType,
            //    Size = u.Size,
            //    UploadDate = u.UploadDate,
            //    DownloadCount = u.DownloadCount
            //});

            return result;
        }
    }
}
