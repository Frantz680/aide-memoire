# Les bases de Django

------------

## Mode d'emploi:

- manage.py
    - Ce qui permet de lancer les différents ligne de commande

### Premier répertoire racine

- __init__.py
    - Un fichier vide qui indique à Python que ce répertoire doit être considéré comme un paquet
- setting.py
    - Réglages et configuration de ce projet Django
- urls.py
    - Les déclarations des URL
- asgi.py
    - Un point d’entrée pour les serveurs Web compatibles aSGI pour déployer votre projet
- wsgi.py
    - Un point d’entrée pour les serveurs Web compatibles WSGI pour déployer votre projet


------------

## Commandes:

- Création d'un projet
    - django-admin startproject mysite

- Lancer le serveur local
    - python manage.py runserver

- Créer un superutilisateur
    - python manage.py createsuperuser

- Création d'une application
    - python manage.py startapp nom_de_l_app

- Création de nouvelles migrations
    - python manage.py makemigrations

- Exécution et annulation des migrations
    - python manage.py migrate

- Création d'un fichier staticfiles
    - python manage.py collectstatic

- Lancer les tests
    - python manage.py test

- Créer une nouvelle application avec un répertoire pour les modèles, vues et URL
    - python manage.py startapp nom_de_l_app

------------

## Lister les dépendances

```bash
source venv/bin/activate

pip freeze > requirements.txt
```
