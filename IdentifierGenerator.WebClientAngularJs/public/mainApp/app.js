"use strict";

var app = angular.module("mainApp", ["ngRoute", "ngTable"]);

app.component("app", {
    templateUrl: '/mainApp/app.html'
});

app.config(function ($routeProvider, $locationProvider) {
    $routeProvider
        .when('/', {
            template: '<app></app>'
        })
        .when('/:factory/:category', {
            template: '<factory-history></factory-history>'
        });

    $locationProvider.html5Mode(true);
});