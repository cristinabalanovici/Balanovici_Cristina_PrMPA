﻿"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/Chat").build();

document.getElementById("sendButton").disabled = true;
connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amps;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " spune " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (evenet) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.errorr(err.toString());
    });
    event.preventDefault();
})