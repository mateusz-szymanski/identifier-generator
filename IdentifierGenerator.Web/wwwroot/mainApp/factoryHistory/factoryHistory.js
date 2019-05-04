"use strict";

var app = angular.module("mainApp");

app.component("factoryHistory", {
    templateUrl: '/mainApp/factoryHistory/factoryHistory.html',
    controllerAs: '$ctrl',
    controller: ["identifierService", "NgTableParams", "$routeParams", "$location", function (identifierService, NgTableParams, $routeParams, $location) {
        var self = this;

        self.$onInit = function () {
            self.factory = $routeParams.factory;
            self.category = $routeParams.category;

            identifierService.getAllFor(self.factory, self.category)
                .then(function (data) {
                    angular.copy(data, self.factories);
                    self.tableParams.reload();
                });
        }

        self.factories = [];

        self.tableParams = new NgTableParams({}, { dataset: self.factories });

        self.goBack = function () {
            $location.path("/");
        }
    }]
});