# Raccourci

Crée un projet complet

```php
symfony new --full my_project
```


symfony new my_project          => If you are building a microservice, console application or API


Lancé le serveur

```php
symfony server:start
```


symfony console make:controller (Nom du controller)
ex => symfony console make:controller MonCompteController

symfony console                 => Permet de voir tout les commandes de symfony

make
  make:auth                                  Creates a Guard authenticator of different flavors
  make:command                               Creates a new console command class
  make:controller                            Creates a new controller class
  make:crud                                  Creates CRUD for Doctrine entity class
  make:docker:database                       Adds a database container to your docker-compose.yaml file
  make:entity                                Creates or updates a Doctrine entity class, and optionally an API Platform resource
  make:fixtures                              Creates a new class to load Doctrine fixtures
  make:form                                  Creates a new form class
  make:message                               Creates a new message and handler
  make:messenger-middleware                  Creates a new messenger middleware
  make:migration                             Creates a new migration based on database changes
  make:registration-form                     Creates a new registration form system
  make:reset-password                        Create controller, entity, and repositories for use with symfonycasts/reset-password-bundle
  make:serializer:encoder                    Creates a new serializer encoder class
  make:serializer:normalizer                 Creates a new serializer normalizer class
  make:subscriber                            Creates a new event subscriber class
  make:test                                  [make:unit-test|make:functional-test] Creates a new test class
  make:twig-extension                        Creates a new Twig extension class
  make:user                                  Creates a new security user class
  make:validator                             Creates a new validator and constraint class
  make:voter                                 Creates a new security voter class


doctrine
  doctrine:cache:clear-collection-region     Clear a second-level cache collection region
  doctrine:cache:clear-entity-region         Clear a second-level cache entity region
  doctrine:cache:clear-metadata              Clears all metadata cache for an entity manager
  doctrine:cache:clear-query                 Clears all query cache for an entity manager
  doctrine:cache:clear-query-region          Clear a second-level cache query region
  doctrine:cache:clear-result                Clears result cache for an entity manager
  doctrine:database:create                   Creates the configured database
  doctrine:database:drop                     Drops the configured database
  doctrine:ensure-production-settings        Verify that Doctrine is properly configured for a production environment
  doctrine:mapping:convert                   [orm:convert:mapping] Convert mapping information between supported formats
  doctrine:mapping:import                    Imports mapping information from an existing database
  doctrine:mapping:info
  doctrine:migrations:current                [current] Outputs the current version
  doctrine:migrations:diff                   [diff] Generate a migration by comparing your current database to your mapping information.
  doctrine:migrations:dump-schema            [dump-schema] Dump the schema for your database to a migration.
  doctrine:migrations:execute                [execute] Execute one or more migration versions up or down manually.
  doctrine:migrations:generate               [generate] Generate a blank migration class.
  doctrine:migrations:latest                 [latest] Outputs the latest version
  doctrine:migrations:list                   [list-migrations] Display a list of all available migrations and their status.
  doctrine:migrations:migrate                [migrate] Execute a migration to a specified version or the latest available version.
  doctrine:migrations:rollup                 [rollup] Rollup migrations by deleting all tracked versions and insert the one version that exists.
  doctrine:migrations:status                 [status] View the status of a set of migrations.
  doctrine:migrations:sync-metadata-storage  [sync-metadata-storage] Ensures that the metadata storage is at the latest version.
  doctrine:migrations:up-to-date             [up-to-date] Tells you if your schema is up-to-date.
  doctrine:migrations:version                [version] Manually add and delete migration versions from the version table.
  doctrine:query:dql                         Executes arbitrary DQL directly from the command line
  doctrine:query:sql                         Executes arbitrary SQL directly from the command line.
  doctrine:schema:create                     Executes (or dumps) the SQL needed to generate the database schema
  doctrine:schema:drop                       Executes (or dumps) the SQL needed to drop the current database schema
  doctrine:schema:update                     Executes (or dumps) the SQL needed to update the database schema to match the current mapping metadata