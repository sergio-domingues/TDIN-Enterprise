// JavaScript source code

console.log("starting js");

var app = require('express')();

//rabitmq

var ioStore = require('./io/ioStore');

//setTimeout(function () {} , 1000 );

var mqStore = require('./mq/mqStore');