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

        [HttpGet]
        public ActionResult Create(int room_id)
        {
            return View(GetRoomViewModel(room_id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomViewModel roomVM)
        {
            if (!ValidateSelectedAmount(roomVM))
            {
                ModelState.AddModelError("AmountOfTamagotchis", "This room has only space for " + roomVM.Room.Size + " tamagotchis. Please choose an amount no more than " + roomVM.Room.Size);
            } else if (!ValidateSelectTamagotchis(roomVM))
            {
                ModelState.AddModelError("Tamagotichis", "You have to select " + roomVM.AmountOfTamagotchis + " Tamagotchis");
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction("Detail");
            }
            else
            {
                return View(GetRoomViewModel(roomVM.Room.ID));
            }
        }

        public bool ValidateReservation(RoomViewModel roomVM)
        {
            return true;
        }

        public bool ValidateSelectedAmount(RoomViewModel roomViewModel) // testbaar voor unit test
        {
            if (roomViewModel.AmountOfTamagotchis <= roomViewModel.Room.Size && roomViewModel.AmountOfTamagotchis != 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public bool ValidateSelectTamagotchis(RoomViewModel roomViewModel) // testbaar voor unit test
        {
            if (roomViewModel.SelectedTamagotchisIDList.Count() <= roomViewModel.AmountOfTamagotchis)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public ActionResult Detail()
        {
            return View(_reservationHelper);
        }

        public RoomViewModel GetRoomViewModel(int id)
        {
            return new RoomViewModel { Room = _roomRepository.Get(id), AmountOfTamagotchisOptions = RoomSizeOptions.SizeOptions, Tamagotichis = _tamagotchiRepository.GetAll().Where(t => t.CurrentRoom == null).ToList() };
        }

        public ActionResult Complete()
        {
            _reservationHelper.SelectedTamagotchis.ForEach(t => _reservationHelper.SelectedRoom.TamagotchiList.Add(t));
            _roomRepository.Update(_reservationHelper.SelectedRoom);
            return RedirectToAction("Index");
        }
    }
}
