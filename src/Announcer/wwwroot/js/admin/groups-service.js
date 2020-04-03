var uri = "/api/v1/Groups";
var groupsTable;
var operationType;

var groupId = document.getElementById("group-id");
var groupName = document.getElementById("group-name");
var groupDescription = document.getElementById("group-description");

$(document).ready(function () {
    groupsTable = $("#groups").DataTable({
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
            { data: "id", visible: false },
            { data: "name" },
            { data: "description" },
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
                        `<a class="text-danger ml-2" data-toggle="tooltip" title="Sil" onclick="deleteGroup('${row.id}','${data.name}')"><i class="las la-trash-alt la-lg"></i></a></div>`;
                },
                width: "75px"
            }
        ]
    });

    $('#search').on('keyup change clear', function () {
        if (groupsTable.search() !== this.value) {
            groupsTable.search(this.value);
            groupsTable.columns(3).search($('#status').val());
            groupsTable.draw();
        }
    });

    $('#status').on('change', function () {
        groupsTable.search($('#search').value);
        groupsTable.columns(3).search($(this).val()).draw();
        groupsTable.draw();
    });
});

function displayAddModal() {
    operationType = "add";
    $("#add-edit-form")[0].reset();
    $("#modal-title").text("Yeni Grup");
    $("#modal-save-button").html('<i class="las la-save"></i> Ekle');
    $("#modal-form").modal('show');
}

function displayEditModal(id) {
    operationType = "edit";
    $("#add-edit-form")[0].reset();
    $("#modal-title").text("Grup Güncelleme");
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
                let group = data.model;

                groupId.value = group.id;
                groupName.value = group.name;
                groupDescription.value = group.description;

                $("#modal-form").modal('show');
            }
            else {
                swal("Grup Okuma Hatası", data.message, "error");
            }
        })
        .catch(error => {
            console.error('Unable to get group.', error);
            swal("Grup Okuma Hatası", error, "error");
        });
}

function save() {
    const group = {
        id: groupId.value.trim(),
        name: groupName.value.trim(),
        description: groupDescription.value.trim()
    };

    if (operationType === "edit") {
        fetch(`${uri}/${group.id}`, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(group)
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
                    swal(`${group.name} adlı grup güncellenmiştir.`, { icon: "success" });
                }
                else {
                    swal("Grup Güncelleme Hatası", data.message, "error");
                }
            })
            .catch(error => {
                console.error('Unable to update group.', error);
                swal("Grup Güncelleme Hatası", error, "error");
            });
    }
    else {
        fetch(uri, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(group)
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
                    swal(`${group.name} adlı grup eklenmiştir.`, { icon: "success" });
                }
                else {
                    swal("Grup Ekleme Hatası", data.message, "error");
                }
            })
            .catch(error => {
                console.error('Unable to add group.', error);
                swal("Grup Ekleme Hatası", error, "error");
            });
    }

    $("#modal-form").modal('hide');
}

function deleteGroup(id, name) {
    swal({
        title: "Emin misiniz?",
        text: `${name} grubunu siliyorsunuz.`,
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
                            swal(`${name} adlı grup silinmiştir.`, { icon: "success" });
                        }
                        else {
                            swal("Grup Silme Hatası", data.message, "error");
                        }
                    })
                    .catch(error => {
                        console.error('Unable to delete group.', error);
                        swal("Grup Silme Hatası", error, "error");
                    });
            }
        });
}

function refreshDatatable() {
    groupsTable.ajax.reload();
}