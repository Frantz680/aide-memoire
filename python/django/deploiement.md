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

