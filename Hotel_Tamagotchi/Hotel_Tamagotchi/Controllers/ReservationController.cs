using Hotel_Tamagotchi.Helpers;
using Hotel_Tamagotchi.Models;
using Hotel_Tamagotchi.Models.Repositories;
using Hotel_Tamagotchi.Models.ViewModels;
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
        [HttpGet]
        public ActionResult SelectAmount(int room_id)
        {
            RoomViewModel roomViewModel = new RoomViewModel { Room = _roomRepository.Get(room_id), AmountOfTamagotchisOptions = RoomSizeOptions.SizeOptions, Tamagotichis = _tamagotchiRepository.GetAll().Where(t => t.CurrentRoom == null).ToList() };
            return View(roomViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectAmount(RoomViewModel roomVM)
        {
            if(ValidateSelectedAmount(roomVM))
            {
                return RedirectToAction("SelectTamagotchis");
            } else
            {
                ModelState.AddModelError("AmountOfTamagotchis", "This room has only space for" + roomVM.Room.Size + "tamagotchis");
                return View(roomVM);
            }
        }
        public bool ValidateSelectedAmount(RoomViewModel roomViewModel)
        {
            if (roomViewModel.AmountOfTamagotchis > roomViewModel.Room.Size)
            {
                return false;
            } else
            {
                return true;
            }
        }

        // POST: Confirm 
        public ActionResult ConfirmSelectAmount(Room room)
        {
           if (ValidateSelectedAmount(null))
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
            _roomRepository.Update(_reservationHelper.SelectedRoom);
        }
    }
}
