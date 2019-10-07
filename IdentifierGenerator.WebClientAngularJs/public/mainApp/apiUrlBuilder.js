"use strict";

var app = angular.module("mainApp");

app.service("apiUrlBuilder", function () {
    var self = this;

    var baseUrl = "https://localhost:44332/";

    self.combineUri = function (path) {
        return new URL(path, baseUrl).href;
    }
});