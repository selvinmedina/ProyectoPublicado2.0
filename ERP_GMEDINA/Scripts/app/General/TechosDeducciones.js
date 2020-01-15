﻿////FUNCION GENERICA PARA REUTILIZAR AJAX
function _ajax(params, uri, type, callback) {
    $.ajax({
        url: uri,
        type: type,
        data: { params },
        success: function (data) {
            callback(data);
        }
    });
}
var InactivarID = 0;

//OBTENER SCRIPT DE FORMATEO DE FECHA
$.getScript("../Scripts/app/General/SerializeDate.js")
  .done(function (script, textStatus) {
      console.log(textStatus);
  })
  .fail(function (jqxhr, settings, exception) {
      console.log("No se pudo recuperar Script SerializeDate");
  });

// EVITAR POSTBACK DE FORMULARIOS
$("#frmEditTechosDeducciones").submit(function (e) {
    e.preventDefault();
});
$("#frmTechosDeduccionesCreate").submit(function (e) {
    e.preventDefault();
});

//FUNCION: CARGAR DATA Y REFRESCAR LA TABLA DEL INDEX
function cargarGridTechosDeducciones() {
    var esAdministrador = $("#rol_Usuario").val();
    _ajax(null,
        '/TechosDeducciones/GetData',
        'GET',
        (data) => {
            if (data.length == 0) {
                iziToast.error({
                    title: 'Error',
                    message: 'No se cargó la información, contacte al administrador',
                });
            }
            var ListaTechosDeducciones = data, template = '';
            //RECORRER DATA OBETINA Y CREAR UN "TEMPLATE" PARA REFRESCAR EL TBODY DE LA TABLA DEL INDEX
            for (var i = 0; i < ListaTechosDeducciones.length; i++) {
                var Activo;

                //variable para verificar el estado del registro
                var estadoRegistro = ListaTechosDeducciones[i].tddu_Activo == false ? 'Inactivo' : 'Activo'

                //variable boton detalles
                var botonDetalles = ListaTechosDeducciones[i].tddu_Activo == true ? '<button data-id = "' + ListaTechosDeducciones[i].tddu_IdTechosDeducciones + '" type="button" class="btn btn-primary btn-xs"  id="btnDetalleTechosDeducciones">Detalles</button>' : '';

                //variable boton editar
                var botonEditar = ListaTechosDeducciones[i].tddu_Activo == true ? '<button data-id = "' + ListaTechosDeducciones[i].tddu_IdTechosDeducciones + '" type="button" class="btn btn-default btn-xs"  id="btnEditarTechosDeducciones">Editar</button>' : '';

                //variable donde está el boton activar
                var botonActivar = ListaTechosDeducciones[i].tddu_Activo == false ? esAdministrador == "1" ? '<button data-id = "' + ListaTechosDeducciones[i].tddu_IdTechosDeducciones + '" type="button" class="btn btn-primary btn-xs"  id="btnActivarTechosDeducciones">Activar</button>' : '' : '';
                template += '<tr data-id = "' + ListaTechosDeducciones[i].tddu_IdTechosDeducciones + '">' +
                    '<td>' + ListaTechosDeducciones[i].tddu_IdTechosDeducciones + '</td>' +
                    '<td>' + ListaTechosDeducciones[i].tddu_PorcentajeColaboradores + '</td>' +
                    '<td>' + ListaTechosDeducciones[i].tddu_PorcentajeEmpresa + '</td>' +
                    '<td>' + ListaTechosDeducciones[i].tddu_Techo + '</td>' +
                    '<td>' + ListaTechosDeducciones[i].cde_DescripcionDeduccion + '</td>' +
                    '<td>' + estadoRegistro + '</td>' +
                    //variable donde está el boton de detalles
                    '<td>' + botonDetalles +

                    //variable donde está el boton de detalles
                     botonEditar +

                    //boton activar 
                    botonActivar
                '</td>' +
                '</tr>';
            }
            //REFRESCAR EL TBODY DE LA TABLA DEL INDEX
            $('#tbodyTechosDeducciones').html(template);
        });
    FullBody();
}

