// JavaScript source code

// JavaScript source code

console.log("starting js");

var app = require('express')();

var httpWarehouse = require('http').Server(app);
var io = require('socket.io')(httpWarehouse);

/*
app.get('/', function (req, res) {
    res.sendFile(__dirname + '/index.html');
}); */

io.on('connection', function (socket) {

    console.log('a user connected');
    //socket.emit('news', { hello: 'world' });

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
        io.emit('user disconnected');
    });
});

httpWarehouse.listen(4000, function () {
    console.log('listening on *:4000');
});