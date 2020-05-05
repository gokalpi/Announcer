var baseUri = '/api';
var groupsUri = baseUri + '/Groups';
var clientsUri = baseUri + '/Clients';
var groupsTable;
var operationType;
var clients = {};
var subscribedClients = {};

var groupId = $('#group-id');
var groupName = $('#group-name');
var groupDescription = $('#group-description');

$(document).ready(function () {
    getJSON(clientsUri, setClients);

    groupsTable = $('#groups').DataTable({
        dom: 'rt<"row justify-content-between bottom-information"lip><"clear">',
        language: {
            url: '/lib/datatables/i18n/Turkish.json'
        },
        stateSave: true,
        processing: true,
        serverSide: true,
        ajax: {
            url: `${groupsUri}/LoadTable`,
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            data: function (d) {
                return JSON.stringify(d);
            }
        },
        // Columns Setups
        columns: [
            { data: 'id', visible: false },
            { data: 'name' },
            { data: 'description' },
            {
                data: 'clientCount',
                orderable: false,
                searchable: false,
                className: 'text-center',
                render: function (data, type, row) {
                    return `<a class="badge badge-md badge-primary" data-toggle="tooltip" title="İstemciler" onclick="displayClientsModal(${row.id})">${data}</a>`;
                }
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
                        actionButtons = actionButtons + `<a class="text-danger ml-2" data-toggle="tooltip" title="Sil" onclick="deleteGroup(${row.id}, '${data.name}')"><i class="las la-trash-alt la-lg"></i></a></div>`;

                    return actionButtons;
                },
                width: '75px'
            }
        ]
    });

    $('#search').on('keyup change clear search', function () {
        if (groupsTable.search() !== this.value) {
            groupsTable.search(this.value);
            groupsTable.columns(3).search($('#status').val());
            groupsTable.draw();
        }
    });

    $('#search-client').on('keyup change clear search', function () {
        var searchResult = $('#search-result');
        searchResult.empty();

        var searchInput = $(this).val();
        if (searchInput.length > 2) {
            const groupId = $('#group').val();
            const filteredClients = clients.filter(client => client.id.toUpperCase().includes(searchInput.toUpperCase()) ||
                client.name.toUpperCase().includes(searchInput.toUpperCase()));

            searchResult.append(filteredClients.map(client => {
                var item = '<li class="list-group-item" id="result-' + client.id.replace(new RegExp('[.]', 'g'), '-') + '">';
                item += subscribedClients.some(sub => sub.id === client.id) ?
                    displayRemoveClient(groupId, client.id, client.name) : displayAddClient(groupId, client.id, client.name);
                item += '</li>';

                return item;
            }));
        }
    });

    $('#status').on('change', function () {
        groupsTable.search($('#search').value);
        groupsTable.columns(3).search($(this).val()).draw();
        groupsTable.draw();
    });
});

function compareClients(left, right) {
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

function deleteGroup(id, name) {
    swal({
        title: 'Emin misiniz?',
        text: `${name} adlı grubu siliyorsunuz.`,
        icon: 'warning',
        buttons: true,
        dangerMode: true
    })
        .then((willDelete) => {
            if (willDelete) {
                deleteJSON(`${groupsUri}/${id}`, showDeleteGroupResult);
            }
        });
}

function displayAddModal() {
    operationType = 'add';
    $('#add-edit-form')[0].reset();
    $('#modal-title').text('Yeni Grup');
    $('#modal-save-button').html('<i class="las la-save"></i> Ekle');
    $('#modal-form').modal('show');
}

function displayClientsModal(id) {
    $('#group-members-form')[0].reset();
    $('#group').val(id);

    getJSON(`${groupsUri}/${id}/Clients`, setClientsModalData);
}

function displayEditModal(id) {
    operationType = 'edit';
    $('#add-edit-form')[0].reset();
    $('#modal-title').text('Grup Güncelleme');
    $('#modal-save-button').html('<i class="las la-save"></i> Güncelle');

    getJSON(`${groupsUri}/${id}`, setEditModalData);
}

function displayAddClient(groupId, clientId, clientName) {
    return `<div>${clientName}</div>` +
        `<a class="text-success" data-toggle="tooltip" title="Grupa Ekle" onclick="addClient(${groupId}, '${clientId}', '${clientName}')">` +
        '<i class="las la-plus-circle"></i></a>';
}

function displayRemoveClient(groupId, clientId, clientName) {
    return `<div>${clientName}</div>` +
        `<a class="text-danger" data-toggle="tooltip" title="Gruptan Çıkar" onclick="removeClient(${groupId}, '${clientId}', '${clientName}')">` +
        '<i class="las la-minus-circle"></i></a>';
}

function addClient(groupId, clientId, clientName) {
    swal({
        title: 'Emin misiniz?',
        text: `${clientName} adlı istemciyi üye yapıyorsunuz.`,
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

                postJSON(`${clientsUri}/${clientId}/Groups`, member, showAddClientResult);
            }
        });
}

