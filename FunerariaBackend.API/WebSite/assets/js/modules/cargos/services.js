(function() {
'use strict';

    angular
        .module('funerariaApp')
        .factory('cargoSvc', cargoSvc);

    cargoSvc.$inject = ['$http'];
    function cargoSvc($http) {
        var apiUrl 

        var service = {
            setApiUrl: setApiUrl,
            get:get,
            post:post,
            put:put,
            del:del
        };
        
        return service;

        ////////////////
        function setApiUrl(url) {
            apiUrl = url;
         }

         function get(filter) { 
            return $http.get(apiUrl, {
                    params: filter
                });
        }

        function post(cargo) {
            return $http.post(apiUrl, cargo);
        }

        function put(cargo) {
            return $http.put(apiUrl, cargo);
        }

        function del(id) {
            return $http.delete(apiUrl + "/" + id);
        }
    }
})();