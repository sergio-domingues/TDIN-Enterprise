var express = require('express');
var nodemailer = require('nodemailer');

function sendEmail(receiver, message, subject, next){

    var transporter = nodemailer.createTransport({
        service: 'Gmail',
        auth: {
            user: 'bookenterprise123@gmail.com', // Your email id
            pass: 'TdinProjeto2' // Your password
        },
        secure: false,
        tls: {rejectUnauthorized: false}
    });

    // setup e-mail data with unicode symbols
    var mailOptions = {
        from: 'bookstore@gmail.com', // sender address
        to: receiver, // list of receivers
        subject: subject, // Subject line
        text: message, // plaintext body
    };

    transporter.sendMail(mailOptions, function(error, info){
        if(typeof next === 'function') {
            console.log('Message sent: ' + info.response);
            next('success');
        }
    });

}   

function getDate() {

    var date = new Date();

    var year = date.getFullYear();

    var month = date.getMonth() + 1;
    month = (month < 10 ? "0" : "") + month;

    var day  = date.getDate()+1;
    day = (day < 10 ? "0" : "") + day;


    return day + "/" + month + "/" + year;

}

function get2daysDate(){
    var date = new Date();

    var year = date.getFullYear();

    var month = date.getMonth() + 1;
    month = (month < 10 ? "0" : "") + month;

    var day  = date.getDate()+2;
    day = (day < 10 ? "0" : "") + day;


    return day + "/" + month + "/" + year;
}


module.exports = {sendEmail, getDate, get2daysDate};