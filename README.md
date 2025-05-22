# Système de Gestion de Cinéma

## Description
Ce projet est un système de gestion de cinéma développé en ASP.NET Core. Il permet de gérer les films, les salles, les réservations et les paiements pour un cinéma.

## Fonctionnalités
- Gestion des utilisateurs
- Gestion des films et des catégories
- Gestion des salles et des places
- Système de réservation
- Gestion des diffusions
- Système de paiement (Mvola, Orange Money, Cash)
- Tableau de bord pour les statistiques

## Prérequis
- .NET 9.0 SDK
- MySQL Server 8.0 ou supérieur
- Visual Studio 2022 ou Visual Studio Code

## Installation

1. Cloner le repository
```bash
git clone [URL_DU_REPO]
cd Cinema
```

2. Configurer la base de données
- Créer une base de données MySQL nommée "cinema"
- Exécuter le script `base/table.sql` pour créer les tables
- Exécuter le script `base/data.sql` pour insérer les données initiales

3. Configurer la connexion à la base de données
- Ouvrir `Services/Utilitaire/Connexion.cs`
- Vérifier que la chaîne de connexion correspond à votre configuration MySQL :
```csharp
string connectionString = "Server=localhost;Database=cinema;User=root;Password=root;";
```

4. Restaurer les dépendances
```bash
dotnet restore
```

5. Lancer l'application
```bash
dotnet run
```

## Structure du Projet
```
Cinema/
├── Controllers/         # Contrôleurs MVC
├── Models/             # Modèles de données
├── Services/           # Services métier
│   ├── CRUD/          # Opérations CRUD
│   ├── FonctionDAO/   # Accès aux données
│   └── Utilitaire/    # Utilitaires
├── Views/              # Vues Razor
└── base/              # Scripts SQL
```

## Technologies Utilisées
- ASP.NET Core 9.0
- MySQL
- Entity Framework Core
- Bootstrap
- jQuery

## Contribution
Les contributions sont les bienvenues ! N'hésitez pas à :
1. Fork le projet
2. Créer une branche pour votre fonctionnalité
3. Commiter vos changements
4. Pousser vers la branche
5. Ouvrir une Pull Request

## Licence
Ce projet est sous licence MIT. Voir le fichier `LICENSE` pour plus de détails.

## Contact
Pour toute question ou suggestion, n'hésitez pas à ouvrir une issue sur le repository. 