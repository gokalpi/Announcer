var uri = "/api/Clients";
var clientsTable;
var operationType;

var clientId = document.getElementById("client-id");
var clientName = document.getElementById("client-name");
var clientDescription = document.getElementById("client-description");

$(document).ready(function () {
    clientsTable = $("#clients").DataTable({
        dom: 'rt<"row justify-content-between bottom-information"lip><"clear">',
        language: {
            url: "/lib/datatables/i18n/Turkish.json"
        },
        stateSave: true,
        processing: true,
        serverSide: true,
        ajax: {
            url: `${uri}/LoadTable`,
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
            {
                data: "description"
            },
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
                        `<a class="text-danger ml-2" data-toggle="tooltip" title="Sil" onclick="deleteClient('${row.id}','${data.name}')"><i class="las la-trash-alt la-lg"></i></a></div>`;
                },
                width: "75px"
            }
        ]
    });

    $('#search').on('keyup change clear', function () {
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

    fetch(`${uri}/${id}`, {
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

                clientId.value = client.id;
                clientId.readOnly = true;
                clientName.value = client.name;
                clientDescription.value = client.description;

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

function save() {
    const client = {
        id: clientId.value.trim(),
        name: clientName.value.trim(),
        description: clientDescription.value.trim()
    };

    if (operationType === "edit") {
        fetch(`${uri}/${client.id}`, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
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
        fetch(uri, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
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
                    swal(`${client.name} adlı istemci eklenmiştir.`, { icon: "success" });
                }
                else {
                    swal("İstemci Ekleme Hatası", data.message, "error");
                }
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
                fetch(`${uri}/${id}`, {
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