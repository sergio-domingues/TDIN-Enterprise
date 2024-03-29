// JavaScript source code

const express = require('express')();
var http = require('http').Server(express);
var io = require('socket.io')(http);

var mqStore = require('../mq/mqStore');

var storeSocket;

http.listen(3500, function () {
    console.log('listening on *:3500');
});

io.on('connection', function (socket) {

    storeSocket = socket;

    console.log('a user connected');

    storeSocket.on('sell', function (msg) {
        console.log('message received: ', 'sell\n', msg);
        storeSocket.emit("info", { data: "data", more: "data" });
    });

    storeSocket.on('order', function (msg) {
        console.log('message received: ', 'order\n', msg);
        storeSocket.emit("info", { data: "data", more: "data" });

        mqStore.sendMsg(msg);
    });

    /* socket.disconnect() or socket.close() triggers disconnect event */
    storeSocket.on('disconnect', function () {
        console.log("user disconnected");
        io.emit('user disconnected');
    });
});

function sendMsg (msg) {
   storeSocket.emit(msg);
}

module.exports = {
    sendMsg,
};