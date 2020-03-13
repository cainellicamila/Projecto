using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCrudNet.Models;
using MVCCrudNet.Models.ViewModels;

namespace MVCCrudNet.Controllers
{
    public class tabla2Controller : Controller
    {
        // GET: tabla2
        public ActionResult Index()
        {
            List<ListTabla2ViewModel> lst;
            using(Crud2Entities db= new Crud2Entities())
            {
                lst = (from d in db.tabla2
                           select new ListTabla2ViewModel
                           {
                               Id = d.id,
                               Nombre = d.nombre,
                               Correo = d.correo,
                               
                           }).ToList();
                        
                        }
            
            return View(lst);
        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Crud2Entities db = new Crud2Entities())
                    {
                        var oTabla = new tabla2();
                        oTabla.correo = model.Correo;
                        oTabla.nombre = model.Nombre;
                        oTabla.fecha_nacimiento = model.Fecha_Nacimiento;

                        db.tabla2.Add(oTabla);
                        db.SaveChanges();


                    }
                    return Redirect("~/tabla2/");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int Id)
        {
            TablaViewModel model = new TablaViewModel();
            using (Crud2Entities db = new Crud2Entities())
            {
                var oTabla = db.tabla2.Find(Id);
                model.Id=oTabla.id;
                model.Nombre=oTabla.nombre;
                model.Correo=oTabla.correo;
                model.Fecha_Nacimiento=oTabla.fecha_nacimiento;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar (TablaViewModel model)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (Crud2Entities db = new Crud2Entities())
                    {
                        var oTabla = db.tabla2.Find(model.Id);
                        oTabla.correo = model.Correo;
                        oTabla.nombre = model.Nombre;
                        oTabla.fecha_nacimiento = model.Fecha_Nacimiento;

                        db.Entry(oTabla).State=System.Data.Entity.EntityState.Modified ;
                        db.SaveChanges();


                    }
                    return Redirect("~/tabla2/");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            
            using (Crud2Entities db = new Crud2Entities())
            {
                var oTabla = db.tabla2.Find(Id);
                db.tabla2.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/tabla2/");
        }
    }
}