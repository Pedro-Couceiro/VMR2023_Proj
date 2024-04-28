const express = require("express");
const hbs = require("handlebars");
const requestHandlers = require("./request-handler.js");

const app = express();

const hbsConfig = hbs.create(
    {
        extname:'',
        defaultLayout:'',
        layoutsDir:'',
        partialsDir:''
    }
)

app.engine('handlebars',)

app.listen(8081, function()
{

    console.log("Servidor à escuta em http://localhost:8081")
});