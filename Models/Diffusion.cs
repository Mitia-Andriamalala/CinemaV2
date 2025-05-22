namespace GestionCinema.Models
{
    public class Diffusion
    {
        public string IdDiffusion { get; set; }
        public string SalleId { get; set; }
        public string FilmId { get; set; }
        public double prix { get; set; }
        public DateTime PlageHoraireDebut { get; set; }
        public DateTime PlageHoraireFin { get; set; }

        // Constructor
        public Diffusion(string salleId, string filmId, double vola ,DateTime plageHoraireDebut, DateTime plageHoraireFin)
        {
            SalleId = salleId;
            FilmId = filmId;
            prix=vola;
            PlageHoraireDebut = plageHoraireDebut;
            PlageHoraireFin = plageHoraireFin;
        }
        public Diffusion(){}
    }
}