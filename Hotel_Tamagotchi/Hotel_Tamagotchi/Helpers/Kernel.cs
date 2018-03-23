using Hotel_Tamagotchi.Controllers;
using Hotel_Tamagotchi.Models;
using Hotel_Tamagotchi.Models.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Tamagotchi.Helpers
{
    public class Kernel : NinjectModule
    {
        private Hotel_TamagotchiContext _context;
        private ReservationController _reservationController;

        public Kernel()
        {
            this.Load();
        }

        public override void Load()
        {
            // Instanciate singleton objects
            _context = new Hotel_TamagotchiContext();
            _reservationController = new ReservationController(GetRoomRepository(), GetTamagotchiRepository(), new Models.ViewModels.RoomViewModel());
        }

        public Hotel_TamagotchiContext GetDBContext()
        {
            return _context;
        }

        // Get Repositories
        public IRoomRepository GetRoomRepository()
        {
            return new RoomRepository(GetDBContext());
        }

        public ITamagotchiRepository GetTamagotchiRepository()
        {
            return new TamagotchiRepository(GetDBContext());
        }

        // Get Controllers
        public IController GetRoomsController()
        {
            return new RoomsController(GetRoomRepository());
        }

        public IController GetTamagotchiController()
        {
            return new TamagotchisController(GetTamagotchiRepository());
        }
        public IController GetReservationController()
        {
            return _reservationController;
        }
    }
}