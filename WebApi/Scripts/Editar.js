

function ActualizarEstudiantes() {

    var PaisNombre = document.getElementById("PaisNombre").value;
    var Nombre = document.getElementById("Nombre").value;
    var Tipo = document.getElementById("Tipo").value;
    var Arranque = document.getElementById("Arranque").value;
    var Envion = document.getElementById("Envion").value;
    var TotalPeso = document.getElementById("TotalPeso").value;

    var PaisID = document.getElementById("PaisID").value;
    var UsuarioID = document.getElementById("UsuarioID").value;
    var RegistroID = document.getElementById("RegistroID").value;
    var NumIntentos = document.getElementById("NumIntentos").value;



    if (PaisNombre == "" || Nombre == "" || Tipo == "" || Arranque == "" || Envion == "" || TotalPeso == "") {
        alert("Debe diligenciar todos los campos");
        Validacampos = "true";
    }


  
    var data = new Object();
    var data = {
        PaisNombre,
        Nombre,
        Tipo,
        Arranque,
        Envion,
        TotalPeso,
        PaisID,
        UsuarioID,
        RegistroID,
        NumIntentos

    }


    $.ajax({
        method: "PUT",
        url: "http://localhost:58683/Registros/Put",
        contentType: 'application/json',
        data: JSON.stringify(data), // access in body
    })
        .done(function (response) {
            console.log(response);
            if (response) {
                alert("Se guardaron los cambios");
                window.location = "http://localhost:58683/Registros/Inicio";
            } else {
                alert("Error al Modificar")
            }
        });


}








