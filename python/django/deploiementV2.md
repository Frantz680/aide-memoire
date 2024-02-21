# Déploiement

## Sur un VPS

### Choix de la distribution

```bash
Ubuntu 18.04
```

### Connexion au serveur

# Se connecter au serveur via SSH

```bash
ssh root@MONIP
```

# L'adresse IP se trouve dans l'onglet "Overview" de Hostinger
bash
Copy code
# Une fois connecté, ouvrir un terminal
# Coller la commande: ssh root@MONIP
# Répondre "yes" si nécessaire
# Entrer le mot de passe du VPS
Mise à jour du serveur
bash
Copy code
apt update && apt upgrade
Ajout d'un utilisateur
bash
Copy code
adduser MONUSER

# Création d'un mot de passe et d'informations facultatives
adduser MONUSER sudo

# Se déconnecter du compte root
exit

# Se reconnecter en tant qu'utilisateur créé
ssh MONUSER@MONIP
Création et association d'une clé SSH
bash
Copy code
# Créer un dossier pour la clé SSH
mkdir -p ~/.ssh

# Vérifier la création du fichier
ls -a

# Générer une clé SSH (répondre aux questions)
ssh-keygen -f ~/.ssh/NOM

# Copier la clé sur le serveur
scp ~/.ssh/NOM.pub MONUSER@MONIP:~/.ssh/authorized_keys

# Reconnecter au serveur et ajuster les permissions
sudo chmod 700 ~/.ssh/
sudo chmod 600 ~/.ssh/*
exit
Configuration des paramètres de connexion
bash
Copy code
ssh UNNOM
sudo nano /etc/ssh/sshd_config

# Modifier les lignes suivantes :
PermitRootLogin no
PasswordAuthentification no

# Redémarrer le service SSH
sudo systemctl restart sshd
Installation d'un pare-feu
bash
Copy code
sudo apt install ufw

# Autoriser le trafic sortant
sudo ufw default allow outgoing

# Bloquer le trafic entrant par défaut
sudo ufw default deny incoming

# Autoriser le SSH
sudo ufw allow ssh

# Autoriser le port 8000 (pour Django)
sudo ufw allow 8000

# Activer le pare-feu
sudo ufw enable

# Vérifier le statut
sudo ufw status
Téléchargement de Django sur le serveur
Liste des dépendances
bash
Copy code
source venv/bin/activate
pip freeze > requirements.txt
Transfert de l'application
bash
Copy code
# Se déplacer vers l'emplacement de l'application sur le serveur
scp -r app UNNOM:~/
Installation de l'application et de ses dépendances
bash
Copy code
# Se connecter au serveur
cd MONAPP
python3 -m venv venv
source venv/bin/activate
pip install -r requirements.txt
Configuration de l'application
bash
Copy code
# Modifier les paramètres dans settings.py
sudo nano MONAPP/settings.py

# Ajouter l'IP dans ALLOWED_HOSTS
ALLOWED_HOSTS = ['MONIP']

# Configurer le chemin des fichiers statiques
STATIC_ROOT = os.path.join(BASE_DIR, 'assets')

# Collecter les fichiers statiques
python manage.py collectstatic

# Lancer l'application
python manage.py runserver 0.0.0.0:8000
Installation d'Apache
bash
Copy code
sudo apt install apache2
sudo apt install libapache2-mod-wsgi-py3
Configuration du fichier de site Apache
bash
Copy code
cd /etc/apache2/sites-available/
sudo cp 000-default.conf MONAPP.conf
sudo nano MONAPP.conf
apache
Copy code
# Configurer le fichier MONAPP.conf
Alias /static /home/USER/APP/assets
<Directory /home/USER/APP/static>
    Require all granted
</Directory>

Alias /media /home/USER/APP/media
<Directory /home/USER/APP/media>
    Require all granted
</Directory>

<Directory /home/USER/APP/APP>
    <Files wsgi.py>
        Require all granted
    </Files>
</Directory>

WSGIScriptAlias / /home/USER/APP/APP/wsgi.py
WSGIDaemonProcess APP python-path=/home/USER/APP python-home=/home/USER/APP/venv
WSGIProcessGroup APP
bash
Copy code
# Activer le site et désactiver le site par défaut
cd
sudo a2ensite MONAPP.conf
sudo a2dissite 000-default.conf
Permissions pour la base de données
bash
Copy code
sudo chown :www-data APP/db.sqlite3
sudo chmod 664 APP/db.sqlite3
sudo chown :www-data APP/
sudo chown -R :www-data APP/media/
sudo chmod -R 775 APP/media/
sudo chmod 775 APP/
Configuration du fichier de l'application
bash
Copy code
sudo touch /etc/config.json
sudo nano /etc/config.json

# Ajouter au fichier
{
    "SECRET_kEY": "...",
    "EMAIL_HOST": "...",
    "EMAIL_PASSWORD": "...",
}
bash

sudo nano APP/APP/settings.py

# Importer le fichier de configuration
import json
with open('/etc/config.json') as config_file:
    config = json.load(config_file)

# Modifier les paramètres
SECRET_KEY = config['SECRET_KEY']
DEBUG = False
Mise à jour du pare-feu
bash
Copy code
sudo ufw delete allow 8000
sudo ufw allow http
sudo service apache2 restart
