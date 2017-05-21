var sqlite3 = require('sqlite3').verbose();
var db = new sqlite3.Database('bookstore.db');
var guid = require('guid');
const nodemailer = require('nodemailer');


function getAllBooksInfo(next){
	db.serialize(function(){
		db.all("SELECT * from Book", function(err, rows){
			if(typeof next === 'function'){
				//console.log(rows);
				next(rows);
			}
		});
	});
}


function getBookPrice(title, next){
	db.serialize(function(){
		db.all("SELECT Price from Book where Book.Title=" + "\x27" + title + "\x27", function(err, rows){
			console.log(title);
			if(typeof next === 'function'){
				next(rows[0].Price);
			}
		});
	});
}

function getBookStock(title, next){
	db.serialize(function(){
		db.all("SELECT Stock from Book where Book.Title= " + "\x27" + title + "\x27", function(err, rows){
			if(typeof next === 'function'){
				next(rows[0].Stock);
			}
		});
	});
}

function createNewSell(clientName, bookTitle, quantity, price, next){
	db.serialize(function(){
		var totalPrice = price * quantity;
		var stmt = db.prepare("INSERT into Sell(ClientName, BookTitle, Quantity, Price) VALUES(?, ?, ?, ?)");
		stmt.run(clientName, bookTitle, quantity, totalPrice);
		stmt.finalize();

		if(typeof next === 'function'){
			decreaseStock(bookTitle, quantity, next);
		}
	});
}

function createNewOrder(clientName, bookTitle, quantity, address, email, state, next){
	if(typeof next === 'function'){
		var stmt = db.prepare("INSERT into Orders(OrderId, BookTitle, Quantity , ClientName, Address, Email, State) VALUES(?, ?, ?, ?, ?, ?, ?)");
		var id = guid.raw();
		stmt.run(id, bookTitle, quantity, clientName, address, email, state);
		stmt.finalize();
		next(id);
	}
}

function decreaseStock(title, num, next){
	getBookStock(title, function(stock){
		var stock =  stock - num;
		db.run("UPDATE Book SET Stock = " + stock + " WHERE Title = " + "\x27" + title + "\x27");

		if(typeof next === 'function'){
			next();
		}
	})
}

function getOrderInfo(orderId, next){
	if(typeof next === 'function'){
		console.log(orderId);
		db.all("SELECT * from Orders where OrderId = " + "\x27" + orderId + "\x27", function(err, rows){
			console.log(rows);
			next(rows);
		});
	}
}


module.exports = {getAllBooksInfo, getBookPrice, getBookStock, createNewSell, createNewOrder, decreaseStock, getOrderInfo};
