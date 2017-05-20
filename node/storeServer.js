// JavaScript source code

console.log("starting js");

var app = require('express')();

//rabitmq
var amqp = require('amqplib/callback_api');

var ioStore = require('./io/ioStore');

//TODO init method that inits IO and MQ



//rabbitmq
amqp.connect('amqp://localhost', function (err, conn) {
    //console.log(err);
    conn.createChannel(function (err, ch) {

        //produce to warehouse
        var q = 'hello';
        var msg = 'Hello World!';

        ch.assertQueue(q, { durable: false });
        // Note: on Node 6 Buffer.from(msg) should be used
        ch.sendToQueue(q, new Buffer(msg));
        console.log(" [x] Sent %s", msg);

        //consume from warehouse
        var r = 'teste';

        ch.assertQueue(r, { durable: false });
        console.log(" [*] Waiting for messages in %s. To exit press CTRL+C", r);
        ch.consume(r, function (msg) {
            console.log(" [x] Received %s", msg.content.toString());
        }, { noAck: true });

    });
    
    //extract to method
    //setTimeout(function () { conn.close(); process.exit(0) }, 500);    
});

var createChannel = new function (conn) {

    
}