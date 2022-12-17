using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace ImageGallery.Models
{
    public class Image
    {
        [Key]
        public int IdImage { get; set; }

        [Required]
        [Display(Name = "Image Title")]
        public string ImageTitle { get; set; }

        public int IdGallery { get; set; }

        [ForeignKey("IdGallery")]
        public Gallery Gallery { get; set; }
        
        [NotMapped, Required(ErrorMessage = "A imagem não pôde ser enviada")]
        public IFormFile ImageFile { get; set; }

        public string imagePath
        {
            get{
                var imageFilePath = Path.Combine($"\\images\\", IdImage.ToString("D6") + ".webp");

                return imageFilePath;
            }
        }
    }
}