'use strict';
var debug = require('debug');
var express = require('express');
var path = require('path');
var favicon = require('serve-favicon');
var logger = require('morgan');

var app = express();

app.use(logger('dev'));

app.use(favicon(__dirname + '/public/favicon.ico'));
app.use("/mainApp", express.static(__dirname + "/public/mainApp"));
app.use("/lib", express.static(__dirname + "/public/lib"));
app.use("/site.css", express.static(__dirname + "/public/site.css"));

app.all("/*", function (req, res, next) {
    res.sendFile("Index.html", { root: __dirname + "/public" });
});

app.set('port', process.env.PORT || 3000);

var server = app.listen(app.get('port'), function () {
    debug('Express server listening on port ' + server.address().port);
});
