using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace ImageGallery.Services
{
    public class FileProcessorService : IFileProcessor
    {
        public async Task<bool> ImageDeleteAsync(string imageFilePath)
        {
            if (File.Exists(imageFilePath))
            {
                try
                {
                    File.Delete(imageFilePath);
                    return true;

                }
                catch (IOException)
                {
                    return await Task.FromResult(false);
                }
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> ImageEffectsAsync(string imageFilePath, ImageEffects effect)
        {
            var fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
            var img = await Image.LoadAsync(fileStream);
            fileStream.Close();

            switch (effect)
            {
                case ImageEffects.FlipHorizontallyEffect:
                    FlipHorizontally(img);
                    break;
                case ImageEffects.FlipVerticallyEffect:
                    FlipVertically(img);
                    break;
                case ImageEffects.GaussianBlurEffect:
                    GaussianBlur(img);
                    break;
                case ImageEffects.GreyScaleEffect:
                    GreyScale(img);
                    break;
                case ImageEffects.NegativeEffect:
                    Negative(img);
                    break;
                case ImageEffects.RotateLeftEffect:
                    RotateLeft(img);
                    break;
                case ImageEffects.RotateRightEffect:
                    RotateRight(img);
                    break;
                case ImageEffects.SepiaEffect:
                    Sepia(img);
                    break;
            }

            await img.SaveAsync(imageFilePath);

            return true;
        }

        private void FlipHorizontally(Image img)
        {
            img.Mutate(x => x.Flip(FlipMode.Horizontal));
        }

        private void FlipVertically(Image img)
        {
            img.Mutate(x => x.Flip(FlipMode.Vertical));
        }

        private void GaussianBlur(Image img)
        {
            img.Mutate(x => x.GaussianBlur());
        }

        private void GreyScale(Image img)
        {
            img.Mutate(x => x.Grayscale());
        }

        private void Negative(Image img)
        {
            img.Mutate(x => x.Invert());
        }

        private void RotateLeft(Image img)
        {
            img.Mutate(x => x.Rotate(-90));
        }

        private void RotateRight(Image img)
        {
            img.Mutate(x => x.Rotate(90));
        }

        private void Sepia(Image img)
        {
            img.Mutate(x => x.Sepia());
        }

        public async Task<bool> ImageUploadAsync(string imageFilePath, IFormFile image)
        {
            if (image is null)
            {
                return false;
            }

            var memoryStream = new MemoryStream();
            await image.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            return await SaveImageAsWebpAsync(imageFilePath, memoryStream, true);
        }

        private async Task<bool> SaveImageAsWebpAsync(string imageFilePath, MemoryStream memoryStream, bool checksIfTheImageIsSquare)
        {
            var img = await Image.LoadAsync(memoryStream);
            var imageFileExtension = imageFilePath.Substring(imageFilePath.LastIndexOf('.')).ToLower();

            if (checksIfTheImageIsSquare)
            {
                var imageSize = img.Size();
                var smallerSide = (imageSize.Height < imageSize.Width) ? imageSize.Height : imageSize.Width;

                img.Mutate(x => x.Resize(new ResizeOptions
                {
                    Size = new Size(smallerSide, smallerSide),
                    Mode = ResizeMode.Crop
                }
                ).BackgroundColor(new Rgba32(255, 255, 255, 0)));
            }

            imageFilePath = imageFilePath.Replace(imageFileExtension, ".webp");

            await img.SaveAsWebpAsync(imageFilePath);

            return true;
        }
    }
}