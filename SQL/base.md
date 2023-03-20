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

/*Exemple :*/
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

``` sql
LIKE
```

``` sql
COMMIT
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
