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