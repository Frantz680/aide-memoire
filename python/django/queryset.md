# Les Queryset

## Les méthodes qui retournent un queryset

```python
# Filtre
filter(**kwargs)

# Exclu
exclude(**kwargs)

# Permet d'associer des valeurs type moyenne, sum et count au queryset
annotate(*args, **kwargs)

# Trie par le colonne désignée
order_by(*fields)

# Inverse l'ordre du queryset
reverse()

# Elimine les doublons
distinct([*fields])

# Retourne un dictionnaire au lieu d'instances de modèles
values(*fields)

# Retourne un tuple au lieu d'instance de modèles
values_list(*fields)

# Transforme les données dans un format datetime.date
dates(field, kind, order='ASC')

# Transforme les données dans un format datetime.datetime
datetimes(field, kind, order='ASC', tzinfo=None)

# Crée un queryset qui ne retourne jamais d'objets
none()

# L'inverse de none, c'est à dire tout
all()

# Retourne un queryset qui "suit" la clé étrangère indiqué
select_related(*fields)

# Optimise les requêtes pour éviter un déluge de SELECT
prefetch_related(*lookups)

# Hook requete SQL pour créer des nouveaux champs
extra(select=None, where=None, params=None, tables=None, order_by=None, select_params=None)

# Ignore des colonnes dans la requete SQL
defer(*fields)¶	

# Sélectionne uniquement les champs indiqués pour la reqête SQL
only(*fields)¶

# Indique la base de données à exploiter
using(alias)

# Retourne un queryset qui bloquera les lignes jusqu'à la fin de la transaction, générant un SELECT ... FOR UPDATE SQL statement sur les bases de données qui le supporte.
select_for_update(nowait=False)	

# Execute une requete SQL et retourne un modèle
raw(raw_query, params=None, translations=None)
```

## Les méthodes qui NE retournent PAS un queryset

```python
# Retourne un objet suivant les paramètres indiqués
get(**kwargs)

# Créer un objet
create(**kwargs)

# Récupère un objet ou le crée
get_or_create(defaults=None, **kwargs)

# Modifie un objet ou le crée
update_or_create(defaults=None, **kwargs)

# Insert en une seule fois une liste d'objets dans la base
bulk_create(objs, batch_size=None)	

# Compte le nombre d'occurences
count()

# Prend une liste de clé primaire et retourne les objets associés
in_bulk(id_list)

# Retourne un itérateur
iterator()

# Retourne le dernier objet dans la table
latest(field_name=None)

# Retourne l'objet dans la base le plus récent
earliest(field_name=None)

# Retourne le premier objet du queryset
first()	

# Retourne le dernier objet du queryset
last()

# Retourne un dictionnaire des valeurs regroupées telles que sum, count, average, etc.
aggregate(*args, **kwargs)	

# Retourne True si le queryset contient un résultat
exists()

# Modifier la valeur d'un champ
update(**kwargs)

# Execute une requete SQL delete sur toutes les lignes dans le queryset
delete()

# Retourne le manager
as_manager()
```

## Les champs de recherche

```python
# Exacte correspondance. Si un None est demandé, la recherche sera Null au niveau SQL
exact

# Insensible à la casse (qu'importe les majuscules ou les minuscules). ILIKE "DATA" est utilisé au niveau SQL
iexact	

# Contient tel élément. LIKE '%DATA%'
contains	

# Contient tel élément quelque soit la casse ILIKE '%DATA%'
icontains	

# Est dans la liste indiqué. exemple .filter(id__in=[1, 2, 3]) en SQL: WHERE id IN (1, 2, 3)
in	

# Plus grand que exemple: filter(id__gt=4) en sql: WHERE id > 4
gt	

# Plus grand ou égal
gte	

# Plus petit que
lt	

# Plus petit ou égal
lte	

# Commence par. en sql LIKE 'DATA%'
startswith

# Insensible à la casse. en slq ILIKE 'DATA%'
istartswith

# Se termine par. en SQL LIKE '%DATA'
endswith

# Insensible à la casse. en SQL: ILIKE '%DATA'
iendswith

# Intervalle de date. exemple: filter(date_creation=(start_date, end_date))
range

# Recherche par année. exemple: filter(date_creation__year=2019)
year

# Recherche par mois. exemple: filter(date_creation__month=10)
month

# Recherche par jour. exemple: filter(date_creation__day=10)
day	

# Recherche par jour dans la semaine
week_day

# Recherche par heure
hour

# Recherche par minute
minute	

# Recherche par seconde
second

# Recherche par valeur Null. exemple: filter(date_creation__isnull=True)
isnull	

# Recheche fonctionnant que sur MySQL utilisant la recherche full-text: filter(name__search="+Tshirt -product Short")
search

# Recherche avec une expression régulière. exemple: Product.objects.get(name__regex=r'^(PR?|TR) +')
regex

# Idem avec insensibilité à la casse
iregex
```

## Les fonctions de regroupement / calcul

```python
# Moyenne
Avg

# Nombre occurences
Count

# Maximum
Max

# Minimum
Min

# Ecart-type
StdDev

# Somme
Sum

# Variance
Variance
```

### Exemple

```python
>>> from django.db.models import Count

>>> p = Product.objects.annotate(nb_items=Count("product_item")).get(pk=1)
>>> p.nb_items
2
```

```python
>>> Product.objects.filter(pk=1)
[Product object]
>>> Product.objects.filter(pk=1).values()
[{'code': u'a0', 'name': u'Tshirt', 'price_ht': Decimal('25'), 'date_creation': datetime.datetime(2010, 9, 7, 12, 55, 55, 935974, tzinfo=), 'price_ttc': Decimal('30'), u'id': 1}]
>>> Product.objects.filter(pk=1).values_list()
[(1, u'Tshirt', u'a0', Decimal('25'), Decimal('30'), 0, datetime.datetime(2019, 9, 7, 12, 55, 55, 935974, tzinfo=))]
>>> Product.objects.filter(pk=1).values("code")
[{'code': u'a0'}]
>>> Product.objects.filter(pk=1).values_list("code")
[(u'a0',)]
```

```python
>>> p = Product.objects.extra(select={'items_count': 'SELECT COUNT(*) FROM backoffice_productitem WHERE backoffice_productitem.product_id = backoffice_product.id'})
>>> p[0].items_count
2
```


## L'objet Q & F

```python
#Les requètes de base proposées par l'ORM Django reste simple et donc limité. Lorsque vous chainez les méthodes, l'opérateur "AND" sera utilisé, si vous voulez utiliser l'opérateur "OR", il vous faudra utiliser l'objet Q


from django.db.model import Q


# Exemple d'utilisation:
Product.objects.filter(Q(id=1))

# Avec l'opérateur AND:
Product.objects.filter(Q(id=1) & Q(name="TEST"))

# Et avec l'opérateur OR:
Product.objects.filter(Q(id=1) | Q(id=2))

# Utiliser le notion de contraire:
Product.objects.filter(~Q(id=1))
```

```python
# L'objet F vous permet d'incrémenter des valeurs d'une colonne:

Product.objects.filter(code="0001").update(stock=F("stock")+1)
```