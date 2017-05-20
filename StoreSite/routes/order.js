var express = require('express');
var router = express.Router();
var db = require('../database/database.js');
var utils = require('../public/js/utils.js');

/* GET home page. */
router.get('/:title', function(req, res, next) {
	var title = req.params.title;

	db.getBookPrice(title, function(price){
		db.getBookStock(title, function(stock){
			res.render('order', { title: 'BookStore', bookTitle: title, price: price, stock: stock });
		});
	});
  	
});


router.post('/purchase/:title', function(req, res, next){
	var title = req.params.title;
	db.getBookPrice(title, function(price){
		db.getBookStock(title, function(stock){
			
			
			if(stock >= req.body.quantity){
				db.createNewSell(req.body.name, title, req.body.quantity, price, function(){
					var msg = "Hello " + req.body.name + " !" + "\n"
					 + "Address: " + req.body.address + "\n" 
					 + "Title: " + title + "\n"
					 + "Quantity: " + req.body.quantity + "\n"
					 + "Price per book: " + price + "\n"
					 + "Total price: " + price * req.body.quantity + "\n\n\n"
					 + "Your order will be dispatched on " + utils.getDate();
					utils.sendEmail(req.body.email, msg, "Your BookStore order");
					res.redirect('/');
				});
				
			}else{
				db.createNewOrder(req.body.name, title, req.body.quantity, req.body.address, req.body.email, state, function(id){
					var msg = "Hello " + req.body.name + " !" + "\n"
					 + "Order: " + id + "\n"
					 + "Address: " + req.body.address + "\n" 
					 + "Title: " + title + "\n"
					 + "Quantity: " + req.body.quantity + "\n"
					 + "Price per book: " + price + "\n"
					 + "Total price: " + price * req.body.quantity + "\n\n\n"
					 + "Your order is waiting expedition due to the lack of stock, we ask you to be patient :D";
					utils.sendEmail(req.body.email, msg, "Your BookStore order");
					res.redirect('/');
				});
			}
			
					
		});
	});
	
});

module.exports = router;