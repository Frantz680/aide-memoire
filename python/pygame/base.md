# Les bases de PyGame

## Installer pygame

```python
pip install pygame
```

## Import la librairi

```python
import sys, pygame
```

## Init pygame

```python
pygame.init()
```

## Configuration de la fenêtre

```python
screen = pygame.display.set_mode(320, 240)
```

## Un simple programme de pygame

```python

# Import et initialiser la library pygame
import pygame
pygame.init()

# Configuration de la fenêtre
screen = pygame.display.set_mode([500, 500])

# Une boucle infini jusqu'à ce que l'utilisateur demande à quitter
running = True
while running:

    # On regarde les événements
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False

    # Background de couleur blanc
    screen.fill((255, 255, 255))

    # Dessinez un cercle bleu au centre
    pygame.draw.circle(screen, (0, 0, 255), (250, 250), 75)

    # Retourner l'affichage
    pygame.display.flip()

# Permet de quitter
pygame.quit()
```