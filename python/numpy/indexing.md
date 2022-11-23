# L'indexing

## Importation de numpy

```python
import numpy as np
```

## Création d'un matrice

```python
matrice = np.array([[0,1,2,3,4], [5,6,7,8,9], [10,11,12,13,14], [15,16,17,18,19]])
```

## Récupérer le premier élément

```python
print(matrice[0])

# Résultat

array([0, 1, 2, 3, 4])
```

## Récupérer le premier élément de la première ligne

```python
print(matrice[0][0])

# Résultat

0
```

Ou alors

```python
print(matrice[0, 0])

# Résultat

0
```

# Index négatifs

## Création d'un vecteur

```python
vecteur = np.array([1,2,3,4,5,6,7,8,9,10])

print(vecteur[-2])

# Résultat

9
```

## Fonctionne aussi avec une matrice

```python
matrice = np.array([[1,2], [3,4], [5,6]])

print(matrice[-1])

print(matrice[-1, -1])

# Résultat

array([5, 6])

6
```
