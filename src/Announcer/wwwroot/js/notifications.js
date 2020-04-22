// jshint esversion: 6
var hubUri = "/NotificationHub";
var clientUri = "/api/Clients";
var infoColumnCount = 0;
var groups;

// QRCode generation
var qrCodeUri = location.href;
var qrcode = new QRCode(document.getElementById("qrcode"), {
    text: qrCodeUri,
    width: 100,
    height: 100
});

// Create SignalR connection
var connection = new signalR.HubConnectionBuilder()
    .withUrl(hubUri)
    .withAutomaticReconnect()
    .configureLogging(signalR.LogLevel.Error)
    .build();

// Start SignalR connection
function start() {
    connection.start().then(function () {
        if (connection.state === signalR.HubConnectionState.Connected) {
            console.log('Connected to hub at ' + hubUri);

            // Get client Info
            getClientInfo(clientId);
        }
    }).catch(error => {
        displayError(error);

        // If disconnected, start connection in 5 seconds
        if (connection.state === signalR.HubConnectionState.Disconnected) {
            setTimeout(() => start(), 5000);
        }
    });
}

// On reconnecting to the hub
connection.onreconnecting((error) => {
    console.log('Reconnecting');

    // Show loader animation
    document.getElementById('loader-wrapper').hidden = false;

    var groupRows = document.getElementsByClassName('notification-item');
    for (var i = 0; i < groupRows.length; i++) {
        groupRows[i].className = 'notification-item disconnected';
        var groupCols = groupRows[i].getElementsByClassName('group-col');
        for (var j = 0; j < groupCols.length; j++) {
            groupCols[j].innerHTML = '';
        }
    }

    console.assert(connection.state === signalR.HubConnectionState.Reconnecting);

    console.warn(`Connection lost due to error "${error}". Reconnecting.`);
});

// On reconnected to the hub
connection.onreconnected((connectionId) => {
    console.log('Reconnected');

    // Hide loader animation
    document.getElementById('loader-wrapper').hidden = true;

    var groupRows = document.getElementsByClassName('notification-item');
    for (var i = 0; i < groupRows.length; i++) {
        groupRows[i].className = 'notification-item';
    }

    console.assert(connection.state === signalR.HubConnectionState.Connected);

    // Client reconnected, so get client info again
    getClientInfo(clientId);

    console.warn(`Connection reestablished and joined to the groups. Connected with connectionId "${connectionId}".`);
});

// On closed connection to the hub
connection.onclose(error => {
    console.assert(connection.state === signalR.HubConnectionState.Disconnected);

    // Leave groups
    if (groups) {
        for (var j = 0; j < groups.length; j++) {
            console.log('On close - leaving groups[%d]: %o', j, groups[j]);
            leaveGroup(groups[j]);
        }
    }

    console.warn('Connection closed due to error ' + error + '. Try refreshing this page to restart the connection.');
});

// When user connected to the hub
connection.on("UserConnected", function (connectionId) {
    console.log(`Client connected with connection id "${connectionId}"`);
});

// When user disconnected from the hub
connection.on("UserDisconnected", function (user, connectionId) {
    console.log(`Client disconnected with connection id "${connectionId}"`);
});

// When user joined to a group
connection.on("JoinedGroup", function (user, group) {
    console.log(`Client "${user}" joined to group "${group}"`);
});

// When user leaves a group
connection.on("LeftGroup", function (user, group) {
    console.log(`Client "${user}" left group "${group}"`);
});

// Group message received function
connection.on("ReceiveGroupMessage", function (req) {
    displayNotification(req.group, req.message);
});

// Message received function
connection.on("ReceiveMessage", function (message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");

    console.log(msg);
});

function joinGroup(groupName) {
    if (groupName) {
        connection.invoke("AddToGroupAsync", groupName).then(function () {
            //console.log(`Joined to "${groupName}" group`);
        }).catch(error => displayError(error));
    }
}

function leaveGroup(groupName) {
    if (groupName) {
        connection.invoke("RemoveFromGroupAsync", groupName).then(function () {
            //console.log(`Left "${groupName}" group`);
        }).catch(error => displayError(error));
    }
}

function displayClock() {
    const options = { hour: '2-digit', minute: '2-digit', second: '2-digit' };
    let clock = document.getElementById("clock");
    if (clock) {
        clock.innerText = new Intl.DateTimeFormat('tr-TR', options).format(new Date());
    }

    setTimeout(function () {
        displayClock();
    }, 1000);
}

function displayError(error) {
    var errorBody = document.getElementById("error-pane");
    var errorMessage = document.getElementById("error-message");

    errorMessage.innerText = error;

    errorBody.style = "";

    // setTimeout(function () {
    //    errorBody.style = "display: none";
    //}, 10000);
}

function displayHeaders(header) {
    if (!header) return;

    var pageHeader = document.getElementById("notifications-header");
    if (pageHeader) {
        // Remove all header columns
        pageHeader.querySelectorAll('*').forEach(n => n.remove());

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

        groupRow.className = "notification-item active";
        setTimeout(() => groupRow.className = "notification-item", 6500);
    }
    else {
        var notifications = document.getElementById('notifications');
        if (notifications) {
            groupRow = document.createElement('div');
            groupRow.id = groupRowId;
            groupRow.className = "notification-item active";
            setTimeout(() => groupRow.className = "notification-item", 6500);

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

function getClientInfo(id) {
    if (!id) return null;

    fetch(`${clientUri}/${id}`, {
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
                let client = data.model;
                if (client.template) {
                    let template = JSON.parse(client.template);

                    displayHeaders(template.header);

                    if (client.groups && client.groups.length > 0) {
                        groups = client.groups.map(group => group.group).sort();

                        for (var i = 0; i < groups.length; i++) {
                            displayNotification(groups[i], '{ "columns": [ "", "" ] }');
                            joinGroup(groups[i]);
                        }

                        getNotifications(id);
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

function getNotifications(id) {
    if (!id) return;

    fetch(`${clientUri}/${id}/GroupNotifications`, {
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

                for (var i = 0; i < notifications.length; i++) {
                    displayNotification(notifications[i].group, notifications[i].content);
                }
            }
            else {
                displayError("İstemcinin mesajları okunamadı. " + data.message);
            }
        })
        .catch(error => {
            displayError("İstemcinin mesajları bulunamadı. " + error);
        });
}

function setClientId(id) {
    var clientId;

    if (id && id.trim().length > 0) {
        clientId = id;
    }
    else {
        const urlParams = new URLSearchParams(window.location.search);

        clientId = urlParams.get("id");
        if (!clientId || clientId.trim().length === 0)
            clientId = clientIP;
    }

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