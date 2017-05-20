// JavaScript source code

var amqp = require('amqplib/callback_api');

var q, r;
var channel;

amqp.connect('amqp://localhost', function (err, conn) {
    conn.createChannel(function (err, ch) {

        channel = ch;

        //consumer
        q = 'hello';

        ch.assertQueue(q, { durable: false });
        console.log(" [*] Waiting for messages in %s. To exit press CTRL+C", q);
        ch.consume(q, function (msg) {
            console.log(" [x] Received %s", msg.content.toString());
        }, { noAck: true });

        //producer
        r = 'teste';
        var msg = 'Hello World!';

        ch.assertQueue(r, { durable: false });
        ch.sendToQueue(r, new Buffer(msg));
        console.log(" [x] Sent %s", msg);
    });

});

function sendMsg(msg) {
    channel.sendToQueue(r, new Buffer(msg));
}

module.exports = {
    sendMsg,
};
