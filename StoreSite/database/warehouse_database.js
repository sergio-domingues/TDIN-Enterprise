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
		db.all("SELECT * from Orders", function(err, rows){
			//console.log(rows);
			next(rows);
		});
	}
}


module.exports = {createNewOrder, getOrdersInfo};