var sqlite3 = require('sqlite3').verbose();
var db = new sqlite3.Database('warehouse.db');

function createNewOrder(id, clientName, bookTitle, quantity, address, email, state, next){
	if(typeof next === 'function'){
		var stmt = db.prepare("INSERT into Orders(id, bookTitle, quantity , clientName, address, emailAddress, status) VALUES(?, ?, ?, ?, ?, ?, ?)");
		stmt.run(id, bookTitle, quantity, clientName, address, email, state);
		stmt.finalize();
		next();
	}
}

function getOrdersInfo(next){
	if(typeof next === 'function'){
		db.all("SELECT * from Orders Where status is not \x27dispatched\x27"  , function(err, rows){
			next(rows);
		});
	}
}

function updateOrderStatus(orderId, next){
	if(typeof next === 'function'){

		db.run("UPDATE Orders SET status = " + "\x27dispatched\x27" + " WHERE id = " + "\x27" + orderId + "\x27", function(err, rows){
			console.log("UPDATE Orders SET status = " + "\x27dispatched\x27" + " WHERE OrderId = " + "\x27" + orderId + "\x27");
			next();
		});
	}
}


module.exports = {createNewOrder, getOrdersInfo, updateOrderStatus};