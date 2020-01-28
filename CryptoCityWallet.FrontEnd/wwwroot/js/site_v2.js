// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function getFormData(form) {
    var unindexed_array = $(form).serializeArray();
    var indexed_array = {};

    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });

    return JSON.stringify(indexed_array);
}

function showPreload(e) {
    e.innerHTML = "Loading...";
    e.style.opacity = 0.5;
    e.setAttribute("editable", true);
}

function sendFormData(url, type, form) {
    $.ajax({
        url: url,
        type: type,
        data: getFormData(form),
        contentType: 'application/json',
        success: function (data) {
            //console.log(data);
            if (data.Message != undefined) {
                alert(data.Message);
            }
            //window.location = data.RedirectUrl;
            window.location.replace(data.RedirectUrl);
        },
        error: function (data, textStatus, jqXHR) {
            console.log(data.responseJSON);
            document.getElementById("myModal").getElementsByClassName("modal-title")[0].innerHTML = data.responseJSON.Status;
            document.getElementById("myModal").getElementsByClassName("modal-message")[0].innerHTML = data.responseJSON.Message;
            $('#myModal').modal('show');
            //window.location.href = data.responseJSON.RedirectUrl;
        },
    });

    return false
}

function sendFormData_V2(url, type, form) {
    $.ajax({
        url: url,
        type: type,
        data: getFormData(form),
        contentType: 'application/json',
        success: function (data) {
            //console.log(data);
            if (data.Message != undefined) {
                alert(data.Message);
            }
            //window.location = data.RedirectUrl;
            //window.location.replace(data.RedirectUrl);
        },
        error: function (data, textStatus, jqXHR) {
            console.log(data.responseJSON);
            //alert(data.responseJSON.Status);
            alert(document.getElementById("myModal").getElementsByClassName("modal-message")[0].innerHTML = data.responseJSON.Message);
            //$('#myModal').modal('show');
            //window.location.href = data.responseJSON.RedirectUrl;
        },
    });

    return false
}