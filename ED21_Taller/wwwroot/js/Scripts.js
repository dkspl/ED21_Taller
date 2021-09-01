$(document).ready(function () {
    $('.js-example-basic-multiple').select2({
        theme: 'bootstrap4'
    });
    $('.js-example-basic-single').select2({
        theme: 'bootstrap4'
    });
    $("#show").click(function () {
        $("#elegir").toggle();
    });
    $("#FormRepuesto").submit(function (e) {
        e.preventDefault();
        $("#SubmitRepuesto").prop("disabled", true);
        var repuesto = {
            Nombre: $("#NombreRepuesto").val(),
            Precio: $("#PrecioRepuesto").val()
        }
        $.ajax({
            url: "/Taller/CrearRepuesto",
            type: "post",
            dataType: 'json',
            data: { "repuesto": JSON.stringify(repuesto) },
        })
            .done(function (result) {
                $("#selectRepuestos").append("<option value=" + result.id + ">" + result.nombre + " - ARS$ " + result.precio + "</option>");
                $("#selectRepuestos option[value='" + result.id + "']").attr("selected", true);
                $('#modalRepuesto').modal('toggle');
        })
        $("#SubmitRepuesto").prop("disabled", false);
    });
});