// JavaScript source code

const express = require('express')();
var http = require('http').Server(express);
var io = require('socket.io')(http);

var mqStore = require('../mq/mqStore');
var utils = require('../public/js/utils');

var storeSocket;

var db = require('../database/database');

http.listen(3500, function () {
    console.log('listening on *:3500');
});

io.on('connection', function (socket) {

    storeSocket = socket;

    console.log('a user connected');

    db.getAllBooksInfo(function (rows) {
        socket.emit("booksList", { data: rows });
    });

    storeSocket.on('sell', function (msg) {
        console.log('message received: ', 'sell\n', msg);

        let json = JSON.parse(msg);
    
        //db
        db.decreaseStock(json.bookTitle, json.quantity, function () { })

        //receipt
        let receipt = "------------- Receipt Details --------------\n\n";
        receipt += "\tBook title: " + json.bookTitle + "\n" +
               "\tQuantity: " + json.quantity + "\n" +
               "\tTotal Price:" + json.totalPrice + "\n" +
               "\tClient: " + json.clientName + "\n\n" +
                      "--------------------------------------------\n\n";

        console.log(receipt);

        db.getBookStock(json.bookTitle, function (bookStock){
            storeSocket.emit("updateBook", { bookTitle: json.bookTitle, stock: bookStock });
        });        
    });

    storeSocket.on('getOrders', function (msg) {
        console.log('message received: ', 'getOrders\n', msg);

        storeSocket.emit("orderList", "");
    });

    storeSocket.on("checkStockOrders", function (msg) {

        var json = JSON.parse(msg);

        var state = "Your order is waiting expedition due to the lack of stock, we ask you to be patient";
        
        db.getBookStock(json.bookTitle, function (bookStock) {

            var fullStock = bookStock + 10; //dont put order qtty

            //fullfill 1st order
            let today = getTodaysDate();
            let acceptState = "dispatched at " + today;
            db.uptadeOrderState(json.id, acceptState, function () { });
            
            var email, msg;

            db.getOrderInfo(json.id, function (data) {
                email = data[0].email;

                msg = "Your order <" + json.id + "> will be " + acceptState + "\n";
                msg += "Details:\n" + "Book title: " + data[0].BookTitle   + "\n" +
                       "Quantity: "+ data[0].Quantity + "\n" + "Adress: " + data[0].Adress;
            });
            
            //send email
            utils.sendEmail(email, msg, "Your Bookstore Order");

            //tries to fullfill more orders
            db.getPendingOrders(json.bookTitle, state, function (pendingOrders) {
                
                console.log(">>>>>>>orders", pendingOrders);

                for (let i = 0; i < pendingOrders.length; i++) {
                    if (fullStock == 0)
                        break;

                    if (pendingOrders[i].Quantity <= fullStock) {
                        db.uptadeOrderState(pendingOrders[i].OrderId, acceptState, function () { });
                        fullStock -= pendingOrders[i].Quantity;
                    }
                }

                //updt book stock
                if (fullStock > 0) {
                    db.updateStock(json.bookTitle, fullStock, function () { })
                }

                storeSocket.emit("updateBook", { stock: fullStock, title : json.bookTitle});
            });
        });

    });

    storeSocket.on('order', function (msg) {
        console.log('message received: ', 'order\n', msg);

        mqStore.sendMsg(msg);
    });


    /* socket.disconnect() or socket.close() triggers disconnect event */
    storeSocket.on('disconnect', function () {
        console.log("user disconnected");
        io.emit('user disconnected');
    });
});

function sendMsg(msg, data) {
    io.emit(msg, data);
}

function getTodaysDate() {
    var date = new Date();
    var year = date.getFullYear();

    var month = date.getMonth() + 1;
    month = (month < 10 ? "0" : "") + month;

    var day = date.getDate();
    day = (day < 10 ? "0" : "") + day;

    return day + "/" + month + "/" + year;
}

module.exports.sendMsg = sendMsg;