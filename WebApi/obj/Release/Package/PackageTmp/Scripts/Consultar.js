
function mostrar() {
   
        function mostrar(num) {
            var id = $("#Codigo_Transporte").val();
        alert(id);

        $(".table tbody").html("");

        $.get("http://localhost:58683/Productos/Get/" + id)
        .done(function (response) {
            console.log(response);
        $.each(response, function (id, fila) {
            $("<tr>").append(
                $("<td>").text(fila.Codigo_Transporte),
                $("<td>").text(fila.Nombre),
                $("<td>").text(fila.Direccion),
                $("<td>").text(fila.Telefono),
                $("<td>").text(fila.Tipo_producto),
                $("<td>").text(fila.Cantidad_Producto),
                $("<td>").text(fila.Fecha_registro),
                $("<td>").text(fila.Fecha_entrega),
                $("<td>").text(fila.Medio_Entrega),
                $("<td>").text(fila.Bodega_Entrega),
                $("<td>").text(fila.Puerto_Entrega),
                $("<td>").text(fila.Precio_envio),
                $("<td>").text(fila.Medio_Transporte),
                $("<td>").text(fila.Placa_vehículo),
                $("<td>").text(fila.Numero_Flota),
                $("<td>").text(fila.Numero_guía),


                $("<td>").append(

                    $("<button>").data("id", fila.Codigo_Transporte).addClass("btn btn-success btn-sm mr-1 editar").text("Editar").attr({ "type": "button" }),
                    $("<button>").data("id", fila.Codigo_Transporte).addClass("btn btn-danger btn-sm eliminar").text("Eliminar").attr({ "type": "button" })
                ), $("</td>"), $("</tr>"),

            ).appendTo(".table");
                });
            });

    }



}








