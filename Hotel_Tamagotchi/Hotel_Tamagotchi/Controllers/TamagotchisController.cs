using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel_Tamagotchi.Models;
using Hotel_Tamagotchi.Models.Repositories;

namespace Hotel_Tamagotchi.Controllers
{
    public class TamagotchisController : Controller
    {
        private ITamagotchiRepository _tamagotchiRepository;
        public TamagotchisController()
        {
        }

        public TamagotchisController(ITamagotchiRepository tamagotchiRepository)
        {
            _tamagotchiRepository = tamagotchiRepository;
        }

        // GET: Tamagotchis
        public ActionResult Index()
        {
            return View(_tamagotchiRepository.GetAll());
        }

        // GET: Tamagotchis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamagotchi tamagotchi = _tamagotchiRepository.Get((int) id);
            if (tamagotchi == null)
            {
                return HttpNotFound();
            }
            return View(tamagotchi);
        }

        // GET: Tamagotchis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tamagotchis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Age,Cents,Health,Boredom,Alive")] Tamagotchi tamagotchi)
        {
            if (ModelState.IsValid)
            {
                _tamagotchiRepository.Add(tamagotchi);
                return RedirectToAction("Index");
            }

            return View(tamagotchi);
        }

        // GET: Tamagotchis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamagotchi tamagotchi = _tamagotchiRepository.Get((int) id);
            if (tamagotchi == null)
            {
                return HttpNotFound();
            }
            return View(tamagotchi);
        }

        // POST: Tamagotchis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Age,Cents,Health,Boredom,Alive")] Tamagotchi tamagotchi)
        {
            if (ModelState.IsValid)
            {
                _tamagotchiRepository.Update(tamagotchi);
                return RedirectToAction("Index");
            }
            return View(tamagotchi);
        }

        // GET: Tamagotchis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamagotchi tamagotchi = _tamagotchiRepository.Get((int) id);
            if (tamagotchi == null)
            {
                return HttpNotFound();
            }
            return View(tamagotchi);
        }

        // POST: Tamagotchis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tamagotchi tamagotchi = _tamagotchiRepository.Get(id);
            _tamagotchiRepository.Delete(tamagotchi);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
