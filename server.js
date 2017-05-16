// JavaScript source code

console.log("starting js");

const io = require('socket.io')(9000);

io.on('connection', (socket) => {
    console.log('Connected');   
});