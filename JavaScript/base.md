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






## Les fonctions

### Fonctions avec arguments infini ( le Rest parameter )

```js
//Exemple

function addition(...nombres) {

    let resultat = 0;

    nombres.forEach(nombre =>{
        resultat += nombre;
    });

    console.log(resultat);
}

addition(4, 9, 5, 415, 78, 54);

```

### Les fonctions récursive

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

```js
//Resumer

let fruits = ['pomme', 'banane', 'poire', 'fraise']

fruits.length  // retourne le nombre d'éléments dans le tableau (ici retourne 4)

fruits[0] // sélectionne le premier élément

fruits[length - 1] // sélectionne le dernier élément

fruits.push('pamplemousse') // ajoute un élément à la fin du tableau

fruits.unshift('pamplemousse') // ajoute un élément au début du tableau

fruits.pop() // supprime le dernier élément

fruits.shift() // supprime le premier élément

fruits.indexOf('banane') // retourne l'index d'un élément

fruits.join() // concatène les éléments dans une chaîne de caractères avec virgules, mais il est possible de spécifier un autre séparateur dans les paranthèses

fruits.slice() // crée une copie du tableau (à associer à une autre variable donc)

fruits.splice([début], [nbASupprimer], [élément(s)]) // retire, remplace ou ajoute des éléments.
// Début : l'index à partir duquel commencer le changement, si négatif, part de la fin du tableau
// nbASupprimer : un entier indiquant le nombre d'éléments à retirer ou remplacer
// Element(s) : les éléments à ajouter à partir du début précisé. Si aucun élément n'est spécifié, alors n'en ajoutera pas.
```

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

// Récuperer l'index
console.log(monTableau.indexOf('un')) // 0

// Le tableau devient une chaine de caractere
console.log(monTableau.join()) // un,deux,trois,quatre
console.log(monTableau.join(', ')) // un, deux, trois, quatre
console.log(monTableau.join(' / ')) // un / deux / trois / quatre

// Splice
console.log(monTableau.splice(0, 0, 'random', 'pie')) // ['random', 'pie', 'un', 'deux', 'trois', 'quatre']
console.log(monTableau.splice(1, 0, 'random', 'pie')) // ['un', 'random', 'pie', 'deux', 'trois', 'quatre']
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
console.log(monTableau2D);
//     ['Jeff', 'Bill'],
//    ['Zuckerberg','Bezos', 'Gates'],


// Le tableau devient une chaine de caractere
let monTableau2D = [
    ['Mark', 'Jeff', 'Bill'],
    ['Zuckerberg','Bezos', 'Gates']
];

console.log(monTableau2D.join()); // Mark,Jeff,Bill,Zuckerberg,Bezos,Gates
console.log(monTableau2D.join(', ')) ;// Mark,Jeff,Bill, Zuckerberg,Bezos,Gates
console.log(monTableau2D.join(' / ')); // Mark,Jeff,Bill / Zuckerberg,Bezos,Gates

console.log(monTableau2D[0].join(' / ')); // Mark / Jeff / Bill 


// Splice
console.log(monTableau2D.splice(0, 1)); // ['Zuckerberg','Bezos', 'Gates']
console.log(monTableau2D[0].splice(0, 1)); // [['Jeff', 'Bill'], ['Zuckerberg','Bezos', 'Gates']]
console.log(monTableau2D.splice(2, 0, ['30', '45', '70'])); // [['Mark', 'Jeff', 'Bill'], ['Zuckerberg','Bezos', 'Gates'], ['30', '45', '70']]
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
console.log(monTableauAssociatif);
//{
//    'prenom' : 'Mark',
//    'nom' : 'Zuckerberg',
//    'nationalite' : 'Américaine'
//}

// Le tableau devient une chaine de caractere
let chaine = '';

for (const valeur in monTableauAssociatif){

    chaine += (valeur + ' : ' + monTableauAssociatif[valeur] + `\n`) 
}

console.log(chaine) 
// prenom' : 'Mark' 
// 'nom' : 'Zuckerberg',
// 'nationalite' : 'Américaine'

// Function qui convertir un tableau en chaine
function convTableauInString(tableau){
    let chaine = '';

    for (const valeur in tableau){

        chaine += (valeur + ' : ' + tableau[valeur] + `\n`) 
    };

    return chaine;
};

console.log(convTableauInString(monTableauAssociatif))

```


## Les boucles

### For in

```js
let panier = ['fraise', 'banane', 'poire'];

for (const fruit in panier) {
    console.log(fruit); // 0 1 2
    console.log(panier[fruit]); // fraise banane poire
    panier[fruit] = 'pomme'
};

console.log(panier) // pomme pomme pomme
```

### For of

```js
let panier = ['fraise', 'banane', 'poire'];

for (const fruit of panier) {
    console.log(fruit); // fraise banane poire
    console.log(panier.indexOf(fruit)); // 0 1 2
};
```

### ForEach

```js
let listeDePays = ['France', 'Belgique', 'Japon', 'Maroc'];

listeDePays.forEach(function(pays){
    console.log(pays); // France Belgique Japon Maroc
});

listeDePays.forEach(pays => console.log(pays));// France Belgique Japon Maroc
```

## Fonction

### Fonction fléchées

```js
let maFonction = () => {
    console.log('test');
};
let maFonction = () => console.log('test');

let maFonction = parametre => {
    console.log('test 1 param');
};
let maFonction = parametre => console.log('test 1 param');

let maFonction = (parametre, autreParametre) => {
    console.log('test 2 param');
};
let maFonction = (parametre, autreParametre) => console.log('test 2 param');

maFonction();
```