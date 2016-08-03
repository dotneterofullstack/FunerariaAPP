(function() {
'use strict';

    angular
        .module('funerariaApp')
        .factory('paquetesSvc', paquetesSvc);

    paquetesSvc.$inject = ['$http', '$rootScope'];
    function paquetesSvc($http, $rootScope) {
        var apiUrl = $rootScope.Configuracion.RutaApi;
        
        var service = {
            get:get,
            post:post,
            put:put,
            del:del
        };
        
        return service;

        ////////////////
        function get(pqtFilter) { 
            return $http.get(apiUrl + "paquetes",{
                    params: pqtFilter
                });
        }

        function post(pqt) {
            return $http.post(apiUrl + "paquetes", pqt);
        }

        function put(pqt) {
            return $http.put(apiUrl + "paquetes", pqt);
        }

        function del(id) {
            return $http.delete(apiUrl + "paquetes/" + id);
        }
    }
})();