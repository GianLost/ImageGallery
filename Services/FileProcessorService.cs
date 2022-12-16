using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace ImageGallery.Services
{
    public class FileProcessorService : IFileProcessor
    {
        public Task<bool> ImageDeleteAsync(string imageFilePath)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ImageEffectsAsync(string imageFilePath, ImageEffects effect)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ImageUploadAsync(string imageFilePath, IFormFile image)
        {
            throw new System.NotImplementedException();
        }
    }
}