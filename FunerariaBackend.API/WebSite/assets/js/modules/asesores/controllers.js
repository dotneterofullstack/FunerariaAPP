(function () {
    'use strict';

    angular
        .module('funerariaApp')
        .controller('asesoresCtl', asesoresCtl);

    asesoresCtl.$inject = ['$scope', "$rootScope", "$filter", 'asesoresSvc', 'cargoSvc', 'documentosSvc', 'estadosSvc', 'municipiosSvc'];
    function asesoresCtl($scope, $rootScope, $filter, asesoresSvc, cargoSvc, documentosSvc, estadosSvc, municipiosSvc) {
        $scope.estadoVista = $rootScope.EstadoVistaEnum.Listado;
        $scope.allAsesores = null;

        $scope.Asesor = {
            Id: 0,
            Nombre: "",
            ApellidoPaterno: "",
            ApellidoMaterno: "",
            RFC: "",
            IdCargo: 0,
            IdReferidoPor: null,
            Codigo: "",
            Documentos: [],
            Domicilios: []
        };

        $scope.AsesorFilter = {
            Id: 0,
            Nombre: "",
            ApellidoPaterno: "",
            ApellidoMaterno: "",
            RFC: "",
            IdCargo: 0,
            IdReferidoPor: null,
            Codigo: ""
        };

        $scope.cambiarSeleccionDocumento = function (documento) {
            var idx = $scope.Asesor.Documentos.indexOf(documento);

            if (idx > -1) {
                $scope.Asesor.Documentos.splice(idx, 1);
            } else {
                $scope.Asesor.Documentos.push(documento);
            }
        }

        $scope.clear = function () {
            //Aqui se limpian Las propiedades de Asesor
        }

        $scope.clearFilter = function () {
            //Aqui se limpian Las propiedades de AsesorFilter
        }

        $scope.edit = function (asesor) {
            $scope.estadoVista = $rootScope.EstadoVistaEnum.Edicion;
            //Iniciar el proceso de edición copiando las propiedades del registro seleccionado a Asesor
        }

        $scope.cancel = function () {
            //Cancelar la edición o el guardado de un nuevo registro
            $scope.estadoVista = $rootScope.EstadoVistaEnum.Listado;
            $scope.clear();
        }

        $scope.add = function () {
            //Preparar la vista para agregar un nuevo registro
            $scope.estadoVista = $rootScope.EstadoVistaEnum.Agregado;
            $scope.clear();
        }

        $scope.obtenerMunicipios = function (idEstado) {
            $scope.municipios = $filter('filter')($scope.todosMunicipios, { IdEstado: idEstado })
        }

        $scope.agregarDomicilio = function (domicilio) {
            domicilio.ID = 0;
            $scope.Asesor.Domicilios.push(domicilio);
            $scope.domicilio = {};
        }

        $scope.save = function (asesor) {
            //Guardar o actualizar un registro
            switch ($scope.estadoVista) {
                case $rootScope.EstadoVistaEnum.Agregado:
                    asesoresSvc.post(asesor).then(function (response) {
                        $scope.allAsesores.push(response.data);
                        $scope.clear();
                        $scope.estadoVista = $rootScope.EstadoVistaEnum.Listado;
                    })
                    break;
                case $rootScope.EstadoVistaEnum.Edicion:
                    asesoresSvc.put(asesor).then(function (response) {
                        $scope.allAsesores = response.data;
                        $scope.clear();
                        $scope.estadoVista = $rootScope.EstadoVistaEnum.Listado;
                    })
                    break;
            }
        }

        $scope.delete = function (idx) {
            asesoresSvc.del($scope.allAsesores[idx].Id).then(function (response) {
                if (response.data)
                    $scope.allAsesores.splice(idx, 1);
            })
        }

        $scope.filter = function (entityFilter) {
            asesoresSvc.get(entityFilter).then(function (response) {
                $scope.allAsesores = response.data;
            })
        }

        $scope.reset = function () {
            $scope.clearFilter();
            $scope.clear();
            activate();
        }

        activate();

        ////////////////

        function activate() {
            cargoSvc.setApiUrl("../api/cargos");
            asesoresSvc.setApiUrl("../api/asesores");
            documentosSvc.setApiUrl("../api/documentos");
            estadosSvc.setApiUrl("../api/estados");
            municipiosSvc.setApiUrl("../api/municipios");

            $scope.estadoVista = $rootScope.EstadoVistaEnum.Listado;

            estadosSvc.get().then(function (response) {
                $scope.estados = response.data;
            });

            municipiosSvc.get().then(function (response) {
                $scope.todosMunicipios = response.data;
            });

            asesoresSvc.get().then(function (response) {
                $scope.allAsesores = response.data;
            });

            documentosSvc.get().then(function (response) {
                $scope.documentos = response.data;
            });

            cargoSvc.get().then(function (response) {
                $scope.Cargos = response.data;
            });
        }
    }
})();