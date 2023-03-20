# Les bases

## Les commandes basics

On selection une donnée 
``` sql
SELECT 
```

Spéficie la table 
``` sql
FROM 
```

Filtrer une requete avec une condition
``` sql
WHERE
```

Renomme une colonne or une table avec un alias
``` sql
AS 
```

Combine des lignes de plusieurs tables
``` sql
JOIN 
```

Combine une requete avec une condition ET
``` sql
AND
```

Combine une requete avec une condition OU
``` sql
OR
```

Spécifie le nombre maximun de résultat
``` sql
Limit
```

L'opérateur logique IN, s'utilise avec la commande WHERE pour vérifier si une colonne est égale à une des valeurs
``` sql
IN

/*Exemple :*/
SELECT nom_colonne
FROM table
WHERE nom_colonne in ( valeur1, valeur2, valeur3, ...)
```

La commande CASE est comme un switch
``` sql
CASE

#Exemple :
CASE a 
       WHEN 1 THEN 'un'
       WHEN 2 THEN 'deux'
       WHEN 3 THEN 'trois'
       ELSE 'autre'
END
```

Pour filtrer les résultats où les champs d'une colonne sont à NULL OU non
``` sql
IS NULL / IS NOT NULL

/*Exemple*/
SELECT *
FROM `table`
WHERE nom_colonne IS NULL

/*Où*/
SELECT *
FROM `table`
WHERE nom_colonne IS NOT NULL
```

Il permet d'éffectuer une recherche sur un modèle particulier
``` sql
LIKE

LIKE '%a' : le caractère “%” est un caractère joker qui remplace tous les autres caractères. Ainsi, ce modèle permet de rechercher toutes les chaines de caractère qui se termine par un “a".

LIKE 'a%' : ce modèle permet de rechercher toutes les lignes de “colonne” qui commence par un “a”.

LIKE '%a%' : ce modèle est utilisé pour rechercher tous les enregistrement qui utilisent le caractère “a”.

LIKE 'pa%on' : ce modèle permet de rechercher les chaines qui commence par “pa” et qui se terminent par “on”, comme “pantalon” ou “pardon”.

LIKE 'a_c' : : peu utilisé, le caractère “_” (underscore) peut être remplacé par n’importe quel caractère, mais un seul caractère uniquement (alors que le symbole pourcentage “%” peut être remplacé par un nombre incalculable de caractères . Ainsi, ce modèle permet de retourner les lignes “aac”, “abc” ou même “azc”.

/*Exemple :*/
SELECT *
FROM table
WHERE colonne LIKE modele
```

Commit est la commande SQL utilisée pour stocker les modifications effectuées par une transaction
``` sql
COMMIT

/*Exemple
Supprimons maintenant une ligne du tableau
*/
DELETE FROM Customer WHERE State = 'Texas';

/*
Si la session est fermée, la modification apportée en raison de la commande DELETE sera perdue
*/
DELETE from Customer where State = 'Texas';
COMMIT;
```

``` sql
ROLLBACK
```

``` sql
ALTER TABLE
```

``` sql
UPDATE
```

``` sql
DELETE
```

``` sql
INSERT
```

``` sql
DROP
```

``` sql
GROUP BY
```

``` sql
ORDER BY
```
