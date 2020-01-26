﻿Admin = true;



function llamarmodalhabilitar(ID) {
    var modalhabilitar = $("#ModalHabilitar");
    $("#ModalHabilitar").find("#hvac_Id").val(ID);
    modalhabilitar.modal('show');
}




$("#btnActivar").click(function () {
    var data = $("#FormActivar").serializeArray();
    data = serializar(data);
    if (data != null) {
        data = JSON.stringify({ tbHistorialVacaciones: data });
        _ajax(data,
            '/HistorialVacaciones/habilitar/',
            'POST',
            function (obj) {
                if (obj != "-1" && obj != "-2" && obj != "-3") {
                    CierraPopups();
                    MsgWarning("¡Exito!", "Se ha activado el registro");
                    LimpiarControles(["hvac_Id"]);
                    llenarTabla();
                } else {
                    MsgError("Error", "Codigo:" + obj + ". contacte al administrador.");
                }
            });
    } else {
        MsgError("Error", "por favor llene todas las cajas de texto");
    }
});