// JavaScript source code

// JavaScript source code

console.log("starting js");

var app = require('express')();

var httpWarehouse = require('http').Server(app),
    httpStore = require('http').Server(app);

var ioWarehouse = require('socket.io')(httpWarehouse),
    ioStore = require('socket.io')(httpStore);

var amqp = require('amqplib/callback_api');


ioWarehouse.on('connection', function (socket) {

    console.log('a user connected');
    //socket.emit('news', { hello: 'world' });

    socket.on('order', function (msg) {
        console.log('message received: ', 'order\n', msg);
        socket.emit("info", { data: "data", more: "data" });
    });
    
    socket.on('shipping', function (msg) {
        console.log('message received: ', 'shipping\n', msg);
        socket.emit("ack", "received ship order");
        
        //todo rabbitMQ
    });

    /* socket.disconnect() or socket.close() triggers disconnect event */
    socket.on('disconnect', function () {
        console.log("user disconnected");
        ioWarehouse.emit('user disconnected');
    });
});

httpWarehouse.listen(4000, function () {
    console.log('listening on *:4000');
});


amqp.connect('amqp://localhost', function (err, conn) {
    conn.createChannel(function (err, ch) {
        var q = 'hello';

        ch.assertQueue(q, { durable: false });
        console.log(" [*] Waiting for messages in %s. To exit press CTRL+C", q);
        ch.consume(q, function (msg) {
            console.log(" [x] Received %s", msg.content.toString());
        }, { noAck: true });
    });
});