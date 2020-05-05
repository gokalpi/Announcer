var baseUri = '/api';
var clientsUri = baseUri + '/Clients';
var groupsUri = baseUri + '/Groups';
var templatesUri = baseUri + '/Templates';
var clientsTable;
var operationType;
var groups = {};
var subscribedGroups = {};
var templates = {};

var clientId = $('#client-id');
var clientName = $('#client-name');
var clientDescription = $('#client-description');
var clientTemplate = $('#client-template');

$(document).ready(function () {
    getJSON(groupsUri, setGroups);
    getJSON(templatesUri, setTemplates);

    clientsTable = $('#clients').DataTable({
        dom: 'rt<"row justify-content-between bottom-information"lip><"clear">',
        language: {
            url: '/lib/datatables/i18n/Turkish.json'
        },
        stateSave: true,
        processing: true,
        serverSide: true,
        ajax: {
            url: `${clientsUri}/LoadTable`,
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            data: function (d) {
                return JSON.stringify(d);
            }
        },
        // Columns Setups
        columns: [
            { data: 'id' },
            { data: 'name' },
            { data: 'description' },
            {
                data: 'templateName',
                orderable: false
            },
            {
                data: 'groupCount',
                orderable: false,
                searchable: false,
                className: 'text-center',
                render: function (data, type, row) {
                    return `<a class="badge badge-md badge-primary" data-toggle="tooltip" title="Gruplar" onclick="displayGroupsModal('${row.id}')">${data}</a>`;
                }
            },
            {
                data: 'notificationsSentCount',
                orderable: false,
                searchable: false,
                className: 'text-center'
            },
            {
                data: 'notificationsReceivedCount',
                orderable: false,
                searchable: false,
                className: 'text-center'
            },
            {
                data: 'isDeleted',
                className: 'text-center',
                render: function (data, type, row) {
                    return (data) ? '<span class="badge badge-pill badge-danger">Silindi</span>'
                        : '<span class="badge badge-pill badge-success">Aktif</span>';
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
                        actionButtons = actionButtons + `<a class="text-danger ml-2" data-toggle="tooltip" title="Sil" onclick="deleteClient('${row.id}', '${data.name}')"><i class="las la-trash-alt la-lg"></i></a></div>`;

                    return actionButtons;
                },
                width: '75px'
            }
        ]
    });

    $('#search').on('keyup change clear search', function () {
        if (clientsTable.search() !== $(this).val()) {
            clientsTable.search($(this).val());
            clientsTable.columns(3).search($('#status').val());
            clientsTable.draw();
        }
    });

    $('#search-group').on('keyup change clear search', function () {
        var searchResult = $('#search-result');
        searchResult.empty();

        var searchInput = $(this).val();
        if (searchInput.length > 2) {
            const clientId = $('#client').val();
            const filteredGroups = groups.filter(group => group.name.toUpperCase().includes(searchInput.toUpperCase()));

            searchResult.append(filteredGroups.map(group => {
                var item = '<li class="list-group-item" id="result-' + group.id + '">';
                item += subscribedClients.some(sub => sub.id === group.id) ?
                    displayLeaveGroup(clientId, group.id, group.name) : displayJoinGroup(clientId, group.id, group.name);
                item += '</li>';

                return item;
            }));
        }
    });

    $('#status').on('change', function () {
        clientsTable.search($('#search').val());
        clientsTable.columns(3).search($(this).val()).draw();
        clientsTable.draw();
    });
});

function compareGroups(left, right) {
    const nameLeft = left.name.toUpperCase();
    const nameRight = right.name.toUpperCase();

    let comparison = 0;
    if (nameLeft > nameRight) {
        comparison = 1;
    } else if (nameLeft < nameRight) {
        comparison = -1;
    }
    return comparison;
}

function deleteClient(id, name) {
    swal({
        title: 'Emin misiniz?',
        text: `${name} adlı istemciyi siliyorsunuz.`,
        icon: 'warning',
        buttons: true,
        dangerMode: true
    })
        .then((willDelete) => {
            if (willDelete) {
                deleteJSON(`${clientsUri}/${id}`, showDeleteClientResult);
            }
        });
}

function displayAddModal() {
    operationType = 'add';
    $('#add-edit-form')[0].reset();
    $('#modal-title').text('Yeni İstemci');
    $('#modal-save-button').html('<i class="las la-save"></i> Ekle');
    $('#client-id').attr('readonly', false);
    $('#modal-form').modal('show');
}

function displayEditModal(id) {
    operationType = 'edit';
    $('#add-edit-form')[0].reset();
    $('#modal-title').text('İstemci Güncelleme');
    $('#modal-save-button').html('<i class="las la-save"></i> Güncelle');

    getJSON(`${clientsUri}/${id}`, setEditModalData);
}

function displayGroupsModal(id) {
    $('#group-members-form')[0].reset();
    $('#client').val(id);

    getJSON(`${clientsUri}/${id}/Groups`, setGroupsModalData);
}

function displayJoinGroup(clientId, groupId, groupName) {
    return `<div>${groupName}</div>` +
        `<a class="text-success" data-toggle="tooltip" title="Grupa Üye Ol" onclick="joinGroup('${clientId}', ${groupId}, '${groupName}')">` +
        '<i class="las la-plus-circle"></i></a>';
}

