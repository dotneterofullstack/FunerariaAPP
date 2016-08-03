(function() {
'use strict';

    angular
        .module('funerariaApp')
        .controller('paquetesCtl', paquetesCtl);

    paquetesCtl.$inject = ['$scope', "$rootScope", 'paquetesSvc'];
    function paquetesCtl($scope, $rootScope, paquetesSvc) {
        $scope.estadoVista = $rootScope.EstadoVistaEnum.Listado;
        $scope.paqueteData = null;
        $scope.paquete = {
            Id: 0,
            Descripcion: "",
            Precio: 0,
            Comision: 0,
            SoloCremacion: false
        };
        $scope.pqtFilter = {
            Id: 0,
            Descripcion: "",
            Precio: 0,
            Comision: 0,
            SoloCremacion: false
        };
        
        $scope.clear = function() {
            $scope.paquete.Id = 0;
            $scope.paquete.Descripcion = "";
            $scope.paquete.Precio = 0;
            $scope.paquete.Comision = 0;
            $scope.paquete.SoloCremacion = "";
        }

        $scope.clearFilter = function() {
            $scope.pqtFilter.Id = 0;
            $scope.pqtFilter.Descripcion = "";
            $scope.pqtFilter.Precio = 0;
            $scope.pqtFilter.Comision = 0;
            $scope.pqtFilter.SoloCremacion = "";
        }

        $scope.edit = function(paquete) {
            $scope.estadoVista = $rootScope.EstadoVistaEnum.Edicion;
            $scope.paquete.Id = paquete.Id;
            $scope.paquete.Descripcion = paquete.Descripcion;
            $scope.paquete.Precio = paquete.Precio;
            $scope.paquete.Comision = paquete.Comision;
            $scope.paquete.SoloCremacion = paquete.SoloCremacion;
        }

        $scope.cancel = function() {
            $scope.estadoVista = $rootScope.EstadoVistaEnum.Listado;
            $scope.clear();
        }

        $scope.add = function() {
            $scope.estadoVista = $rootScope.EstadoVistaEnum.Agregado;
            $scope.clear();
        }

        $scope.save = function(pqt) {
            switch ($scope.estadoVista) {
                case $rootScope.EstadoVistaEnum.Agregado:
                    paquetesSvc.post(pqt).then(function(response) {
                        $scope.paqueteData.push(response.data);
                        $scope.clear();
                        $scope.estadoVista = $rootScope.EstadoVistaEnum.Listado;
                    })
                    break;
                case $rootScope.EstadoVistaEnum.Edicion:
                    paquetesSvc.put(pqt).then(function (response) {
                        $scope.paqueteData = response.data;
                        $scope.clear();
                        $scope.estadoVista = $rootScope.EstadoVistaEnum.Listado;
                    })
                    break;
            }
        }

        $scope.delete = function(idx) {
            paquetesSvc.del($scope.paqueteData[idx].Id).then(function (response) {
                if (response.data)
                    $scope.paqueteData.splice(idx, 1);
            })
        }

        $scope.filter = function(pqtFilter) {
            paquetesSvc.get(pqtFilter).then(function (response) {
                $scope.paqueteData = response.data;
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
            paquetesSvc.get().then(function (response) {
                $scope.paqueteData = response.data;
            })
        }
    }
})();