//Modal Create Techos Deducciones
$(document).on("click", "#btnAgregarTechosDeducciones", function () {
    //PEDIR DATA PARA LLENAR EL DROPDOWNLIST DEL MODAL
    $.ajax({
        url: "/TechosDeducciones/EditGetDDL",
        method: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8"
    })
        //LLENAR EL DROPDONWLIST DEL MODAL CON LA DATA OBTENIDA
        .done(function (data) {
            $("#Crear #cde_IdDeducciones").empty();
            $("#Crear #cde_IdDeducciones").append("<option value='0'>Selecione una opción...</option>");
            $.each(data, function (i, iter) {
                $("#Crear #cde_IdDeducciones").append("<option value='" + iter.Id + "'>" + iter.Descripcion + "</option>");
            });
        });
    //MOSTRAR EL MODAL DE AGREGAR
    $(".field-validation-error").css('display', 'none');
    $('#Crear input[type=text], input[type=number]').val('');
    $("#AgregarTechosDeducciones").modal();
});

//FUNCION: CREAR EL NUEVO REGISTRO TECHOS DEDUCCIONES
$('#btnCreateTechoDeducciones').click(function () {
    var ModelState = true;

    //$("#Editar #tede_Id").val() == "" ? ModelState = false : '';
    $("#Crear #tddu_Techo").val() == "" ? ModelState = false : $("#Crear #tddu_Techo").val() == "0.00" ? ModelState = false : $("#Crear #tddu_Techo").val() == null ? ModelState = false : isNaN($("#Crear #tddu_Techo").val()) == true ? ModelState = false : '';
    $("#Crear #tddu_PorcentajeColaboradores").val() == "" ? ModelState = false : $("#Crear #tddu_PorcentajeColaboradores").val() == "0.00" ? ModelState = false : $("#Crear #tddu_PorcentajeColaboradores").val() == null ? ModelState = false : isNaN($("#Crear #tddu_PorcentajeColaboradores").val()) == true ? ModelState = false : '';
    $("#Crear #tddu_PorcentajeEmpresa").val() == "" ? ModelState = false : $("#Crear #tddu_PorcentajeEmpresa").val() == "0" ? ModelState = false : $("#Crear #tddu_PorcentajeEmpresa").val() == null ? ModelState = false : isNaN($("#Crear #tddu_PorcentajeEmpresa").val()) == true ? ModelState = false : '';
    $("#Crear #cde_IdDeducciones").val() == "" ? ModelState = false : $("#Crear #cde_IdDeducciones").val() == "0" ? ModelState = false : $("#Crear #cde_IdDeducciones").val() == null ? ModelState = false : isNaN($("#Crear #cde_IdDeducciones").val()) == true ? ModelState = false : '';

    //SERIALIZAR EL FORMULARIO DEL MODAL (ESTÁ EN LA VISTA PARCIAL)
    if (ModelState) {
        var data = $("#frmTechosDeduccionesCreate").serializeArray();
        console.log(data);
        debugger;
        $.ajax({
            url: "/TechosDeducciones/Create",
            method: "POST",
            data: data
        }).done(function (data) {
            $("#AgregarTechosDeducciones").modal('hide');
            //VALIDAR RESPUESTA OBETNIDA DEL SERVIDOR, SI LA INSERCIÓN FUE EXITOSA O HUBO ALGÚN ERROR
            if (data == "error") {
                iziToast.error({
                    title: 'Error',
                    message: 'No se guardó el registro, contacte al administrador',
                });
            }
            else if (data == "bien") {
                cargarGridTechosDeducciones();
                console.log(data);
                // Mensaje de exito cuando un registro se ha guardado bien
                iziToast.success({
                    title: 'Éxito',
                    message: '¡El registro se agregó de forma exitosa!',
                });
            }
        });
    }
    else {
        iziToast.error({
            title: 'Error',
            message: 'Ingrese datos válidos.',
        });
    }

});

