# Environnement virtuel

## Créer un environnement

```python
pip install virtualenv

# Ceci va vous créer un dossier venv.
python -m venv venv

# Ceci active un environnement virtuel.
venv/Scripts/activate
```

```python
# Sur linux

# Installation
pip install virtualenv

# Ceci va vous créer un dossier venv.
virtualenv -p python3 env

# Ceci active un environnement virtuel.
source env/bin/activate
```