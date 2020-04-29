var baseUri = "/api";
var clientsUri = baseUri + "/Clients";
var groupsUri = baseUri + "/Groups";
var templatesUri = baseUri + "/Templates";
var clientsTable;
var operationType;
var groups;
var templates;

var clientId = document.getElementById("client-id");
var clientName = document.getElementById("client-name");
var clientDescription = document.getElementById("client-description");
var clientTemplate = document.getElementById("client-template");

const jsonHeaders = new Headers({
    'Accept': 'application/json',
    'Content-Type': 'application/json'
});

$(document).ready(function () {
    getAllGroups();
    getAllTemplates();

    clientsTable = $("#clients").DataTable({
        dom: 'rt<"row justify-content-between bottom-information"lip><"clear">',
        language: {
            url: "/lib/datatables/i18n/Turkish.json"
        },
        stateSave: true,
        processing: true,
        serverSide: true,
        ajax: {
            url: `${clientsUri}/LoadTable`,
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            data: function (d) {
                return JSON.stringify(d);
            }
        },
        // Columns Setups
        columns: [
            { data: "id" },
            { data: "name" },
            { data: "description" },
            {
                data: "templateName",
                orderable: false
            },
            {
                data: "groupCount",
                orderable: false,
                searchable: false,
                className: "text-center"
            },
            {
                data: "notificationsSentCount",
                orderable: false,
                searchable: false,
                className: "text-center"
            },
            {
                data: "notificationsReceivedCount",
                orderable: false,
                searchable: false,
                className: "text-center"
            },
            {
                data: "isDeleted",
                className: "text-center",
                render: function (data, type, row) {
                    return (data) ? `<span class="btn btn-xs btn-font-sm btn-bold btn-label-danger">Silindi</span>`
                        : `<span class="btn btn-xs btn-font-sm btn-bold btn-label-success">Aktif</span>`;
                }
            },
            {
                data: null,
                orderable: false,
                searchable: false,
                render: function (data, type, row) {
                    var actionButtons = '<div class="action-buttons">' +
                        `<a class="text-primary" data-toggle="tooltip" title="Güncelle" onclick="displayEditModal('${row.id}')"><i class="las la-pencil-alt la-lg"></i></a>`;

                    if (row.isDeleted)
                        actionButtons = actionButtons + '<i class="las la-trash-alt la-lg ml-2"></i>';
                    else
                        actionButtons = actionButtons + `<a class="text-danger ml-2" data-toggle="tooltip" title="Sil" onclick="deleteClient('${row.id}','${data.name}')"><i class="las la-trash-alt la-lg"></i></a></div>`;

                    return actionButtons;
                },
                width: "75px"
            }
        ]
    });

    $('#search').on('keyup change clear search', function () {
        if (clientsTable.search() !== this.value) {
            clientsTable.search(this.value);
            clientsTable.columns(3).search($('#status').val());
            clientsTable.draw();
        }
    });

    $('#status').on('change', function () {
        clientsTable.search($('#search').value);
        clientsTable.columns(3).search($(this).val()).draw();
        clientsTable.draw();
    });
});

function displayAddModal() {
    operationType = "add";
    $("#add-edit-form")[0].reset();
    $("#modal-title").text("Yeni İstemci");
    $("#modal-save-button").html('<i class="las la-save"></i> Ekle');
    clientId.readOnly = false;

    $("#modal-form").modal('show');
}

function displayEditModal(id) {
    operationType = "edit";
    $("#add-edit-form")[0].reset();
    $("#modal-title").text("İstemci Güncelleme");
    $("#modal-save-button").html('<i class="las la-save"></i> Güncelle');

    fetch(`${clientsUri}/${id}`, {
        method: 'GET',
        headers: jsonHeaders
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

                clientId.value = client.id;
                clientId.readOnly = true;
                clientName.value = client.name;
                clientDescription.value = client.description;
                clientTemplate.value = client.templateId;
                //const subscribedGroups = client.groups.map(group => group.group);

                //if (groups) {
                //    var groupList = $("#client-group-list");
                //    groupList.empty();

                //    var c = document.createDocumentFragment();
                //    for (var i = 0; i < groups.length; i++) {
                //        var selected = "";
                //        if (subscribedGroups.includes(groups[i].name)) {
                //            console.log(groups[i].name + " found");
                //            selected = " checked";
                //        };
                //        var e = document.createElement("div");
                //        e.className = "custom-control custom-checkbox mb-3";
                //        e.innerHTML = '<input class="custom-control-input" type="checkbox" id="group-' + groups[i].id + '" value="' + groups[i].id + '"' + selected +
                //            '><label class="custom-control-label" for="group-' + groups[i].id + '">' + groups[i].name + '</label>';
                //        c.appendChild(e);
                //    }

                //    groupList.append(c);
                //}

                $("#modal-form").modal('show');
            }
            else {
                swal("İstemci Okuma Hatası", data.message, "error");
            }
        })
        .catch(error => {
            console.error('Unable to get client.', error);
            swal("İstemci Okuma Hatası", error, "error");
        });
}

