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