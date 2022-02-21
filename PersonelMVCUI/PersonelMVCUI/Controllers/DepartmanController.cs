using PersonelMVCUI.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelMVCUI.Controllers
{
    public class DepartmanController : Controller
    {
        PersonelDbEntities db = new PersonelDbEntities();
        // GET: Departman
        public ActionResult Index() 
        {
            var model = db.Departman.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Yeni()
        {

            return View("DepartmanForm",new Departman());
        }
        [ValidateAntiForgeryToken]
        public ActionResult Kaydet(Departman departman)
        {
            if(!ModelState.IsValid)
            {
                return View("DepartmanForm",departman);
            }
            
            if(departman.id==0)
            {
                db.Departman.Add(departman);
            }
            else
            {
                var güncellenecekDepartman = db.Departman.Find(departman.id);
                if(güncellenecekDepartman==null)
                {
                    return HttpNotFound();
                }
                güncellenecekDepartman.Ad = departman.Ad;
            }
            db.SaveChanges();
            return RedirectToAction("Index","Departman");
        }
        public ActionResult Guncelle(int id)
        {
            var model = db.Departman.Find(id);
            if (model == null)
                return HttpNotFound();
            return View("DepartmanForm",model);
        }
        public JsonResult Sil(int id)
        {
            var silinecekDepartman = db.Departman.Find(id);

            if(silinecekDepartman==null)
            return null;

            db.Departman.Remove(silinecekDepartman);
            db.SaveChanges();
            return null;
            
        }
    }
}