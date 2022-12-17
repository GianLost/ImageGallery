using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImageGallery.Models
{
    public class Gallery{

        [Key]
        public int IdGallery { get; set; }
        
        [Required]
        [Display(Name = "Gallery Title")]
        public string Title { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}