# Les models

## Les champs

```python
# Incrémente automatiquement sa valeur
AutoField

# Stocke des données binaires brutes en octets (bytes)
BinaryField

# Un champ True / False
BooleanField

# Un champ pour une chaine de caractères assez courte
CharField

# Pour du texte long
TextField

# Entiers séparés par un virgule
CommaSeparatedIntegerField

# Vérifie une valeur d'adresse valide
EmailField

# Format slug (alphanumérique + tirets)
SlugField

# Format URL
URLField

# Une date, instance de datetime.date en python
DateField

# Une date et une heure, instance python de datetime.datetime
DateTimeField

# Un nombre décimal de taille fixe, instance python de Decimal
DecimalField

# Un champ de fichier à téléverser (paramètre upload_to est obligatoire)
FileField

# Idem que FileField mais vérifie qu'il s'agit d'une image
ImageField

# Un path de fichier (paramètre path est obligatoire)
FilePathField

# Une instance de float en python
FloatField

# Une adresse ip valide IPV4 / IPV6
GenericIPAddressField

# Une adresse ip textuel type 192.168.0.1
IPAddressField

# Valeurs comprises entre -2147483648 à 2147483647 
IntegerField

# Un entier 64 bits
BigIntegerField

# Valeurs comprises entre 0 et 2147483647 
PositiveIntegerField

# Valeurs comprises entre 0 et 32767
PositiveSmallIntegerField

# Valeurs comprises entre -32768 et 32767 
SmallIntegerField

# Un champ booléen qui accepte le Null
NullBooleanField

# Format heure instance de datetime.time
TimeField


####### Relation



# Relation plusieurs-à-un
ForeignKey

# Relation plusieurs-à-plusieurs 
ManyToManyField

# Relation un-à-un 
OneToOneField
```

### Paramètres communs

```python
# Nom de la colonne dans la base de données
db_column

# Créer un index pour la colonne
db_index

# La valeur par défaut du champ
default

# Si False le champ n'est pas éditable dans admin
editable

# Texte d'aide affiché dans le formulaire
help_text

# Si True devient la clé primaire
primary_key

# Si True impossible d'avoir des doublons de valeur
unique

# Un nom plus explicite
verbose_name

# Une liste de validateurs à exécuter
validators
```


### Paramètres spécifiques


```python
# Renseigner la clé primaire
primary_key

# Autoriser la soumission d'un champ vide
blank

# Autoriser d'enregistrer en base une valeur nulle 
null

# Unique pour une date 
unique_for_date

# Unique pour un mois 
unique_for_month

# Unique pour un an 
unique_for_year

# Choix possibles 
choices
```

#### Exemples

```python
class Product(models.Model): 
    name       = models.CharField(max_length=100)
    code       = models.CharField(max_length=10, null=True, blank=True, unique=True)
    price_ht   = models.DecimalField(max_digits=8, decimal_places=2, verbose_name="Prix unitaire HT")
    price_ttc  = models.DecimalField(max_digits=8, decimal_places=2, verbose_name="Prix unitaire TTC")

# Les dates

from django.utils import timezone

class Product(models.Model):
    date_creation  =  models.DateTimeField(default=timezone.now(), blank=True, verbose_name="Date création") 

# Clé étrangères

class ProductItem(models.Model):
    product  = models.ForeignKey('Product', verbose_name="Produit")

class ProductItem(models.Model):
    attributes  = models.ManyToManyField("ProductAttributeValue", related_name="product_item")
```

