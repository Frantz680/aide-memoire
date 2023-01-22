# Interface Admin

## Les options

```python
# Une liste d'actions sur la page des listings
action

# L'emplacement des actions
action_on_top

# Idem
action_on_bottom

# Affiche un compteur à côté des action (True par défaut)
action_selection_counter

# Listing des items avec éclatement des dates
date_hierarchy

# Champs à exclure
exclude

# Champs à afficher
fields

# Créer un fieldset
fieldset

# Filtre horizontal pour le many-to-many
filter_horizontal

# Filtre vertical pour le many-to-many
filter_vertical

# Associer un formulaire
form

# Permet d'écraser des champs
formfield_overrides

# Liste d'autre(s) ModelAdmin associé à celui-ci
inlines

# champs affiché par défaut
list_display

# Champs qui pointent vers la fiche de l'item
list_display_links

# Champs modifiable depuis la page de listing
list_editable

# Champs que l'on peut filtrer dans la page listing
list_filter

# Nombre d'items affichables lors de l'action "Show All" (200 par défaut)
list_max_show_all

# Nombre d'items par page
list_per_page

# Dire à Django d'utiliser selected_related() pour les champs indiqués
list_select_related

# Trier en fonction des champs indiqués
ordering

# Par défaut django.core.paginator.Paginator est utilisé
paginator

# Rempli un champs en même temps qu'un autre (utilisé par exemple par un slug)
prepopulated_fields	

# Conserve les filtres en mémoire
preserve_filters	

# Remplace le select par des boutons radio
radio_fields	

# Remplace le select par un input texte
raw_id_fields	

# Un champ en mode lecture seule
readonly_fields	

# Lors de la sauvegarde d'un objet, au lieu d'une modification il y a création
save_as	

# Créer un search box dans la page de listing
search_fields	

# Permet de créer un lien de l'objet vers le front
view_on_site	

# Path du template d'ajout
add_form_template	

# Path du template de modification
change_form_template	

# Path du template de listing
change_list_template

# Path du template de confirmation de suppression
delete_confirmation_template	

# Path du template suppression des éléments sélectionnés
delete_selected_confirmation_template	

# Path de l'historique de l'objet
object_history_template	
```

