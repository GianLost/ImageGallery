using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace ImageGallery.Services
{
    // Aqui são Implementadas as funcionalidades das assinaturas dos métodos da interface...

    public class FileProcessorService : IFileProcessor
    {
        // Aqui temos a assinatura será responsável por fazer de fato o Upload da imagem, mas se tratando de arquivos devemos ter em mente qual o formato de arquivo que estamos lidando, e que no nosso caso são imagens. Antes de fazermos o upload de fato do arquivo precisamos redimensioná-lo, e salvá-lo em algum formato compatível de arquivos de imagem, neste exemplo usaremos o formato .webp, ou seja, precisamos receber uma imagem de um usuário, tratála para que seja redimensionada e que seja atribuído à ela um novo nome que contenha a extensão (formato) válido para o tipo de arquivo (Imagem) antes de fazermos o upload de fato. 

        private async Task<bool> SaveImageAsWebpAsync(string imageFilePath, MemoryStream memoryStream, bool checksIfTheImageIsSquare)
        {
            // aqui passamos por parâmetro nosso caminho do arquivo de imagem, um objeto de fluxo de memória MemoryStream que será encarregado de tratar o fluxo de bytes do nosso arquivo utilizando a memória para recuperar propriedades da imagem, e por fim um parâmetro booleano que corresponde a verificação do nosso método de upload. A verificação nada mais é do que checkar se a imagem é quadrada, ou seja se possui ambos os parâmetros altura e largura iguais.

            var img = await Image.LoadAsync(memoryStream); // Atríbuindo um MemoryStream à variável img para acessarmos propriedades do objeto de imagem que será carregado.

            var imageFileExtension = imageFilePath.Substring(imageFilePath.LastIndexOf('.')).ToLower(); // Formatando nossa string do caminho de Imagem para receber o novo nome e extensão do arquivo.

            if (checksIfTheImageIsSquare) // Aqui partimos para o redimensionamento da imagem. Para verificarmos se a condição de que se a imagem é quadrada utilizamos a compração entre altura e largura.
            {
                var imageSize = img.Size(); // Obtendo o tamanho total do nosso arquivo de imagem.
                var smallerSide = (imageSize.Height < imageSize.Width) ? imageSize.Height : imageSize.Width; // Atribuindo uma condicional que verifica se a altura é maior que a largura, e obtem o menor lado.

                img.Mutate(x => x.Resize(new ResizeOptions
                // Para processarmos nossa imagem utilizamos aqui dois recursos de ResizeOptions 
                {
                    Size = new Size(smallerSide, smallerSide), // uma novo tamanho recebendo como parâmetro a altura e largura desejada, onde aqui passamos o menor lado em ambos já que queremos uma imagem quadrada com base nas medidas do seu menor lado.

                    Mode = ResizeMode.Crop // Modo de redimensionamento Crop, corta uma imagem para aplicar o redimensionamento à ela.
                }
                ).BackgroundColor(new Rgba32(255, 255, 255, 0)));
            }

            imageFilePath = imageFilePath.Replace(imageFileExtension, ".webp"); // Esse será o formato que nosso arquivo será salvo em nosso diretório do projeto após o upload, aqui aplicamos o Replace() para reformar nosso caminho do arquivo de imagem com base na nossa nova extensão que será aplicada aos arquvos que serão salvos.

            await img.SaveAsWebpAsync(imageFilePath); // Finalmente salvamos a imagem no formato webp através do método SaveAsWebpAsync() que passado pelo objeto MemoryStream e que recebe nosso novo caminho de imagem já com a nova extensão do arquivo 

            return true;
        }

        public async Task<bool> ImageUploadAsync(string imageFilePath, IFormFile image)
        {
            // Aqui então de fato fazemos nosso upload e salvamos nossa imagem. Recebendo por parâmetro nosso caminho do arquivo, e o arquivo em si que é representado pelo objeto de IFormFile que recebe arquivos enviados via requisições de um formulário formulário que contenha um enctype="multipart/fotm-data". 

            if (image is null)
            // De início verifique se o arquivo é nulo pois caso satisfaça essa condição sabemos que nenhum arquivo foi carreagado e podemos então retornar falso
            {
                return false;
            }

            var memoryStream = new MemoryStream(); // Obtendo objeto MemoryStream para manipular o fluxo de dados.

            await image.CopyToAsync(memoryStream); // Copiando o conteúdo do arquivo de upload de forma assíncrona e passando nossa variável de controle de fluxo para o carregamento.

            memoryStream.Position = 0; // setando a posição do fluxo em zero.

            return await SaveImageAsWebpAsync(imageFilePath, memoryStream, true); // Retorno o método que salva nossas imagens como webp e passo os parâmetros referentes ao caminho do nosso arquivo, o objeto do controle de fluxo MemoryStream, e a validação da nossa condicional que é um parâmetro utilizado para o redimensionamento da imagem.
        }

        public async Task<bool> ImageDeleteAsync(string imageFilePath)
        {
            if (File.Exists(imageFilePath)) // Ao ser invocado verifica a rota da imgem se existe um arquivo como solicitado
            {
                try
                {
                    File.Delete(imageFilePath); // Exclui a imagem e retorna verdadeiro, caso não exista um arquivo correspondente cai como uma excessão retornando falso.
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
            // Para aplicarmos os efeitos nas nossa imagens precisamos primeiro de um objeto de FileStream que atribuirá ao qual será atribído as ações de manipulação dos nossos arquivos de imagem.

            var fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read); // atribuindo uma variável FileStream que recebe o caminho do arquivo de imagem e que abre uma execução que possibilita a leitura de arquivos.

            var img = await Image.LoadAsync(fileStream); // variável img sendo atribuída com o valor da Classe Image do pacote do SixLabors que permite o carregamento assíncrono do arquivo recebido .

            fileStream.Close(); // fechamento da execução do nosso FileStream após a leitura e carregamento do arquivo de imagem.

            switch (effect)
            {
                // Estrutura de repetição switch para atribuir os efeitos a serem aplicados na imagem. Para cada efeito precisamos de um método que através de recursos do SixLabors irá aplicar o respectivo efeito ao caso selecionado.

                case ImageEffects.FlipHorizontallyEffect: // A estrutura aqui é bem simples,para ca caso passamos apenas nosso atributo a ser preenchido que é de referência da nossa Classe de serviços ImageEffects, e logo abaixo invocamos o método que irá aplicar o efeito à imagem, passando como parâmetro nosso arquivo de imagem caregado.
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

            await img.SaveAsync(imageFilePath); // Ao selecionar o efeito salvamos a edição através de SaveAsync(), utilize await para suspender a avaliação do método caso não seja concluída.

            return true;
        }

        /*START*/

        // Métodos que aplicam os efeitos às imagens

        //Aqui mais uma vez a lógica é bem simples, para cada efeito utilizamos um dos recursos do SixLabors que é chamado através de uma Arrow Function.
        private void FlipHorizontally(Image img) // recebe como parâmetro um objeto de Image do ImageSharp
        {
            img.Mutate(x => x.Flip(FlipMode.Horizontal)); // Passa o efeito para o objeto img. neste exemplo o efeito de inverter a imagem na horizontal.
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
        /*END*/

    }
}