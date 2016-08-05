(function() {
'use strict';

    angular
        .module('funerariaApp')
        .controller('cargoCtl', cargoCtl);

    cargoCtl.$inject = ['$scope', "$rootScope", 'cargoSvc'];
    function cargoCtl($scope, $rootScope, cargoSvc ) {
        $scope.estadoVista = $rootScope.EstadoVistaEnum.Listado;
        $scope.AllCargos = null;
        
        $scope.Cargo = {
            Id: 0,
            Nombre: ""
        };

        $scope.CargoFilter = {
            Id: 0,
            Nombre: ""
        };

        $scope.clear = function() {
            $scope.Cargo.Id = 0;
            $scope.Cargo.Nombre = "";
        }

        $scope.clearFilter = function() {
            $scope.CargoFilter.Id = 0;
            $scope.CargoFilter.Nombre = "";
        }

        $scope.edit = function(cargo) {
            $scope.estadoVista = $rootScope.EstadoVistaEnum.Edicion;
            $scope.Cargo.Id = cargo.Id;
            $scope.Cargo.Nombre = cargo.Nombre;
        }

        $scope.cancel = function() {
            //Cancelar la edición o el guardado de un nuevo registro
            $scope.estadoVista = $rootScope.EstadoVistaEnum.Listado;
            $scope.clear();
        }

        $scope.add = function() {
            //Preparar la vista para agregar un nuevo registro
            $scope.estadoVista = $rootScope.EstadoVistaEnum.Agregado;
            $scope.clear();
        }

        $scope.save = function(cargo) {
            //Guardar o actualizar un registro
            switch ($scope.estadoVista) {
                case $rootScope.EstadoVistaEnum.Agregado:
                    cargoSvc.post(cargo).then(function(response) {
                        $scope.AllCargos.push(response.data);
                        $scope.clear();
                        $scope.estadoVista = $rootScope.EstadoVistaEnum.Listado;
                    })
                    break;
                case $rootScope.EstadoVistaEnum.Edicion:
                    cargoSvc.put(cargo).then(function (response) {
                        $scope.AllCargos = response.data;
                        $scope.clear();
                        $scope.estadoVista = $rootScope.EstadoVistaEnum.Listado;
                    })
                    break;
            }
        }

        $scope.delete = function(idx) {
            cargoSvc.del($scope.AllCargos[idx].Id).then(function (response) {
                if (response.data)
                    $scope.AllCargos.splice(idx, 1);
            })
        }

        $scope.filter = function(entityFilter) {
            cargoSvc.get(entityFilter).then(function (response) {
                $scope.AllCargos = response.data;
            })
        }

        $scope.reset = function() {
            $scope.clearFilter();
            $scope.clear();
            activate();
        }

        activate();

        ////////////////

        function activate() {
            cargoSvc.setApiUrl("../api/cargos");
            $scope.estadoVista = $rootScope.EstadoVistaEnum.Listado;
            cargoSvc.get().then(function (response) {
                $scope.AllCargos = response.data;
            })
        }
    }
})();