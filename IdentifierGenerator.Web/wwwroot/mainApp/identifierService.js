"use strict";

var app = angular.module("mainApp");

app.service("identifierService", ["$http", function ($http) {
    var self = this;

    self.getFactories = function () {
        return $http.get("/api/identifier")
            .then(function (response) {
                return response.data;
            });
    };

    self.getAllFor = function (factory, category) {
        return $http.get("/api/identifier/" + factory + "/" + category)
            .then(function (response) {
                return response.data;
            });
    }

    self.generateNew = function (factory, category) {
        return $http.post("/api/identifier/" + factory + "/" + category)
            .then(function (response) {
                return response.data;
            });
    }
}]);