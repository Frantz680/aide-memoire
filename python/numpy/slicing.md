# Le slicing

## Importation de numpy

```python
import numpy as np
```

## Fonctionnement du slicing

La syntax du slicing est [ start : stop : step ]


## Création d'un matrice

```python
matrice = np.array([[0,1,2,3,4], [5,6,7,8,9], [10,11,12,13,14], [15,16,17,18,19]])
```

## Récupérer les colonnes 2 et 3 de toutes les lignes

```python
matrice[:,2:4]

# Résultat

[[ 2  3]
 [ 7  8]
 [12 13]
 [17 18]]
```

La virgule sert a dire qu'on veut interagir sur les colonnes

## Récupérer les 3 dernières colonnes des 3 dernières lignes

```python
matrice[2:,1:]

# Résultat

[[11 12 13 14]
 [16 17 18 19]]


# Autre solution


matrice[2:5,1:4]

# Résultat

[[11 12 13 14]
 [16 17 18 19]]
```

## Création d'un vecteur

```python
vecteur = np.array([1,2,3,4,5,6,7,8,9,10,11,12,13,14])
```

## Récupérer les 4 derniers éléments du vecteur

```python
vecteur[-4:]

# Résultat

[11 12 13 14]

# Autre solution

vecteur[10:]

# Résultat

[11 12 13 14]
```

## Le pas

```python
vecteur[::2]

# Résultat

[ 1  3  5  7  9 11 13]
```

