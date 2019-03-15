"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.on("ReceiveMessage", function (message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var div = document.createElement("div");
    div.className = "ui message";
    div.innerHTML= `<p>${message}</p>`
    //div.innerHTML = msg + "<hr/>";
    document.getElementById("messages").appendChild(div)
});

connection.on("UserConnected", function (connectionId, email) {
    var groupElement = document.getElementById("dmContainer");
    var message = document.getElementById("message").value;
    var userOnline = document.createElement("a");
    userOnline.id = connectionId;
    userOnline.text = email;
    userOnline.className = "item dm";
    
    groupElement.appendChild(userOnline);
});

//TODO REMOVE FROM SIDEBAR
connection.on("UserDisconnected", function (connectionId) {
    var groupElement = document.getElementById("group");
    for (var i = 0; i < groupElement.Length; i++) {
        if (groupElement.options[i].value === connectionId) {
            groupElement.remove(i);
        }
    }
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

//TDOD ON KEYPRESS and CLEAR TEXT FIELD
document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("message").value;
    var groupElement = document.getElementById("group");
    var groupValue = groupElement.options[groupElement.selectedIndex].value;

    if (groupValue === "All" || groupValue === "Myself") {
        var method = groupValue === "All" ? "SendMessageToAll" : "SendMessageToCaller";
        connection.invoke(method, message).catch(function (err) {
            return console.error(err.toString());
        });
    } else if (groupValue === "PrivateGroup") {
        connection.invoke("SendMessageToGroup", "PrivateGroup", message).catch(function (err) {
            return console.error(err.toString());
        });

    } else {
        connection.invoke("SendMessageToUser", groupValue, message).catch(function (err) {
            return console.error(err.toString());
        });
    }

    event.preventDefault();
});

document.getElementById("joinGroup").addEventListener("click", function (event) {
    connection.invoke("JoinGroup", "PrivateGroup").catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});



