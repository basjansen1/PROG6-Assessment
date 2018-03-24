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
        private RoomViewModel _detailsRoomVM;
        //public ReservationController()
        //{
            
        //}

        public ReservationController(IRoomRepository roomRepository, ITamagotchiRepository tamagotchiRepository, RoomViewModel detailsRoomVM)
        {
            this._roomRepository = roomRepository;
            this._tamagotchiRepository = tamagotchiRepository;
            this._detailsRoomVM = detailsRoomVM;
        }

        [HttpGet]
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
                ModelState.AddModelError("Tamagotichis", "You have to select at most " + roomVM.AmountOfTamagotchis + " Tamagotchis");
            }

            if (ModelState.IsValid)
            {
                ProcessReservation(roomVM);
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
            if (roomViewModel.SelectedTamagotchisIDList.Count() <= roomViewModel.AmountOfTamagotchis && roomViewModel.SelectedTamagotchisIDList.Count() > 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        [HttpGet]
        public ActionResult Detail()
        {
            return View(_detailsRoomVM);
        }

        [HttpPost]
        public ActionResult Detail(RoomViewModel roomViewModel)
        {
            Complete(roomViewModel);
            return RedirectToAction("Index");
        }

        public RoomViewModel GetRoomViewModel(int id)
        {
            return new RoomViewModel { Room = _roomRepository.Get(id), AmountOfTamagotchisOptions = RoomSizeOptions.SizeOptions, Tamagotichis = _tamagotchiRepository.GetAll().Where(t => t.CurrentRoom == null).ToList() };
        }

        public RoomViewModel ProcessReservation(RoomViewModel roomVM)
        {
            _detailsRoomVM.AmountOfTamagotchis = roomVM.AmountOfTamagotchis;
            _detailsRoomVM.Room = roomVM.Room;
            _detailsRoomVM.SelectedTamagotchisIDList = roomVM.SelectedTamagotchisIDList;
            _detailsRoomVM.Tamagotichis = roomVM.SelectedTamagotchisIDList.Select(ti => _tamagotchiRepository.Get(ti)).ToList();
            return roomVM;
        }

        public void Complete(RoomViewModel roomViewModel)
        {
            Room room = _roomRepository.Get(_detailsRoomVM.Room.ID);
            List<Tamagotchi> SelectedTamagotchiList = _detailsRoomVM.Tamagotichis.Select(t => _tamagotchiRepository.Get(t.ID)).ToList();

            room.TamagotchiList = SelectedTamagotchiList;
            //SelectedTamagotchiList.ForEach(t => _tamagotchiRepository.SetRoom(room, t));
            SelectedTamagotchiList.ForEach(t => _tamagotchiRepository.Delete(t));
            _roomRepository.Update(room);
        }
    }
}
