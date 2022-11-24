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

## Récupérer tous les éléments aux indices pairs

```python
vecteur[0:14:2]

# Résultat

[ 1  3  5  7  9 11 13]

# On récupérer tous les chiffres impairs
```

## Récupérer tous les éléments aux indices impairs

```python
vecteur[1:14:2]

# Résultat

[ 2 4 6 8 10 12 14]
```

## Assigner des valeurs

### Changer un seul élément dans un vecteur

```python
vecteur = np.array([1,2,3])

vecteur[-1] = 10
vecteur[2] = 10

# Résultat

[1 2 3]

[1 2 10]
[1 2 10]
```

### Changer toutes les valeurs d'un vecteur une par une

```python
vecteur = np.array([1,2,3,4,5,6,7,8,9])

for i in range(vecteur.shape[0]):
    vecteur[i] = vecteur.shape[0]-i

# Résultat

[1 2 3 4 5 6 7 8 9]

[9 8 7 6 5 4 3 2 1]
```

### Changer un seul élément dans une matrice

```python
matrice = np.array([[1,2,3], [4,5,6], [7,8,9], [10,11,12]])

matrice[1, 2] = 10

# Resultat

[[ 1  2  3]
 [ 4  5  6]
 [ 7  8  9]
 [10 11 12]]

[[ 1  2  3]
 [ 4  5 10]
 [ 7  8  9]
 [10 11 12]]
```

### Changer toutes les valeurs d'une matrice 2x2

```python
matrice = np.array([4,3], [2,1])

for i in range(2):
    for j in range(2):
        matrice[i, j] = i + j

# Résultat

[[4 3]
 [2 1]]

[[0 1]
 [1 2]]
```


### Affecter une même valeur à toute une ligne d'une matrice 

```python
matrice = np.array([[10,11,12], [-6,-5,-4], [1,2,3], [100,108,402], [121,323,454]])

matrice[0] = 0

# Résultat

[[ 10  11  12]
 [ -6  -5  -4]
 [  1   2   3]
 [100 108 402]
 [121 323 454]]

[[  0   0   0]
 [ -6  -5  -4]
 [  1   2   3]
 [100 108 402]
 [121 323 454]]
```

```python
matrice = np.array([[10,11,12], [-6,-5,-4], [1,2,3], [100,108,402], [121,323,454]])

matrice[0] = np.array([404,60,100])

# Résultat

[[ 10  11  12]
 [ -6  -5  -4]
 [  1   2   3]
 [100 108 402]
 [121 323 454]]

[[404  60 100]
 [ -6  -5  -4]
 [  1   2   3]
 [100 108 402]
 [121 323 454]]
```

```python
matrice = np.array([[10,11,12], [-6,-5,-4], [1,2,3], [100,108,402], [121,323,454]])

matrice[0] = matrice[1]

# Résultat

[[ 10  11  12]
 [ -6  -5  -4]
 [  1   2   3]
 [100 108 402]
 [121 323 454]]

[[ -6  -5  -4]
 [ -6  -5  -4]
 [  1   2   3]
 [100 108 402]
 [121 323 454]]
```

### Affecter une même valeur à toute une colonne d'une matrice

```python
matrice = np.array([[10,11,12], [-6,-5,-4], [1,2,3], [100,108,402], [121,323,454]])

matrice[:,-1] = 0

# Résultat

[[ 10  11  12]
 [ -6  -5  -4]
 [  1   2   3]
 [100 108 402]
 [121 323 454]]

[[ -6  -5   0]
 [ -6  -5   0]
 [  1   2   0]
 [100 108   0]
 [121 323   0]]
```

### Changer toutes les valeurs d'une matrice

```python
matrice = np.array([[10,11,12], [-6,-5,-4], [1,2,3], [100,108,402], [121,323,454]])

matrice[:,:] = 0

# Résultat

[[ 10  11  12]
 [ -6  -5  -4]
 [  1   2   3]
 [100 108 402]
 [121 323 454]]

[[  0   0   0]
 [  0   0   0]
 [  0   0   0]
 [  0   0   0]
 [  0   0   0]]
```

## Affecter des valeurs avec le slicing

### Affecter une valeur au croisement des lignes 2 et 3 et des colonnes 2 et 3 d'une matrice 5x5

```python
matrice = np.array([[1,2,3,4,5],[6,7,8,9,10],[11,12,13,14,15],[16,17,18,19,20],[21,22,23,24,25]])

matrice[2:4, 2:4] = 0

# Résultat

[[ 1  2  3  4  5]
 [ 6  7  8  9 10]
 [11 12 13 14 15]
 [16 17 18 19 20]
 [21 22 23 24 25]]

[[ 1  2  3  4  5]
 [ 6  7  8  9 10]
 [11 12  0  0 15]
 [16 17  0  0 20]
 [21 22 23 24 25]]
```