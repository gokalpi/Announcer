"use strict";

var hubUri = "/NotificationHub";
var clientUri = "/api/Clients";
var clientId;
var groups;
var infoColumnCount = 0;

// Start the connection.
var connection = new signalR.HubConnectionBuilder()
    .withUrl(hubUri)
    .configureLogging(signalR.LogLevel.Error)
    .build();

async function start() {
    try {
        await connection.start();
        if (connection.state === signalR.HubConnectionState.Connected) {
            console.log(`Connected to hub at ${hubUri}`);

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

function displayClock() {
    const options = { hour: '2-digit', minute: '2-digit', second: '2-digit' };
    let clock = document.getElementById("clock");
    if (clock) {
        clock.innerText = new Intl.DateTimeFormat('tr-TR', options).format(new Date());
    }

    var t = setTimeout(function () {
        displayClock()
    }, 1000);
}

function displayError(error) {
    var errorBody = document.getElementById("error-pane");
    var errorMessage = document.getElementById("error-message");

    errorMessage.innerText = error;

    errorBody.style = "";

    //var t = setTimeout(function () {
    //    errorBody.style = "display: none";
    //}, 10000);
}

function displayHeaders(header) {
    if (!header) return;

    var pageHeader = document.getElementById("page-header");
    if (pageHeader) {
        infoColumnCount = header.columns.length > 0 ? header.columns.length - 1 : 0;

        var c = document.createDocumentFragment();

        header.columns.forEach(column => {
            let e = document.createElement("div");
            e.innerHTML = column;
            c.appendChild(e);
        });

        pageHeader.appendChild(c);
    }
}

function displayLastUpdate() {
    const options = { year: 'numeric', month: 'long', day: 'numeric', hour: '2-digit', minute: '2-digit', second: '2-digit' };
    let lastUpdate = document.getElementById("last-update");
    if (lastUpdate) {
        lastUpdate.innerText = new Intl.DateTimeFormat('tr-TR', options).format(new Date());
    }
}

function displayNotification(group, content) {
    var contentJson = JSON.parse(content);
    var groupSlug = slugify(group);
    var groupRowId = `group-${groupSlug}`;
    var groupRow = document.getElementById(groupRowId);

    if (groupRow) {
        var groupColumns = groupRow.getElementsByClassName("group-col");

        for (var i = 0; i < groupColumns.length; i++) {
            if (contentJson.columns[i]) {
                groupColumns[i].innerHTML = contentJson.columns[i];
            }
        }

        groupRow.setAttribute("class", "active");
    }
    else {
        var notifications = document.getElementById('notifications');
        if (notifications) {
            groupRow = document.createElement('div');
            groupRow.setAttribute("id", groupRowId);

            var c = document.createDocumentFragment();

            var divGroupName = document.createElement("div");
            divGroupName.className = "group-name";
            divGroupName.innerHTML = group;
            c.appendChild(divGroupName);

            for (var j = 0; j < infoColumnCount; j++) {
                var divCol = document.createElement('div');
                divCol.className = "group-col";
                if (contentJson.columns[j]) {
                    divCol.innerHTML = contentJson.columns[j];
                }
                c.appendChild(divCol);
            }

            groupRow.appendChild(c);
            notifications.appendChild(groupRow);
        }
    }

    if (groupRow) {
        displayLastUpdate();
    }
}

function getClientId() {
    if (clientId && clientId.trim().length > 0) return clientId;

    const urlParams = new URLSearchParams(window.location.search);

    var clientId = urlParams.get("id");
    if (!clientId || clientId.trim().length === 0)
        clientId = clientIP;

    if (clientId && clientId.trim().length > 0) {
        clientId = clientId.trim();
        document.getElementById("client-id").innerText = clientId;
        return clientId;
    }
    else {
        displayError("İstemci bilgisi bulunamadı");
        return null;
    }
}

function getClientInfo() {
    if (!clientId) return;

    fetch(`${clientUri}/${clientId}`, {
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

                if (clientInfo.template) {
                    let template = JSON.parse(clientInfo.template);
                    displayHeaders(template.header);

                    if (clientInfo.groups && clientInfo.groups.length > 0) {
                        groups = clientInfo.groups.map(group => group.group).sort();

                        for (var i = 0; i < groups.length; i++) {
                            displayNotification(groups[i], '{ "columns": [ "", "" ] }');
                        }
                    }
                    else {
                        displayError("İstemcinin üye olduğu gruplar bulunamadı.");
                    }
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

    fetch(`${clientUri}/${clientId}/Notifications`, {
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

// Start displaying clock
displayClock();

// Set client id
clientId = getClientId();

// Get client info
getClientInfo();

//getNotifications(clientId);

// Start the connection.
start();