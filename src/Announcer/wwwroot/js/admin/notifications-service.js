var notificationsUri = "/api/Notifications";
var clientsUri = "/api/Clients";
var groupsUri = "/api/Groups";
var notificationsTable;
var operationType;

var notificationId = document.getElementById("notification-id");
var notificationContent = document.getElementById("notification-content");
var notificationSender = document.getElementById("notification-sender");
var notificationSentTime = document.getElementById("notification-sent-time");
var notificationGroup = document.getElementById("notification-group");
var notificationRecipient = document.getElementById("notification-recipient");

$(document).ready(function () {
    notificationsTable = $("#notifications").DataTable({
        dom: 'rt<"row justify-content-between bottom-information"lip><"clear">',
        language: {
            url: "/lib/datatables/i18n/Turkish.json"
        },
        stateSave: true,
        processing: true,
        serverSide: true,
        ajax: {
            url: `${notificationsUri}/LoadTable`,
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            }
        },
        // Columns Setups
        columns: [
            { data: "id", visible: false },
            { data: "content" },
            {
                data: "sentTime",
                render: function (data, type, row) {
                    if (type === 'display' || type === 'filter') {
                        const options = { year: 'numeric', month: 'long', day: 'numeric', hour: '2-digit', minute: '2-digit', second: '2-digit' };
                        var sentTime = new Intl.DateTimeFormat('tr-TR', options).format(new Date(data));
                        return sentTime;
                    }
                    else
                        return data;
                }
            },
            { data: "sender" },
            { data: "group" },
            { data: "recipient" },
            {
                data: null,
                orderable: false,
                render: function (data, type, row) {
                    var statusHTML = (data.isDeleted) ? `<span class="btn btn-xs btn-font-sm btn-bold btn-label-danger">Silindi</span>` : `<span class="btn btn-xs btn-font-sm btn-bold btn-label-success">Aktif</span>`;
                    return statusHTML;
                }
            },
            {
                data: null,
                orderable: false,
                searchable: false,
                render: function (data, type, row) {
                    return '<div class="action-buttons">' +
                        `<a class="text-primary" data-toggle="tooltip" title="Güncelle" onclick="displayEditModal('${row.id}')"><i class="las la-pencil-alt la-lg"></i></a>` +
                        `<a class="text-danger ml-2" data-toggle="tooltip" title="Sil" onclick="deleteNotification('${row.id}')"><i class="las la-trash-alt la-lg"></i></a></div>`;
                },
                width: "75px"
            }
        ]
    });

    $('#search').on('keyup change clear', function () {
        if (notificationsTable.search() !== this.value) {
            notificationsTable.search(this.value);
            notificationsTable.columns(6).search($('#status').val());
            notificationsTable.draw();
        }
    });

    $('#status').on('change', function () {
        notificationsTable.search($('#search').value);
        notificationsTable.columns(6).search($(this).val()).draw();
        notificationsTable.draw();
    });
});

function displayAddModal() {
    operationType = "add";
    $("#add-edit-form")[0].reset();
    $("#modal-title").text("Yeni Mesaj");
    $("#modal-save-button").html('<i class="las la-save"></i> Ekle');
    $("#modal-form").modal('show');
}

function getClients() {
    fetch(clientsUri, {
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
                let clients = data.model;
                var clientList = $("");
                for (var i = 0; i < clients.length; i++) {

                };

                notificationId.value = client.id;
                notificationContent.value = client.name;
            }
            else {
                swal("Mesaj Okuma Hatası", data.message, "error");
            }
        })
        .catch(error => {
            console.error('Unable to get notification.', error);
            swal("Mesaj Okuma Hatası", error, "error");
        });
}

function displayEditModal(id) {
    operationType = "edit";
    $("#add-edit-form")[0].reset();
    $("#modal-title").text("Mesaj Güncelleme");
    $("#modal-save-button").html('<i class="las la-save"></i> Güncelle');

    fetch(`${notificationsUri}/${id}`, {
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
                let notification = data.model;

                notificationId.value = notification.id;
                notificationContent.value = notification.content;
                notificationSender.value = notification.sender;
                notificationSentTime.value = notification.sentTime;
                notificationGroup.value = notification.group;
                notificationRecipient.value = notification.recipient;

                $("#modal-form").modal('show');
            }
            else {
                swal("Mesaj Okuma Hatası", data.message, "error");
            }
        })
        .catch(error => {
            console.error('Unable to get notification.', error);
            swal("Mesaj Okuma Hatası", error, "error");
        });
}

function save() {
    const notification = {
        id: notificationId.value.trim(),
        content: notificationContent.value.trim(),
        senderId: notificationSender.value.trim(),
        sentTime: notificationSentTime.value.trim(),
        groupId: notificationGroup.value.trim(),
        recipientId: notificationRecipient.value.trim()
    };

    if (operationType === "edit") {
        fetch(`${notificationsUri}/${notification.id}`, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(notification)
        })
            .then(function (response) {
                if (!response.ok) {
                    throw Error(`${response.status} status code received.`);
                }

                return response.json();
            })
            .then(function (data) {
                if (data.isSuccessful) {
                    $("#add-edit-form")[0].reset();
                    refreshDatatable();
                    swal(`${notification.id} nolu mesaj güncellenmiştir.`, { icon: "success" });
                }
                else {
                    swal("Mesaj Güncelleme Hatası", data.message, "error");
                }
            })
            .catch(error => {
                console.error('Unable to update notification.', error);
                swal("Mesaj Güncelleme Hatası", error, "error");
            });
    }
    else {
        fetch(notificationsUri, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(notification)
        })
            .then(function (response) {
                if (!response.ok) {
                    throw Error(`${response.status} status code received.`);
                }

                return response.json();
            })
            .then(function (data) {
                if (data.isSuccessful) {
                    $("#add-edit-form")[0].reset();
                    refreshDatatable();
                    swal(`${notification.name} mesaj eklenmiştir.`, { icon: "success" });
                }
                else {
                    swal("Mesaj Ekleme Hatası", data.message, "error");
                }
            })
            .catch(error => {
                console.error('Unable to add notification.', error);
                swal("Mesaj Ekleme Hatası", error, "error");
            });
    }

    $("#modal-form").modal('hide');
}

function deleteNotification(id) {
    swal({
        title: "Emin misiniz?",
        text: `${name} nolu mesajı siliyorsunuz.`,
        icon: "warning",
        buttons: true,
        dangerMode: true
    })
        .then((willDelete) => {
            if (willDelete) {
                fetch(`${notificationsUri}/${id}`, {
                    method: 'DELETE'
                })
                    .then(function (response) {
                        if (!response.ok) {
                            throw Error(`${response.status} status code received.`);
                        }

                        return response.json();
                    })
                    .then(function (data) {
                        if (data.isSuccessful) {
                            refreshDatatable();
                            swal(`${id} nolu mesaj silinmiştir.`, { icon: "success" });
                        }
                        else {
                            swal("Mesaj Silme Hatası", data.message, "error");
                        }
                    })
                    .catch(error => {
                        console.error('Unable to delete notification.', error);
                        swal("Mesaj Silme Hatası", error, "error");
                    });
            }
        });
}

function refreshDatatable() {
    notificationsTable.ajax.reload();
}