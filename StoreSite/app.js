var express = require('express');
var path = require('path');
var favicon = require('serve-favicon');
var logger = require('morgan');
var cookieParser = require('cookie-parser');
var bodyParser = require('body-parser');

var index = require('./routes/index');
var order = require('./routes/order');
var search = require('./routes/search');

var http = require('http').Server(app);
var io = require('socket.io')(http);

var app = express();

// view engine setup
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'hbs');

// uncomment after placing your favicon in /public
//app.use(favicon(path.join(__dirname, 'public', 'favicon.ico')));
app.use(logger('dev'));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));

app.use('/', index);
app.use('/order', order);
app.use('/search', search);

// catch 404 and forward to error handler
app.use(function(req, res, next) {
  var err = new Error('Not Found');
  err.status = 404;
  next(err);
});

// error handler
app.use(function(err, req, res, next) {
  // set locals, only providing error in development
  res.locals.message = err.message;
  res.locals.error = req.app.get('env') === 'development' ? err : {};

  // render the error page
  res.status(err.status || 500);
  res.render('error');
});





/*
app.get('/', function (req, res) {
    res.sendFile(__dirname + '/index.html');
}); */

io.on('connection', function (socket) {

    console.log('a user connected');

    //socket.emit('ack', { hello: 'world' });

    socket.on('sell', function (msg) {
        console.log('message received: ', 'sell\n', msg);
        socket.emit("info", { data: "data", more: "data" });       
    });

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
        //io.emit('user disconnected');
    });
});

http.listen(3500, function () {
    console.log('listening on *:3500');
});





module.exports = app;