//FUNCION: PRIMERA FASE DE EDICION DE REGISTROS, MOSTRAR MODAL CON LA INFORMACIÓN DEL REGISTRO SELECCIONADO
$(document).on("click", "#tblTechosDeducciones tbody tr td #btnEditarTechosDeducciones", function () {
    var ID = $(this).data('id');
    InactivarID = ID;
    $.ajax({
        url: "/TechosDeducciones/Edit/" + ID,
        method: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ ID: ID })
    })
        .done(function (data) {
            //SI SE OBTIENE DATA, LLENAR LOS CAMPOS DEL MODAL CON ELLA
            if (data) {
                $("#Editar #tddu_IdTechosDeducciones").val(data.tddu_IdTechosDeducciones);
                $("#Editar #tddu_Techo").val(data.tddu_Techo);
                $("#Editar #tddu_PorcentajeColaboradores").val(data.tddu_PorcentajeColaboradores);
                $("#Editar #tddu_PorcentajeEmpresa").val(data.tddu_PorcentajeEmpresa);
                $("#Editar #cde_IdDeduccion").val(data.cde_IdDeducciones);
                $(".field-validation-error").css('display', 'none');

                //GUARDAR EL ID DEL DROPDOWNLIST (QUE ESTA EN EL REGISTRO SELECCIONADO) QUE NECESITAREMOS PONER SELECTED EN EL DDL DEL MODAL DE EDICION
                var SelectedId = data.cde_IdDeducciones;
                //CARGAR INFORMACIÓN DEL DROPDOWNLIST PARA EL MODAL
                $.ajax({
                    url: "/TechosDeducciones/EditGetDDL",
                    method: "GET",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify({ ID })
                })
                    .done(function (data) {
                        //LIMPIAR EL DROPDOWNLIST ANTES DE VOLVER A LLENARLO
                        $("#Editar #cde_IdDeducciones").empty();
                        //LLENAR EL DROPDOWNLIST
                        $("#Editar #cde_IdDeducciones").append("<option value=0>Selecione una opción...</option>");
                        $.each(data, function (i, iter) {
                            $("#Editar #cde_IdDeducciones").append("<option" + (iter.Id == SelectedId ? " selected" : " ") + " value='" + iter.Id + "'>" + iter.Descripcion + "</option>");
                        });
                    });
                $("#EditarTechosDeducciones").modal();
                $('body').css("overflow", "hidden");
            }
            else {
                //Mensaje de error si no hay data
                iziToast.error({
                    title: 'Error',
                    message: 'No se cargó la información, contacte al administrador',
                });
            }
        });
});

//EJECUTAR EDICIÓN DEL REGISTRO EN EL MODAL
$("#btnEditarTecho").click(function () {

    var ModelState = true;
    $("#Editar #tddu_IdTechosDeducciones").val() == "" ? ModelState = false : $("#Editar #tddu_IdTechosDeducciones").val() == "0" ? ModelState = false : $("#Editar #tddu_IdTechosDeducciones").val() == null ? ModelState = false : '';
    $("#Editar #tddu_Techo").val() == "" ? ModelState = false : $("#Editar #tddu_Techo").val() == "0.00" ? ModelState = false : $("#Editar #tddu_Techo").val() == null ? ModelState = false : '';
    $("#Editar #tddu_PorcentajeColaboradores").val() == "" ? ModelState = false : $("#Editar #tddu_PorcentajeColaboradores").val() == "0.00" ? ModelState = false : $("#Editar #tddu_PorcentajeColaboradores").val() == null ? ModelState = false : '';
    $("#Editar #tddu_PorcentajeEmpresa").val() == "" ? ModelState = false : $("#Editar #tddu_PorcentajeEmpresa").val() == "0" ? ModelState = false : $("#Editar #tddu_PorcentajeEmpresa").val() == null ? ModelState = false : '';
    $("#Editar #cde_IdDeducciones").val() == "" ? ModelState = false : $("#Editar #cde_IdDeducciones").val() == "0" ? ModelState = false : $("#Editar #cde_IdDeducciones").val() == null ? ModelState = false : '';

    if (ModelState) {
        //SERIALIZAR EL FORMULARIO (QUE ESTÁ EN LA VISTA PARCIAL) DEL MODAL, SE PARSEA A FORMATO JSON
        var data = $("#frmEditTechosDeducciones").serializeArray();
        //SE ENVIA EL JSON AL SERVIDOR PARA EJECUTAR LA EDICIÓN
        $.ajax({
            url: "/TechosDeducciones/Edit",
            method: "POST",
            data: data
        }).done(function (data) {
            if (data == "error") {
                //Cuando traiga un error del backend al guardar la edicion
                iziToast.error({
                    title: 'Error',
                    message: 'No se editó el registro, contacte al administrador',
                });
            }
            else {
                cargarGridTechosDeducciones();
                //UNA VEZ REFRESCADA LA TABLA, SE OCULTA EL MODAL
                $("#EditarTechosDeducciones").modal('hide');
                //Mensaje de exito de la edicion
                iziToast.success({
                    title: 'Éxito',
                    message: '¡El registro fue editado de forma exitosa!',
                });
            }
        });
    }
    //else {
    //    iziToast.error({
    //        title: 'Error',
    //        message: 'Ingrese datos válidos.',
    //    });
    //}
});

