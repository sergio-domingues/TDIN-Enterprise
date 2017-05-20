// JavaScript source code

console.log("starting js");

var app = require('express')();
var httpStore = require('http').Server(app) /*,
    httpWarehouse = require('http').Server(app)*/;

var io/*Store*/ = require('socket.io')(httpStore);


io.on('connection', function (socket) {

    console.log('a user connected');

    //socket.emit('ack', { hello: 'world' });

    socket.on('sell', function (msg) {
        console.log('message received: ', 'sell\n', msg);
        socket.emit("info", { data: "data", more: "data" });       
    });

    socket.on('order', function (msg) {
        console.log('message received: ', 'order\n', msg);
        socket.emit("info", { data: "data", more: "data" });
    });

    socket.on('shipping', function (msg) {
        console.log('message received: ', 'shipping\n', msg);
        socket.emit("ack", "received ship order");
    });

    /* socket.disconnect() or socket.close() triggers disconnect event */
    socket.on('disconnect', function () {
        console.log("user disconnected");
        //io.emit('user disconnected');
    });
});

httpStore.listen(3500, function () {
    console.log('listening on *:3500');
});