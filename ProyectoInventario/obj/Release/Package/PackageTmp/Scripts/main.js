$(document).ready(function () {

    $("select").prop('class', 'selectpicker form-control');

    $(".datePicker").datetimepicker();

    $("#fechaHasta").on('blur', function () {
        var fecha1 = new Date($("#fechaDesde").val());
        var fecha2 = new Date($("#fechaHasta").val());

        if (fecha2 <= fecha1) {
            alert("Fecha Hasta debe ser mayor que Fecha Desde ")
            $("#fechaDesde").val("");
            $("#fechaHasta").val("");
        }
    });
    

});