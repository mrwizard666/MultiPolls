using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MultiPolls.Models;

namespace MultiPolls.Controllers
{
    public class VoteLogController : Controller
    {
        private PollDBContext db = new PollDBContext();

            
        
        
        // GET: /VoteLog/
        public ActionResult Index()
        {
            return View(db.VoteLogs.ToList());
        }

        // GET: /VoteLog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoteLog votelog = db.VoteLogs.Find(id);
            if (votelog == null)
            {
                return HttpNotFound();
            }
            return View(votelog);
        }

        // GET: /VoteLog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /VoteLog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,User,QuestionID")] VoteLog votelog)
        {
            if (ModelState.IsValid)
            {
                db.VoteLogs.Add(votelog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(votelog);
        }

        // GET: /VoteLog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoteLog votelog = db.VoteLogs.Find(id);
            if (votelog == null)
            {
                return HttpNotFound();
            }
            return View(votelog);
        }

        // POST: /VoteLog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,User,QuestionID")] VoteLog votelog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(votelog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(votelog);
        }

        // GET: /VoteLog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VoteLog votelog = db.VoteLogs.Find(id);
            if (votelog == null)
            {
                return HttpNotFound();
            }
            return View(votelog);
        }

        // POST: /VoteLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VoteLog votelog = db.VoteLogs.Find(id);
            db.VoteLogs.Remove(votelog);
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
