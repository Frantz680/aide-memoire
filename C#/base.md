# Les bases de C#

## Les différents types de varibles

```c#
// Nombre entier
int

// Nombre à virgule flottante
float // le type  float  donne une approximation de 6 à 9 chiffres
double // le  double  donne une approximation de 15 à 17 chiffres
decimal // le  décimal  une approximation de 28 à 29 chiffres

// Char
char

// Texte
string

// Booléan
bool

// Constante
const int
const string
...

// Exemple
int myNum = 5;
double myDoubleNum = 5.99D;
char myLetter = 'D';
bool myBool = true;
string myText = "Hello";
```

## Les différents types d'opérateurs

```c#
// Addtion
+
+=

// Soustraction
-
-=

// Multiplication
*
*=

// Division
/
/=
```

```c
int a = 10;
double b = 4;
int c = a / (int) b; //-> c contient 2, car a/(int) b est une division entière

int a = 10;
int b = 4;
double c = a / (double) b; //-> c contient 2,5, car la valeur de b est convertie en double
```