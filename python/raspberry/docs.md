# Raspberry

# Raccourcis et Commandes Utiles pour le Raspberry Pi

Lorsque vous travaillez avec un Raspberry Pi, il existe plusieurs raccourcis clavier et commandes en ligne de commande qui peuvent vous aider à naviguer plus efficacement et à effectuer des tâches spécifiques. Voici quelques-uns des raccourcis et des commandes les plus utiles :

## Raccourcis Clavier

- `Ctrl` + `C` : Interrompt une commande en cours d'exécution dans le terminal.
- `Ctrl` + `D` : Quitte le terminal en cours.
- `Ctrl` + `L` : Efface l'écran du terminal.
- `Ctrl` + `A` : Déplace le curseur au début de la ligne.
- `Ctrl` + `E` : Déplace le curseur à la fin de la ligne.
- `Ctrl` + `U` : Supprime tout le texte avant le curseur.
- `Ctrl` + `K` : Supprime tout le texte après le curseur.
- `Ctrl` + `R` : Permet de rechercher dans l'historique des commandes.
- `Tab` : Auto-complétion des commandes et des noms de fichiers.

## Commandes en Ligne de Commande

- `ls` : Liste les fichiers et les dossiers dans le répertoire courant.
- `cd [dossier]` : Change le dossier actuel.
- `pwd` : Affiche le chemin absolu du dossier actuel.
- `mkdir [nom_dossier]` : Crée un nouveau dossier.
- `rm [nom_fichier]` : Supprime un fichier.
- `rmdir [nom_dossier]` : Supprime un dossier vide.
- `cp [fichier_source] [fichier_destination]` : Copie un fichier.
- `mv [fichier_source] [fichier_destination]` : Déplace un fichier.
- `nano [nom_fichier]` : Ouvre l'éditeur de texte Nano pour éditer un fichier.
- `sudo [commande]` : Exécute une commande en tant qu'administrateur.
- `apt-get update` : Met à jour la liste des paquets disponibles.
- `apt-get install [nom_paquet]` : Installe un paquet.
- `apt-get upgrade` : Met à jour les paquets installés.
- `ifconfig` : Affiche les informations sur les interfaces réseau.
- `ping [adresse_ip]` : Envoie des paquets ICMP pour tester la connectivité réseau.

## Personnalisation du Shell

Vous pouvez personnaliser votre shell en modifiant le fichier de configuration `.bashrc`. Pour ce faire, utilisez la commande :

```bash
nano ~/.bashrc
```

## Activée le port serie du raspberry 

- sudo raspi-config
- Choissisez Interface Options
- Puis choissisez Serial Port
- Répondez non
- Puis Yes

- https://raspberry-pi.fr/activer-port-serie-raspberry-pi/


## Configuration et utilisation des sorties avec RPI.GPIO

- import RPi.GPIO as GPIO 

- GPIO.setup(port_or_pin, GPIO.IN)
- GPIO.setup(port_or_pin, GPIO.OUT)

### Pour basculer les port sur 3,3V

- GPIO.output(port_or_pin, 1)

### Pour basculer les port sur 0V

- GPIO.output(port_or_pin, 0)

### Sortie ("Analogique")

- GPIO.PWM([pin], [frequency])

### Remettre à zéro une entrée-sortie

- GPIO.cleanup()

## Les ports du raspberry

![alt text](https://raspberry-pi.fr/wp-content/uploads/2020/07/gpios-diagram-939x528.png)

https://raspberrypi.stackexchange.com/questions/45570/how-do-i-make-serial-work-on-the-raspberry-pi3-pizerow-pi4-or-later-models/107780#107780

Voir les pin sur le raspberry
- pinout

## Docs GPIO

- https://pypi.org/project/RPi.GPIO/
- https://sourceforge.net/p/raspberry-gpio-python/wiki/Examples/

## Autre docs

- https://raspi.tv/2013/rpi-gpio-basics-5-setting-up-and-using-outputs-with-rpi-gpio

### Intéresant a creuser

- https://www.editions-eni.fr/open/mediabook.aspx?idR=95a74a203820b0ab4eb45008abcaa14f

## Tutoriel

### Désactiver le bluetooth pour les rapsberry < 3
	- echo "dtoverlay=disable-bt" | sudo tee -a /boot/config.txt
	- sudo systemctl disable hciuart
	- sudo reboot

### Activer le port serie
	- https://raspberry-pi.fr/activer-port-serie-raspberry-pi/
	- Ce repporter en haut du ReadMe
 
### Le module a installer :
	- sudo apt update
	- sudo apt install minicom

### Permet de vérifier si le port serie fonctionne
	- minicom -D /dev/serial0
	- On met un resistance entre TX et RX
	- On appuie sur n'importe qu'elle touche, elle s'affiche dans le document serial0

### Savoir si le module gsm marche
	- sudo minicom -b 115000 -o -D /dev/serial0
	- AT
		- Si Ok c'est bon
	- AT+CPIN=0000 (Pour deverrouillez la carte sim)
	- AT+CMGF=1 (Pour activer le mode texte)
	- AT+CMGS="+336xxxxxxxxxxxxx"

### Configuration du raspberry
	- tail /boot/config.txt

	- sudo apt-get install raspi-gpio
	- dtoverlay -a | grep uart (Permet de voir tous les uart du raspberry)
	- dtoverlay -h uart5 (Permet d'avoir des informations sur l'uart5)
	- raspi-gpio get 12-15 
	- raspi-gpio funcs

## Activer plusieur Uart

### Boot/config.txt
- /boot/config.txt
- Ajouter
	- dtoverlay=uart2
	- dtoverlay=uart3
	- dtoverlay=uart4

![alt text](https://cdn.mos.cms.futurecdn.net/kSo96fYwdrfQKSvALMKqzc.png)

- https://forums.raspberrypi.com/viewtopic.php?t=244827

- ls -l /dev/ttyA* (Pour lister les uarts)
- sudo minicom -b 115000 -o -D /dev/ttyAMA0
- sudo minicom -b 115000 -o -D /dev/ttyAMA1
- sudo minicom -b 115000 -o -D /dev/ttyAMA2
- sudo minicom -b 115000 -o -D /dev/ttyAMA3

GPIO14 = TXD0 -> ttyAMA0<br>
GPIO0  = TXD2 -> ttyAMA1<br>
GPIO4  = TXD3 -> ttyAMA2<br>
GPIO8  = TXD4 -> ttyAMA3<br>
GPIO12 = TXD5 -> ttyAMA4<br>

GPIO15 = RXD0 -> ttyAMA0<br>
GPIO1  = RXD2 -> ttyAMA1<br>
GPIO5  = RXD3 -> ttyAMA2<br>
GPIO9  = RXD4 -> ttyAMA3<br>
GPIO13 = RXD5 -> ttyAMA4<br>