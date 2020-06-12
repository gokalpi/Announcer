const jsonHeaders = new Headers({
    'Accept': 'application/json',
    'Content-Type': 'application/json'
});

function logResult(result) {
    console.log(result);
}

function logError(error) {
    console.error('Hata: \n', error);
    alert('Hata' + error);
}

function readResponseAsJSON(response) {
    return response.json();
}

function validateResponse(response) {
    if (!response.ok) {
        throw Error(response.statusText);
    }
    return response;
}

function deleteJSON(pathToResource, action) {
    fetch(pathToResource, {
        method: 'DELETE',
        headers: jsonHeaders
    })
        .then(validateResponse)
        .then(readResponseAsJSON)
        .then(action)
        .catch(logError);
}

function getJSON(pathToResource, action) {
    fetch(pathToResource, {
        method: 'GET',
        headers: jsonHeaders
    })
        .then(validateResponse)
        .then(readResponseAsJSON)
        .then(action)
        .catch(logError);
}

function postJSON(pathToResource, body, action) {
    fetch(pathToResource, {
        method: 'POST',
        headers: jsonHeaders,
        body: JSON.stringify(body)
    })
        .then(validateResponse)
        .then(readResponseAsJSON)
        .then(action)
        .catch(logError);
}

function putJSON(pathToResource, body, action) {
    fetch(pathToResource, {
        method: 'PUT',
        headers: jsonHeaders,
        body: JSON.stringify(body)
    })
        .then(validateResponse)
        .then(readResponseAsJSON)
        .then(action)
        .catch(logError);
}