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

## Les méthodes

```python
# Permet de créer des actions pre et post operation
save_model(request, obj, form, change)

# Permet de créer des actions pre et post delete operation
delete_model(request, obj)	

# Permet de créer des actions pre et post operation pour le formset
(request, form, formset, change)

# Permet de créer un ordre d'affichage
get_ordering(request)

# Créer la queryset de recherche
get_search_results(request, queryset, search_term)

# Permet de créer des actions pre / post operation pour les objets associés au parent
save_related(request, form, formsets, change)

# Retourne une liste des champs non éditable
get_readonly_fields(request, obejct=None)

# Retourne une liste des champs prérempli
get_prepopulated_fields(request, None)

# Retourne les champs affichés par défaut
get_list_display(request)

# Retourne les champs qui pointent vers la fiche de l'item
get_list_display_links(request, list_display)

# Retourne tous les champs
get_fields(request, obj=None)

# Retourne les fieldset
get_fieldsets(request, obj=None)

# Retourne la même séquence que l'attribut list_filter
get_list_filter(request)

# Retourne la même séquence que l'attribut search_fields
get_search_fields(request)

# Retourne la même séquence que l'attirbut inlines
get_inline_instances(request, obj=None)

# Retourne l'URL utilisé par le ModelAdmin
get_urls()

# Retourne un ModelForm utilisé par le ModelAdmin
get_form(request, obj=None, **kwargs)

# yield InlineModelAdmins pour la vue change et add
get_formsets(request, obj=None)	

# yield (Formset, InlineModelAdmin) pour la vue change et add
get_formsets_with_inlines(request, obj=None)

# Ecrase le formfield par défaut pour une clé étrangère
formfield_for_foreignkey(db_field, request, **kwargs)

# Ecrase le formfield par défaut pour un m2m
formfield_for_manytomany(db_field, request, **kwargs)

# Ecrase le formfield par défaut pour les choix multiple
formfield_for_choice_field(db_field, request, **kwargs)	

# Retourne la class ChangeList utilisé pour le listing
get_changelist(request, **kwargs)

# Retourne une classe ModelForm pour le Formset dans la page de modification
get_changelist_form(request, **kwargs)	

# Retourne une classe ModelFormSet pour la page de modification
get_changelist_formset(request, **kwargs)

# Retourne True si l'ajout d'un objet est autorisée
has_add_permission(request)	

# Retourne True si la modification d'un objet est autorisée
has_change_permission(request, obj=None)

# Retourne True si la supression d'un objet est autorisée
has_delete_permission(request, obj=None)

# Retourne un queryset de toutes les instances de modèle qui peuvent être édités
get_queryset(request)

# Envoie un messager à l'utilisateur
message_user(request, message, level=messages.INFO, extra_tags='', fail_silently=False)

# Retourne le paginator utilisé
get_paginator(queryset, per_page, orphans=0, allow_empty_first_page=True)

# Détermine le HttpResponse pour le vue add
response_add(request, obj, post_url_continue=None)

# Détermine le HttpResponse de la vue change
response_change(request, obj)

# Détermine le HttpResponse de la vue delete
response_delete(request, obj_display)

# Hook pour les données initiales du form change
get_changeform_initial_data(request)

# La vue Django pour la page ADD
add_view(request, form_url='', extra_context=None)

# La vue Django pour la page CHANGE
change_view(request, object_id, form_url='', extra_context=None)

# La vue Django pour la page CHANGELIST
changelist_view(request, extra_context=None)

# La vue Django pour la page DELETE
delete_view(request, object_id, extra_context=None)

# La vue Django pour la page HISTORY
history_view(request, object_id, extra_context=None)	
```
