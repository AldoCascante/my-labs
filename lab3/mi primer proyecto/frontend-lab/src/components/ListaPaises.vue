<template>
    <div class="container mt-5">
        <h1 class="display-4 text-center">Lista de países</h1>
    </div>

    <div class="row justify-content-end">
        <div class="col-2"> 
            <a href="/pais">
                <button type="button" class="btn btn-outline-secondary float-right"> Agregar país </button> 
            </a>
        </div>
    </div>

    <div class="container mt-5">
        <table class="table is-bordered is-striped is-narrow is-hoverable is-fullwidth">
            <thead>
                <tr>
                    <th>Nombre</th>
                    <th>Continente</th>
                    <th>Idioma</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(pais, index) of paises" :key="index">
                    <td>{{pais.nombre}}</td>
                    <td>{{pais.continente}}</td>
                    <td>{{pais.idioma}}</td>
                    <td>
                        <button class="btn btn-secondary btn-sm">Editar</button>
                        <button v-on:click="deleteCountry(index)" class="btn btn-danger btn-sm">Eliminar</button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    import axios from "axios";
    export default {
     name:"ListaPaises",
     data() {
        return {
            paises: [
                { nombre: "Costa Rica", continente: "América", idioma:"Español" },
                { nombre: "Japón", continente: "Asia", idioma: "Japonés" },
                { nombre: "Corea del Sur", continente: "Asia", idioma:"Coreano" },
                { nombre: "Italia", continente: "Europa", idioma: "Italiano" },
                { nombre: "Alemania", continente: "Europa", idioma: "Alemán" },
            ],
        };
     },
     methods: {
        deleteCountry(index) {
            this.paises.splice(index, 1)
        },

        obtenerTareas() {
            axios.get("https://localhost:7121/api/Paises").then((response) => //7121
            { this.paises = response.data;
                console.log(this.paises);
             });
        },
     },
     
     created: function () { 
        this.obtenerTareas();
     },
    }
</script>

<style lang="scss" scoped>

</style>