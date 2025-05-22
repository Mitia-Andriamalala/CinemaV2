using Microsoft.AspNetCore.Mvc;
using GestionCinema.Models;
using GestionCinema.Services;
using Cinema.Services.FonctionPage;
using Newtonsoft.Json;


namespace Cinema.Controllers
{
    public class DiffusionController : Controller
    {
        DiffusionPage diff=new DiffusionPage();

        [HttpGet]
        public IActionResult diffusion()
        {
            var listeSalle=diff.getSalle();
            var listeFilm=diff.getListeFilm();
            ViewBag.SalleList = listeSalle;
            ViewBag.FilmList = listeFilm;
            return View();
        }


        [HttpGet]
        public IActionResult ListeDiffusion()
        {
            var listeDiffusionFilm=diff.getListeDiffFilm();
            return View(listeDiffusionFilm);
        }
        

        [HttpPost]
        public IActionResult saveDiffusion(string salle, string film,double prix ,DateTime plageDebt)
        {
            try
            {   
                diff.insertDiffusion(salle,film,prix,plageDebt);
                return RedirectToAction("ListeDiffusion");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("diffusion");
            }
        }


        public IActionResult PlaceInfo(string salleId, string idDiff)
        {
            var placesDispo=diff.getPlacesdispo(salleId);
            var placesFilm=diff.getPlacesPrisReserverDiff(idDiff);
            ViewBag.Places = placesDispo;
            ViewBag.PlacesFilm = placesFilm;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReservationStatus()
        {
            using (var reader = new System.IO.StreamReader(Request.Body))
            {
                var body = await reader.ReadToEndAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(body);
                string idReservation = data.idReservation;
                try
                {
                    diff.updateReservationStatu(idReservation);
                    return Json(new { success = true, message = "Suppression réussie pour la réservation: " + idReservation });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = "Erreur lors de la suppression: " + ex.Message });
                }
            }
        }

    }
}
