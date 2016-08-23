(function () {
    'use strict';

    angular
        .module('funerariaApp')
        .factory('asesoresSvc', asesoresSvc);

    asesoresSvc.$inject = ['$http'];
    function asesoresSvc($http) {
        var apiUrl
        var asesores = [];

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
            return $http.get(apiUrl , {
                params: filter,
                cache: true
            });
        }

        function post(asesor) {
            return $http.post(apiUrl, asesor);
        }

        function put(asesor) {
            return $http.put(apiUrl, asesor);
        }

        function del(id) {
            return $http.delete(apiUrl + "/" + id);
        }
    }
})();