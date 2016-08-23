(function () {
    'use strict';

    angular
        .module('funerariaApp')
        .factory('documentosSvc', documentosSvc);

    documentosSvc.$inject = ['$http'];
    function documentosSvc($http) {
        var apiUrl
        var domicilios = [];

        var service = {
            setApiUrl: setApiUrl,
            get: get
        };

        return service;

        ////////////////
        function setApiUrl(url) {
            apiUrl = url;
        }

        function get(filter) {
            return $http.get(apiUrl, {
                params: filter,
                cache: true
            });
        }
    }
})();