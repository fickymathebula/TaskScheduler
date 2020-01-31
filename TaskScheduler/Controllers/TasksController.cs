using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskScheduler.Models;

namespace TaskScheduler.Controllers
{
    public class TasksController : Controller
    {
        private TaskSchedulerContext db = new TaskSchedulerContext();

        // GET: Tasks
        public ActionResult Index(int? userid)
        {
            // This is a dummy view, we only need to present users to search here
            ViewBag.Users = db.user.ToList();
            ViewBag.SelectedUser = userid;

            if (userid != null)
            {
                var results = db.task.Where(x => x.assignedtoid == userid).ToList();
                if(results.Count > 0)
                {
                    ViewBag.UserTasks = results;
                }               

                return View(results);
            }
            return View();
        }
        
        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            task task = db.task.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            // Allocate session data for users
            ViewBag.Users = db.user.ToList();

            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,createdbyid,assignedtoid,taskdescription, createdate")] task task)
        {
            // Collect data to work with in the view
            ViewBag.Users = db.user.ToList();
            ViewBag.CreatedBy = task.createdbyid;
            ViewBag.AssignedTo = task.assignedtoid;

            // Always make create date current date
            task.createdate = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.task.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(task);
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