//FUNCION: OCULTAR MODAL DE EDICIÓN
$("#btnCerrarEditar").click(function () {
    $("#EditarTechosDeducciones").modal('hide');
});




$(document).on("click", "#btnInactivarTechoDeducciones", function () {
    $("#EditarTechosDeducciones").modal('hide');
    $("#InactivarTechosDeducciones").modal();
});



//Inactivar registro Techos Deducciones
$("#btnInactivarTechosDeducciones").click(function () {
    var data = $("#frmInactivarTechosDeducciones").serializeArray();
    //SE ENVIA EL JSON AL SERVIDOR PARA EJECUTAR LA EDICIÓN
    $.ajax({
        url: "/TechosDeducciones/Inactivar/" + InactivarID,
        method: "POST",
        data: data
    }).done(function (data) {
        if (data == "error") {
            //Cuando traiga un error del backend al guardar la edicion
            iziToast.error({
                title: 'Error',
                message: 'No se inactivó el registro, contacte al administrador',
            });
        }
        else {
            cargarGridTechosDeducciones();
            //UNA VEZ REFRESCADA LA TABLA, SE OCULTA EL MODAL
            $("#InactivarTechosDeducciones").modal('hide');
            //Mensaje de exito de la edicion
            iziToast.success({
                title: 'Éxito',
                message: '¡El registro se inactivó de forma exitosa!',
            });
        }
    });
    InactivarID = 0;
});


