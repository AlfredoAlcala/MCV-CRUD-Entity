using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using MVCcrud.Models;
using MVCcrud.Models.ViewModels;

namespace MVCcrud.Controllers
{
    public class TablaController : Controller
    {
        // GET: Tabla
        public ActionResult Index()
        {

            List<ListTableViewModel> lst;
           using (cmEntities db= new cmEntities()) 
            {
                lst = (from d in db.tabla
                       select new ListTableViewModel
                       {
                           id = d.id,
                           name = d.name,
                           Email = d.Email
                          
                       }).ToList();
            }

            return View(lst);
        }

         public ActionResult Newreg()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Newreg(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (cmEntities db = new cmEntities())
                    {
                        var obtabla = new tabla
                        {
                            Email = model.Email,
                            name = model.Name,
                            fecha_nacimiento = model.Fecha_nacimiento
                        };

                        db.tabla.Add(obtabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Tabla/");
                }

                return View(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
          
        }


        public ActionResult Edit(int id)
        {
            TablaViewModel model = new TablaViewModel();
           using (cmEntities db = new cmEntities())
            {
                var obtabla = db.tabla.Find(id);
                model.Name = obtabla.name;
                model.Email = obtabla.Email;
                model.Fecha_nacimiento = (DateTime)obtabla.fecha_nacimiento;
                model.id = obtabla.id;
                
            }
                return View(model);
        }

        [HttpPost]
        public ActionResult Edit(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (cmEntities db = new cmEntities())
                    {
                        var obtabla = db.tabla.Find(model.id);
                        {
                            obtabla.Email = model.Email;
                            obtabla.name = model.Name;
                            obtabla.fecha_nacimiento = model.Fecha_nacimiento;
                        }

                        db.Entry(obtabla).State= System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Tabla/");
                }

                return View(model);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }



        [HttpGet]
        public ActionResult Delete(TablaViewModel model)
        {
            
                    using (cmEntities db = new cmEntities())
                    {
                        var obtabla = db.tabla.Find(model.id);
                        db.tabla.Remove(obtabla);

                       db.SaveChanges();
                    }
                    return Redirect("~/Tabla/");
                

               
           

        }

    }
}