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

                    var gallery = dataBase.Galerias.AsNoTracking().ToList();
                    
                    return View(gallery);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao Exibir Galeria de Imagem !" + e.Message);
                return RedirectToAction("Index", "Home");
            }

        }

        public IActionResult Register()
        {
            try
            {

                return View();

            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao exibir página de cadastro Galeria de Imagem !" + e.Message);
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public IActionResult Register(Gallery gallery)
        {
            try
            {

                using (GalleryContext dataBase = new GalleryContext())
                {
                    if (ModelState.IsValid)
                    {
                        dataBase.Galerias.Add(gallery);
                        dataBase.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    return View(gallery);
                }

            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao cadastrar Galeria de Imagem !" + e.Message);
                return RedirectToAction("Index", "Home");
            }

        }

        public IActionResult Upgrade(int? id)
        {
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
                _logger.LogError("Erro ao exibir view de Edição de Galeria de Imagem !" + e.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Upgrade(Gallery gallery)
        {
            try
            {
                using (GalleryContext dataBase = new GalleryContext())
                {

                    if (ModelState.IsValid)
                    {
                        dataBase.Entry(gallery).State = EntityState.Modified;
                        dataBase.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    return View(gallery);
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
        [ActionName("Delete")]
        public IActionResult DeleteGallery(int? id)
        {
            try
            {
                using (GalleryContext dataBase = new GalleryContext())
                {

                    var gallery = dataBase.Galerias.Find(id);

                    if (gallery == null)
                    {
                        return NotFound();
                    }

                    dataBase.Galerias.Remove(gallery);
                    dataBase.SaveChanges();
                    return RedirectToAction("Index");

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