function getAllGroups() {
    fetch(groupsUri, {
        method: 'GET',
        headers: jsonHeaders
    })
        .then(function (response) {
            if (!response.ok) {
                throw Error(`${response.status} status code received.`);
            }

            return response.json();
        })
        .then(function (data) {
            if (data.isSuccessful) {
                groups = data.model;
            }
            else {
                swal("Grup Okuma Hatası", data.message, "error");
            }
        })
        .catch(error => {
            console.error('Unable to get groups.', error);
            swal("Grup Okuma Hatası", error, "error");
        });
}

function getAllTemplates() {
    fetch(templatesUri, {
        method: 'GET',
        headers: jsonHeaders
    })
        .then(function (response) {
            if (!response.ok) {
                throw Error(`${response.status} status code received.`);
            }

            return response.json();
        })
        .then(function (data) {
            if (data.isSuccessful) {
                templates = data.model;

                if (templates) {
                    var templateList = $("#client-template");
                    templateList.empty();

                    var d = document.createDocumentFragment();
                    for (var j = 0; j < templates.length; j++) {
                        var f = document.createElement("option");
                        f.value = templates[j].id;
                        f.innerText = templates[j].name;
                        d.appendChild(f);
                    }

                    templateList.append(d);
                }
            }
            else {
                swal("Şablon Okuma Hatası", data.message, "error");
            }
        })
        .catch(error => {
            console.error('Unable to get templates.', error);
            swal("Şablon Okuma Hatası", error, "error");
        });
}

function save() {
    const client = {
        id: clientId.value.trim(),
        name: clientName.value.trim(),
        description: clientDescription.value.trim(),
        templateId: clientTemplate.value.trim()
    };

    if (operationType === "edit") {
        fetch(`${clientsUri}/${client.id}`, {
            method: 'PUT',
            headers: jsonHeaders,
            body: JSON.stringify(client)
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
                    swal(`${client.name} adlı istemci güncellenmiştir.`, { icon: "success" });
                }
                else {
                    swal("İstemci Güncelleme Hatası", data.message, "error");
                }
            })
            .catch(error => {
                console.error('Unable to update client.', error);
                swal("İstemci Güncelleme Hatası", error, "error");
            });
    }
    else {
        fetch(clientsUri, {
            method: 'POST',
            headers: jsonHeaders,
            body: JSON.stringify(client)
        })
            .then(function (response) {
                if (!response.ok) {
                    throw Error(`${response.status} status code received.`);
                }

                return response.json();
            })
            .then(function (data) {
                $("#add-edit-form")[0].reset();
                refreshDatatable();
                swal(`${data.name} adlı istemci eklenmiştir.`, { icon: "success" });
            })
            .catch(error => {
                console.error('Unable to add client.', error);
                swal("İstemci Ekleme Hatası", error, "error");
            });
    }

    $("#modal-form").modal('hide');
}

function deleteClient(id, name) {
    swal({
        title: "Emin misiniz?",
        text: `${name} adlı istemciyi siliyorsunuz.`,
        icon: "warning",
        buttons: true,
        dangerMode: true
    })
        .then((willDelete) => {
            if (willDelete) {
                fetch(`${clientsUri}/${id}`, {
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
                            swal(`${name} adlı istemci silinmiştir.`, { icon: "success" });
                        }
                        else {
                            swal("Grup Silme Hatası", data.message, "error");
                        }
                    })
                    .catch(error => {
                        console.error('Unable to delete client.', error);
                        swal("İstemci Silme Hatası", error, "error");
                    });
            }
        });
}

function refreshDatatable() {
    clientsTable.ajax.reload();
}