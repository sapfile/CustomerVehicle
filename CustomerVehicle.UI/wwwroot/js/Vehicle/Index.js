$(document).ready(function () {
    $('input:radio[name=parameter]').change(function () {
        GetData();
    });
});

function GetData() {
    var radioValue = $('input[name="parameter"]:checked').val();
    var serviceURL = `/GetVehicles/${radioValue}`;

    $.ajax({
        type: "GET",
        url: serviceURL,
        success: successFunc,
        error: errorFunc
    });

    function successFunc(data, status) {
        var targetDiv = $('#vehicleList');
        targetDiv.empty();
        targetDiv.html(data);
    }
}

function errorFunc(err) {
    alert(err.responseText);
}

function DeleteVehicle(vehicleId) {
    if (confirm("Are you sure to delete this record?")) {
        var serviceURL = `/Delete/${vehicleId}`;
        $.ajax({
            type: "POST",
            url: serviceURL,
            success: successFunc,
            error: errorFunc
        });

        function successFunc(data, status) {
            GetData();
        }
    }
}