# Les objets

## L'objet Set

```js
// Créer un objet Set
let monObjet = new Set();
// ou
let monObjet = new Set(['un', 'deux', 'trois']);

// Ajouter un élément
monObjet.add('quatre');

// Supprimer un élément
monObjet.delete('quatre');

// Supprimer tous les éléments
monObjet.clear();

// S'avoir la taille de l'objet 
monObjet.size;

// Vérifier si un élément existe (renvoie donc true ou false)
monObjet.has('un');

// Retourner tous les éléments
monObjet.values();
// ou
monObjet.keys();
```

## L'objet Map

```js
// Créer un objet Map
let monObjet = new Map();

// Ajouter un élément
monObjet.set('John Doe', {
    email: 'john@doe.com',
});

// Supprimer un élément
monObjet.delete('John Doe');

// Supprimer tous les éléments
monObjet.clear();

// Vérifier si un élément existe (renvoie donc true ou false)
monObjet.has('John Doe');

// Retourner un élément
monObjet.get('John Doe');

// Retourner tous les éléments
monObjet.values();
// ou
monObjet.keys();
```

## L'objet WeakSet

```js
// Créer un objet WeakSet
let monObjet = new WeakSet();
// ou
let monObjet = new WeakSet([objet1, objet2, objet3]);

// Ajouter un élément
monObjet.add(objet4);

// Supprimer un élément
monObjet.delete(objet4);

// S'avoir la taille de l'objet (le nombre d'éléments)
monObjet.length();

// Vérifier si un élément existe (renvoie donc true ou false)
monObjet.has(objet4);
```

## L'objet WeakMap

```js
// Créer un objet WeakMap
let monObjet = new WeakMap();

// Ajouter un élément
const objet1 = {
    nom: 'John Doe',
}
 
monObjet.set(objet1, {
    email: 'john@doe.com',
});

// Supprimer un élément
monObjet.delete(objet1);

// S'avoir la taille de l'objet (le nombre d'éléments)
monObjet.length();

// Vérifier si un élément existe (renvoie donc true ou false)
monObjet.has(objet4);

// Retourner un élément
monObjet.get(objet1);
```

## Créer un objet

```js
let chien = {
    race: 'Shiba',
    poil: 'court',
    aboyer: function(){
        console.log('Ouaf ouaf');
    }
    aboyer1: () => console.log('Ouaf ouaf 1');
}

chien.aboyer(); // Ouaf ouaf
chien.aboyer1(); // Ouaf ouaf 1
```

```js
let magicien = {
    attaquer: function(){
        console.log('Le magicien lance un sort');
    }
}

let guerrier = {
    attaquer: function(){
        console.log('Le guerrier prend son épée');
    }
}

magicien.attaquer(); // Le magicien lance un sort
guerrier.attaquer(); // Le guerrier prend son épée
```