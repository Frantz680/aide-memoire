# Deploiement

## Sur un VPS 

### Choisir comme distribution

```python
Ubuntu 18.04
```

### Ce connecter au serveur

```python
ssh root@MONIP

# Votre trouverez l'ip sur hostinger dans l'onglet Overview
```

```python
Ouvrir le terminal 

coller la commande: ssh root@MONIP

Puis répondre: yes

Un mot de passe sera demander
Le mdp demander est celui de votre VPS

Vous voilà, connecter au serveur
```

### MAJ de votre server

```bash
apt update && apt upgrade
```

### Ajouter un utilisateur

```bash
adduser MONUSER

# Il demandera de créer un MDP
# Puis des informations personnels, elle ne sont pas obligatoire

# Permet de donnée des permissions administrateurs
adduser MONUSER sudo

# On quitte le serveur
exit

# Puis on se reconnecter avec notre utilisateur
ssh MONUSER@MONIP
```

### Créer et associer une clé ssh

```bash

# Créer un dossier 
mkdir -p ~/.ssh

# Verifier que votre fichier est créer
ls -a
ls -la

# Ouvrir une nouvelle console qui se trouve sur votre local 
# On va créer une clé ssh
ssh-keygen -f ~/.ssh/NOM

ou

cd .ssh
ssh-keygen
NOM

# On copie la clé sur notre serveur
scp ~/.ssh/NOM.pub MONUSER@MONIP:~/.ssh/authorized_keys


# On se reconnecte au serveur
# On change les permissions sur le serveur
sudo chmod 700~/.ssh/
sudo chmod 600~/.ssh/*
exit

# Création d'un fichier config
sudo touch ~/.ssh/config
sudo nano ~/.ssh/config

# Dans ~/.ssh/config
# Rajouter ceci : ATTENTION AU TAB
host UNNOM
    user MONUSER # ATTENTION AU TAB
    hostname MONIP # ATTENTION AU TAB
    identityfile ~/.ssh/UNNOM # ATTENTION AU TAB

# Pour quitter le fichier bash
Ctrl + x
```

### Configuration des paramètres de connexion:

```bash
# Lancer votre serveur
ssh UNNOM
sudo nano /etc/ssh/sshd_config

# Changer
PermitRootLogin no
PasswordAuthentification no

# On redemarre les controles les systèmes
sudo systemctl restart sshd
```

### Installation d'un pare feu

```bash

sudo apt install ufw

# Par default tu aurorise le trafic sortant
sudo ufw default allow outgoing

# Par default tu interdit le trafic entrant
sudo ufw default deny incoming

# Tu autorise le ssh
sudo ufw allow ssh

# Tu autorise le port 8000 ( le port de django en dev )
sudo ufw allow 8000

sudo ufw enable
sudo ufw status
```

------------

## Upload Django sur notre serveur

### Lister les dépendances

```bash
source venv/bin/active

pip freeze > requirements.txt
```

### Transférer votre app

```bash
# Chercher son application sur son bureau
cd /chemin/APP
cd /mnt/c/Users/ACER/Desktop/UNNOM

scp -r app UNNOM:~/
```

### Installer son app et ses dépendances

```bash
# On se connecter a votre serveur
# On verifie si notre application a bien été copier
ls

# Puis on installe python et les independances
sudo apt install python3-pip
sudo apt install python3-venv
cd MONAPP
python3 -m venv venv
source venv/bin/activate
pip install -r requirements.txt
```

### Configurer son app

```bash
# Allez dans les settings
sudo nano MONAPP/settings.py

# Ajoutez l'ip
ALLOWED_HOSTS = ['MONIP']

STATIC_ROOT = os.path.join(BASE_DIR, 'assets')

python manage.py collectstatic
python manage.py runserver 0.0.0.0:8000
```

### Installer Apache

```bash
sudo apt install apache2
sudo apt install libapache2-mod-wsgi-py3
```

### Créer et paramétrer son fichier de configuration

```bash
cd /etc/apache2/sites-available/

sudo cp 000-default.conf MONAPP.conf

sudo nano MONAPP.conf
```

```bash
# Une fois dans ce ficher: MONAPP.conf
# Ajouter les informations

    Alias /static /home/USER/APP/assets
    <Directory /home/USER/APP/static>
        Require all granted
    </Directory>

    Alias /media  /home/USER/APP/media
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
```

```bash
# Revenir à la racine
cd

# Activer votre site
sudo a2ensite APP.conf

# Desactiver celui par default
sudo a2dissite 000-default.conf
```

### Permissions pour la base de données

```bash
sudo chown :www-data APP/db.sqlite3

sudo chmod 664 APP/db.sqlite3

sudo chown :www-data APP/

sudo chown -R :www-data APP/media/

sudo chmod -R 775 APP/media/

sudo chmod 775 APP/
```

### Création d'un fichier configuration pour votre application

```bash
sudo touch /etc/config.json

sudo nano /etc/config.json

# Ajouter au fichier

{
    "SECRET_kEY": "...",
    "EMAIL_HOST": "...",
    "EMAIL_PASSWORD": "...",
}
```

### Importer le fichier de configuration dans settings.py

```bash
sudo nano APP/APP/settings.py

# Dans settings.py ajouter:
import json

with open('/etc/config.json') as config_file:
    config = json.load(config_file)

# Dans settings.py changer :
SECRET_KEY = config['SECRET_KEY']
DEBUG = False
```

### Re-configurer son pare-feu

```bash
sudo ufw delete allow 8000
sudo ufw allow http
sudo service apache2 restart
```