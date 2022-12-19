using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace ImageGallery.Models
{
    public class Image
    {
        [Key]
        public int IdImage { get; set; } // Chave primária da tabela imagens

        [Required]
        [Display(Name = "Image Title")]
        public string ImageTitle { get; set; } // título da imagem

        public int IdGallery { get; set; } // Id da galeria que armazena a imagem para recuperarmos a galeria com seu conteúdo

        [ForeignKey("IdGallery")]
        public Gallery Gallery { get; set; } // objeto galeria que será nossa chave estrangeira para o relacionamento de tabelas.

        [NotMapped, Required(ErrorMessage = "A imagem não pôde ser enviada")]
        [Display(Name = "Image File")]
        public IFormFile ImageFile { get; set; } // o arquivo de imagem não será mapeado em nossas migrações para o banco de dados uma vez que utilizaremos o sistema de carregamento de arquivos em stream para recuperarmos os arquivos da memória não precisamos salvar o arquivo em si no nosso banco para fins de melhoria de permorfarmance se tratando do banco de dados, para isso salvamos apenas o seu diretório original, e demais propriedades para que possamos recuperar o arquivo em memória apenas pela sua rota na aplicação.
        
        public string imagePath
        {
            // Como foi dito utilizamos a rota em que foi salvo nosso arquivo para que possamos recuperá-lo em Stream, e esta propriedade obtém justamente isso, a rota completa do nosso arquivo junto ao seu nome + extensão do arquivo, ou seja, o caminho completo para acessá-lo em nosso projeto. Com isso obtemos através do nosso get a combinação do diretório onde se encontra o arquivo (Pasta onde serão feitos os uploads) + o nome do arquivo presente (img.webp)
            get
            {
                var imageFilePath = Path.Combine($"\\Images\\", IdImage.ToString("D6") + ".webp");

                return imageFilePath; // E por fim retornamos a rota obtida para acessarmos o arquivo.
            }
        }
    }
}