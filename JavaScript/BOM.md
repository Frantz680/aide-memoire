# Le BOM

Browser object Model

## Window

L'objet Window a pour fonction d'englober l'ensemble des fonctions, et autres objets de JavaScript. C'est de lui que tout part.

```js
// Ouvrir une fenêtre
window.open('https://....com');

// Redimensionner une fenêtre
let fenetre = window.open('https://....com', '', 'width=900, height=700');

function resize() {
fenetre.resizeTo(700, 470);
}

// Fermer une fenêtre
function resize() {
fenetre.close();
}
```




## Navigator

L'objet Navigator a pour fonction de fournir tout un tas d'informations sur le navigateur de nos utilisateurs. Pour certaines de ces informations, vous devrez demander une permission grâce à une boîte de dialogue.

```js
navigator.cookieEnabled // Les cookies sont-ils autorisés ? true
navigator.platform // Système d'exploitation ? Win32
navigator.language // Langue du navigateur ? fr-FR
``` 




## History

L'objet History a pour fonction de manipuler l'historique de nos utilisateurs.
SI l'utilisateur n'utilise pas la navigation privée.

```js
// Page précédente
history.back();

// Page suivante (si existante)
history.forward();
```




## Location

L'objet Location a pour fonction de nous donner des informations relatives aux adresses, pour, par exemple, rediriger l'utilisateur.

```js
// Recharger une page
location.reload();

// Rediriger
location.href();
```




## Screen

L'objet Screen a pour fonction de nous donner des informations relatives aux écrans.

```js
screen.availWidth; // Largeur de l'écran : 1920px
screen.availHeight; // Hauteur de l'écran : 1032px
screen.pixelDepth; // Résolution : 24
```




## Document

L'objet document permet d'agir sur le document HTML. 
Par exemple, ajouter, supprimer, etc ...