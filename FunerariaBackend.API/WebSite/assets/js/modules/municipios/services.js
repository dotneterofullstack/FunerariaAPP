(function () {
    'use strict';

    angular
        .module('funerariaApp')
        .factory('municipiosSvc', municipiosSvc);

    municipiosSvc.$inject = ['$http'];
    function municipiosSvc($http) {
        var apiUrl
        var municipios = [];

        var service = {
            setApiUrl: setApiUrl,
            get: get,
            post: post,
            put: put,
            del: del
        };

        return service;

        ////////////////
        function setApiUrl(url) {
            apiUrl = url;
        }

        function get(filter) {
            return $http.get(apiUrl + "municipios", {
                params: filter,
                cache: true
            });
        }

        function post(entity) {
            return $http.post(apiUrl + "municipios", entity);
        }

        function put(entity) {
            return $http.put(apiUrl + "municipios", entity);
        }

        function del(id) {
            return $http.delete(apiUrl + "municipios/" + id);
        }
    }
})();