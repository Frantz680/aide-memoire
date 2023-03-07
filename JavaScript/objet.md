# Les objets

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