"use strict";

var app = angular.module("mainApp");

app.component("newFactory", {
    templateUrl: '/mainApp/newFactory/newFactory.html',
    controllerAs: '$ctrl',
    controller: ["identifierService", "$rootScope", function (identifierService, $rootScope) {
        var self = this;

        self.factory = '';
        self.category = '';

        self.generateNew = function () {
            if (!self.factory || !self.category)
                return;

            identifierService.generateNew(self.factory, self.category)
                .then(function () {
                    $rootScope.$broadcast("newCodeGenerated");
                });
        }
    }]
});