# Les bases du JS

## Les variables

```js
// 
let variableLet = 1;

// 
var variableVar = 1;

//
const variableConst = 1;
```

### Les différents types d'opérateurs

```js
// Addtion
+
+=

// Soustraction
-
-=

let numberOfLikes = 10;
numberOfLikes++;  // cela fait 11
numberOfLikes--; // et on revient à 10

// Multiplication
*
*=

// Division
/
/=

let numberOfCats = 2;
numberOfCats *= 6;  // numberOfCats vaut maintenant 2*6 = 12;
numberOfCats /= 3;  // numberOfCats vaut maintenant 12/3 = 4;
```

### La porté des variables

```js
let variableLet = "globale";
var variableVar = "globale";

if(true) {

    let variableLet = "locale";
    var variableVar = "locale";

    console.log("let : " + variableLet); // locale
    console.log("var : " + variableVar); // locale

}

console.log("let : " + variableLet); // globale
console.log("var : " + variableVar); // locale
```

## Les fonctions récursive

```js
// Un concept qui fait qu'on appelle une fonction dans laquelle nous sommes déjà

// Exemple

function timer(secondes) { // 10

    if(secondes > 0) {
        console.log(secondes);
        timer(secondes - 1); // 9

        // afficher 9
        // timer(8)

        // afficher 8
        // timer(7)

        // etc
    }
    else {
        console.log(secondes);
    }
}

timer(10)

// Sortie
// 10
// 9
// 8
// 7
// 6
// 5
// 4
// 3
// 2
// 1
// 0
```

## Les tableaux

### Tableau simple

```js
// Créer un tableau de différentes façon
let monTableau = New Array('un', 'deux', 'trois');
let monTableau = Array('un', 'deux', 'trois');
let monTableau = ['un', 'deux', 'trois']

// Accéder à un élément
console.log(monTableau[0]); // un
console.log(monTableau[monTableau.length - 1]); // trois

// Ajouter un élément
monTableau.push('quatre');
montTableau.unshift('zero');
console.log(monTableau); // ['zero', 'un', 'deux', 'trois', 'quatre']

// Supprimer des éléments
monTableau.pop();
console.log(monTableau) // ['zero', 'un', 'deux', 'trois']

monTableau.shift();
console.log(monTableau) // ['un', 'deux', 'trois']
```

### Tableau à plusieurs dimensions

```js
// Créer un tableau deux dimenssions
let monTableau2D = New Array(
    Array('Mark', 'Jeff', 'Bill'),
    Array('Zuckerberg','Bezos', 'Gates')
);

let monTableau2D = [
    ['Mark', 'Jeff', 'Bill'],
    ['Zuckerberg','Bezos', 'Gates']
];


// Accéder à un élément
console.log(monTableau2D[0][0]); // Mark
console.log(monTableau2D[1][1]); // Bezos


// Ajouter un élément
monTableau2D.push('test');
console.log(monTableau2D); 
//     ['Mark', 'Jeff', 'Bill'],
//    ['Zuckerberg','Bezos', 'Gates'],
//      test

monTableau2D[0].push('test');
console.log(monTableau2D); 
//     ['Mark', 'Jeff', 'Bill', 'test],
//    ['Zuckerberg','Bezos', 'Gates'],

monTableau2D[0].unshift('test');
console.log(monTableau2D); 
//     ['test', 'Mark', 'Jeff', 'Bill'],
//    ['Zuckerberg','Bezos', 'Gates'],


// Supprimer des éléments
monTableau2D.shift();
console.log(monTableau2D)// ['Zuckerberg','Bezos', 'Gates'],

let monTableau2D = [
    ['Mark', 'Jeff', 'Bill'],
    ['Zuckerberg','Bezos', 'Gates']
];

monTableau2D[0].shift();
console.log(monTableau2D)
//     ['Jeff', 'Bill'],
//    ['Zuckerberg','Bezos', 'Gates'],
```

### Tableau associatif

```js
// Créer un tableau associatif
let monTableauAssociatif = {
    'prenom' : 'Mark',
    'nom' : 'Zuckerberg',
    'poste' : 'PDG de Facebook'
};

// Accéder à un élément
console.log(monTableauAssociatif['poste']); // PDG de Facebook

// Ajouter un élément
monTableauAssociatif['nationalite'] = 'Américaine';
console.log(monTableauAssociatif); 
//{
//    'prenom' : 'Mark',
//    'nom' : 'Zuckerberg',
//    'poste' : 'PDG de Facebook',
//    'nationalite' : 'Américaine'
//}

// Supprimer des éléments
delete(monTableauAssociatif.poste);
console.log(monTableauAssociatif)
//{
//    'prenom' : 'Mark',
//    'nom' : 'Zuckerberg',
//    'nationalite' : 'Américaine'
//}
```
