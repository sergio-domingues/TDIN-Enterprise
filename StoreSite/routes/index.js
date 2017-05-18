var express = require('express');
var router = express.Router();
var db = require('../database/database.js');

/* GET home page. */
router.get('/', function(req, res, next) {
	db.getAllBooksInfo(function(books){
		console.log("agora");
		res.render('index', { title: 'BookStore', books: books });
	});
  	
});

module.exports = router;
