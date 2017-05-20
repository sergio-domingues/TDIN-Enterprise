// JavaScript source code

console.log("starting js");

var app = require('express')();
var http = require('http').Server(app);

var io = require('socket.io')(http);

var amqp = require('amqplib/callback_api');


io.on('connection', function (socket) {

    console.log('a user connected');

    socket.on('sell', function (msg) {
        console.log('message received: ', 'sell\n', msg);
        socket.emit("info", { data: "data", more: "data" });       
    });

    socket.on('order', function (msg) {
        console.log('message received: ', 'order\n', msg);
        socket.emit("info", { data: "data", more: "data" });
    });

    /* socket.disconnect() or socket.close() triggers disconnect event */
    socket.on('disconnect', function () {
        console.log("user disconnected");
        //io.emit('user disconnected');
    });
});

http.listen(3500, function () {
    console.log('listening on *:3500');
});

//rabbitmq
amqp.connect('amqps://guest:guest@localhost:5672', function (err, conn) {
    console.log(err);
    conn.createChannel(function (err, ch) {
        var q = 'hello';
        var msg = 'Hello World!';

        ch.assertQueue(q, { durable: false });
        // Note: on Node 6 Buffer.from(msg) should be used
        ch.sendToQueue(q, new Buffer(msg));
        console.log(" [x] Sent %s", msg);
    });
    setTimeout(function () { conn.close(); process.exit(0) }, 500);
});