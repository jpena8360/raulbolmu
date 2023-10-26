using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebApi.Data;
using model.entity;

namespace WebApi.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Inicio()
        {
            List<Registros> lista = RegistrosData.Listar();
            return View(lista);
        }


        public bool Get([FromBody] Login oCliente)
        {
            return LoginData.RegistrarUsuarios(oCliente);
        }


        public string Post([FromBody] Login oCliente)

        {

            return LoginData.LoginUsuarios(oCliente);

            //return View("Inicio");
        }



    }
}