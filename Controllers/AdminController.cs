using Microsoft.AspNetCore.Mvc;
using GestionCinema.Models;
using GestionCinema.Services;
using Cinema.Services.FonctionPage;

namespace Cinema.Controllers
{
    public class AdminController : Controller
    {
        Administrateur admin=new Administrateur();

        [HttpGet]
        public IActionResult AccueilAdmin()
        {
            var listeReserveSalle=admin.getListeReserveSalle();
            return View(listeReserveSalle);
        }

        [HttpGet]
        public IActionResult Gestion()
        {
            var listeInfoSalle=admin.getListeSalle();
            return View(listeInfoSalle);
        }

        [HttpGet]
        public IActionResult Reservation()
        {
            var listeListeReserve=admin.getListeReservation();
            return View(listeListeReserve);
        }

        [HttpGet]
        public IActionResult InfoReserveSalle()
        {
            var listeListeReserve=admin.getListeReservation();
            return View(listeListeReserve);
        }
    }
}