function displayLeaveGroup(clientId, groupId, groupName) {
    return `<div>${groupName}</div>` +
        `<a class="text-danger" data-toggle="tooltip" title="Gruptan Çık" onclick="leaveGroup('${clientId}', ${groupId}, '${groupName}')">` +
        '<i class="las la-minus-circle"></i></a>';
}

function joinGroup(clientId, groupId, groupName) {
    swal({
        title: 'Emin misiniz?',
        text: `${groupName} adlı gruba üye oluyorsunuz.`,
        icon: 'warning',
        buttons: true,
        dangerMode: true
    })
        .then((willJoin) => {
            if (willJoin) {
                const member = {
                    groupId: parseInt(groupId),
                    clientId: clientId
                };

                postJSON(`${clientsUri}/${clientId}/Groups`, member, showJoinGroupResult);
            }
        });
}

function leaveGroup(clientId, groupId, groupName) {
    swal({
        title: 'Emin misiniz?',
        text: `${groupName} adlı gruptan çıkmak istiyorsunuz.`,
        icon: 'warning',
        buttons: true,
        dangerMode: true
    })
        .then((willDelete) => {
            if (willDelete) {
                deleteJSON(`${clientsUri}/${clientId}/Groups/${groupId}`, showLeaveGroupResult);
            }
        });
}

function refreshDatatable() {
    clientsTable.ajax.reload();
}

function refreshSubscribedGroups() {
    const clientId = $('#client').val();
    console.log('subscribedGroups', subscribedGroups);
    var groupList = $('#subscribed-groups-list');
    groupList.empty();
    groupList.append(subscribedGroups.map(group => '<li class="list-group-item">' + displayLeaveGroup(clientId, group.id, group.name) + '</li>'));
}

function save() {
    const client = {
        id: clientId.val().trim(),
        name: clientName.val().trim(),
        description: clientDescription.val().trim(),
        templateId: parseInt(clientTemplate.val().trim())
    };

    if (operationType === 'edit') {
        putJSON(`${clientsUri}/${client.id}`, client, showEditResult);
    }
    else {
        postJSON(clientsUri, client, showAddClientResult);
    }

    $('#modal-form').modal('hide');
}

function setGroups(result) {
    if (result.isSuccessful) {
        groups = result.model;
    }
    else {
        swal('Grup Okuma Hatası', result.message, 'error');
    }
}

function setGroupsModalData(result) {
    if (result.isSuccessful) {
        subscribedGroups = result.model;

        refreshSubscribedGroups();

        $('#subscribed-groups-modal').modal('show');
    }
    else {
        swal('İstemci Okuma Hatası', result.message, 'error');
    }
}

function setEditModalData(result) {
    if (result.isSuccessful) {
        let client = result.model;

        clientId.val(client.id);
        clientId.readOnly = true;
        clientName.val(client.name);
        clientDescription.val(client.description);
        clientTemplate.val(client.templateId);

        $('#modal-form').modal('show');
    }
    else {
        swal('İstemci Okuma Hatası', result.message, 'error');
    }
}

function setTemplates(result) {
    if (result.isSuccessful) {
        templates = result.model;

        if (templates) {
            var templateList = $('#client-template');
            templateList.empty();
            templateList.append(templates.map(template => '<option value="' + template.id + '">' + template.name + '</option>'));
        }
    }
    else {
        swal('Şablon Okuma Hatası', result.message, 'error');
    }
}

function showAddClientResult(result) {
    if (result) {
        refreshDatatable();
        swal(`${result.name} adlı istemci eklenmiştir.`, { icon: 'success' });
    }
    else {
        swal('İstemci Ekleme Hatası', 'İstemci Eklenenemiştir', 'error');
    }
}

function showDeleteClientResult(result) {
    if (result.isSuccessful) {
        refreshDatatable();
        swal('İstemci silinmiştir.', { icon: 'success' });
    }
    else {
        swal('İstemci Silme Hatası', result.message, 'error');
    }
}

function showEditResult(result) {
    if (result.isSuccessful) {
        $('#add-edit-form')[0].reset();
        refreshDatatable();
        swal(`${result.model.name} adlı istemci güncellenmiştir.`, { icon: 'success' });
    }
    else {
        swal('İstemci Güncelleme Hatası', result.message, 'error');
    }
}

function showJoinGroupResult(result) {
    if (result.isSuccessful) {
        subscribedGroups.push({ id: result.model.groupId, name: result.model.group });
        subscribedGroups = subscribedGroups.sort(compareGroups);
        refreshSubscribedGroups();

        var groupToUpdate = $('#result-' + result.model.groupId);
        groupToUpdate.html(displayLeaveGroup(result.model.clientId, result.model.groupId, result.model.group));

        swal(`${result.model.group} adlı gruba üye olundu.`, { icon: 'success' });
    }
    else {
        swal('Gruba Ekleme Hatası', 'Gruba Üye Olunamamıştır', 'error');
    }
}

function showLeaveGroupResult(result) {
    if (result.isSuccessful) {
        subscribedGroups = subscribedGroups.filter(group => group.id !== result.model.groupId);
        refreshSubscribedGroups();

        var groupToUpdate = $('#result-' + result.model.groupId);
        groupToUpdate.html(displayJoinGroup(result.model.clientId, result.model.groupId, result.model.group));

        swal(`${result.model.group} grubundan çıkılmıştır.`, { icon: 'success' });
    }
    else {
        swal('Gruptan Çıkma Hatası', result.message, 'error');
    }
}