# Les bases

## Exemples de commandes

```js
// Affichez les bases de données
show dbs

// Connexion et/ou création d'une base de données "restaurants"
use restaurants

// Connaitre le nom de la base de données sur laquelle on est connecté
db

// Créer une collection vide "addresses"
db.createCollection('addresses')

// Voir les collections existantes de la 'db'
show collections

// Insérer un document dans une collection
db.addresses.insertOne(
  {
    name: 'Indiana Coffee',
    location: '4th Baker Street, London'
  }
)

// Voir la liste des documents dans une collection
db.addresses.find()

// Renommer une collection "addresses" en "address"
db.addresses.renameCollection("address")

// ex: Supprimer l'ensemble des documents dans une collection
db.address.deleteMany({})

// Supprimer physiquement une collection
db.address.drop()

// Supprimer la base de données actuelle
//  ⚠ Cela supprimera également toutes les collections dans cette base !
db.dropDatabase()


// Efface la console
cls
```

```bash
quit()  # équivalent : exit
```