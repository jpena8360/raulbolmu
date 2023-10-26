
function ActualizarEstudiantes() {
    //var res = document.getElementById("Codigo_Transporte").value;

    var Codigo_Transporte = document.getElementById("Id_Envio").value;
    var Nombre = document.getElementById("Nombre").value;
    var Direccion = document.getElementById("Direccion").value;
    var Telefono = document.getElementById("Telefono").value;
    var Tipo_producto = document.getElementById("Tipo_producto").value;
    var Cantidad_Producto = document.getElementById("Cantidad_Producto").value;
    var Fecha_registro = document.getElementById("Fecha_registro").value;
    var Fecha_entrega = document.getElementById("Fecha_entrega").value;
    var Medio_Entrega = document.getElementById("Medio_Entrega").value;
    var Bodega_Entrega = document.getElementById("Bodega_Entrega").value;
    var Puerto_Entrega = document.getElementById("Puerto_Entrega").value;
    var Precio_envio = document.getElementById("Precio_envio").value;
    var Medio_Transporte = document.getElementById("Medio_Transporte").value;
    var Placa_vehículo = document.getElementById("Placa_vehículo").value;
    var Numero_Flota = document.getElementById("Numero_Flota").value;
    var Numero_guía = document.getElementById("Numero_guía").value;



    var data = new Object();
    var data = {              
        Codigo_Transporte,
        Nombre,
        Direccion,
        Telefono,
        Tipo_producto,
        Cantidad_Producto,
        Fecha_registro,
        Fecha_entrega,
        Medio_Entrega,
        Bodega_Entrega,
        Puerto_Entrega,
        Precio_envio,
        Medio_Transporte,
        Placa_vehículo,
        Numero_Flota,
        Numero_guía      
    }

    $.ajax({
        method: "PUT",
        url: "http://localhost:58683/Productos/Put",
        contentType: 'application/json',
        data: JSON.stringify(data), // access in body
    })
        .done(function (response) {
            console.log(response);
            if (response) {
                alert("Se guardaron los cambios");
                window.location = "http://localhost:58683/Productos/Inicio";
            } else {
                alert("Error al Modificar")
            }
        });
}








