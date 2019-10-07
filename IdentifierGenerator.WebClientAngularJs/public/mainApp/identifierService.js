"use strict";

var app = angular.module("mainApp");

app.service("identifierService", ["$http", "apiUrlBuilder", function ($http, apiUrlBuilder) {
    var self = this;

    self.getFactories = function () {
        return $http.get(apiUrlBuilder.combineUri("/api/identifier"))
            .then(function (response) {
                return response.data;
            });
    };

    self.getAllFor = function (factory, category) {
        return $http.get(apiUrlBuilder.combineUri("/api/identifier/" + factory + "/" + category))
            .then(function (response) {
                return response.data;
            });
    }

    self.generateNew = function (factory, category) {
        return $http.post(apiUrlBuilder.combineUri("/api/identifier/" + factory + "/" + category))
            .then(function (response) {
                return response.data;
            });
    }
}]);