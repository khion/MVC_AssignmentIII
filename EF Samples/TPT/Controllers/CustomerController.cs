using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TPT.Models;

namespace TPT.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Customer/
        public ActionResult Index()
        {
            List<Customer> customer = new List<Customer>();
            foreach (var person in db.People.ToList())
            {
                if (person is Customer)
                    customer.Add(person as Customer);
            }


            return View(customer);
        }

        // GET: /Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = (Customer) db.People.Find(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: /Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Name,Address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: /Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = (Customer) db.People.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult AddService(string id, int? customerID)
        {
            if (customerID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = (Customer)db.People.Find(customerID);
            if (customer == null)
            {
                return HttpNotFound();
            }
            customer.Services.Add((Service)db.Services.Find(id));
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
            return View(customer);
        }

        public ActionResult CustomerServices(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = (Customer)db.People.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.CustomerID = id;
            return View(customer.Services);
        }

        // POST: /Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Name,Address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: /Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = (Customer) db.People.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer.Services);
        }

        // POST: /Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = (Customer) db.People.Find(id);
            db.People.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteService(string id, int customerID)
        {
            Customer customer = (Customer)db.People.Find(customerID);
            customer.Services.Remove(db.Services.Find(id));
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Add(int? id, int customerID)
        {
            ViewBag.CustomerID = customerID;
            List<Service> courses = db.Services.ToList();
            IEnumerable<Service> customerServices = ((Customer)db.People.Find(customerID)).Services;
            foreach (var c in customerServices) {
                courses.Remove((Service) c);
            }
            return View(courses);
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
