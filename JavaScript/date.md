## plus 1 year
new Date().setFullYear(new Date().getFullYear() + 1)
## plus 1 month
new Date().setMonth(new Date().getMonth() + 1)
## plus 1 day
new Date().setDate(new Date().getDate() + 1)


## Fonction pour calculer les semaines à partir d'une date

```js
function Semaine(dateDebut){
  var dateDebutFR = GetDateFormatteeFr(dateDebut); 

  // On recupere le jour, le mois et l'année
  let oneDay = dateDebutFR.substring(0,2);
  let month = dateDebutFR.substring(3,5);
  let year = dateDebutFR.substring(6,10)

  var newDate = new Date(year + "-" + month + "-" + oneDay);

  // On recupere la semaine
  var janvier = new Date(newDate.getFullYear(),0,1);
  var numberOfDays = Math.floor((newDate - janvier) / (24 * 60 * 60 * 1000));
  return Math.ceil((newDate.getDay() + 1 + numberOfDays) / 7);
}
```
## Fonction pour avoir le format JJ/MM/YYYY

```js
function GetDateFormatteeFr(d) {
  if(d==null){
    return "-";
  }
  if(typeof d=="string"){
    d= new Date(d);
  }
  var jj = (d.getDate() < 10) ? "0" : "";
  jj += d.getDate();
  var mm = (d.getMonth() + 1 < 10) ? "0" : "";
  mm += d.getMonth() + 1;
  var yyyy = d.getFullYear();
  return jj + "/" + mm + "/" +yyyy;
}
```

## Fonction pour avoir le format JJ/MM/YYYY à HH h MM

```js
function GetDateEtHeureFormatteeFr(d) {
  if(typeof d=="string" ){
    d= new Date(d);
  }

// OU
  if (typeof d === "string") {
    var parts = d.split(/[\s\/:]/);

    // parts[2] année, parts[1] - 1 mois
    // parts[0] jour, parts[3] heure, parts[4] minute, parts[5] seconde
    d = new Date(parts[2], parts[1] - 1, parts[0], parts[3], parts[4], parts[5]);
  }

  var jj = (d.getDate() < 10) ? "0" : "";
  jj += d.getDate();
  var mm = (d.getMonth() + 1 < 10) ? "0" : "";
  mm += d.getMonth() + 1;
  var yyyy = d.getFullYear();
  var hh = d.getHours();
  var MM = (d.getMinutes() < 10) ? "0" + d.getMinutes() : "" + d.getMinutes();
  return jj + "/" + mm + "/" +yyyy+" à "+hh+"h"+MM;
}
```

## Fonction pour avoir la date d'aujourd'hui

```js
function getCurrentDateHour() {
  let d = new Date;
  let annee = d.getFullYear();
  let mois = d.getMonth() + 1;
  mois = (mois < 10) ? "0"+mois : mois;
  let jour = d.getDate() < 10 ? "0" + d.getDate() : d.getDate();
  let heure = d.getHours() < 10 ? "0" + d.getHours() : d.getHours();
  let minute = d.getMinutes() < 10 ? "0" + d.getMinutes() : d.getMinutes();
  return jour+"."+mois+"."+annee+"-"+heure+"."+minute;
}
```

```js
function getVendredisDansMois(mois, annee) {
   const vendredis = [];

   // Création d'une date pour le premier jour du mois spécifié
   const dateDebut = new Date(annee, mois, 1);

   // Boucle pour parcourir tous les jours du mois
   while (dateDebut.getMonth() === mois ) {
      if (dateDebut.getDay() === 5) { // 5 correspond au vendredi (dimanche=0, lundi=1, ..., vendredi=5, samedi=6)
            vendredis.push(new Date(dateDebut).toLocaleDateString("fr"));
      }
          dateDebut.setDate(dateDebut.getDate() + 1);
      }

   return vendredis;
}
```
