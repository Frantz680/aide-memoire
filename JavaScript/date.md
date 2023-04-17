## plus 1 year
new Date().setFullYear(new Date().getFullYear() + 1)
## plus 1 month
new Date().setMonth(new Date().getMonth() + 1)
## plus 1 day
new Date().setDate(new Date().getDate() + 1)


## Fonction pour calculer les semaines à partir d'une date

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
