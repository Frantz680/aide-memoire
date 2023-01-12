# Les bases de numpy

## Importation de numpy

```python
import numpy as np
```

## Création d'un tableau

```python
scalaire = np.array(3)
```

### Type de notre variable

```python
type(scalaire)
type(3)
```

### Tableau à 1 dimension

```python
vecteur = np.array([1,2,3])
```

### Tableau à 2 dimension

```python
matrice = np.array([[1,2,3], [4,5,6]])
```

```python
matrice = np.array([[1,2,3], [4,5,6]])


# Il n'est pas possible de crée une matrice de longueur différente

matrice_erreur = np.array([[1,2], [3,4,5]])

```

### Dimensions d'un tableau

```python
scalaire.shape
vecteur.shape
matrice.shape

# Résultat

()
(3,)
(2,3)
```

### L'opérateur somme : +

```python
list_1 = [1,2,3]
list_2 = [4,5,6]
print(list_1 + list_2)

# Resultat

[1,2,3,4,5,6]
```

```python
scalaire_1 = np_array(2)
scalaire_2 = np_array(3)
print(scalaire_1 + scalaire_2)

# Resultat

5
```

```python
vecteur_1 = np_array([1,2,3])
vecteur_2 = np_array([-1,-2,-3])
print(vecteur_1 + vecteur_2)

# Resultat

[0 0 0]
```

```python
matrice_1 = np_array([[1,0,0], [0,1,0], [0,0,1]])
matrice_2 = np_array([[1,0,0], [0,1,0], [0,0,1]])
print(matrice_1 + matrice_2)

# Resultat

[[2 0 0]
 [0 2 0]
 [0 0 2]]
```

### Racine carré

```python
matrice = np.array([[1,2,3]])
print(np.sqrt(matrice))

# Resultat

array([[1.    ,1.41421356, 1.73205081]])
```
