# Depoilement

## Sur un VPS de Hostinger

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
cd /mnt/c/ACER/Desktop/UNNOM

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
python manage.py runserver
```