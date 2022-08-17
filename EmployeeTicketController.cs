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
    public class EmployeeTicketController : Controller
    {
        private EmployeeEntities1 db = new EmployeeEntities1();

        // GET: Ticket
        public ActionResult Index()
        {
            return View(db.TicketAttributes.ToList());
        }

        // GET: Ticket/Details/5
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

        // GET: Ticket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ticket/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Subject,Description,AssignedTo,ExecutiveComment,Status,CreatedDate,CreatedBy,UpdatedDate")] TicketAttribute ticketAttribute)
        {
            if (ModelState.IsValid)
            {
                db.TicketAttributes.Add(ticketAttribute);
                ticketAttribute.Status = 1;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ticketAttribute);
        }

        // GET: Ticket/Edit/5
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

        // POST: Ticket/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Subject,Description,AssignedTo,ExecutiveComment,Status,CreatedDate,CreatedBy,UpdatedDate")] TicketAttribute ticketAttribute)
        {
            if (ModelState.IsValid)
            {
                if (ticketAttribute.Status == 1)
                {
                    db.Entry(ticketAttribute).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(ticketAttribute);
        }

        // GET: Ticket/Delete/5
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

        // POST: Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketAttribute ticketAttribute = db.TicketAttributes.Find(id);
           
                db.TicketAttributes.Remove(ticketAttribute);
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
