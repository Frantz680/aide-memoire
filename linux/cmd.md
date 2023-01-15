# Les commandes

## man

```bash
# Signification : manual


# Affiche les informations pour l'utilisation de man
man man

# décrit le contenu et la syntaxe du fichier /etc/exports pour les partages NFS
man exports

# Pour quitter
q
```

## ls

```bash
# Signification : list


# Permet un affichage détaillé du répertoire
-l

# Associé avec -l affiche la taille des fichiers avec un suffixe correspondant à l'unité (K,M,G)
-h

# Permet l'afficha des fichiers et répertoires caché
-a

# Permet de trier les fichiers et répertoires par date de modification décroissante
-lct

# Exemple

# Affiche tous les fichiers et répertoires y compris les cachés du répertoire courant
ls -a

# Affiche le contenu du répertoire /etc/
ls /etc/

# Affiche les périphériques PCI ou USB connectés
lspi ou lsub

# Affiche les caractéristiques de tout le matériel physique, non-logiciel
lshw
```

## cd

```bash

# Signification : change directory


# Permet de revenir au répertoire /home/utilisateur (identique à cd ~) 
cd

# Permet de revenir au répertoire précédent
cd -

# Permet de remonter au répertoire parent (ne pas oublier l'espace contrairement à windows)
cd /

# Se place dans le répertoire /usr/bin/
cd /usr/bin/ ou usr/bin
```

## mv

```bash

# Signification : move


-f : Écrase les fichiers de destination sans confirmation

-i : Demande confirmation avant d'écraser

-u : N'écrase pas le fichier de destination si celui-ci est plus récent


# Exemple

mv monFichier unRep/
Déplace monFichier dans le répertoire unRep

mv unRep/monFichier .
Déplace le fichier monFichier du répertoire unRep là où on se trouve

mv unRep monRep
Renomme unRep en monRep
```

## cp

```bash

# Signification : copy


-a : Archive. Copie en gardant les droits, dates, propriétaires, groupes, etc.
-i : Demande une confirmation avant d'écraser
-f : Si le fichier de destination existe et ne peut être ouvert alors le détruire et essayer à nouveau
-R ou -r : Copie un répertoire et tout son contenu, y compris les éventuels sous-répertoires
-u : Ne copie que les fichiers plus récents ou qui n'existent pas
-v : permet de suivre les copies réalisées en temps réel

# Exemple

cp monFichier sousrep/
Copie monFichier dans sousrep
cp -r monRep/ ailleurs/
Copie le répertoire monRep (et ses éventuels sous-répertoires) vers ailleurs en créant le répertoire ailleurs/monRep s'il n'existe pas.
cp monRep/{*.cpp,*.h,MakeFile,Session.vim} ailleurs/
Copie les fichiers spécifiés dans {} contenus dans le répertoire monRep vers ailleurs. Notez bien qu'il n'y a pas d'espace entre ces noms de fichiers.
```

## rm

```bash

# Signification : remove


-i : Demande confirmation avant d'effacer
-f : Ne demande pas de confirmation avant d'effacer
-r : Efface récursivement. Ce mot signifie "y compris ses sous-répertoires et leur contenu".

# Exemple

rm CeFichier
Efface du répertoire courant le fichier CeFichier.
rm -rf /tmp/LeRep
Efface le répertoire /tmp/LeRep ainsi que tous ses fichiers, liens et sous-répertoires sans demander de confirmation.
rm -rf /*
…La commande qui "tue"… Disparition immédiate de tous vos fichiers.
```

## mkdir

```bash

# Signification : make directory


-p : Crée les répertoires parents s'ils n'existent pas

# Exemple

mkdir photos
Crée le répertoire photos
mkdir -p photos/2005/noel
Crée le répertoire noel et s'ils n'existent pas les répertoires 2005 et photos
```

## rmdir

```bash

# Signification : remove directory


-p : Supprime les répertoires parents s'ils deviennent vides

# Exemple

rmdir LeRep
Supprime le répertoire LeRep
```

