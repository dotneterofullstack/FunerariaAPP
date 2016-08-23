(function() {
'use strict';

    angular
        .module('funerariaApp')
        .factory('estadosSvc', estadosSvc);

    estadosSvc.$inject = ['$http'];
    function estadosSvc($http) {
        var apiUrl
        var estados = [];

        var service = {
            setApiUrl: setApiUrl,
            get:get
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

        //function post(entity) {
        //    return $http.post(apiUrl, entity);
        //}

        //function put(entity) {
        //    return $http.put(apiUrl, entity);
        //}

        //function del(id) {
        //    return $http.delete(apiUrl + "/" + id);
        //}
    }
})();