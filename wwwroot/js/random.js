"use strict";

// Define the connection to signalR hub
var connection = new signalR.HubConnectionBuilder().withUrl("/random").build();

// Define response to receiving "ReceiveRandom" 
connection.on("DisplayRandom", function (randomNum) {
    var randDisplay = document.getElementById("randomNum");
    randDisplay.textContent = `From Server: ${randomNum}`;
});

// 'start' the connection to begin receiving communication from server
connection.start().then(function () {
    console.log("Start connection to /random");
}).catch(function (err) {
    return console.error(err.toString());
});
