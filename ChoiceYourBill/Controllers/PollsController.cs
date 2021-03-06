﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChoiceYourBill.Controllers.AbstractClass;
using ChoiceYourBill.Models;
using ChoiceYourBill.Models.AbstractClass;
using ChoiceYourBill.TemplateHelpers.EditMode;
using ChoiceYourBill.TemplateHelpers.RecordMode;

namespace ChoiceYourBill.Controllers
{
    public class PollsController : GenericController
    {
        private DbbContext db = new DbbContext();

        // GET: Polls
        public ActionResult Index()
        {
            PollsRecordTemplateHelper templateHelper = new PollsRecordTemplateHelper();
//            List<Poll> list = db.Polls.Include("Votes").ToList();
            ViewBag.templateHelper = templateHelper;
            IEnumerable<Poll> List =  templateHelper.Polls;
            return View(List);
        }

        // GET: Polls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poll poll = db.Polls.Find(id);
            if (poll == null)
            {
                return HttpNotFound();
            }
            return View(poll);
        }

        // GET: Polls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Polls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Date")] Poll poll)
        {
            if (ModelState.IsValid)
            {
                PollsEditTemplateHelper pollsEditTemplateHelper = new PollsEditTemplateHelper(poll);
               //db.Polls.Add(poll);
               //db.SaveChanges();
               if(pollsEditTemplateHelper.UpdateRecord())
               {
                    return RedirectToAction("Index");

               }
            }
            
            return View(poll);
        }

        // GET: Polls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poll poll = db.Polls.Find(id);
            List<Restaurant> restaurants = db.Restaurants.ToList();
            ViewBag.ListeRestaurantss = new SelectList(restaurants, "Id", "Nom");
            poll.Votes.Add(new Vote());
            if (poll == null)
            {
                return HttpNotFound();
            }
            return View(poll);
        }

        // POST: Polls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdPoll,Date")] Poll poll)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poll).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(poll);
        }

        // GET: Polls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poll poll = db.Polls.Find(id);
            if (poll == null)
            {
                return HttpNotFound();
            }
            return View(poll);
        }

        // POST: Polls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Poll poll = db.Polls.Find(id);
            db.Polls.Remove(poll);
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
