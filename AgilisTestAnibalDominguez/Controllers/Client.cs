using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgilisTestAnibalDominguez.DAL;
using AgilisTestAnibalDominguez.Models;

namespace AgilisTestAnibalDominguez.Controllers
{
    public class Client : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Client
        public ActionResult Index()
        {
            var clients = db.Clients.Include(c => c.Company);
            return View(clients.ToList());
        }

        // GET: Client/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            Models.Company company = db.Companies.Find(client.CompanyFK);
            client.Company = company;
            return View(client);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            ViewBag.CompanyFK = new SelectList(db.Companies, "ID", "Name");
            return View();
        }

        // POST: Client/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address,CompanyFK")] Models.Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyFK = new SelectList(db.Companies, "ID", "Name", client.CompanyFK);
            return View(client);
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyFK = new SelectList(db.Companies, "ID", "Name", client.CompanyFK);
            return View(client);
        }

        // POST: Client/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address,CompanyFK")] Models.Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyFK = new SelectList(db.Companies, "ID", "Name", client.CompanyFK);
            return View(client);
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            Models.Company company = db.Companies.Find(client.CompanyFK);
            client.Company = company;
            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
