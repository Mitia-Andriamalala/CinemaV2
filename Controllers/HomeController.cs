using Microsoft.AspNetCore.Mvc;
using GestionCinema.Models;
using GestionCinema.Services;
using Cinema.Services.FonctionPage;

namespace Cinema.Controllers
{
    public class HomeController : Controller
    {
        ClientPage client=new ClientPage();
        DiffusionPage diffPage=new DiffusionPage();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Connecter(string nom)
        {
            try
            {
                string idOlona=client.connexion(nom);
                HttpContext.Session.SetString("UserId", idOlona);
                return RedirectToAction("ListeProgramme");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = e.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult ListeReservation()
        {
            var userId = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(userId))
            {
                TempData["ErrorMessage"] = "Vous devez être connecté pour voir vos réservations.";
                return RedirectToAction("Index");
            }
            var reservationPerso=client.reservationPers(userId);
            return View(reservationPerso);
        }


        public IActionResult ListeProgramme()
        {
            var DiffusionFilmData=client.lsDiffusionFilm();
            return View(DiffusionFilmData);
        }

        public IActionResult ReservationPage(string salleId, string idDiff)
        {
            
            var placesDispo = diffPage.getPlacesdispo(salleId);
            var placesFilm = diffPage.getPlacesPrisReserverDiff(idDiff);
            var modePaiement = client.lsModePaiement();
            ViewBag.IdDiffusion = idDiff;
            ViewBag.salleId = salleId;
            ViewBag.Places = placesDispo;
            ViewBag.mode = modePaiement;
            ViewBag.PlacesFilm = placesFilm;

            return View();
        }


        [HttpPost]
        public IActionResult Reservation(string salleId, string idDiffusion, string place, int choix,string mode,DateTime dtRes,double vola)
        {
            try
            {
                Console.WriteLine("idDiffusion: " + idDiffusion);
                Console.WriteLine("place: " + place);
                Console.WriteLine("choix: " + choix);
                Console.WriteLine("mode: " + mode);
                
                var userId = HttpContext.Session.GetString("UserId");
                if (string.IsNullOrEmpty(userId))
                {
                    TempData["ErrorMessage"] = "Vous devez être connecté pour faire une réservation.";
                    return RedirectToAction("Index");
                }
                else
                {
                    if (string.IsNullOrEmpty(place) || choix == null || choix==0)
                    {
                        throw new Exception("Veuillez compléter tous les champs requis de reservation.");
                    }
                    client.doReservation(idDiffusion,place,choix,userId,mode,dtRes,vola);

                    return RedirectToAction("ListeProgramme");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("ReservationPage", new { salleId, idDiffusion });
            }
        }


        public IActionResult Update(string idReservation)
        {
            client.maj(idReservation);
            return RedirectToAction("ListeReservation");
        }

        public IActionResult Annuler(string idReservation)
        {
            client.supprimer(idReservation);
            return RedirectToAction("ListeReservation");
        }
    }
}
