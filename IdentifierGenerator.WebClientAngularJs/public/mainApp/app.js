"use strict";

var app = angular.module("mainApp", ["ngRoute", "ngTable"]);


app.component("app", {
    templateUrl: '/mainApp/app.html'
});

app.config(function ($routeProvider) {
    $routeProvider
        .when('/', {
            template: '<app></app>'
        })
        .when('/:factory/:category', {
            template: '<factory-history></factory-history>'
        })
});