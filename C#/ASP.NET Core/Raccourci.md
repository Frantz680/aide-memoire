## Commandes .NET Core
Voici quelques-unes des commandes les plus couramment utilisées avec .NET Core :

Gestion de projets
dotnet new: Crée un nouveau projet, par exemple, dotnet new console pour créer une application console.

dotnet restore: Restaure les dépendances du projet en lisant le fichier project.json (pour .NET Core 2.x) ou *.csproj (pour .NET 3.0+) et télécharge les packages nécessaires.

dotnet build: Compile le projet et ses dépendances. Cela génère les fichiers binaires dans le dossier de sortie.

dotnet run: Compile et exécute l'application en une seule étape.
dotnet watch run --non-interactive

dotnet publish: Publie l'application pour un déploiement. Cette commande crée une version exécutable de l'application dans un dossier de publication.

Gestion des packages
dotnet add package <PACKAGE_NAME>: Ajoute un package NuGet au projet.

dotnet remove package <PACKAGE_NAME>: Supprime un package NuGet du projet.

dotnet list package: Affiche la liste des packages NuGet installés dans le projet.

Tests
dotnet test: Exécute les tests unitaires du projet.
Entity Framework Core (EF Core)
dotnet ef: Commande racine pour EF Core.

dotnet ef migrations: Gère les migrations de base de données.

dotnet ef database update: Applique les migrations à la base de données.

Gestion des dépendances
dotnet tool install: Installe une commande .NET Core globalement en tant qu'outil.

dotnet tool uninstall: Désinstalle une commande .NET Core globalement.

dotnet tool list: Liste les outils installés.

Informations
dotnet --version: Affiche la version actuelle de .NET Core installée.

dotnet --info: Affiche les informations détaillées sur l'installation de .NET Core et ses composants.

N'hésitez pas à ajouter ou à retirer des commandes selon vos besoins et vos préférences. Vous pouvez également inclure des descriptions supplémentaires pour chaque commande si vous le souhaitez. Ce fichier .md vous servira de référence rapide pour les commandes .NET Core.






