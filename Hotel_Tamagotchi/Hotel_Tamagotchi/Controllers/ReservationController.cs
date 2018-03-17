using Hotel_Tamagotchi.Models;
using Hotel_Tamagotchi.Models.Helpers;
using Hotel_Tamagotchi.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Tamagotchi.Controllers
{
    public class ReservationController : Controller
    {
        private IRoomRepository _roomRepository;
        private ITamagotchiRepository _tamagotchiRepository;
        private BookingData _bookingData;
        public ReservationController()
        {

        }

        public ReservationController(IRoomRepository roomRepository, ITamagotchiRepository tamagotchiRepository)
        {
            this._roomRepository = roomRepository;
            this._tamagotchiRepository = tamagotchiRepository;
        }

        // GET: Reservation
        public ActionResult Index()
        {
            return View(_roomRepository.GetAll());
        }

        // GET: Reservation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reservation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reservation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reservation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reservation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reservation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SelectAmount(int room_id)
        {
            _bookingData = new BookingData(_roomRepository.Get(room_id));
            return View(_bookingData);
        }

        // POST: Confirm 
        public void ConfirmSelectAmount(int amountOfTamagotchis)
        {
           // this._selectedAmountOfTamagotchis = amountOfTamagotchis;
            Redirect("SelectTamagotchis");
        }
        public ActionResult SelectTamagotchis()
        {
            return View();
        }
    }
}
