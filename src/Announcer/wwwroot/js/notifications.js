"use strict";

var uri = "/api/v1/Clients";
var clientId;
var groups;

// Start the connection.
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/NotificationHub")
    .configureLogging(signalR.LogLevel.Error)
    .build();

async function start() {
    try {
        await connection.start();
        if (connection.state === signalR.HubConnectionState.Connected) {
            console.log("Connected to hub");

            // Join groups
            if (groups) {
                groups.map(group => joinGroup(group));
            }
        }
    } catch (error) {
        displayError(error);

        // If disconnected, start connection in 5 seconds
        if (connection.state === signalR.HubConnectionState.Disconnected) {
            setTimeout(() => start(), 5000);
        }
    }
};

connection.onclose(async (error) => {
    console.assert(connection.state === signalR.HubConnectionState.Disconnected);

    // Leave groups
    if (groups) {
        groups.map(group => leaveGroup(group));
    }

    console.warn(`Connection closed due to error "${error}". Try refreshing this page to restart the connection.`);

    // If connection is closed, then reconnect again
    await start();
});

connection.on("Send", function (notification) {
    displayNotification(notification.group, notification.message);
});

function displayClock() {
    var date = new Date();
    var hour = date.getHours().toString().padStart(2, '0');
    var min = date.getMinutes().toString().padStart(2, '0');
    var sec = date.getSeconds().toString().padStart(2, '0');

    document.getElementById("clock").innerText = hour + " : " + min + " : " + sec;

    var t = setTimeout(function () {
        displayClock()
    }, 1000);
}

function displayLastUpdate() {
    var date = new Date();
    var hour = date.getHours().toString().padStart(2, '0');
    var min = date.getMinutes().toString().padStart(2, '0');
    var sec = date.getSeconds().toString().padStart(2, '0');
    var msec = date.getMilliseconds().toString().padStart(2, '0');

    document.getElementById("last-update").innerText = `${date.toLocaleDateString()} ${hour}:${min}:${sec}.${msec}`;
}

function getClientId() {
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);

    var clientId = urlParams.get("id");

    if (!clientId || clientId === "") {
        clientId = clientIP;
    }

    if (clientId && clientId !== "") {
        document.getElementById("client-id").innerText = clientId;
    }
    else {
        displayError("İstemci bilgisi bulunamadı");
    }

    return clientId;
}

function displayNotification(group, content) {
    var groupSlug = slugify(group);
    var groupRow = document.getElementById(`notification-${groupSlug}-row`);

    if (groupRow) {
        var tdCurrentGroup = document.getElementById(`group-${groupSlug}`);
        var tdCurrentContent = document.getElementById(`content-${groupSlug}`);

        tdCurrentGroup.setAttribute("id", `group-${groupSlug}`);

        tdCurrentGroup.innerHTML = group;
        tdCurrentContent.innerHTML = content;
    }
    else {
        var notifications = document.getElementById('notifications');

        let tr = document.createElement('tr'),
            tdGroup = document.createElement('td'),
            tdContent = document.createElement('td');

        tr.setAttribute("id", `notification-${groupSlug}-row`);
        tr.setAttribute("class", "hvr-buzz-out");

        tdGroup.setAttribute("id", `group-${groupSlug}`);
        tdGroup.innerHTML = group;

        tdContent.setAttribute("id", `content-${groupSlug}`);
        tdContent.innerHTML = content;

        tr.appendChild(tdGroup);
        tr.appendChild(tdContent);
        notifications.appendChild(tr);
    }

    displayLastUpdate();
}

function getClientInfo(clientId) {
    if (clientId === "") return;

    fetch(`${uri}/${clientId}`, {
        method: 'GET',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    })
        .then(function (response) {
            if (!response.ok) {
                throw Error(`${response.status} status code received.`);
            }

            return response.json();
        })
        .then(function (data) {
            if (data.isSuccessful) {
                let clientInfo = data.model;

                if (clientInfo.groups) {
                    groups = clientInfo.groups.map(group => group.group).sort();

                    for (var i = 0; i < groups.length; i++) {
                        displayNotification(groups[i], "");
                    }
                }
                else {
                    displayError("İstemcinin üye olduğu gruplar bulunamadı.");
                }
            }
            else {
                displayError("İstemci bilgisi okunamadı. " + data.message);
            }
        })
        .catch(error => {
            displayError("İstemci bilgisi bulunamadı. " + error);
        });
}

function getNotifications(clientId) {
    if (clientId === "") return;

    fetch(`${uri}/${clientId}/Notifications`, {
        method: 'GET',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    })
        .then(function (response) {
            if (!response.ok) {
                throw Error(`${response.status} status code received.`);
            }

            return response.json();
        })
        .then(function (data) {
            if (data.isSuccessful) {
                let notifications = data.model;

                return notifications.map(notification => displayNotification(notification));
            }
            else {
                displayError("İstemcinin mesajları okunamadı. " + data.message);
            }
        })
        .catch(error => {
            displayError("İstemcinin mesajları bulunamadı. " + error);
        });
}

async function joinGroup(groupName) {
    if (groupName === "") return;

    try {
        await connection.invoke("AddToGroup", groupName);
        console.log(`Joined to "${groupName}" group`);
    }
    catch (e) {
        displayError(e);
    }
}

async function leaveGroup(groupName) {
    if (groupName === "") return;

    try {
        await connection.invoke("RemoveFromGroup", groupName);
        console.log(`Left "${groupName}" group`);
    }
    catch (e) {
        displayError(e);
    }
}

function slugify(text) {
    var trMap = { 'çÇ': 'c', 'ğĞ': 'g', 'şŞ': 's', 'üÜ': 'u', 'ıİ': 'i', 'öÖ': 'o' };
    for (var key in trMap) {
        text = text.replace(new RegExp('[' + key + ']', 'g'), trMap[key]);
    }
    return text.replace(/[^-a-zA-Z0-9\s]+/ig, '') // remove non-alphanumeric chars
        .replace(/\s/gi, "-") // convert spaces to dashes
        .replace(/[-]+/gi, "-") // trim repeated dashes
        .toLowerCase();
}

function displayError(error) {
    console.error(error);

    var errorBody = document.getElementById("error-body");
    var errorMessage = document.getElementById("error-message");

    errorMessage.innerText = error;

    errorBody.style = "";

    var t = setTimeout(function () {
        errorBody.style = "display: none";
    }, 10000);
}

// Get client id
clientId = getClientId();

// Start displaying clock
displayClock();

// Get client info
getClientInfo(clientId);

//getNotifications(clientId);

// Start the connection.
start();