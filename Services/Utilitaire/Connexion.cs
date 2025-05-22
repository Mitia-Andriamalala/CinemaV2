using MySqlConnector;
using System;

namespace GestionCinema.Services.Utilitaire
{
    public class Connexion : IDisposable
    {
        private MySqlConnection _connexion;
        private MySqlCommand _command;

        // Getter pour la commande
        public MySqlCommand GetCommand()
        {
            return _command;
        }

        // Setter pour la commande
        public void SetCommand(MySqlCommand command)
        {
            _command = command;
        }

        // Getter pour la connexion
        public MySqlConnection GetConnexion()
        {
            // Vérifier si la connexion est fermée avant de l'ouvrir
            if (_connexion == null || _connexion.State == System.Data.ConnectionState.Closed)
            {
                try 
                {
                    Console.WriteLine("Tentative de connexion à la base de données...");
                    string connectionString = "Server=localhost;Database=cinema;User=root;Password=root;CharSet=utf8;Convert Zero Datetime=True;Allow Zero Datetime=True;";
                    Console.WriteLine($"Chaîne de connexion : {connectionString}");
                    _connexion = new MySqlConnection(connectionString);
                    _connexion.Open();
                    Console.WriteLine("Connexion réussie à la base de données cinema");
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Erreur de connexion à la base de données : {ex.Message}");
                    Console.WriteLine($"Code d'erreur : {ex.Number}");
                    Console.WriteLine($"Source : {ex.Source}");
                    throw;
                }
            }

            return _connexion;
        }

        // Méthode pour fermer la connexion et la commande
        public void CloseServ()
        {
            try
            {
                if (_command != null)
                {
                    _command.Dispose();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erreur lors de la fermeture de la commande : {e.Message}");
            }

            try
            {
                if (_connexion != null && _connexion.State == System.Data.ConnectionState.Open)
                {
                    _connexion.Close();
                    Console.WriteLine("Connexion fermée");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erreur lors de la fermeture de la connexion : {e.Message}");
            }
        }

        // Constructeur
        public Connexion()
        {
            // L'initialisation de la connexion est désormais gérée à chaque fois qu'on l'appelle
        }

        // Implémente IDisposable pour garantir la libération des ressources
        public void Dispose()
        {
            CloseServ();
        }
    }
}
