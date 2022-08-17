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
    public class EmployeeAttributesController : Controller
    {
        private EmployeeEntities db = new EmployeeEntities();

        // GET: EmployeeAttributes
        public ActionResult Index()
        {
            return View(db.EmployeeAttributes.ToList());
        }

        // GET: EmployeeAttributes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAttribute employeeAttribute = db.EmployeeAttributes.FirstOrDefault(x => x.Id == id);
            if (employeeAttribute == null)
            {
                return HttpNotFound();
            }
            return View(employeeAttribute);
        }
        

        // GET: EmployeeAttributes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeAttributes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,First_Name,Last_Name,Middle_Name,Email_id,Date_of_Birth,Department,Role,Address,Username,Password,Created_Date")] EmployeeAttribute employeeAttribute)
        {
            if (ModelState.IsValid)
            {
                if (db.EmployeeAttributes.FirstOrDefault(x => x.Email_id == employeeAttribute.Email_id) == null)
                {
                    db.EmployeeAttributes.Add(employeeAttribute);
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.Message = "You are already registered.";
                    return View();
                }
                return RedirectToAction("Index");

            }

            return View(employeeAttribute);
        }

        // GET: EmployeeAttributes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAttribute employeeAttribute = db.EmployeeAttributes.FirstOrDefault(x => x.Id == id);
            if (employeeAttribute == null)
            {
                return HttpNotFound();
            }
            return View(employeeAttribute);
        }

        // POST: EmployeeAttributes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,First_Name,Last_Name,Middle_Name,Email_id,Date_of_Birth,Department,Role,Address,Username,Password,Created_Date")] EmployeeAttribute employeeAttribute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeAttribute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeAttribute);
        }

        // GET: EmployeeAttributes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeAttribute employeeAttribute = db.EmployeeAttributes.FirstOrDefault(x => x.Id == id);
            if (employeeAttribute == null)
            {
                return HttpNotFound();
            }
            return View(employeeAttribute);
        }

        // POST: EmployeeAttributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeAttribute employeeAttribute = db.EmployeeAttributes.FirstOrDefault(x => x.Id == id);
            db.EmployeeAttributes.Remove(employeeAttribute);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        
        }
        [HttpPost]
        
        public ActionResult LoginEmployee([Bind(Include = "Email_id, Password")] EmployeeAttribute employeeAttribute)
        {
            if (ModelState.IsValid)
            {
                if (db.EmployeeAttributes.FirstOrDefault(x => x.Email_id == employeeAttribute.Email_id && x.Password == employeeAttribute.Password) != null)
                {
                    if (db.EmployeeAttributes.FirstOrDefault(y => y.Department == 1) != null){
                        return View("EmployeePage");
                    }
                    else
                    {
                        return View("ExecutivePage");
                    }
                }
                else
                {
                    ViewBag.Message = "Wrong email-id or password.";
                    return View("Login");
                }
                return RedirectToAction("Index");
            }

            return View(employeeAttribute);
        }

        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult EmployeePage()
        {
            return View();
        }

        public ActionResult ExecutivePage()
        {
            return View();
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
