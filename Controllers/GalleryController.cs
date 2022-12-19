using System;
using System.Linq;
using ImageGallery.DataBase;
using ImageGallery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ImageGallery.Controllers
{
    public class GalleryController : Controller
    {
        private readonly ILogger<GalleryController> _logger;

        public GalleryController(ILogger<GalleryController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                using (GalleryContext dataBase = new GalleryContext())
                {
                    // Na nossa página index de galerias teremos a listagem das galerias cadastradas e as ações de CRUD para as galerias de imagens

                    var gallery = dataBase.Galerias.AsNoTracking().ToList(); // Atribuíndo uma consulta que irá retornar uma listagem da tabela percorrida sem que os resultados sejam rastreados pelo contexto

                    return View(gallery); // retornando a consulta
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao Exibir Lista de Galerias !" + e.Message);
                return RedirectToAction("Index", "Home");
            }

        }

        public IActionResult Register()
        {
            try
            {
                return View(); // retorna a view de cadastro de galerias
            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao exibir página de cadastro Galeria de Imagem !" + e.Message);
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public IActionResult Register(Gallery gallery) // recebe por parãmetro um objeto de galeria
        {
            // A página de cadastro de galerias é chamada em um componente modal e receberá um formulário que será validado. Após o sucesso na validação serão persistidos e salvos os dados no contexto do banco de dados.

            try
            {

                using (GalleryContext dataBase = new GalleryContext())
                {
                    if (ModelState.IsValid) // Verifica o estado e valida a model
                    {
                        dataBase.Galerias.Add(gallery); // adiciono o objeto galeria ao contexto
                        dataBase.SaveChanges(); // Salva no contexto
                        return RedirectToAction("Index");
                    }

                    return View(gallery); // retorna uma vizualização incrementada com o objeto.
                }

            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao cadastrar Galeria de Imagem !" + e.Message);
                return RedirectToAction("Index", "Home");
            }

        }

        public IActionResult Upgrade(int? id) // recebe um id por parâmetro que não poderá ser nullo.
        {
            // A página de atualização de galerias é chamada em um componente modal. A view de atualização de galeria precisa receber o id da galeria a ser editada para que possa ser retornada, para isso criamos validações que caso recebam um valor nullo irão retornar um erro de não encontrado 404/405

            try
            {
                using (GalleryContext dataBase = new GalleryContext())
                {

                    if (id == null) // verifica se o id é nullo, se for nulo retorna NotFound()
                    {
                        return NotFound();
                    }

                    var gallery = dataBase.Galerias.Find(id); // Consulta na tabela de galerias que busca pelo id e retorna galerias cadastradas

                    if (gallery == null) // Valida se existem galerias, se a validação for nullo retorna NotFoun()
                    {
                        return NotFound();
                    }

                    return View(gallery); // retorna uma vizualização incrementada com o objeto galeria a ser editado.
                }

            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao exibir view de Edição de Galeria de Imagem !" + e.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Upgrade(Gallery gallery)
        {
            // A requisição para edição de galeria recebe por parãmetro um objeto galeria que será retornado caso a validação da model seja feita com sucesso.
            try
            {
                using (GalleryContext dataBase = new GalleryContext())
                {

                    if (ModelState.IsValid) // Verifica o estado e valida a Model 
                    {
                        dataBase.Entry(gallery).State = EntityState.Modified; // Realiza a alteração no campo editado alterando seu estado.
                        dataBase.SaveChanges(); // salva as alterações no contexto do banco de dados
                        return RedirectToAction("Index"); // redireciona para index de galeria
                    }

                    return View(gallery);// retorna uma vizualização incrementada com o objeto galeria editado.
                }

            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao editar Galeria de Imagem !" + e.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Delete(int? id)
        {
            // A página de exclusão de galerias é chamada em um componente modal. A view de Exclusão de galeria precisa receber o id da galeria a ser excluida para que possa ser retornada, para isso criamos validações que caso recebam um valor nullo irão retornar um erro de não encontrado 404/405. Aqui temos o controle de rotas bem similar ao da edição de galerias onde primeiro validamos o id e a galaria a ser excluída para verificar se o valor passado não é nulo, caso a condição retorne um valor nullo será exibido o retorno de que não foi encontrado um objeto para ser excluído, se for localizado o objeto retornamos a exibição da view no seu modal.
            try
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

                    return View(gallery);
                }

            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao exibir view de exclusão de Galeria de Imagem !" + e.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Delete(string decision, Gallery galleryObject)
        {
            // A requisição para exclusão de galeria recebe por parãmetro um objeto galeria e uma string que representa a decisão da nossa estrutura de repetição para verificarmos se o usuário decidiu excluir ou não a galeria. O retorno será com base no valor da decisão.
            try
            {
                using (GalleryContext dataBase = new GalleryContext())
                {
                    // Criamos uma estrutura que verifica qual a opção selecionada pelo usuário, que caso seja a opção deletar, excluímos a galeria e salvamos as alterações no nosso banco de dados. se a opção escolhida for cancelar apenas redirecionamos o usuário para a página inicial de galerias.

                    switch (decision)
                    {
                        case "delete":

                            if (galleryObject.IdGallery != 0)
                            {
                                // verifica se o id da galeria não é 0 para então remover a galeria selecionda

                                dataBase.Galerias.Remove(galleryObject);
                                dataBase.SaveChanges();
                                return RedirectToAction("Index", "Gallery");

                            }

                            break;

                        case "cancel":

                            if (galleryObject.IdGallery != 0)
                            {
                                return RedirectToAction("Index", "Gallery"); // Retorna o usuário para página inicial de galerias caso opte por não excluir a galeria.
                            }

                            break;
                    }

                    return View(galleryObject);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao excluir Galeria de Imagem !" + e.Message);
                return RedirectToAction("Index", "Home");
            }
        }

    }
}