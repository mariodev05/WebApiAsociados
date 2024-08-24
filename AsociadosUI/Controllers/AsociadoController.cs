using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AsociadosUI.Components;
using AsociadosUI.Models.Context;

namespace AsociadosUI.Controllers
{
    public class AsociadoController : Controller
    {
        public ActionResult List()
        {
            List<Asociados> listAsoc = new List<Asociados>();
            AsociadoComponent asocCom = new AsociadoComponent();
            listAsoc = asocCom.getListAsociados();
            return View(listAsoc);
        }
        [HttpGet]
        public ActionResult Agregar()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Agregar(Asociados asoc)
        {

            AsociadoComponent asocCom = new AsociadoComponent();
             int id= asocCom.AddAsociados(asoc)   ;    
                return View();
        }


        [HttpGet]
        public ActionResult Editar(int id)
        {
            Asociados asoc = new Asociados();
            AsociadoComponent asocCom = new AsociadoComponent();
            asoc = asocCom.GetAsociados(id);
            return View(asoc);
        }

        [HttpPost]
        public ActionResult Editar(Asociados asoc)
        {
            Asociados asoc2 = new Asociados();
            AsociadoComponent asocCom = new AsociadoComponent();
            asoc2 = asocCom.UpdateAsociados(asoc);
            return View(asoc2);
        }

        public ActionResult Eliminar(int id)
        {
            Asociados asoc2 = new Asociados();
            AsociadoComponent asocCom = new AsociadoComponent();
            //asoc2 = asocCom.UpdateAsociados(asoc);
            return View(asoc2);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }




    }
}