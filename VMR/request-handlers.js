const mysql = require("mysql2");
const config = require("./config/config.json");

const connectOptions = config.db;

function getPlayerData(request, response) {
    let connection = mysql.createConnection(connectOptions);

    connection.query(
        "SELECT * FROM player_table",
        function (err, rows, fields) {
            if (err) {
                console.log("Error:", err.message);
                response.sendStatus(500);
            }
            else {

            }
        }
    )
    connection.end();
}

function getStageData(request, response) {

    let connection = mysql.createConnection(connectOptions);
    connection.query(
        "SELECT * FROM stages_table",
        function (err, rows, fields) {
            if (err) {
                console.log("Error", err.message);
                response.sendStatus();
            }
            else {

            }
        }
    )
    connection.end();
}

function getSaveData(request, response) {

    let connection = mysql.createConnection(connectionOptions);
    connection.query(
        "SELECT * FROM save_data",
        function (err, rows, fields) {
            if (err) {
                console.log("Error", err.message);
                response.sendStatus();
            }
            else {

            }
        }
    )
    connection.end();
}

module.exports.getPlayerData = getPlayerData;
module.exports.getStageData = getStageData;
module.exports.getSaveData = getSaveData;