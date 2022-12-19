using System.IO;
using System.Linq;
using ImageGallery.DataBase;
using ImageGallery.Models;
using ImageGallery.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ImageGallery.Controllers
{
    public class ImageController : Controller
    {
        private readonly IWebHostEnvironment env;
        private readonly IFileProcessor fp;
        private readonly ILogger<ImageController> _logger;

        public ImageController(IWebHostEnvironment enviroment, IFileProcessor fileProcessor, ILogger<ImageController> logger)
        {
            this.env = enviroment;
            this.fp = fileProcessor;
            _logger = logger;
        }

        public IActionResult Index(int? id)
        {
            using (GalleryContext dataBase = new GalleryContext())
            {
                if (id == null)
                {
                    return NotFound();
                }

                var gallery = dataBase.Galerias.Find(id);

                if (gallery == null)
                {
                    return NotFound();
                }

                dataBase.Entry(gallery).Collection(g => g.Images).Load();
                ViewBag.IdGallery = id.Value;
                ViewBag.GalleryTitle = gallery.Title;

                return View(gallery.Images.ToList());
            }

        }

        public IActionResult Register(int? id)
        {
            using (GalleryContext dataBase = new GalleryContext())
            {
                if (id == null)
                {
                    return NotFound();
                }

                var gallery = dataBase.Galerias.Find(id);

                if (gallery == null)
                {
                    return NotFound();
                }
                var newImage = new Image() { IdGallery = gallery.IdGallery };

                return View(newImage);
            }

        }

        private string GetImageFilePath(string imageFolder, int idImage, string extension)
        {
            string imageFolderPath = env.WebRootPath + imageFolder;
            var fileName = $"{idImage:D6}{extension}";

            var imageFilePath = Path.Combine(imageFolderPath, fileName);

            return imageFilePath;
        }

        [HttpPost]
        public IActionResult Register(Image image)
        {
            using (GalleryContext dataBase = new GalleryContext())
            {

                if (ModelState.IsValid)
                {
                    dataBase.Imagens.Add(image);
                    if (dataBase.SaveChanges() > 0)
                    {
                        string imageFilePath = GetImageFilePath("\\Images\\", image.IdImage, ".webp");
                        fp.ImageUploadAsync(imageFilePath, image.ImageFile).Wait();

                        return RedirectToAction("Index", "Image", new { id = image.IdGallery });
                    }

                }
                return View(image);

            }
        }

        public IActionResult Update(int? id)
        {
            using (GalleryContext dataBase = new GalleryContext())
            {

                if (id == null)
                {
                    return NotFound();
                }
                var image = dataBase.Imagens.Find(id);
                if (image == null)
                {
                    return NotFound();
                }

                return View(image);
            }
        }

        [HttpPost]
        public IActionResult Update(Image image)
        {

            using (GalleryContext dataBase = new GalleryContext())
            {
                ModelState.Remove("ImageFile");

                if (ModelState.IsValid)
                {
                    dataBase.Entry(image).State = EntityState.Modified;
                    if (dataBase.SaveChanges() > 0)
                    {
                        if (image.ImageFile != null)
                        {
                            string imageFilePath = GetImageFilePath("\\Images\\", image.IdImage, ".webp");

                            fp.ImageUploadAsync(imageFilePath, image.ImageFile).Wait();
                        }
                    }
                    return RedirectToAction("Index", new { id = image.IdGallery });
                }
                return View(image);
            }
        }

        public IActionResult Delete(int? id)
        {

            using (GalleryContext dataBase = new GalleryContext())
            {
                if (id == null)
                {
                    return NotFound();
                }
                var image = dataBase.Imagens.Find(id);
                if (image == null)
                {
                    return NotFound();
                }

                return View(image);
            }
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public IActionResult DeleteImage(int id)
        {

            using (GalleryContext dataBase = new GalleryContext())
            {

                var image = dataBase.Imagens.Find(id);
                dataBase.Imagens.Remove(image);
                if (dataBase.SaveChanges() > 0)
                {
                    string imageFilePath = GetImageFilePath("\\Images\\", image.IdImage, ".webp");

                    fp.ImageUploadAsync(imageFilePath, image.ImageFile).Wait();

                }
                return RedirectToAction("Index", "Image", new { id = image.IdGallery });

            }

        }

        [HttpGet]
        public IActionResult ApplyEffects(int? id)
        {

            using (GalleryContext dataBase = new GalleryContext())
            {
                if (id == null)
                {
                    return NotFound();
                }
                var image = dataBase.Imagens.Find(id);
                if (image == null)
                {
                    return NotFound();
                }

                return View("ApplyEffects", image);
            }
        }

        [HttpPost]
        public IActionResult ApplyEffects(int id, string effects)
        {
            
            string imageFilePath = GetImageFilePath("\\Images\\", id, ".webp");

            switch (effects)
            {
                case "rr":
                    fp.ImageEffectsAsync(imageFilePath, ImageEffects.RotateRightEffect).Wait();
                    break;

                case "rl":
                    fp.ImageEffectsAsync(imageFilePath, ImageEffects.RotateLeftEffect).Wait();
                    break;

                case "ih":
                    fp.ImageEffectsAsync(imageFilePath, ImageEffects.FlipHorizontallyEffect).Wait();
                    break;

                case "iv":
                    fp.ImageEffectsAsync(imageFilePath, ImageEffects.FlipVerticallyEffect).Wait();
                    break;

                case "gs":
                    fp.ImageEffectsAsync(imageFilePath, ImageEffects.GreyScaleEffect).Wait();
                    break;

                case "sp":
                    fp.ImageEffectsAsync(imageFilePath, ImageEffects.SepiaEffect).Wait();
                    break;

                case "ng":
                    fp.ImageEffectsAsync(imageFilePath, ImageEffects.NegativeEffect).Wait();
                    break;

                case "df":
                    fp.ImageEffectsAsync(imageFilePath, ImageEffects.GaussianBlurEffect).Wait();
                    break;
            }

            return RedirectToAction("ApplyEffects", new { id = id });
        }

    }

}
