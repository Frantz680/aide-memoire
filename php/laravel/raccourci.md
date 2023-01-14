# Raccourci

## Crée un projet complet

## Lancé le serveur

```php
php artisan serve
```

## Compile le sass en css

```php
npm run watch
```

## Création d'un controller

```php
php artisan make:controller (Nom du controller)
example => php artisan make:controller MonCompteController
```

## Lance l'ajout des tables

```php
php artisan migrate
```

## Annule la dernière migration

```php
php artisan migrate:rollback
```

## Réinit les caches

```php
php artisan optimize:clear
```

## Supprime ta bdd et la recréer totalement.

```php
php artisan migrate:refresh
```

## Creer une table dans la base de données

```php
php artisan make:model (Nom de la table) --migration
```

## Permet de vider toutes sortes de cache à la fois.

```php
php artisan optimize:clear
```

## Création d'un liens storage/app/public a l'application public

```php
php artisan storage::link
```