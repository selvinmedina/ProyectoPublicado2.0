﻿using ERP_GMEDINA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_GMEDINA.Controllers
{
    public class MenuController : Controller
    {
        private ERP_GMEDINAEntities db = new ERP_GMEDINAEntities();
        // GET: Menu
        public ActionResult Index()
        {
            tbUsuario sesionUsuario = db.tbUsuario.Where(x => x.usu_Id == 1).FirstOrDefault();
            Session["sesionUsuario"] = sesionUsuario;			
            return View();
        }
    }
}
