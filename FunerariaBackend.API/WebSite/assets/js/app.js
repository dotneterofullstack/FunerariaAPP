(function() {
    'use strict';

    angular.module('funerariaApp', [
        "ui.router"
    ])

    .config(["$stateProvider",
        "$urlRouterProvider",
        function($stateProvider, $urlRouterProvider) {

            $stateProvider
                .state("catalogos", {
                    url: "/catalogos",
                    abstract: true,
                    templateUrl: "assets/partials/catalogos/index.html"
                })

                .state("catalogos.paquetes", {
                    url: "/paquetes",
                    templateUrl: "assets/partials/catalogos/paquetes.html",
                    controller: "paquetesCtl"
                })

                .state("catalogos.cargos", {
                    url: "/cargos",
                    templateUrl: "assets/partials/catalogos/cargos.html",
                    controller: "cargoCtl"
                })
                
                .state("catalogos.asesores", {
                    url: "/asesores",
                    templateUrl: "assets/partials/catalogos/asesores.html",
                    controller: "asesoresCtl"
                })
    }])

    .run(["$rootScope",
        function($rootScope) {
            $rootScope.Configuracion = {
                RutaApi: "../api/"
            };

            $rootScope.EstadoVistaEnum = {
                Listado: 0,
                Edicion: 1,
                Agregado: 2
            }
        }])
})();