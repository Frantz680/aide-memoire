<template>
    <Navigation pageName="DeclarationsListe" />
    <Spinner :loading="Loading" />
    <div class="container main-content">

        <header class="jumbotron">
            <h3>Modèles déclarations</h3>
        </header>

        <div class="select">
            <label for="annee-select">Années</label>
            <br>
            <!-- <select v-model="selected" @change="PostDeclaListeModif(annee)"> -->
            <select class="form-select form-select-lg mb-3" v-model="selected" @change="GetDeclaListeModif($event)" >
                <option disabled value="">Selectionner une date</option>
                <option v-for="annee in UniqueAnnee" :value="annee" v-bind:key="annee">{{ annee }} </option>

            </select>
        </div>

        <EasyDataTable :headers="TableUsersHeaders" :items="Declarations" :rows-per-page=100 :rows-items=[100] buttons-pagination
            alternating table-class-name="customize-table" rowsPerPageMessage="Résultats par page" theme-color="#002f64a6" 
            header-text-direction="center" body-text-direction="center"
            rowsOfPageSeparatorMessage="sur" emptyMessage="Aucune donnée" class="table-success" style="overflow: hidden !important;">

            <!-- Code -->
            <template #item-code="item">
                <span class="overme">{{ item.code }}</span>
                <span v-if="item.code.length > 27" class="tooltip">{{ item.code }}</span>
            </template>

            <!-- Details -->
            <template #item-details="item">
                <font-awesome-icon icon="fa-solid fa-circle-xmark" class="TxtRouge" v-if="!item.details" />
                <font-awesome-icon icon="fa-solid fa-circle-check" class="TxtVert" v-if="item.details" />
            </template>

            <!-- Libelle -->
            <template #item-libellePerso="item">
                    <div v-if="!item.edition" v-bind:id="item.idModeleDeclarationLigne">
                        <span v-if="!item.modif">
                            <Popper hover arrow  content="Modifier" placement="top">
                                <font-awesome-icon v-on:click="actif(item.idModeleDeclarationLigne)" icon="edit" class="clickable background-red" />
                            </Popper>
                        </span>
                        <span v-else>
                            <Popper hover arrow  content="Modifier à nouveau" placement="top">
                                <font-awesome-icon v-on:click="actif(item.idModeleDeclarationLigne)" icon="edit" class="clickable background-blue"/>
                            </Popper>
                        </span>
                        <div class="overme">
                            {{ item.libellePerso }}
                        </div>
                        <span  v-if="item.libellePerso.length > 27" class="tooltip">
                            {{ item.libellePerso }}
                        </span>
                    </div>

                    <input  v-else type="text" v-bind:value="item.libellePerso" v-bind:id="item.idModeleDeclarationLigne" v-on:keyup.enter="onEntrer(item.idModeleDeclarationLigne, 'libelle')">
            </template>

            <!-- Bloc -->
            <template #item-bloc="item">
                <input class="table-input" type="number" v-bind:id="item.idModeleDeclarationLigne" v-bind:value="item.bloc" @change="onEntrer(item.idModeleDeclarationLigne, 'bloc')"/>
            </template>

        </EasyDataTable>

    </div>
</template>

<script>
import Navigation from "@/components/Nav.vue";
import Spinner from "@/components/Spinner.vue";
import { getUrlWs } from "@/utilities";
import authHeader from '@/services/auth-header';
import { set } from "lodash";

