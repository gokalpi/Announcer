var uri = "/api/Templates";
var templatesTable;
var operationType;

var templateId = document.getElementById("template-id");
var templateName = document.getElementById("template-name");
var templateContent = document.getElementById("template-content");

const jsonHeaders = new Headers({
    'Accept': 'application/json',
    'Content-Type': 'application/json'
});

$(document).ready(function () {
    templatesTable = $("#templates").DataTable({
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
            {
                data: "content",
                orderable: false,
            },
            {
                data: "clientCount",
                orderable: false,
                searchable: false
            },
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
                        actionButtons = actionButtons + `<a class="text-danger ml-2" data-toggle="tooltip" title="Sil" onclick="deleteTemplate('${row.id}','${data.name}')"><i class="las la-trash-alt la-lg"></i></a></div>`;

                    return actionButtons;
                },
                width: "75px"
            }
        ]
    });

    $('#search').on('keyup change clear search', function () {
        if (templatesTable.search() !== this.value) {
            templatesTable.search(this.value);
            templatesTable.columns(3).search($('#status').val());
            templatesTable.draw();
        }
    });

    $('#status').on('change', function () {
        templatesTable.search($('#search').value);
        templatesTable.columns(3).search($(this).val()).draw();
        templatesTable.draw();
    });
});

function displayAddModal() {
    operationType = "add";
    $("#add-edit-form")[0].reset();
    $("#modal-title").text("Yeni Şablon");
    $("#modal-save-button").html('<i class="las la-save"></i> Ekle');
    $("#modal-form").modal('show');
}

function displayEditModal(id) {
    operationType = "edit";
    $("#add-edit-form")[0].reset();
    $("#modal-title").text("Şablon Güncelleme");
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
                let template = data.model;
                console.log('template: %o', template);

                templateId.value = template.id;
                templateName.value = template.name;
                templateContent.value = template.content;

                $("#modal-form").modal('show');
            }
            else {
                swal("Şablon Okuma Hatası", data.message, "error");
            }
        })
        .catch(error => {
            console.error("Unable to get template.", error);
            swal("Şablon Okuma Hatası", error, "error");
        });
}

function save() {
    const template = {
        id: templateId.value.trim(),
        name: templateName.value.trim(),
        content: templateContent.value.trim()
    };

    if (operationType === "edit") {
        fetch(`${uri}/${template.id}`, {
            method: 'PUT',
            headers: jsonHeaders,
            body: JSON.stringify(template)
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
                    swal(`${template.name} adlı şablon güncellenmiştir.`, { icon: "success" });
                }
                else {
                    swal("Şablon Güncelleme Hatası", data.message, "error");
                }
            })
            .catch(error => {
                console.error("Unable to update template.", error);
                swal("Şablon Güncelleme Hatası", error, "error");
            });
    }
    else {
        fetch(uri, {
            method: 'POST',
            headers: jsonHeaders,
            body: JSON.stringify(template)
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
                swal(`${data.name} adlı şablon eklenmiştir.`, { icon: "success" });
            })
            .catch(error => {
                console.error("Unable to add template.", error);
                swal("Şablon Ekleme Hatası", error, "error");
            });
    }

    $("#modal-form").modal('hide');
}

function deleteTemplate(id, name) {
    swal({
        title: "Emin misiniz?",
        text: `${name} şablonu siliyorsunuz.`,
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
                            swal(`${name} adlı şablon silinmiştir.`, { icon: "success" });
                        }
                        else {
                            swal("Şablon Silme Hatası", data.message, "error");
                        }
                    })
                    .catch(error => {
                        console.error("Unable to delete template.", error);
                        swal("Şablon Silme Hatası", error, "error");
                    });
            }
        });
}

function refreshDatatable() {
    templatesTable.ajax.reload();
}