function removeClient(groupId, clientId, clientName) {
    swal({
        title: 'Emin misiniz?',
        text: `${clientName} adlı istemciyi üyelikten çıkartmak istiyorsunuz.`,
        icon: 'warning',
        buttons: true,
        dangerMode: true
    })
        .then((willDelete) => {
            if (willDelete) {
                deleteJSON(`${clientsUri}/${clientId}/Groups/${groupId}`, showRemoveClientResult);
            }
        });
}

function refreshDatatable() {
    groupsTable.ajax.reload();
}

function refreshSubscribedClients() {
    const groupId = $('#group').val();

    var clientList = $('#subscribed-clients-list');
    clientList.empty();
    clientList.append(subscribedClients.map(client => '<li class="list-group-item">' + displayRemoveClient(groupId, client.id, client.name) + '</li>'));
}

function save() {
    const group = {
        id: parseInt(groupId.val().trim()),
        name: groupName.val().trim(),
        description: groupDescription.val().trim()
    };

    if (operationType === 'edit') {
        putJSON(`${groupsUri}/${group.id}`, group, showEditResult);
    }
    else {
        postJSON(groupsUri, group, showAddGroupResult);
    }

    $('#modal-form').modal('hide');
}

function setClients(result) {
    if (result.isSuccessful) {
        clients = result.model;
    }
    else {
        swal('İstemci Okuma Hatası', result.message, 'error');
    }
}

function setClientsModalData(result) {
    if (result.isSuccessful) {
        subscribedClients = result.model;

        refreshSubscribedClients();

        $('#subscribed-clients-modal').modal('show');
    }
    else {
        swal('İstemci Okuma Hatası', result.message, 'error');
    }
}

function setEditModalData(result) {
    if (result.isSuccessful) {
        let group = result.model;

        groupId.val(group.id);
        groupName.val(group.name);
        groupDescription.val(group.description);

        $('#modal-form').modal('show');
    }
    else {
        swal('Grup Okuma Hatası', result.message, 'error');
    }
}

function showAddGroupResult(result) {
    if (result) {
        refreshDatatable();
        swal(`${result.name} adlı grup eklenmiştir.`, { icon: 'success' });
    }
    else {
        swal('Grup Ekleme Hatası', 'Grup Eklenenemiştir', 'error');
    }
}

function showDeleteGroupResult(result) {
    if (result.isSuccessful) {
        refreshDatatable();
        swal('Grup silinmiştir.', { icon: 'success' });
    }
    else {
        swal('Grup Silme Hatası', result.message, 'error');
    }
}

function showEditResult(result) {
    if (result.isSuccessful) {
        $('#add-edit-form')[0].reset();
        refreshDatatable();
        swal(`${result.model.name} adlı grup güncellenmiştir.`, { icon: 'success' });
    }
    else {
        swal('Grup Güncelleme Hatası', result.message, 'error');
    }
}

function showAddClientResult(result) {
    if (result.isSuccessful) {
        subscribedClients.push({ id: result.model.clientId, name: result.model.client });
        subscribedClients = subscribedClients.sort(compareClients);
        refreshSubscribedClients();

        var clientToUpdate = $('#result-' + result.model.clientId.replace(new RegExp('[.]', 'g'), '-'));
        clientToUpdate.html(displayRemoveClient(result.model.groupId, result.model.clientId, result.model.client));

        swal(`${result.model.client} adlı istemci üye yapıldı.`, { icon: 'success' });
    }
    else {
        swal('İstemci Ekleme Hatası', 'İstemci Üye Olamamıştır', 'error');
    }
}

function showRemoveClientResult(result) {
    if (result.isSuccessful) {
        subscribedClients = subscribedClients.filter(client => client.id !== result.model.clientId);
        refreshSubscribedClients();

        var clientToUpdate = $('#result-' + result.model.clientId.replace(new RegExp('[.]', 'g'), '-'));
        clientToUpdate.html(displayAddClient(result.model.groupId, result.model.clientId, result.model.client));

        swal(`${result.model.client} istemcisi üyelikten çıkartılmıştır.`, { icon: 'success' });
    }
    else {
        swal('Üyelikten Çıkarma Hatası', result.message, 'error');
    }
}