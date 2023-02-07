# Les fonctions utiles

## Fonction de conversion

```python
# La fonction str retourne une chaine de caractères à partir 
# d'une donnée qu'on va lui passer en argument

str()


# La fonction int() retourne un entier à partir d’un nombre ou d’une chaine 
# contenant un nombre qu’on va lui passer en argument

int()


# La fonction float() retourne un nombre décimal à partir d’un nombre ou 
# d’une chaine contenant un nombre qu’on va lui passer en argument

float()


# La fonction complex() retourne un nombre complexe à partir d’un nombre ou 
# d’une chaine contenant un nombre qu’on va lui passer en argument

complex()


# La fonction bool() retourne un booléen à partir d’une donnée qu’on va lui passer en argument

bool()


# La fonction list() retourne une liste à partir d’une donnée itérable (une donnée dont on peut parcourir les valeurs)

list()


# La fonction tuple() retourne un tuple à partir d’une donnée itérable

tuple()


# La fonction dict() crée un dictionnaire à partir d’un ensemble de paires clef = “valeur”

dict()


# La fonction set() retourne un ensemble (set) à partir d’une donnée itérable

set()
```

## Fonction mathématiques

```python
# La fonction range() renvoie une séquence de nombres. On peut lui passer jusqu’à 3 arguments mais 1 seul est obligatoire

# Si on ne passe qu’un argument à range(), cette fonction va renvoyer une séquence de nombres commençant par 0 et en incrémentant de 1 à chaque fois jusqu’au nombre spécifié en argument moins 1.

# En lui passant 2 arguments, le premier argument servira de départ pour la séquence et le deuxième indiquera la fin de la séquence (avec le nombre indiqué exclu).

# En lui passant trois arguments, le premier argument servira de départ pour la séquence, le deuxième indiquera la fin de la séquence (avec le nombre indiqué exclu) et le troisième indiquera le “pas”, c’est-à-dire l’écart entre chaque nombre renvoyé.

range()



# La fonction round() permet d’arrondir un nombre spécifié en argument t à l’entier le plus proche avec un degré de précision (un nombre de décimales) éventuellement spécifié en deuxième argument.

# Le nombre de décimales par défaut est 0, ce qui signifie que la fonction retournera l’entier le plus proche.

round()



# La fonction sum() permet de calculer une somme. On peut lui passer une liste de nombres en arguments par exemple. On peut également lui passer une valeur “de départ” en deuxième argument qui sera ajoutée à la somme calculée.

sum([1,2,3])

# Sortie

6



# La fonction max() retourne la plus grande valeur d’une donnée itérable, c’est-à-dire d’une donnée dont on peut parcourir les différentes valeurs.

# On peut lui passer autant d’arguments qu’on souhaite comparer de valeurs. Notez qu’on peut également comparer des chaines même si max() est peu souvent utilisée pour faire cela.

# La fonction min(), au contraire, retourne la plus petite valeur d’une donnée itérable. Elle s’utilise exactement comme max().

max()
max([1,3,2,6,99,1])

# Sortie 
99

min()
min([1,3,2,6,99,1])

# Sortie 
1
```

## Fonction natives

```python
# La fonction len(), tout d’abord, renvoie la longueur ou le nombre de valeurs d’une donnée de type séquence ou collection.

len()


# La fonction input() permet de dialoguer et d’échanger des données avec l’utilisateur. On va pouvoir passer un message en argument de cette fonction. Attention : il est de votre responsabilité de bien vérifier si les données envoyées sont conformes à celles attendues pas la suite.

input()


# La fonction dir(), lorsqu’elle est utilisée sans argument, renvoie la liste des variables et des fonctions (ou plus exactement des objets et des méthodes) disponibles dans l’espace de portée courant.

dir()
```

```python
# La méthode sort permet de trier une liste.
list.sort()

l = [5,1,4,2,10]
l.sort()
print(l)

# Sortie

[1, 2, 4, 5, 10]
```

```python
# Tri un élément itérable.
sorted(iterable)

sorted([3,2,12,1])

# Sortie

[1, 2, 3, 12]
```

```python
# La méthode split transforme une chaine de caractères en liste.
split()

# Exemple
"olivier:engel".split(":")

# Sortie
['olivier', 'engel']
```

```python
# Transforme la chaine dans un format title.
.title()

# Exemple
"Ceci est un titre".title()

# Sortie
'Ceci Est Un Titre'
```

```python
# La méthode upper permet de mettre en majuscule une chaine de caractères.
upper()

# Exemple
"olivier".upper()

# Sortie
'OLIVIER'
```

https://python.doctor/page-builtin-built-in-fonctions-internes-python