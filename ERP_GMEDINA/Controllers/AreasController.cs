﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERP_GMEDINA.Models;
namespace ERP_GMEDINA.Controllers
{
    public class AreasController : Controller
    {
        private ERP_GMEDINAEntities db = null;

        // GET: Areas
        public ActionResult Index()
        {
            if (Session["Admin"] == null && Session["Usuario"] == null)
            {
                Response.Redirect("");
            }
            tbAreas tbAreas = new tbAreas { };
            return View(tbAreas);
        }
        public ActionResult llenarTabla()
        {
            try
            {
                db = new ERP_GMEDINAEntities();

                //declaramos la variable de coneccion solo para recuperar los datos necesarios.
                //posteriormente es destruida.
                var tbAreas = db.tbAreas
                    .Select(
                    t => new
                    {
                        area_Id = t.area_Id,
                        area_Descripcion = t.area_Descripcion,
                        Sucursales = t.tbSucursales.suc_Descripcion,
                        Encargado = t.tbCargos.tbEmpleados
                            .Select(p => p.tbPersonas.per_Nombres + " " + p.tbPersonas.per_Apellidos),
                        area_Estado = t.area_Estado
                    }
                    )
                    .ToList();
                return Json(tbAreas, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return Json("-2", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ChildRowData(int id)
        {
            try
            {
                //declaramos la variable de coneccion solo para recuperar los datos necesarios.
                //posteriormente es destruida.
                using (db = new ERP_GMEDINAEntities())
                {
                    var lista = db.tbDepartamentos
                        .Where(x => x.area_Id == id && x.depto_Estado == true)
                        .Select(depto =>
                        new
                        {
                            car_Descripcion = depto.tbCargos.car_Descripcion,
                            depto_Descripcion = depto.depto_Descripcion,
                            persona = new
                            {
                                per_NombreCompleto = depto.tbCargos.tbEmpleados.Select(persona => persona.tbPersonas.per_Nombres + " " + persona.tbPersonas.per_Apellidos),
                                per_Telefono = depto.tbCargos.tbEmpleados.Select(persona => persona.tbPersonas.per_Telefono),
                                per_CorreoElectronico = depto.tbCargos.tbEmpleados.Select(persona => persona.tbPersonas.per_CorreoElectronico),
                            }
                        }).ToList();
                    return Json(lista, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json(new List<tbDepartamentos> { }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult cargarChild(int id)
        {
            try
            {
                using (db = new ERP_GMEDINAEntities())
                {
                    var lista = db.tbDepartamentos
                        .Where(x => x.area_Id == id)
                        .Select(depto =>
                        new
                        {
                            depto_Id = depto.depto_Id,
                            car_Id = depto.tbCargos.car_Id,
                            car_Descripcion = depto.tbCargos.car_Descripcion,
                            depto_Descripcion = depto.depto_Descripcion,
                            depto_Estado = depto.depto_Estado
                        }).ToList();
                    return Json(lista, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json("-2", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult llenarDropDowlist()
        {
            var Sucursales = new List<object> { };
            try
            {
                using (db = new ERP_GMEDINAEntities())
                {
                    Sucursales.Add(new
                    {
                        Id = 0,
                        Descripcion = "**Seleccione una opción**"
                    });
                    Sucursales.AddRange(db.tbSucursales
                    .Select(tabla => new { Id = tabla.suc_Id, Descripcion = tabla.suc_Descripcion })
                    .ToList());
                }
            }
            catch
            {
                return Json("-2", JsonRequestBehavior.AllowGet);
            }
            var result = new Dictionary<string, object>();
            result.Add("suc_Id", Sucursales);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        // GET: Areas/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Admin"] == null && Session["Usuario"] == null)
            {
                Response.Redirect("");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAreas tbAreas = null;
            try
            {
                //declaramos la variable de coneccion solo para recuperar los datos necesarios.
                //posteriormente es destruida.
                db = new ERP_GMEDINAEntities();
                tbAreas = db.tbAreas.Find(id);
            }
            catch
            {
                return HttpNotFound();
            }
            return View(tbAreas);
        }
        // GET: Areas/Create
        public ActionResult Create()
        {
            if (Session["Admin"] == null && Session["Usuario"] == null)
            {
                Response.Redirect("");
            }
            //declaramos la variable de coneccion solo para recuperar los datos necesarios.
            //posteriormente es destruida.
            List<tbSucursales> Sucursales = new List<tbSucursales> { };
            ViewBag.suc_Id = new SelectList(Sucursales, "suc_Id", "suc_Descripcion");
            return View();
        }
        // POST: Areas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(tbAreas tbAreas, tbDepartamentos[] tbDepartamentos)
        {
            tbDepartamentos = tbDepartamentos == null ? new tbDepartamentos[] { } : tbDepartamentos;
            //declaramos la variable de coneccion solo para recuperar los datos necesarios.
            //posteriormente es destruida.
            string result = "";
            var Usuario = (tbUsuario)Session["Usuario"];
            //en esta area ingresamos el registro con el procedimiento almacenado
            try
            {
                db = new ERP_GMEDINAEntities();
                using (var transaction = db.Database.BeginTransaction())
                {
                    var cargo = db.UDP_RRHH_tbCargos_Insert(
                        tbAreas.car_Descripcion,
                        Usuario.usu_Id,
                        DateTime.Now
                        );
                    foreach (UDP_RRHH_tbCargos_Insert_Result item in cargo)
                    {
                        if (item.MensajeError == "-1")
                        {
                            return Json(new { codigo = "-3", input = "car_Descripcion", result = tbAreas.car_Descripcion }, JsonRequestBehavior.AllowGet);
                        }
                        tbAreas.car_Id = int.Parse(item.MensajeError);
                    }
                    var list = db.UDP_RRHH_tbAreas_Insert(
                        tbAreas.suc_Id,
                        tbAreas.area_Descripcion,
                        tbAreas.car_Id,
                        Usuario.usu_Id,
                        DateTime.Now);
                    foreach (UDP_RRHH_tbAreas_Insert_Result item in list)
                    {
                        if (item.MensajeError == "-1")
                        {
                            return Json(new { codigo = "-2", input = "area_Descripcion", result = tbAreas.area_Descripcion }, JsonRequestBehavior.AllowGet);
                        }
                        tbAreas.area_Id = int.Parse(item.MensajeError);
                    }
                    foreach (tbDepartamentos item in tbDepartamentos)
                    {
                        var deptocargo = db.UDP_RRHH_tbCargos_Insert(
                                                               item.tbCargos.car_Descripcion,
                                                               Usuario.usu_Id,
                                                               DateTime.Now
                                                             );
                        foreach (UDP_RRHH_tbCargos_Insert_Result i in cargo)
                        {
                            if (i.MensajeError == "-1")
                            {
                                return Json(new { codigo = "-4", input = "car_Descripcion", result = item.tbCargos.car_Descripcion }, JsonRequestBehavior.AllowGet);
                            }
                            tbAreas.car_Id = int.Parse(i.MensajeError);
                        }
                        var depto = db.UDP_RRHH_tbDepartamentos_Insert(
                            tbAreas.area_Id,
                            item.depto_Descripcion,
                            item.tbCargos.car_Id,
                            Usuario.usu_Id,
                            DateTime.Now);
                        string mensajeDB = "";
                        foreach (UDP_RRHH_tbDepartamentos_Insert_Result i in depto)
                        {
                            mensajeDB = i.MensajeError.ToString();
                        }
                        if (mensajeDB == "-1")
                        {
                            return Json("-4", JsonRequestBehavior.AllowGet);
                        }
                    }
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("-2", JsonRequestBehavior.AllowGet);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        // GET: Areas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Admin"] == null && Session["Usuario"] == null)
            {
                Response.Redirect("");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<tbSucursales> Sucursales = null;
            try
            {
                //declaramos la variable de coneccion solo para recuperar los datos necesarios.
                //posteriormente es destruida.
                using (db = new ERP_GMEDINAEntities())
                {
                    Session["area_Id"] = id;
                    var tbAreas = db.tbAreas
                        .Select(tabla => new cAreas
                        {
                            area_Id = tabla.area_Id,
                            suc_Id = tabla.suc_Id,
                            area_Descripcion = tabla.area_Descripcion,
                            car_Descripcion = tabla.tbCargos.car_Descripcion,
                            area_Estado = tabla.area_Estado
                        }).ToList()
                        .Where(x => x.area_Id == id)
                        .First();
                    Sucursales = db.tbSucursales.ToList();
                    ViewBag.suc_Id = new SelectList(Sucursales, "suc_Id", "suc_Descripcion");
                    if (tbAreas.area_Estado == false)
                    {
                        return HttpNotFound();
                    }
                    if (tbAreas == null)
                    {
                        return HttpNotFound();
                    }
                    return View(tbAreas);
                }
            }
            catch
            {
                return HttpNotFound();
            }
        }
        // POST: Areas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(cAreas cAreas, cDepartamentos[] Departamentos, cDepartamentos[] inactivar)
        {
            //declaramos la variable de coneccion solo para recuperar los datos necesarios.
            //posteriormente es destruida.
            string result = "";
            cAreas.area_Id = (int)Session["area_Id"];
            var Usuario = (tbUsuario)Session["Usuario"];
            //en esta area ingresamos el registro con el procedimiento almacenado
            try
            {
                db = new ERP_GMEDINAEntities();
                using (var transaction = db.Database.BeginTransaction())
                {
                    var list = db.UDP_RRHH_tbAreas_Update(
                        cAreas.area_Id,
                        cAreas.suc_Id,
                        cAreas.car_Descripcion,
                        Usuario.usu_Id,
                        DateTime.Now);
                    foreach (UDP_RRHH_tbAreas_Update_Result item in list)
                    {
                        if (item.MensajeError == "-1")
                        {
                            return Json("-2", JsonRequestBehavior.AllowGet);
                        }
                        cAreas.area_Id = int.Parse(item.MensajeError);
                    }
                    inactivar = inactivar == null ? new cDepartamentos[] { } : inactivar;
                    Departamentos = Departamentos == null ? new cDepartamentos[] { } : Departamentos;
                    foreach (cDepartamentos item in inactivar)
                    {
                        var depto = db.UDP_RRHH_tbDepartamentos_Delete(
                                item.depto_Id,
                                item.depto_RazonInactivo,
                                Usuario.usu_Id,
                                DateTime.Now);
                        string mensajeDB = "";
                        foreach (UDP_RRHH_tbDepartamentos_Delete_Result i in depto)
                        {
                            mensajeDB = i.MensajeError.ToString();
                        }
                        if (mensajeDB == "-1")
                        {
                            return Json("-2", JsonRequestBehavior.AllowGet);
                        }
                    }
                    foreach (cDepartamentos item in Departamentos)
                    {
                        if (item.Accion == "i")
                        {
                            var depto = db.UDP_RRHH_tbDepartamentos_Insert(
                                cAreas.area_Id,
                                item.depto_Descripcion,
                                item.car_Id,
                                Usuario.usu_Id,
                                DateTime.Now);
                            string mensajeDB = "";
                            foreach (UDP_RRHH_tbDepartamentos_Insert_Result i in depto)
                            {
                                mensajeDB = i.MensajeError.ToString();
                            }
                            if (mensajeDB == "-1")
                            {
                                return Json("-2", JsonRequestBehavior.AllowGet);
                            }
                        }
                        else if (item.Accion == "e")
                        {
                            var depto = db.UDP_RRHH_tbDepartamentos_Update(
                                item.depto_Id,
                                cAreas.area_Id,
                                item.car_Descripcion,
                                Usuario.usu_Id,
                                DateTime.Now);
                            string mensajeDB = "";
                            foreach (UDP_RRHH_tbDepartamentos_Update_Result i in depto)
                            {
                                mensajeDB = i.MensajeError.ToString();
                            }
                            if (mensajeDB == "-1")
                            {
                                return Json("-2", JsonRequestBehavior.AllowGet);
                            }
                        }
                        else if (item.Accion == "a")
                        {
                            var depto = db.UDP_RRHH_tbDepartamentos_Restore(item.depto_Id, Usuario.usu_Id, DateTime.Now);
                            string mensajeDB = "";
                            foreach (UDP_RRHH_tbDepartamentos_Restore_Result items in depto)
                            {
                                mensajeDB = items.MensajeError.ToString();
                            }
                            if (mensajeDB == "-1")
                            {
                                return Json("-2", JsonRequestBehavior.AllowGet);
                            }
                        }
                    }
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return Json("-2", JsonRequestBehavior.AllowGet);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        // POST: Areas/Delete/5
        [HttpPost]
        public ActionResult Delete(string area_Razoninactivo)
        {
            //declaramos la variable de coneccion solo para recuperar los datos necesarios.
            //posteriormente es destruida.
            string result = "";
            var cAreas =
                new cAreas
                {
                    area_Id = (int)Session["area_Id"],
                    area_Razoninactivo = area_Razoninactivo
                };
            var Usuario = (tbUsuario)Session["Usuario"];
            try
            {
                using (db = new ERP_GMEDINAEntities())
                {
                    var list = db.UDP_RRHH_tbAreas_Delete(cAreas.area_Id, cAreas.area_Razoninactivo, Usuario.usu_Id, DateTime.Now);
                    foreach (UDP_RRHH_tbAreas_Delete_Result item in list)
                    {
                        result = item.MensajeError;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                result = "-2";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // POST: Areas/Delete/5
        [HttpPost]
        public JsonResult hablilitar(int id)
        {
            string result = "";
            var Usuario = (tbUsuario)Session["Usuario"];
            try
            {
                using (db = new ERP_GMEDINAEntities())
                {
                    var list = db.UDP_RRHH_tbAreas_Restore(id, Usuario.usu_Id, DateTime.Now);
                    foreach (UDP_RRHH_tbAreas_Restore_Result item in list)
                    {
                        result = item.MensajeError;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                result = "-2";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && db != null)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}