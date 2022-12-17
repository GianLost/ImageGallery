using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImageGallery.Models
{
    public class Gallery
    {

        [Key]
        public int IdGallery { get; set; } // Chave primária da nossa tabela Galeria

        [Required]
        [Display(Name = "Gallery Title")]
        public string Title { get; set; } // Título

        public ICollection<Image> Images { get; set; } // Coleção de Imagens
    }
}