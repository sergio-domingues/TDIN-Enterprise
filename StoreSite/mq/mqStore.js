// JavaScript source code

var amqp = require('amqplib/callback_api');

var guiSocket = require('../io/ioStore');
var db = require('../database/database.js');
var utils = require('../public/js/utils.js');

var q, r;
var channel;

//rabbitmq
amqp.connect('amqp://localhost', function (err, conn) {
    //console.log(err);
    conn.createChannel(function (err, ch) {
        channel = ch;
                       
        q = 'teste', r = 'hello';
        var msg = 'Hello World!';

        //consume from warehouse
        receiveMsgs();

        //produce to warehouse  
       //sendMsg(msg);
    });

    //extract to method
    //setTimeout(function () { conn.close(); process.exit(0) }, 500);    
});

function sendMsg(msg) {
    channel.assertQueue(r, { durable: false });
    channel.sendToQueue(r, new Buffer(msg));
    console.log(" [x] Sent %s", msg);
}

function receiveMsgs() {
    channel.assertQueue(q, { durable: false });
    console.log(" [*] Waiting for messages in %s. To exit press CTRL+C", q);
    channel.consume(q, function (msg) {
        console.log(" [x] Received %s", msg.content.toString());
        
        
        var obj = JSON.parse(msg.content.toString());
        console.log("CARALHO " + obj.id);
        db.uptadeOrderState(obj.id, "The dispatch of your order should occur at " + utils.get2daysDate() , function(){
            guiSocket.sendMsg("acceptOrder", msg.content.toString());
        });
        

    }, { noAck: true });

    //send to socket or call function
}

module.exports = {
    sendMsg,
};