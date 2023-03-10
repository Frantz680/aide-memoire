# DOM

Document Object Model

## Résumer

```js
// Accéder aux éléments
getElementsByTagName() // Sélectionne tous les éléments avec la balise entre parenthèses

getElementById() // Sélectionne un seul élément : le premier ayant l'ID entre parenthèses

getElementsByClassName() // Sélectionne tous les éléments avec la classe entre parenthèses

querySelector() // Sélectionne un seul élément : celui avec le sélecteur entre parenthèses

querySelectorAll() // Sélectionne tous les éléments avec le sélecteur entre parenthèses



// Modifier les éléments
textContent // Modifie le texte d'un élément

innerHTML // Modifie l'HTML d'un élément



// Ajouter et supprimer des éléments
createElement() // Crée un élément

prepend() // Ajoute l'élément entre parenthèses devant l'élément cible

append() // Ajouter l'élément entre parenthèses derrière l'élément cible (peut contenir du texte)

appendChild() // Ajouter l'élément entre parenthèses derrière l'élément cible (ne peut pas contenir du texte)

insertBefore() // Insère un élément avant l'élément cible



// Modifier le style d'un élément
style.propriété // Modifie la propriété CSS spécifiée, par exemple : style.color = "orange"

className // Modifie les classes d'un élément
```






## Accéder aux éléments du DOM

```js
// Récuperer le nom d'une balise
document.getElementsByTagName('header');

// Récuperer l'id (Element sans S)
document.getElementById('logo');

// Récuperer une classe
document.getElementsByClassName('container');

// Sélectionner n'importe qu'elle éléments 
document.querySelector('h1'); // Balise
document.querySelector('.h1'); // Classe
document.querySelector('#h1'); // ID

// Sélectionner tous les éléments
document.querySelectorAll('p'); // Balise
document.querySelectorAll('.p'); // Classe
document.querySelectorAll('#p'); // ID
```





## Modifier un élément

```js
let h1 = document.querySelector('h1');

// Modifier le texte
h1.textContent = 'Hello World !';

// Rajouter une div avec du style dans notre balise h1
h1.innerHtml = "<div style='font-weight: normal'>Hello World !</div>";


// Attention
// Ceci retourne un tableau car il recuperer tous les éléments avec la balise h1
let h1 = document.getElementsByTagName('h1');
h1[0].textContent = 'Hello World !';

// Ou alors

let h1 = document.getElementsByTagName('h1')[0];
h1.textContent = 'Hello World !';
```





## Ajouter des éléments

```js
// 1ère méthode
// Ecrit a la suite de notre contenu
document.write('test');

// 2ème méthode
// Ajouter un élément brut
// On selection le body
document.body.append('test');

let h1 = document.querySelector('h1');
h1.append('test');

// 3ème méthode (celle des objets)
// Créer un élément
let helloWorld = document.createElement('div');

// Le personnaliser
helloWorld.textContent = 'Hello world !';

// L'ajouter à notre page
// Avant
document.body.append(helloWorld);
// Ou
document.body.appendChild(helloWorld); // On ne peut pas passer du texte 

// Après
document.body.insertBefore(helloWorld, document.querySelector('.container'));
// Ou
document.querySelector('.container').prepend(helloWorld);
```





## Supprimer un élément du DOM

```js
let h1 = document.querySelector('h1');
h1.remove();

// Ou

document.querySelector('h1').remove();
```






## Modifier le style des éléments

Pour chaque propriété CSS il y'a une propriété JS.

```js
// 1ère méthode : décomposée
let header = document.querySelector('header');
header.style.color = 'red';
header.style.backgroundColor = '#ffbd69';

// 2ème méthode : direct
document.querySelector('h1').style.color = '#111de5';
document.querySelector('h1').style.textAlign = 'center';

// 3ème méthode : avec une classe
document.querySelector('header').className = '.ma_new_class';
```






## Les évènements

### Résumer

```js
// Les écouteurs "on" et les propriétés JavaScript
onfocus // Quand l'utilisateur sélectionne l'élément

onchange // Quand l'utilisateur change la valeur de l'élément

onclick // Quand l'utilisateur clique sur l'élément

ondblclick // Quand l'utilisateur double-clique sur l'élément

onkeypress // Quand l'utilisateur appuie sur une touche du clavier dans l'élément



// Les évènements avec addEventListener
click // Quand l'utilisateur clique sur l'élément

mouseover // Quand l'utilisateur passe avec sa souris au-dessus d'un élément

mouseout // Quand l'utilisateur sort avec sa souris d'un élément

copy // Quand l'utilisateur copie un élément

cut // Quand l'utilisateur coupe un élément

paste // Quand l'utilisateur colle un élément
```



### onclick

```js
<a onclick="return confirm('Etes-vous sûr de vouloir supprimer cet article ?')" href="https://site.com">Supprimer cet article</a>

<button onmouseover="document.body.style.backgroundColor='orange'"
        onmouseout="document.body.style.backgroundColor='white'">Passez au-dessus de moi</button>
```


### Les propriétés JS

```js
let a = document.querySelector('a');
let button = document.querySelector('button');

// Fonction non fléchée
a.onclick = function(){
  if(confirm('Etes-vous sûr ?')) {
    location.href="https://site.com"
  }
}

// Fonction fléchée
a.onclick = () => {
  if(confirm('Etes-vous sûr ?')) {
    location.href="https://site.com"
  }
}

button.onmouseover = () => {
  document.body.style.backgroundColor = 'orange';
}

button.onmouseout = () => {
  document.body.style.backgroundColor = 'white';
}
```



### Gestionnaire d'évènements

```js
let a = document.querySelector('a');
let button = document.querySelector('button');

a.addEventListener('click', (e) => {
  if(confirm('Etes-vous sûr ?')) {
    location.href = "https://site.com";
  }
});

button.addEventListener('mouseover', () => {
  document.body.style.backgroundColor = 'orange';
});

function backgroundWhite() {
  document.body.style.backgroundColor = 'white';
}

button.addEventListener('mouseout', backgroundWhite);
button.addEventListener('mouseout', () => {
  document.body.style.fontFamily = 'arial';
});

button.removeEventListener('mouseout', backgroundWhite);
```