export default {
    name: 'modeleDeclaration',
    data() {
    return {
        Declarations: [],
        UniqueAnnee: [],
        anneeFilter: null,
        selected: null,
        rowsPage: null,
        TableUsersHeaders: [
            {
                value: 'idModeleDeclarationLigne',
                text: 'Id',
                sortable: true
            },
            {
                value: 'code',
                text: 'Code',
                sortable: true
            },
            {
                value: 'couleur',
                text: 'Couleur',
                sortable: true
            },
            {
                value: 'details',
                text: 'Détails',
                sortable: true
            },
            {
                value: 'libellePerso',
                text: 'Libelle personnel',
                sortable: true
            },
            {
                value: 'bloc',
                text: 'Bloc',
                sortable: true
            }
        ],
        }
    },

    computed: {
    },

    components: {
        Navigation, Spinner,
    },
    methods: {
        getListAnnee(){
            this.$http
                .get(getUrlWs() + 'Declaration/getListAnnee', { headers: authHeader() })
                .then(response => {
                    
                    // On recupere la reponse
                    let listAnnee = response.data;

                    // On recuperer les années uniques
                    this.UniqueAnnee = listAnnee.filter(this.isUnique);

                    // On declare l'année a null
                    let anneeMax = null;

                    // On appelle la fonction
                    this.GetDeclaListe(anneeMax);

                }).catch((err) => {

                    console.log(err);

                    var msgErr = err;
                    if (err.response && err.response.data) {
                        msgErr = err.response.data;
                    }
                    this.$toast.error(msgErr);
                    this.Loading = false;
                });
        },
        GetDeclaListe(anneeMax) {
            this.Loading = true;

            // On converti l'objet en array
            let arrayAnnee = Object.values(this.UniqueAnnee);

            if(anneeMax == null){
                // On recupere l'année la plus grande
                anneeMax = Math.max(...arrayAnnee);
            }


            this.$http
                .get(getUrlWs() + 'Declaration/getModeleDeclaration/' + anneeMax, { headers: authHeader() })
                .then(response => {
                    
                    // On ajouter la valeur au select
                    this.selected = anneeMax;

                    // On ajout les déclartions
                    this.Declarations = response.data.listModeleDeclarationRequete;

                    this.Loading = false;

                    this.Declarations.forEach( item => {
                        item.edition = false;
                    }
                )
                
                }).catch((err) => {

                    var msgErr = err;
                    if (err.response && err.response.data) {
                        msgErr = err.response.data;
                    }
                    this.$toast.error(msgErr);
                    console.log(msgErr);
                    this.Loading = false;
                });
        },
        actif(id) {
            var object = this.Declarations.find( item => item.idModeleDeclarationLigne == id );

            object.edition = !object.edition;
            
        },
        onEntrer(id, cible){
            this.Loading = true;

            // On declare la variable valeur
            var valeur = 0;

            if (cible == 'bloc') {
                // On selection tous les inputs
                let tableInput = document.querySelectorAll(".table-input");

                // On boucle sur tous nos inputs
                tableInput.forEach((item) => {

                    // Si un input est egale avec notre id
                    if(item.id == id){

                        // On lui donne la valeur de l'item
                        valeur = item.value;

                    }
                })
            }
            else {
                // On recupere la valeur du libelle
                valeur = document.getElementById(id).value;
            }
            

            // Param
            let param = {
                Id : id,
                Valeur : valeur,
                Cible : cible,
            }

            this.$http
            .post(getUrlWs() + 'Declaration/postModeleDeclarationSave', param, { headers: authHeader() })
            .then(response => {

                console.log(response.data);

                // On appelle la fonction avec en parametre l'année
                this.GetDeclaListe(this.anneeFilter);
            
            }).catch((err) => {

                console.log(err);

                var msgErr = err;
                if (err.response && err.response.data) {
                    msgErr = err.response.data;
                }
                this.$toast.error(msgErr);
                this.Loading = false;
            });
        
        },
        isUnique(item, position, array) {
            return array.indexOf(item) === position;
        },
        GetDeclaListeModif(paramAnnee){

            this.anneeFilter = parseInt(paramAnnee.target.value);

            // On appelle la fonction avec le param année
            this.GetDeclaListe(parseInt(paramAnnee.target.value));

        }

    },
    mounted() {
        this.getListAnnee()
    }
}


</script>

<style lang="scss" scoped>
@import "@/scss/variables";
@import "@/scss/popper";

.container {
    height: auto;
}

.background-red {
    color: rgb(255, 60, 60) !important;
}

.background-blue {
    color: rgba(0, 47, 100);;
}

.custom-tooltip {
  --bs-tooltip-bg: var(--bs-primary);
}

.table-input {
    background: transparent;
    border-left: 1px solid rgba(255, 255, 255, .3);
    border-top: 1px solid rgba(255, 255, 255, .3);
    border: none;
    border-radius: 50px;
    backdrop-filter: blur(5px);
    -webkit-backdrop-filter: blur(5px);
    -moz-backdrop-filter: blur(5px);
    transition: all 0.5s ease-out;
    text-align: center;
    table-layout: fixed; 
    overflow: hidden;
    white-space: nowrap;
    text-overflow: ellipsis;
}

.table-input:hover {
    background: rgba(255, 255, 255, .1);
    box-shadow:  4px 4px 60px 8px rgba(0, 0, 0, .2);
}

.table-input:focus {
    background: rgba(255, 255, 255, .5);
    box-shadow:  4px 4px 60px 8px rgba(0, 0, 0, .2);
}


.customize-table {
    --easy-table-row-border: 1px solid #445269;

    --easy-table-header-background-color: rgba(0, 47, 100, 0.651);
    --easy-table-header-font-size: 20px;
    --easy-table-header-font-color: #ffffff;


    --easy-table-body-row-height: 100px;
    --easy-table-body-row-width: 100px;
    --easy-table-body-row-font-size: 14px;

    --easy-table-footer-background-color: rgba(0, 47, 100, .65);
    --easy-table-footer-font-color: #ffffff;
    --easy-table-footer-font-size: 14px;
    --easy-table-footer-padding: 0px 10px;
    --easy-table-footer-height: 50px;

    --easy-table-body-row-hover-font-color: #2d3a4f;
    --easy-table-body-row-hover-background-color: #eee;

    --easy-table-scrollbar-track-color: #2d3a4f;
    --easy-table-scrollbar-color: #2d3a4f;
    --easy-table-scrollbar-thumb-color: #4c5d7a;;
    --easy-table-scrollbar-corner-color: #2d3a4f;
}

.text-align-right {
    text-align: right;
}

.select {
    padding: 7px;
    width: 200px;
    border: solid 2px rgba(0, 47, 100, 0.651);
    box-shadow: 10px 2px 10px -6px rgb(0 0 0 / 20%);
}

.overme {
    display:inline-block;
    width:200px;
    white-space: nowrap;
    overflow:hidden !important;
    text-overflow: ellipsis;
    vertical-align: bottom;
    padding-left: 5px;
}

.overme:hover:after {
   cursor: pointer;
}

.tooltip {
    width: 100%;
    bottom: 55%;
    visibility: hidden;
    background-color: #fff;
    padding: 20px;
    -webkit-box-shadow: 0 0 50px 0 rgba(0,0,0,0.3);
    opacity: 0;
    transition: opacity 0.8s ease; 
    transition: all 0.5s ease-out;
    border-radius: 5px;
}

.overme:hover + .tooltip {
    visibility: visible;
    transition: opacity 0.8s ease;
    transition: all 0.5s ease-out;
    opacity: 1;
}

</style>
