// JavaScript source code

var amqp = require('amqplib/callback_api');

var guiSocket = require('../io/ioWarehouse');

var q, r;
var channel;

amqp.connect('amqp://localhost', function (err, conn) {
    conn.createChannel(function (err, ch) {

        channel = ch;

        //consumer
        q = 'teste', r = 'hello';
        var msg = 'Hello World!';

        //consume from store
        receiveMsgs();

        //produce to store  
        //sendMsg(msg);
    });

});

function sendMsg(msg) {
    channel.assertQueue(q, { durable: false });
    channel.sendToQueue(  q  , new Buffer(msg));
    console.log(" [x] Sent %s", msg);
}

function receiveMsgs() {
    channel.assertQueue(r, { durable: false });
    console.log(" [*] Waiting for messages in %s. To exit press CTRL+C", r);
    channel.consume(r, function (msg) {
        console.log(" [x] Received %s", msg.content.toString());
        
        guiSocket.sendMsg("order", msg.content.toString());

    }, { noAck: true });
}


module.exports = {
    sendMsg,
};
