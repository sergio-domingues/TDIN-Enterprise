var express = require('express');
var router = express.Router();
var db = require('../database/database.js');

/* GET home page. */
router.get('/', function(req, res, next) {
	var orderId = req.query.order;
	console.log(orderId);
	db.getOrderInfo(orderId, function(rows){
		res.render('search', { title: 'BookStore', orderId: orderId, book: rows[0].BookTitle, quantity: rows[0].Quantity, name: rows[0].ClientName, address: rows[0].Address, state: rows[0].State});
	})
	
});

module.exports = router;