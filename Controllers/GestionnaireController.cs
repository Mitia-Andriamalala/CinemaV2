using Microsoft.AspNetCore.Mvc;
using GestionCinema.Models;
using GestionCinema.Services;
using Cinema.Services.FonctionPage;

namespace Cinema.Controllers
{
    public class GestionnaireController : Controller
    {
        GestionPage gestionPage=new GestionPage();
        DiffusionPage diffusionPage=new DiffusionPage();
        [HttpGet]
        public IActionResult AccueilAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveSalle(string salle,TimeSpan ouvre,TimeSpan ferme)
        {
            gestionPage.setSalle(salle,ouvre,ferme);
            return RedirectToAction("Gestion", "Admin");
        }

        [HttpGet]
        public IActionResult PlaceSalle()
        {
            var listeSalle = diffusionPage.getSalle();
            return View("~/Views/Admin/PlaceSalle.cshtml", listeSalle);

        }


        [HttpPost]
        public IActionResult InsertPlaceSalle(string salle,string col,int nbLine,int nbPl)
        {
            gestionPage.setPlaceSalle(salle,col,nbLine,nbPl);
            return RedirectToAction("PlaceSalle");
        }

        
    }
}
