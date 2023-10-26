
using System.Collections.Generic;
using System.Web.Mvc;
using WebApi.Data;
using model.entity;
using System.Web.Http;

namespace WebApi.Controllers
{

    [System.Web.Http.Authorize]
    public class RegistrosController : Controller
    {
        // GET api/<controller>

        public ActionResult Login()
        {
            List<Registros> lista = RegistrosData.Listar();
            return View();

        }



        public bool LoginUsuarios([FromBody] Login oCliente)
        {
            return RegistrosData.LoginUsuarios(oCliente);
        }


        public ActionResult Inicio()
        {
            List<Registros> lista = RegistrosData.Listar();
            return View(lista);
        }

        RegistrosData objweb = new RegistrosData();

   
        public ActionResult Create()
        {

            return View();
        }

        public ActionResult Editar(int id)
        {

            return View(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Registros oCliente)
        {
            return RegistrosData.Registrar(oCliente);
        }


       // PUT api/<controller>/5
        public bool Put([FromBody] Registros oCliente)
        {
            //RegistrosData.Modificar(oCliente);
            return RegistrosData.Modificar(oCliente);
        }

        public ActionResult Acualizar(int id)
        {
            List<Registros> lista = RegistrosData.Obtener(id);
            return View(lista);
        }

    }
}