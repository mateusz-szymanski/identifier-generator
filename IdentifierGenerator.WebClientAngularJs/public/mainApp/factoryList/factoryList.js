"use strict";

var app = angular.module("mainApp");

app.component("factoryList", {
    templateUrl: '/mainApp/factoryList/factoryList.html',
    controllerAs: '$ctrl',
    controller: ["identifierService", "NgTableParams", "$location", "$scope", "$rootScope",
        function (identifierService, NgTableParams, $location, $scope, $rootScope) {
        var self = this;

        self.$onInit = function () {
            reloadData();
        }

        var reloadData = function () {
            identifierService.getFactories()
                .then(function (data) {
                    angular.copy(data, self.factories);
                    self.tableParams.reload();
                });
        }

        $scope.$on("newCodeGenerated", function () {
            reloadData();
        });

        self.factories = [];

        self.tableParams = new NgTableParams({}, { dataset: self.factories });

        self.generateNew = function (factory, category) {
            identifierService.generateNew(factory, category)
                .then(function () {
                    $rootScope.$broadcast("newCodeGenerated");
                });
        }

        self.goToHistory = function (factory, category) {
            var path = "/{factory}/{category}"
                .replace("{factory}", factory)
                .replace("{category}", category);

            $location.path(path);
        }
    }]
});