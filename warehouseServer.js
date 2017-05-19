// JavaScript source code

// JavaScript source code

console.log("starting js");

var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(http);

/*
app.get('/', function (req, res) {
    res.sendFile(__dirname + '/index.html');
}); */

io.on('connection', function (socket) {

    console.log('a user connected');
    //socket.emit('news', { hello: 'world' });

    /*
    socket.on('sell', function (msg) {
        console.log('message received: ', 'sell\n', msg);
        socket.emit("info", { data: "data", more: "data" });
    });

    socket.on('order', function (msg) {
        console.log('message received: ', 'order\n', msg);
        socket.emit("info", { data: "data", more: "data" });
    });
    */

    /* socket.disconnect() or socket.close() triggers disconnect event */
    socket.on('disconnect', function () {
        console.log("user disconnected");
        io.emit('user disconnected');
    });
});

http.listen(4000, function () {
    console.log('listening on *:4000');
});