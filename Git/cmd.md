# Les bases de git

```bash
# Créer un nouveau répository local
git init

# Afficher les modifications non encore mises en scène
git diff

# Lister les fichiers suivants ou non modifiés
git status

# Ajouter tous les fichiers modifiés
git add .

# Ajouter tous le fichier
git add <file>

# Valider toutes les modifications locales dans les fichiers suivis
git commit -a

# Valider les changements précédemment mis en place
git commit

# Changer le dernier commit
git commit --amend

# Afficher l'historique complet des modifications
git log

# Basculer vers une branche et mettre à jour le répertoire de travail
git checkout <branch>

# Créer une nouvelle branche
git branch <new-branch>

# Supprimer une branche
git branch -d <branch>

# Récupérer toutes les branches du dépôt distant
git fetch <remote>

# Récupérer la version distante d'une branche et mettre à jour la branche locale
git pull <remote> <branch>

# Pousser les modifications validées vers un référentiel distant
git push <remote> <branch>

# Fusionner la branche spécifiée dans la branche actuelle
git merge <branch>

# Rebasez votre HEAD actuel sur la branche spécifiée
git rebase <branch>

# Crée un nouveau commit pour annuler le commit spécifié
git revert <commit>