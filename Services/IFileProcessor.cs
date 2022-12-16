using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

// Interface de manipulação de images a serem obtidas por upload de arquivos

namespace ImageGallery.Services
{
    public interface IFileProcessor
    {
        Task<bool> ImageUploadAsync(string imageFilePath, IFormFile image); //A tarefa ImageUploadAsync() salva no servidor uma imagem que tenha sido enviada pelo usuário através de um formulário. Recebe por parâmetro uma string que representa o caminho do arquivo de imagem que será salvo e um objeto do Tipo IFormFile que será o arquivo de imagem propriamente dito recebido através de um formulário que passe por sua vez um enctype="multipart/form" e faz sua requisição via POST.

        Task<bool> ImageDeleteAsync(string imageFilePath); //A Tarefa ImageDeleteAsync() Exclui um arquivo de imagem armazenado no servidor e apenas o caminho do arquivo de imagem precisa ser dado como parâmetro.

        Task<bool> ImageEffectsAsync(string imageFilePath, ImageEffects effect); //A Tarefa ImageEffectsAsync() recebe o caminho do arquivo de imagem como parâmetro e um objeto do serviço enumerado ImageEffects que será responsável por aplicar os efeitos que utilizaremos nas imagens.
    }
}