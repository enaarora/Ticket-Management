using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicketManagement;

namespace TicketManagement.Controllers
{
    public class ExecutiveTicketController : Controller
    {
        private EmployeeEntities2 db = new EmployeeEntities2();

        // GET: ExecutiveTicket
        public ActionResult Index()
        {
            return View(db.TicketAttributes.ToList());
        }

        // GET: ExecutiveTicket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketAttribute ticketAttribute = db.TicketAttributes.FirstOrDefault(x => x.Id == id);
            if (ticketAttribute == null)
            {
                return HttpNotFound();
            }
            return View(ticketAttribute);
        }

        // GET: ExecutiveTicket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExecutiveTicket/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Subject,Description,AssignedTo,ExecutiveComment,Status,CreatedDate,CreatedBy,UpdatedDate")] TicketAttribute ticketAttribute)
        {
            if (ModelState.IsValid)
            {
                db.TicketAttributes.Add(ticketAttribute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ticketAttribute);
        }

        // GET: ExecutiveTicket/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketAttribute ticketAttribute = db.TicketAttributes.FirstOrDefault(x => x.Id == id);
            if (ticketAttribute == null)
            {
                return HttpNotFound();
            }
            return View(ticketAttribute);
        }

        // POST: ExecutiveTicket/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Subject,Description,AssignedTo,ExecutiveComment,Status,CreatedDate,CreatedBy,UpdatedDate")] TicketAttribute ticketAttribute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketAttribute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticketAttribute);
        }

        // GET: ExecutiveTicket/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketAttribute ticketAttribute = db.TicketAttributes.FirstOrDefault(x => x.Id == id);
            if (ticketAttribute == null)
            {
                return HttpNotFound();
            }
            return View(ticketAttribute);
        }

        // POST: ExecutiveTicket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketAttribute ticketAttribute = db.TicketAttributes.Find(id);
            db.TicketAttributes.Remove(ticketAttribute);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("InProgress")]
        [ValidateAntiForgeryToken]
        public ActionResult InProgress(int id)
        {
            TicketAttribute ticketAttribute = db.TicketAttributes.Find(id);
            ticketAttribute.Status = 2;
            db.Entry(ticketAttribute).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Resolve")]
        [ValidateAntiForgeryToken]
        public ActionResult Resolve(int id)
        {
            TicketAttribute ticketAttribute = db.TicketAttributes.Find(id);
            ticketAttribute.Status = 3;
            db.Entry(ticketAttribute).State = EntityState.Modified;
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
