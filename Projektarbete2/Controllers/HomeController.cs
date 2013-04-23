using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projektarbete2.Models;

namespace Projektarbete2.Controllers
{
    public class HomeController : Controller
    {
        private fakturaDBEntities _entities = new fakturaDBEntities();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(_entities.Faktura_tabel.ToList());
        }

        //
        // GET: /Home/Details/5
        public ActionResult Print(int id = -1)
        {
            var FakturaItem = _entities.Faktura_tabel.SingleOrDefault(p => p.Id == id);

            if (FakturaItem == null)
            {
                return HttpNotFound();
            }
            return View(FakturaItem);
        }


        

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(Faktura_tabel FakturaToCreate)
        {
            try
            {
                // TODO: Add insert logic here
     
                _entities.AddToFaktura_tabel(FakturaToCreate);

                //Räkna Total
                FakturaToCreate.Total = FakturaToCreate.Price * FakturaToCreate.Quantity;

                _entities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = -1)
        {
            var FakturaItem = _entities.Faktura_tabel.SingleOrDefault(p => p.Id == id);

            if (FakturaItem == null)
            {
                return HttpNotFound();
            }
            return View(FakturaItem);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Faktura_tabel FakturaItem)
        {
            try
            {
                var FakturaEdit = _entities.Faktura_tabel.Single(p => p.Id ==id);

                FakturaEdit.Name = FakturaItem.Name;
                FakturaEdit.City = FakturaItem.City;
                FakturaEdit.Deadline = FakturaItem.Deadline;
                FakturaEdit.Article = FakturaItem.Article;
                FakturaEdit.Price = FakturaItem.Price;
                FakturaEdit.Quantity = FakturaItem.Quantity;
                FakturaEdit.Total = FakturaItem.Total;

                FakturaEdit.Total = FakturaEdit.Price * FakturaEdit.Quantity;

                _entities.SaveChanges();
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Faktura_tabel FakturaDelete = _entities.Faktura_tabel.FirstOrDefault(s => s.Id.Equals(id));
                if (FakturaDelete != null)
                {
                    _entities.DeleteObject(FakturaDelete);
                    _entities.SaveChanges();
                }
 

                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
