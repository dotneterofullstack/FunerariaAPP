﻿(function () {
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