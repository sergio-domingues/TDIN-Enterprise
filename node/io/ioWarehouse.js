// JavaScript source code

var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(http);

var warehouseSocket;

io.on('connection', function (socket) {
    console.log('a user connected');

    warehouseSocket = socket;

    warehouseSocket.on('order', function (msg) {
        console.log('message received: ', 'order\n', msg);
        warehouseSocket.emit("info", { data: "data", more: "data" });
    });

    warehouseSocket.on('shipping', function (msg) {
        console.log('message received: ', 'shipping\n', msg);
        warehouseSocket.emit("ack", "received ship order");

        //todo rabbitMQ
    });

    /* socket.disconnect() or socket.close() triggers disconnect event */
    warehouseSocket.on('disconnect', function () {
        console.log("user disconnected");
        io.emit('user disconnected');
    });
});

http.listen(4000, function () {
    console.log('listening on *:4000');
});

module.exports = warehouseSocket;