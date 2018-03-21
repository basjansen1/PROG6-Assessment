using Hotel_Tamagotchi.Helpers;
using Hotel_Tamagotchi.Models;
using Hotel_Tamagotchi.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Tamagotchi.Controllers
{
    public class ReservationController : Controller
    {
        private IRoomRepository _roomRepository;
        private ITamagotchiRepository _tamagotchiRepository;
        private ReservationHelper _reservationHelper;
        //public ReservationController()
        //{
            
        //}

        public ReservationController(IRoomRepository roomRepository, ITamagotchiRepository tamagotchiRepository, ReservationHelper reservationHelper)
        {
            this._roomRepository = roomRepository;
            this._tamagotchiRepository = tamagotchiRepository;
            this._reservationHelper = reservationHelper;
        }

        // GET: Reservation
        public ActionResult Index()
        {
            return View(_roomRepository.GetAll());
        }

        // GET: Reservation/Create
        public ActionResult Create(int room_id)
        {
            return View();
        }

        // POST: Reservation/Create
        [HttpPost]
        public ActionResult Create()
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

        public ActionResult SelectRoom(int room_id)
        {
          //  _reservationHelper.Set(_roomRepository.Get(room_id));
            return RedirectToAction("SelectAmount");
        }
        public ActionResult SelectAmount()
        {
            return View(_reservationHelper);
        }

        public bool ValidateSelectedAmount(Room room)
        {
            if (room.Size >= room.TamagotchiList.Count())
            {
                return true;
            } else
            {
                return false;
            }
        }

        // POST: Confirm 
        public ActionResult ConfirmSelectAmount(Room room)
        {
           if (ValidateSelectedAmount(room))
            {
                return RedirectToAction("SelectTamagotchis");
            } else
            {
                throw new InvalidOperationException();
            }
        }
        public ActionResult SelectTamagotchis()
        {
            _reservationHelper.SelectedTamagotchis = _tamagotchiRepository.GetAll().Where(t => t.CurrentRoom == null).ToList();
            return View(_reservationHelper);
        }

        [HttpPost]
        public ActionResult ConfirmSelectedTamagotchis()
        {
            return null;
        }

        [HttpPost]
        public ActionResult SelectTamagotchis(ReservationHelper helper)
        {
            return RedirectToAction("Detail");
        }

        public ActionResult Detail()
        {
            return View(_reservationHelper);
        }

        public void Complete()
        {
            _reservationHelper.SelectedTamagotchis.ForEach(t => _reservationHelper.SelectedRoom.TamagotchiList.Add(t));
            //_roomRepository.Update(_reservationHelper.SelectedRoom);
        }
    }
}