//DETALLES
$(document).on("click", "#tblTechosDeducciones tbody tr td #btnDetalleTechosDeducciones", function () {
    var ID = $(this).data('id');
    $.ajax({
        url: "/TechosDeducciones/Details/" + ID,
        method: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ ID: ID })
    })
        .done(function (data) {
            //SI SE OBTIENE DATA, LLENAR LOS CAMPOS DEL MODAL CON ELLA
            if (data) {
                var FechaCrea = FechaFormato(data[0].tddu_FechaCrea);
                var FechaModifica = FechaFormato(data[0].tddu_FechaModifica);
                $("#Detalles #tddu_UsuarioCrea").val(data[0].tddu_UsuarioCrea);
                $("#Detalles #cde_IdDeducciones").html(data[0].cde_IdDeducciones);

                $("#Detalles #tddu_PorcentajeColaboradores").html(data[0].tddu_PorcentajeColaboradores);
                $("#Detalles #tddu_PorcentajeEmpresa").html(data[0].tddu_PorcentajeEmpresa);
                $("#Detalles #tddu_Techo").html(data[0].tddu_Techo);
                $("#Detalles #tede_UsuarioCrea").html(data[0].tede_UsuarioCrea);
                $("#Detalles #tbUsuario_usu_NombreUsuario").html(data[0].UsuCrea);
                $("#Detalles #tddu_FechaCrea").html(FechaCrea);
                $("#Detalles #tddu_UsuarioModifica").html(data.tddu_UsuarioModifica);
                data[0].UsuModifica == null ? $("#Detalles #tbUsuario1_usu_NombreUsuario").html('Sin modificaciones') : $("#Detalles #tbUsuario1_usu_NombreUsuario").html(data[0].UsuModifica);
                $("#Detalles #tddu_FechaModifica").html(FechaModifica);
                //GUARDAR EL ID DEL DROPDOWNLIST (QUE ESTA EN EL REGISTRO SELECCIONADO) QUE NECESITAREMOS PONER SELECTED EN EL DDL DEL MODAL DE EDICION
                var SelectedId = data[0].cde_IdDeducciones;
                //CARGAR INFORMACIÓN DEL DROPDOWNLIST PARA EL MODAL
                //$.ajax({
                //    url: "/TechosDeducciones/EditGetDDL",
                //    method: "GET",
                //    dataType: "json",
                //    contentType: "application/json; charset=utf-8",
                //    data: JSON.stringify({ ID })
                //    })
                //    .done(function (data) {
                //        //LIMPIAR EL DROPDOWNLIST ANTES DE VOLVER A LLENARLO
                //        $("#Detalles #cde_IdDeducciones").empty();
                //        //LLENAR EL DROPDOWNLIST
                //        $("#Detalles #cde_IdDeducciones").append("<option value=0>Selecione una opción...</option>");
                //        $.each(data, function (i, iter) {
                //            $("#Detalles #cde_IdDeducciones").append("<option" + (iter.Id == SelectedId ? " selected" : " ") + " value='" + iter.Id + "'>" + iter.Descripcion + "</option>");
                //        });
                //    });
                $('body').css("overflow", "hidden");
                $("#DetailsTechosDeducciones").modal();
            }
            else {
                //Mensaje de error si no hay data
                iziToast.error({
                    title: 'Error',
                    message: 'No se cargó la información, contacte al administrador',
                });
            }
        });
});

// activar
var activarID = 0;
$(document).on("click", "#btnActivarTechosDeducciones", function () {
    activarID = $(this).data('id');
    $("#ActivarTechosDeducciones").modal();
});

//activar ejecutar
$("#btnActivarTechosDeduccionesEjecutar").click(function () {

    $.ajax({
        url: "/TechosDeducciones/Activar/" + activarID,
        method: "POST",
        data: {id : activarID}
    }).done(function (data) {
        if (data == "error") {
            iziToast.error({
                title: 'Error',
                message: 'No se activó el registro.',
            });
        }
        else {
            cargarGridTechosDeducciones();
            $("#ActivarTechosDeducciones").modal('hide');
            //Mensaje de exito de la edicion
            iziToast.success({
                title: 'Éxito',
                message: '¡El registro fue activado de forma exitosa!',
            });
        }
    });
    activarID = 0;
});

//VALIDAR LAS ENTRADAS DE LOS CONCEPTOS AGREGADOS
function isNumberKey(txt, evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode == 46) {
        //Check if the text already contains the . character
        //var len = $('.ValidarCaracteres').val().length;
        //var index = $('.ValidarCaracteres').val().indexOf('.')
        if (txt.value.indexOf('.') === -1) {
            return true;
        } else {
            return false;
        }
    }
    else {
        if (charCode > 31 &&
          (charCode < 48 || charCode > 57))
            return false;
    }
    //if (index > 0) {
    //    var CharAfterdot = (len + 1) - index;
    //    if (CharAfterdot > 3) {
    //        return false;
    //    }
    //}
    return true;
}

//$('.ValidarCaracteres').bind('keypress', function (event) {
//    //var regex = new RegExp("^[a-zA-Z0-9]+$");
//    var regex = new RegExp("^[0-9.]");
//    var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
//    if (!regex.test(key)) {
//        event.preventDefault();
//        return false;
//    }
//});
