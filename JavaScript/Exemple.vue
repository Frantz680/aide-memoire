<template>
    <div class="select">
        <label for="annee-select">Années</label>
        <br>
        <!-- <select v-model="selected" @change="PostDeclaListeModif(annee)"> -->
        <select class="form-select form-select-lg mb-3" v-model="selected" @change="GetDeclaListeModif($event)" >
            <option disabled value="">Selectionner une date</option>
            <option v-for="annee in UniqueAnnee" :value="annee" v-bind:key="annee">{{ annee }} </option>

        </select>
    </div>

    <span class="ombre">
        <EasyDataTable :headers="TableUsersHeaders" :items="Declarations" :rows-per-page=100 :rows-items=[100] buttons-pagination
            alternating table-class-name="customize-table" rowsPerPageMessage="Résultats par page" theme-color="#002f64a6"
            rowsOfPageSeparatorMessage="sur" emptyMessage="Aucune donnée" class="table-success">

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
                                <font-awesome-icon v-on:click="actif(item.idModeleDeclarationLigne)" icon="edit" class="clickable" />
                            </Popper>
                        </span>
                        {{ item.libellePerso }}
                    </div>

                    <input  v-else type="text" v-bind:value="item.libellePerso" v-bind:id="item.idModeleDeclarationLigne" v-on:keyup.enter="onEntrer(item.idModeleDeclarationLigne, 'libelle')">
            </template>

            <!-- Bloc -->
            <template #item-bloc="item">
                <input class="table-input" type="number" v-bind:id="item.idModeleDeclarationLigne" v-bind:value="item.bloc" @change="onEntrer(item.idModeleDeclarationLigne, 'bloc')"/>
            </template>

        </EasyDataTable>
    </span>

</template>

<script>
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

                    console.log(response.data)

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

            // On selection tous les inputs
            let tableInput = document.querySelectorAll(".table-input");

            // On declare la variable valeur
            var valeur = 0;

            // On boucle sur tous nos inputs
            tableInput.forEach((item) => {

                // Si un input est egale avec notre id
                if(item.id == id){

                    // On lui donne la valeur de l'item
                    valeur = item.value;
                    
                }
            })

            

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

.background-red {
    color: rgb(243, 100, 100) !important;
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
    --easy-table-header-background-color: rgba(0, 47, 100, 0.651);
    --easy-table-header-font-size: 20px;
    --easy-table-header-font-color: #ffffff;


    --easy-table-body-row-height: 50px;
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

.vue3-easy-data-table__main {
    overflow: none;
}

.text-align-right {
    text-align: right;
}

.select {
    padding: 7px;
    width: 200px;
    border: solid 2px rgba(0, 47, 100, 0.651);
    box-shadow: 20px 20px 40px -6px rgb(0 0 0 / 20%);
}

</style>
