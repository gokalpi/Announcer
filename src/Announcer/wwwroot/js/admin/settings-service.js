var uri = "/api/Settings";
var settingsTable;
var operationType;

var settingId = document.getElementById("setting-id");
var settingKey = document.getElementById("setting-key");
var settingValue = document.getElementById("setting-value");

const jsonHeaders = new Headers({
    'Accept': 'application/json',
    'Content-Type': 'application/json'
});

$(document).ready(function () {
    settingsTable = $("#settings").DataTable({
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
            { data: "key" },
            { data: "value" },
            {
                data: "isDeleted",
                className: "text-center",
                render: function (data, type, row) {
                    return (data) ? '<span class="btn btn-xs btn-font-sm btn-bold btn-label-danger">Silindi</span>'
                        : '<span class="btn btn-xs btn-font-sm btn-bold btn-label-success">Aktif</span>';
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
                        actionButtons = actionButtons + `<a class="text-danger ml-2" data-toggle="tooltip" title="Sil" onclick="deleteSetting('${row.id}','${data.key}')"><i class="las la-trash-alt la-lg"></i></a></div>`;

                    return actionButtons;
                },
                width: "75px"
            }
        ]
    });

    $('#search').on('keyup change clear search', function () {
        if (settingsTable.search() !== this.value) {
            settingsTable.search(this.value);
            settingsTable.columns(2).search($('#status').val());
            settingsTable.draw();
        }
    });

    $('#status').on('change', function () {
        settingsTable.search($('#search').value);
        settingsTable.columns(2).search($(this).val()).draw();
        settingsTable.draw();
    });
});

function displayAddModal() {
    operationType = "add";
    $("#add-edit-form")[0].reset();
    $("#modal-title").text("Yeni Ayar");
    $("#modal-save-button").html('<i class="las la-save"></i> Ekle');
    $("#modal-form").modal('show');
}

function displayEditModal(id) {
    operationType = "edit";
    $("#add-edit-form")[0].reset();
    $("#modal-title").text("Ayar Güncelleme");
    $("#modal-save-button").html('<i class="las la-save"></i> Güncelle');

    fetch(`${uri}/${id}`, {
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
                let setting = data.model;

                settingId.value = setting.id;
                settingKey.value = setting.key;
                settingValue.value = setting.value;

                $("#modal-form").modal('show');
            }
            else {
                swal("Ayar Okuma Hatası", data.message, "error");
            }
        })
        .catch(error => {
            console.error("Unable to get setting.", error);
            swal("Ayar Okuma Hatası", error, "error");
        });
}

function save() {
    const setting = {
        id: settingId.value.trim(),
        key: settingKey.value.trim(),
        value: settingValue.value.trim()
    };

    if (operationType === "edit") {
        fetch(`${uri}/${setting.id}`, {
            method: 'PUT',
            headers: jsonHeaders,
            body: JSON.stringify(setting)
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
                    swal(`${setting.key} adlı ayar güncellenmiştir.`, { icon: "success" });
                }
                else {
                    swal("Ayar Güncelleme Hatası", data.message, "error");
                }
            })
            .catch(error => {
                console.error("Unable to update setting.", error);
                swal("Ayar Güncelleme Hatası", error, "error");
            });
    }
    else {
        fetch(uri, {
            method: 'POST',
            headers: jsonHeaders,
            body: JSON.stringify(setting)
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
                swal(`${data.key} adlı ayar eklenmiştir.`, { icon: "success" });
            })
            .catch(error => {
                console.error("Unable to add setting.", error);
                swal("Ayar Ekleme Hatası", error, "error");
            });
    }

    $("#modal-form").modal('hide');
}

function deleteSetting(id, key) {
    swal({
        title: "Emin misiniz?",
        text: `${key} ayarını siliyorsunuz.`,
        icon: "warning",
        buttons: true,
        dangerMode: true
    })
        .then((willDelete) => {
            if (willDelete) {
                fetch(`${uri}/${id}`, {
                    method: 'DELETE',
                    headers: jsonHeaders
                })
                    .then(function (response) {
                        if (!response.ok) {
                            throw Error(`${response.status} status code received.`);
                        }

                        return response.json();
                    })
                    .then(function (data) {
                        console.log('data: ', data);
                        if (data.isSuccessful) {
                            refreshDatatable();
                            swal(`${key} adlı ayar silinmiştir.`, { icon: "success" });
                        }
                        else {
                            swal("Ayar Silme Hatası", data.message, "error");
                        }
                    })
                    .catch(error => {
                        console.error("Unable to delete setting.", error);
                        swal("Ayar Silme Hatası", error, "error");
                    });
            }
        });
}

function refreshDatatable() {
    settingsTable.ajax.reload();
}