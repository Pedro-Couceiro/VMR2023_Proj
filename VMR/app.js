const express = require("express");
const config = require("./config/config.json");
const requestHandlers = require("./request-handlers.js");

const app = express();

app.listen(config.server.port, function()
{
    console.log("Servidor à escuta em http://localhost:8081")
});