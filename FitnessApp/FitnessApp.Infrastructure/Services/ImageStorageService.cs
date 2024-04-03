using System;
using FitnessApp.Contracts.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace FitnessApp.Infrastructure.Services
{
	public class ImageStorageService:IImageStorageService
	{
        public const string IMAGEFOLDER = "StaticFiles/";

        public async Task<string> SaveFileAsync(IFormFile file, string fileName)
        {
            var filePath = Path.Combine(IMAGEFOLDER, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return filePath;
        }
    }
}