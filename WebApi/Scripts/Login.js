

var editar = false;
var ValTipo_Producto = "";
var Val_Placa_vehículo = "";


function Login() {

    var Nombre = document.getElementById("Usuario").value;
    var Contrasena = document.getElementById("Contrasena").value;

    var data = {
        Nombre: (Nombre),
        Contrasena: (Contrasena),
    }


    var settings = {
        "url": "http://localhost:58683/Login/Post",
        "method": "POST",
        "timeout": 0,
        "headers": {
            "Content-Type": "application/json"
        },
        "data": JSON.stringify({
            "Nombre": Nombre,
            "Contrasena": Contrasena
        }),
    };

    $.ajax(settings).done(function (response) {
        if (response != "Error 401 - Not authorized") {
            alert("Usuario Autorizado");
            window.location = "http://localhost:58683/Registros/Inicio";
        }
        else {
            alert("Error 401 - No Autorizado");
        }

    });
}


function Registrar() {

    var Usuario = document.getElementById("Usuario").value;
    var Contrasena = document.getElementById("Contrasena").value;

    var data = {
        Usuario: (Usuario),
        Contrasena: (Contrasena),
    }

    $.get("http://localhost:58683/Login/Get", data)
        .done(function (response) {
            console.log(response);
            if (response) {
                //alert("Usuario Registrado Correctamente");
                window.location = "http://localhost:58683/Registros/Inicio";
            } else {
                alert("Error al Registrar Usuario");
            }
        });
}



