
var ValTipo_Producto = "";
var Val_Placa_vehículo = "";
var Validacampos = "false";


function PintarProductos(IdProducto) {

    $.get("http://localhost:58683/api/Producto/" + IdProducto)
        .done(function (response) {
            console.log(response);
            $("#txtTipoProducto").val(response.TipoProducto),
                $("#txtCodigoUnico").val(response.CodigoUnico),
                $("#txtNombreProducto").val(response.NombreProducto),
                $("#txtActivo").val(response.Activo),
                $("#txtCantidad").val(response.Cantidad),
                $("#txtValor").val(response.Valor)
        });
}

function ShowSelected() {
    /* Para obtener el valor */
    var cod = document.getElementById("Tipo_Producto").value;
    /* Para obtener el texto */
    var combo = document.getElementById("Tipo_Producto");
    var selected = combo.options[combo.selectedIndex].text;
    ValTipo_Producto = selected;
}


function IrFormularioInicio() {
    window.location = "http://localhost:58683/Registros/Inicio";
}


function SelectedPlacaFlota() {
    /* Para obtener el valor */
    var cod = document.getElementById("Placa_vehículo").value;
    /* Para obtener el texto */
    var combo = document.getElementById("Placa_Flota");
    var selected = combo.options[combo.selectedIndex].text;
    Val_Placa_vehículo = selected;
}


function GuardarEstudiantes() {

    var PaisNombre = $("#PaisNombre").val();
    var Nombre = $("#Nombre").val();
    var Tipo = $("#Tipo").val();
    var Arranque = $("#Arranque").val();
    var Envion = $("#Envion").val();
    var TotalPeso = $("#TotalPeso").val();
   

    if (PaisNombre == "" || Nombre == "" || Tipo == "" || Arranque == "" || Envion == "" || TotalPeso == "" ) {
        alert("Debe diligenciar todos los campos");
        Validacampos = "true";
    }



 



    if (Validacampos === "false") {
        var data = {
            PaisNombre: $("#PaisNombre").val(),
            Nombre: $("#Nombre").val(),
            Tipo: $("#Tipo").val(),
            Arranque: $("#Arranque").val(),
            Envion: (Envion),
            TotalPeso: $("#TotalPeso").val(),
           
        }

        $.post("http://localhost:58683/Registros/Post", data)
            .done(function (response) {
                console.log(response);
                if (response) {
                    alert("Datos registrados Correctamente");
                    window.location = "http://localhost:58683/Registros/Inicio";
                } else {
                    alert("Error al Registrar");
                }
            });
    }


}



function ActualizarEstudiantes() {

    var data = {
        Codigo_Cliente: $("#Codigo_Cliente").val(),
        Nombre: $("#Nombre").val(),
        Direccion: $("#Direccion").val(),
        Telefono: $("#Telefono").val(),

        Tipo_producto: $("#Tipo_producto").val(),
        Cantidad_producto: $("#Cantidad_producto").val(),
        Fecha_registro: $("#Fecha_registro").val(),
        Fecha_entrega: $("#Fecha_entrega").val(),
        Bodega_Entrega: $("#Bodega_Entrega").val(),
        Precio_envio: $("#Precio_envio").val(),
        Placa_vehículo: $("#Placa_vehículo").val(),
        Numero_guía: $("#Numero_guía").val(),
    }

    $.post("http://localhost:58683/Registros/Post", data)
        .done(function (response) {
            console.log(response);
            if (response) {
                alert("Usuario registrado Correctamente");
                window.location = "http://localhost:58683/Registros/Inicio";
            } else {
                alert("Error al registras");
            }
        });
}


