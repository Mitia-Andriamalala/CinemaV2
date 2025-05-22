using Microsoft.AspNetCore.Mvc;
using GestionCinema.Models;
using GestionCinema.Services;
using Cinema.Services.FonctionPage;

namespace Cinema.Controllers
{
    public class FilmController : Controller
    {
        FilmPage filmPage=new FilmPage();

        [HttpGet]
        public IActionResult InsertFilm()
        {
            var listeCategorie=filmPage.getListeCategorie();
            var listeClassification=filmPage.getClasseFilm();
            ViewBag.CategorieList = listeCategorie;
            ViewBag.ClassificationList = listeClassification;
            return View();
        }

        [HttpGet]
        public IActionResult Film()
        {
            var listeFilm=filmPage.getInfoFilm();
            return View(listeFilm);
        }

        public IActionResult SaveFilm(string titre,string categorie,string classe,string duree,IFormFile image)
        {
            filmPage.setFilm(titre,categorie,classe,duree,image);
            return RedirectToAction("Film");
        }
        
        


        [HttpGet]
        public IActionResult Categorie()
        {
            var listeCategorie=filmPage.getListeCategorie();
            return View(listeCategorie);
        }


        public IActionResult SaveCategorie(string categorie)
        {
            filmPage.setCategorie(categorie);
            return RedirectToAction("Categorie");
        }


        [HttpGet]
        public IActionResult Classe()
        {
            var listeClassification=filmPage.getClasseFilm();
            return View(listeClassification);
        }


        public IActionResult SaveClasse(string classe)
        {
            filmPage.setClasse(classe);
            return RedirectToAction("Classe");
        }

    }
}
