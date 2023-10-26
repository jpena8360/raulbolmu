
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
    window.location = "http://localhost:58683/Productos/Inicio";
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

    var valCodigo_Cliente = $("#Codigo_Cliente").val();
    var valNombre = $("#Nombre").val();
    var valDireccion = $("#Direccion").val();
    var valTelefono = $("#Telefono").val();
    var valTipo_producto = $("#Tipo_producto").val();
    var valCantidad_producto = $("#Cantidad_producto").val();
    var valFecha_registro = $("#Fecha_registro").val();
    var valFecha_entrega = $("#Fecha_entrega").val();
    var valBodega_Entrega = $("#Bodega_Entrega").val();
    var valPrecio_envio = $("#Precio_envio").val();
    var valPlaca_vehículo = $("#Placa_vehículo").val();
    var valNumero_guía = $("#Numero_guía").val();

    if (valCodigo_Cliente == "" || valNombre == "" || valDireccion == "" || valTelefono == "" || valTipo_producto == "" || valCantidad_producto == "" || valFecha_registro == "" || valFecha_entrega == "" || valBodega_Entrega == "" || valPrecio_envio == "" || valPlaca_vehículo == "" || valNumero_guía == "") {
        alert("Debe diligenciar todos los campos");
        Validacampos = "true";
    }
    //else {
    //    const btncompra = document.getElementById('Guardar');
    //    btncompra.disabled = false;
    //}

    ///* Para obtener el valor */
    //var cod = document.getElementById("Tipo_Producto").value;

    var tel = $("#Telefono").val();
    ///* Para obtener el texto */
    //var combo = document.getElementById("producto");
    //var selected = combo.options[combo.selectedIndex].text;

    if (Val_Placa_vehículo == "Placa") {
        var ValidaPlaca = $("#Placa_vehículo").val();
        var reg = /^[A-Za-z]{3}[0-9]{3}$/;
        if (!reg.test(ValidaPlaca)) {
            alert("El Número de Placa No cumple con el formato: 3 letras iniciales y 3 números ");
            Validacampos = "true";
        }
    }
    else {
        var ValidaPlaca = $("#Placa_vehículo").val();
        var reg = /^[A-Za-z]{3}[0-9]{4}[A-Za-z]{1}$/;
        if (!reg.test(ValidaPlaca)) {
            alert("El Número de Flota No cumple con el formato:  3 letras iniciales, seguidas de 4 números y finalizando con una letra ");
            Validacampos = "true";
        }
    }

    var ValNumero_guía = $("#Numero_guía").val();
    var CountNumero_guía = ValNumero_guía.length;


    if (CountNumero_guía != 10) {
        alert("El  Numero de guía  debe tener 10 dí­gitos");
        Validacampos = "true";
    }

    if (Validacampos === "false") {
        var data = {
            Codigo_Cliente: $("#Codigo_Cliente").val(),
            Nombre: $("#Nombre").val(),
            Direccion: $("#Direccion").val(),
            Telefono: $("#Telefono").val(),
            Tipo_producto: (ValTipo_Producto),
            Cantidad_producto: $("#Cantidad_producto").val(),
            Fecha_registro: $("#Fecha_registro").val(),
            Fecha_entrega: $("#Fecha_entrega").val(),
            Bodega_Entrega: $("#Bodega_Entrega").val(),
            Precio_envio: $("#Precio_envio").val(),
            Placa_vehículo: $("#Placa_vehículo").val(),
            Numero_guía: $("#Numero_guía").val(),

        }

        $.post("http://localhost:58683/Productos/Post", data)
            .done(function (response) {
                console.log(response);
                if (response) {
                    alert("Producto Creado");
                    window.location = "http://localhost:58683/Productos/Inicio";
                } else {
                    alert("Error al crear");
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

    $.post("http://localhost:58683/Productos/Post", data)
        .done(function (response) {
            console.log(response);
            if (response) {
                alert("Producto Creado");
                window.location = "http://localhost:58683/Productos/Inicio";
            } else {
                alert("Error al crear");
            }
        });
}


